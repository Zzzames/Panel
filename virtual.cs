using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using System.Windows.Forms;

namespace DA
{
    public class VirtualPort : IDisposable
    {
        // 串口对象
        private SerialPort realPort;
        private SerialPort virtualPort;

        // 数据缓冲区和统计
        private long bytesReceived = 0;
        private long bytesSent = 0;
        private DateTime startTime;

        // 控制标志
        private bool isRunning = false;
        private CancellationTokenSource tokenSource;

        private string powerDeviceModel;

        // 添加用于消息合并的缓冲区
        private List<byte> deviceDataBuffer = new List<byte>();
        private List<byte> appDataBuffer = new List<byte>();
        private DateTime lastDeviceDataTime = DateTime.MinValue;
        private DateTime lastAppDataTime = DateTime.MinValue;
        private const int MESSAGE_TIMEOUT_MS = 100;

        // 添加功率仪电能数据合并逻辑所需的变量
        private readonly object pendingDataLock = new object();
        private PowerDataEventArgs pendingPowerData = null;
        private System.Threading.Timer flushTimer;

        // 帧头定义
        private const byte FRAME_HEADER_HOST_REQUEST = 0x55;
        private const byte FRAME_HEADER_DEVICE_RESPONSE = 0xAA;

        // 事件
        public event EventHandler<PowerDataEventArgs> PowerDataReceived;
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event EventHandler<RawDataEventArgs> RawDataReceived;

        // 串口参数
        public string RealPortName { get; private set; }
        public string VirtualPortName { get; private set; }
        public bool IsConnected => isRunning;

        // 连接串口
        public bool Connect(string realPortName, string virtualPortName, string deviceModel, int baudRate = 9600,
                        Parity parity = Parity.None, int dataBits = 8,
                        StopBits stopBits = StopBits.One, Handshake handshake = Handshake.None)
        {
            if (isRunning)
                return false;

            try
            {
                RealPortName = realPortName;
                VirtualPortName = virtualPortName;
                this.powerDeviceModel = deviceModel;

                // 检查端口是否相同
                if (realPortName == virtualPortName)
                {
                    LogMessage("物理端口和虚拟端口不能相同", true);
                    return false;
                }

                // 初始化物理端口
                realPort = new SerialPort(realPortName, baudRate, parity, dataBits, stopBits);
                realPort.Handshake = handshake;
                realPort.ReadTimeout = 1000;
                realPort.WriteTimeout = 1000;
                realPort.ReadBufferSize = 4096;
                realPort.WriteBufferSize = 4096;

                // 初始化虚拟端口
                virtualPort = new SerialPort(virtualPortName, baudRate, parity, dataBits, stopBits);
                virtualPort.Handshake = handshake;
                virtualPort.ReadTimeout = 1000;
                virtualPort.WriteTimeout = 1000;
                virtualPort.ReadBufferSize = 4096;
                virtualPort.WriteBufferSize = 4096;

                // 打开端口
                realPort.Open();
                virtualPort.Open();

                // 注册数据接收事件
                realPort.DataReceived += RealPort_DataReceived;
                virtualPort.DataReceived += VirtualPort_DataReceived;

                // 设置运行状态
                isRunning = true;
                startTime = DateTime.Now;

                // 创建取消令牌
                tokenSource = new CancellationTokenSource();

                // 初始化定时器，用于超时发送数据
                flushTimer = new System.Threading.Timer(FlushPendingData, null, Timeout.Infinite, Timeout.Infinite);

                // 写入日志
                LogMessage($"[提示] 请将与物理串口 {realPortName} 通信的设备配置为连接到 {GetPairedVirtualPort(virtualPortName)}", true);

                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"连接串口失败: {ex.Message}", true);
                CleanupPorts();
                return false;
            }
        }
        private string GetPairedVirtualPort(string virtualPort)
        {
            // 从端口名称中提取数字部分
            string portNumber = new string(virtualPort.Where(char.IsDigit).ToArray());
            if (int.TryParse(portNumber, out int portNum))
            {
                // 计算配对的端口号
                int pairedPortNum = portNum + 1;
                return $"COM{pairedPortNum}";
            }
            return virtualPort;
        }
        // 断开连接
        public void Disconnect()
        {
            if (!isRunning)
                return;

            // 停止数据采集
            isRunning = false;

            // 释放定时器
            flushTimer?.Dispose();
            flushTimer = null;

            // 取消监控线程
            if (tokenSource != null && !tokenSource.IsCancellationRequested)
            {
                try { tokenSource.Cancel(); } catch { }
            }

            // 关闭所有端口连接
            CleanupPorts();

            // 清理消息缓冲区
            deviceDataBuffer.Clear();
            appDataBuffer.Clear();

            LogMessage("串口连接已断开");
        }

        // 清理端口资源
        private void CleanupPorts()
        {
            try
            {
                if (realPort != null)
                {
                    try
                    {
                        if (realPort.IsOpen)
                        {
                            realPort.DataReceived -= RealPort_DataReceived;
                            realPort.Close();
                        }
                        realPort.Dispose();
                        realPort = null;
                    }
                    catch { }
                }

                if (virtualPort != null)
                {
                    try
                    {
                        if (virtualPort.IsOpen)
                        {
                            virtualPort.DataReceived -= VirtualPort_DataReceived;
                            virtualPort.Close();
                        }
                        virtualPort.Dispose();
                        virtualPort = null;
                    }
                    catch { }
                }
            }
            catch { }
        }

        // 物理端口数据接收事件处理
        private void RealPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!isRunning)
                return;

            try
            {
                // 读取数据
                int bytesToRead = realPort.BytesToRead;
                if (bytesToRead <= 0)
                    return;

                byte[] buffer = new byte[bytesToRead];
                int bytesRead = realPort.Read(buffer, 0, bytesToRead);

                if (bytesRead <= 0)
                    return;

                // 更新统计
                Interlocked.Add(ref bytesSent, bytesRead);

                DateTime now = DateTime.Now;
                bool isNewMessage = (now - lastAppDataTime).TotalMilliseconds > MESSAGE_TIMEOUT_MS;
                lastAppDataTime = now;

                // 触发原始数据接收事件
                RawDataReceived?.Invoke(this, new RawDataEventArgs(buffer, "设备 → 上位机", now));

                // 处理数据
                ProcessReceivedData(buffer, "设备 → 上位机", isNewMessage, appDataBuffer);

                // 转发给虚拟端口
                if (virtualPort != null && virtualPort.IsOpen)
                {
                    try
                    {
                        virtualPort.Write(buffer, 0, bytesRead);
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"向虚拟端口写入数据时出错: {ex.Message}", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"从物理端口读取数据时出错: {ex.Message}", true);
            }
        }

        // 虚拟端口数据接收事件处理
        private void VirtualPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!isRunning)
                return;

            try
            {
                // 读取数据
                int bytesToRead = virtualPort.BytesToRead;
                if (bytesToRead <= 0)
                    return;

                byte[] buffer = new byte[bytesToRead];
                int bytesRead = virtualPort.Read(buffer, 0, bytesToRead);

                if (bytesRead <= 0)
                    return;

                // 更新统计
                Interlocked.Add(ref bytesReceived, bytesRead);

                DateTime now = DateTime.Now;
                bool isNewMessage = (now - lastDeviceDataTime).TotalMilliseconds > MESSAGE_TIMEOUT_MS;
                lastDeviceDataTime = now;

                // 触发原始数据接收事件
                RawDataReceived?.Invoke(this, new RawDataEventArgs(buffer, "上位机 → 设备", now));

                // 处理数据
                ProcessReceivedData(buffer, "上位机 → 设备", isNewMessage, deviceDataBuffer);

                // 转发给物理端口
                if (realPort != null && realPort.IsOpen)
                {
                    try
                    {
                        realPort.Write(buffer, 0, bytesRead);
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"向物理端口写入数据时出错: {ex.Message}", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"从虚拟端口读取数据时出错: {ex.Message}", true);
            }
        }

        // 处理接收到的数据
        private void ProcessReceivedData(byte[] buffer, string direction, bool isNewMessage, List<byte> dataBuffer)
        {
            try
            {
                if (isNewMessage)
                {
                    // 新消息时清空旧缓冲区
                    dataBuffer.Clear();
                }

                // 添加新数据到缓冲区
                dataBuffer.AddRange(buffer);

                // 检查至少三帧数据
                if (dataBuffer.Count < 3)
                    return;

                bool hasMessageEnd = false;
                int endIndex = -1;
                byte frameHeader = dataBuffer[0];
                byte command = 0;

                // 处理上位机请求（0x55帧头）
                if (frameHeader == FRAME_HEADER_HOST_REQUEST && direction == "上位机 → 设备")
                {
                    // 完整帧
                    if (dataBuffer.Count >= 4)
                    {
                        byte calculatedChecksum = 0;
                        for (int i = 0; i < 3; i++) // 前3字节（帧头+地址+命令）
                        {
                            calculatedChecksum = (byte)(calculatedChecksum + dataBuffer[i]);
                        }
                        if (dataBuffer[3] == calculatedChecksum)
                        {
                            hasMessageEnd = true;
                            endIndex = 3;
                        }
                    }
                }
                // 处理设备响应（0xAA帧头）
                else if (frameHeader == FRAME_HEADER_DEVICE_RESPONSE && direction == "设备 → 上位机")
                {
                    int requiredLength;
                    command = dataBuffer[2]; // 第三帧为命令

                    switch (command)
                    {
                        case 0x34: // 电压电流功率等参数
                            requiredLength = 72;
                            break;
                        case 0x43: // 有功电能
                            requiredLength = 12;
                            break;
                        default:
                            requiredLength = 4;
                            break;
                    }

                    if (dataBuffer.Count >= requiredLength)
                    {
                        byte calculatedChecksum = 0;
                        for (int i = 0; i < requiredLength - 1; i++) // 校验码前所有字节
                        {
                            calculatedChecksum = (byte)(calculatedChecksum + dataBuffer[i]);
                        }

                        if (dataBuffer[requiredLength - 1] == calculatedChecksum)
                        {
                            hasMessageEnd = true;
                            endIndex = requiredLength - 1;
                        }
                    }
                }

                // 找到完整消息则提取
                if (hasMessageEnd && endIndex >= 0)
                {
                    byte[] message = dataBuffer.GetRange(0, endIndex + 1).ToArray();

                    // 如果是设备响应帧，解析数据
                    if (frameHeader == FRAME_HEADER_DEVICE_RESPONSE && direction == "设备 → 上位机")
                    {
                        ParseDeviceResponse(message, command);
                    }

                    // 移除已处理数据
                    dataBuffer.RemoveRange(0, endIndex + 1);
                }
                // 缓冲区过大时截断（保留最后256字节）
                else if (dataBuffer.Count > 1024)
                {
                    dataBuffer.RemoveRange(0, dataBuffer.Count - 256);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理接收数据时出错: {ex.Message}", true);
            }
        }

        // 解析设备响应
        private void ParseDeviceResponse(byte[] buffer, byte command)
        {
            switch (this.powerDeviceModel)
            {
                case "青智8904F":
                    ParseQingzhi8904F(buffer, command);
                    break;
                case "致远仪器PV300":
                    ParseZhiyuanPV300(buffer);
                    break;
                default:
                    LogMessage($"未选择或不支持的功率仪型号: '{this.powerDeviceModel}'，默认按青智8904F解析。", true);
                    ParseQingzhi8904F(buffer, command);
                    break;
            }
        }

        // 致远仪器PV300协议解析
        private void ParseZhiyuanPV300(byte[] buffer)
        {
            LogMessage($"TODO: 致远仪器PV300", true);
        }

        // 青智8904F协议解析
        private void ParseQingzhi8904F(byte[] buffer, byte command)
        {
            try
            {
                PowerDataEventArgs currentData = null;

                // 处理不同命令类型
                switch (command)
                {
                    case 0x34: // 处理34命令 - 电压电流功率等参数
                        if (buffer.Length >= 72)
                        {
                            currentData = new PowerDataEventArgs
                            {
                                Timestamp = DateTime.Now,

                                // 解析Ua (4-7字节，索引3-6)
                                Ua = ParseFloat(buffer, 3),

                                // 解析Ub (20-23字节，索引19-22)
                                Ub = ParseFloat(buffer, 19),

                                // 解析Uc (36-39字节，索引35-38)
                                Uc = ParseFloat(buffer, 35),

                                // 解析Ia (8-11字节，索引7-10)
                                Ia = ParseFloat(buffer, 7),

                                // 解析Ib (24-27字节，索引23-26)
                                Ib = ParseFloat(buffer, 23),

                                // 解析Ic (40-43字节，索引39-42)
                                Ic = ParseFloat(buffer, 39),

                                // 解析总功率P (60-63字节，索引59-62)
                                P = ParseFloat(buffer, 59),

                                // 解析频率Freq (68-71字节，索引67-70)
                                Freq = ParseFloat(buffer, 67)
                            };
                        }
                        break;

                    case 0x43: // 处理43命令 - 有功电能
                        if (buffer.Length >= 12)
                        {
                            currentData = new PowerDataEventArgs
                            {
                                Timestamp = DateTime.Now,
                                En = ParseFloat(buffer, 3) // 解析有功电能En (4-7字节，索引3-6)
                            };
                        }
                        break;
                }

                if (currentData == null) return;

                lock (pendingDataLock)
                {
                    if (pendingPowerData == null)
                    {
                        pendingPowerData = currentData;
                        flushTimer.Change(500, Timeout.Infinite);
                    }
                    // 有等待中的数据（0x43，电能数据），检查是否可以合并
                    else
                    {
                        // 检查是否在同一秒，并且是互补的数据类型
                        bool isSameSecond = pendingPowerData.Timestamp.Second == currentData.Timestamp.Second;
                        bool isComplementary = (pendingPowerData.P != 0 && currentData.En != 0) || (pendingPowerData.En != 0 && currentData.P != 0);

                        if (isSameSecond && isComplementary)
                        {
                            flushTimer.Change(Timeout.Infinite, Timeout.Infinite); // 成功合并，取消超时

                            // 合并数据
                            if (currentData.P != 0)
                            {
                                pendingPowerData.Ua = currentData.Ua;
                                pendingPowerData.Ub = currentData.Ub;
                                pendingPowerData.Uc = currentData.Uc;
                                pendingPowerData.Ia = currentData.Ia;
                                pendingPowerData.Ib = currentData.Ib;
                                pendingPowerData.Ic = currentData.Ic;
                                pendingPowerData.P = currentData.P;
                                pendingPowerData.Freq = currentData.Freq;
                            }
                            else if (currentData.En != 0)
                            {
                                pendingPowerData.En = currentData.En;
                            }

                            // 发送合并后的数据
                            PowerDataReceived?.Invoke(this, pendingPowerData);
                            pendingPowerData = null; // 清空等待状态
                        }
                        else
                        {
                            // 不是匹配数据，立即发送旧的等待数据
                            flushTimer.Change(Timeout.Infinite, Timeout.Infinite);
                            PowerDataReceived?.Invoke(this, pendingPowerData);

                            // 当前数据成为新的等待数据
                            pendingPowerData = currentData;
                            flushTimer.Change(500, Timeout.Infinite); // 为新数据启动超时
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"解析青智8904F响应时出错: {ex.Message}", true);
            }
        }

        // 定时器回调，用于发送超时未合并的数据
        private void FlushPendingData(object state)
        {
            lock (pendingDataLock)
            {
                if (pendingPowerData != null)
                {
                    PowerDataReceived?.Invoke(this, pendingPowerData);
                    pendingPowerData = null;
                }
            }
        }

        // 字节数组转换为浮点数
        private float ParseFloat(byte[] buffer, int startIndex)
        {
            if (startIndex + 3 >= buffer.Length)
                return 0;

            byte[] floatBytes = new byte[4] {
                buffer[startIndex],
                buffer[startIndex + 1],
                buffer[startIndex + 2],
                buffer[startIndex + 3]
            };

            return BitConverter.ToSingle(floatBytes, 0);
        }

        // 发送日志消息
        private void LogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        // 释放资源
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Disconnect();
                }

                disposed = true;
            }
        }

        ~VirtualPort()
        {
            Dispose(false);
        }
    }

    // 功率仪数据事件参数类
    public class PowerDataEventArgs : EventArgs
    {
        public DateTime Timestamp { get; set; }
        public float Ua { get; set; }
        public float Ub { get; set; }
        public float Uc { get; set; }
        public float Ia { get; set; }
        public float Ib { get; set; }
        public float Ic { get; set; }
        public float P { get; set; }
        public float Freq { get; set; }
        public float En { get; set; }
    }

    // 添加原始数据事件参数类
    public class RawDataEventArgs : EventArgs
    {
        public byte[] Data { get; private set; }
        public string Direction { get; private set; }
        public DateTime Timestamp { get; private set; }

        public RawDataEventArgs(byte[] data, string direction, DateTime timestamp)
        {
            Data = data;
            Direction = direction;
            Timestamp = timestamp;
        }
    }
}
