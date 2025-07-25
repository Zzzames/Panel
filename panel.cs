using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace DA
{
    // IH设备监听类 - 监听显示板和功率板的通信数据
    public class IHDevice : IDisposable
    {
        // 串口对象
        private SerialPort dispSerialPort;  // 显示板串口
        private SerialPort ctrlSerialPort;  // 功率板串口

        // 控制标志
        private bool isDispRunning = false;
        private bool isCtrlRunning = false;

        // 数据缓冲区
        private readonly List<byte> dispDataBuffer = new List<byte>();
        private readonly List<byte> ctrlDataBuffer = new List<byte>();
        private bool dispInFrameCollecting = false;
        private bool ctrlInFrameCollecting = false;
        private int dispExpectedFrameLength = 0;
        private int ctrlExpectedFrameLength = 0;

        // 通信协议常量
        private const byte FUNCTION_ID_CONTROL = 0x03;      // 显示板控制消息
        private const byte FUNCTION_ID_CTRL_RESP = 0xFC;    // 功率板响应消息
        private const byte CONTROL_FRAME_LENGTH = 13;       // 控制消息帧长度
        private const byte RESPONSE_FRAME_LENGTH = 21;      // 响应消息帧长度

        // 事件定义
        public event EventHandler<IHDisplayDataEventArgs> DisplayDataReceived;
        public event EventHandler<IHPowerDataEventArgs> PowerDataReceived;
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event EventHandler<RawDataEventArgs> RawDataReceived;

        // 连接状态属性
        public bool IsDispConnected => isDispRunning && dispSerialPort?.IsOpen == true;
        public bool IsCtrlConnected => isCtrlRunning && ctrlSerialPort?.IsOpen == true;
        public string DispPortName { get; private set; }
        public string CtrlPortName { get; private set; }

        // 连接显示板串口
        public bool ConnectDisplayBoard(string portName, int baudRate = 4800,
                                      Parity parity = Parity.None, int dataBits = 8,
                                      StopBits stopBits = StopBits.One, Handshake handshake = Handshake.None)
        {
            if (isDispRunning)
                return false;

            try
            {
                DispPortName = portName;

                // 初始化显示板串口
                dispSerialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                dispSerialPort.Handshake = handshake;
                dispSerialPort.ReadTimeout = 1000;
                dispSerialPort.WriteTimeout = 1000;
                dispSerialPort.ReadBufferSize = 4096;
                dispSerialPort.WriteBufferSize = 4096;

                // 打开端口
                dispSerialPort.Open();

                // 注册数据接收事件
                dispSerialPort.DataReceived += DispSerialPort_DataReceived;

                isDispRunning = true;
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"显示板串口连接失败: {ex.Message}", true);
                CleanupDispPort();
                return false;
            }
        }

        // 连接功率板串口
        public bool ConnectPowerBoard(string portName, int baudRate = 4800,
                                    Parity parity = Parity.None, int dataBits = 8,
                                    StopBits stopBits = StopBits.One, Handshake handshake = Handshake.None)
        {
            if (isCtrlRunning)
                return false;

            try
            {
                CtrlPortName = portName;

                // 初始化功率板串口
                ctrlSerialPort = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                ctrlSerialPort.Handshake = handshake;
                ctrlSerialPort.ReadTimeout = 1000;
                ctrlSerialPort.WriteTimeout = 1000;
                ctrlSerialPort.ReadBufferSize = 4096;
                ctrlSerialPort.WriteBufferSize = 4096;

                // 打开端口
                ctrlSerialPort.Open();

                // 注册数据接收事件
                ctrlSerialPort.DataReceived += CtrlSerialPort_DataReceived;

                isCtrlRunning = true;
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"功率板串口连接失败: {ex.Message}", true);
                CleanupCtrlPort();
                return false;
            }
        }

        // 断开所有连接
        public void Disconnect()
        {
            DisconnectDisplayBoard();
            DisconnectPowerBoard();
        }

        // 断开显示板连接
        public void DisconnectDisplayBoard()
        {
            if (!isDispRunning)
                return;

            try
            {
                isDispRunning = false;

                CleanupDispPort();
                dispDataBuffer.Clear();
            }
            catch (Exception ex)
            {
                LogMessage($"断开显示板连接时出错: {ex.Message}", true);
            }
        }

        // 断开功率板连接
        public void DisconnectPowerBoard()
        {
            if (!isCtrlRunning)
                return;

            try
            {
                isCtrlRunning = false;

                CleanupCtrlPort();
                ctrlDataBuffer.Clear();
            }
            catch (Exception ex)
            {
                LogMessage($"断开功率板连接时出错: {ex.Message}", true);
            }
        }

        // 显示板数据接收事件
        private void DispSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!isDispRunning || dispSerialPort == null || !dispSerialPort.IsOpen)
                return;

            try
            {
                Thread.Sleep(30); // 等待数据接收完整

                // 再次检查状态，防止在Sleep期间状态发生变化
                if (!isDispRunning || dispSerialPort == null || !dispSerialPort.IsOpen)
                    return;

                int bytesToRead = dispSerialPort.BytesToRead;
                if (bytesToRead <= 0)
                    return;

                byte[] buffer = new byte[bytesToRead];
                int bytesRead = dispSerialPort.Read(buffer, 0, bytesToRead);

                if (bytesRead > 0 && isDispRunning)
                {
                    // 触发原始数据事件
                    RawDataReceived?.Invoke(this, new RawDataEventArgs(buffer, "显示板数据", DateTime.Now));

                    // 处理数据
                    ProcessDisplayData(buffer);
                }
            }
            catch (Exception ex)
            {
                if (isDispRunning)
                {
                    LogMessage($"显示板数据接收错误: {ex.Message}", true);
                }
            }
        }

        // 功率板数据接收事件
        private void CtrlSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!isCtrlRunning || ctrlSerialPort == null || !ctrlSerialPort.IsOpen)
                return;

            try
            {
                Thread.Sleep(30); // 等待数据接收完整

                // 再次检查状态，防止在Sleep期间状态发生变化
                if (!isCtrlRunning || ctrlSerialPort == null || !ctrlSerialPort.IsOpen)
                    return;

                int bytesToRead = ctrlSerialPort.BytesToRead;
                if (bytesToRead <= 0)
                    return;

                byte[] buffer = new byte[bytesToRead];
                int bytesRead = ctrlSerialPort.Read(buffer, 0, bytesToRead);

                if (bytesRead > 0 && isCtrlRunning)
                {
                    // 触发原始数据事件
                    RawDataReceived?.Invoke(this, new RawDataEventArgs(buffer, "功率板数据", DateTime.Now));

                    // 处理数据
                    ProcessPowerData(buffer);
                }
            }
            catch (Exception ex)
            {
                if (isCtrlRunning)
                {
                    LogMessage($"功率板数据接收错误: {ex.Message}", true);
                }
            }
        }

        // 处理显示板数据
        private void ProcessDisplayData(byte[] data)
        {
            try
            {
                if (data == null || data.Length == 0)
                    return;

                // 处理收到的数据
                int index = 0;
                while (index < data.Length)
                {
                    if (!dispInFrameCollecting)
                    {
                        // 检查剩余数据是否至少包含帧头
                        if (index + 2 >= data.Length)
                        {
                            // 数据不足，添加到缓冲区
                            for (int i = index; i < data.Length; i++)
                            {
                                dispDataBuffer.Add(data[i]);
                            }
                            break;
                        }

                        byte frameLength = data[index + 1];

                        // 验证帧长度
                        if (frameLength < 3 || frameLength > 30)
                        {
                            index++;
                            continue;
                        }

                        // 开始收集新帧
                        dispDataBuffer.Clear();
                        int bytesToCopy = Math.Min(frameLength, data.Length - index);
                        for (int i = 0; i < bytesToCopy; i++)
                        {
                            dispDataBuffer.Add(data[index + i]);
                        }

                        dispInFrameCollecting = true;
                        dispExpectedFrameLength = frameLength;
                        index += bytesToCopy;

                        // 检查是否已收集到完整帧
                        if (dispDataBuffer.Count == dispExpectedFrameLength)
                        {
                            ProcessCompleteDisplayFrame(dispDataBuffer.ToArray());
                            dispInFrameCollecting = false;
                        }
                    }
                    else
                    {
                        // 继续收集当前帧的剩余数据
                        int bytesNeeded = dispExpectedFrameLength - dispDataBuffer.Count;
                        int bytesToAdd = Math.Min(bytesNeeded, data.Length - index);

                        for (int i = 0; i < bytesToAdd; i++)
                        {
                            dispDataBuffer.Add(data[index + i]);
                        }
                        index += bytesToAdd;

                        // 检查是否已收集到完整帧
                        if (dispDataBuffer.Count == dispExpectedFrameLength)
                        {
                            ProcessCompleteDisplayFrame(dispDataBuffer.ToArray());
                            dispInFrameCollecting = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理显示板数据错误: {ex.Message}", true);
                dispInFrameCollecting = false;
            }
        }

        // 处理功率板数据
        private void ProcessPowerData(byte[] data)
        {
            try
            {
                if (data == null || data.Length == 0)
                    return;

                // 处理收到的数据
                int index = 0;
                while (index < data.Length)
                {
                    if (!ctrlInFrameCollecting)
                    {
                        // 检查剩余数据是否至少包含帧头
                        if (index + 2 >= data.Length)
                        {
                            // 数据不足，添加到缓冲区
                            for (int i = index; i < data.Length; i++)
                            {
                                ctrlDataBuffer.Add(data[i]);
                            }
                            break;
                        }

                        byte frameLength = data[index + 1];

                        // 验证帧长度
                        if (frameLength < 3 || frameLength > 30)
                        {
                            index++;
                            continue;
                        }

                        // 开始收集新帧
                        ctrlDataBuffer.Clear();
                        int bytesToCopy = Math.Min(frameLength, data.Length - index);
                        for (int i = 0; i < bytesToCopy; i++)
                        {
                            ctrlDataBuffer.Add(data[index + i]);
                        }

                        ctrlInFrameCollecting = true;
                        ctrlExpectedFrameLength = frameLength;
                        index += bytesToCopy;

                        // 检查是否已收集到完整帧
                        if (ctrlDataBuffer.Count == ctrlExpectedFrameLength)
                        {
                            ProcessCompletePowerFrame(ctrlDataBuffer.ToArray());
                            ctrlInFrameCollecting = false;
                        }
                    }
                    else
                    {
                        // 继续收集当前帧的剩余数据
                        int bytesNeeded = ctrlExpectedFrameLength - ctrlDataBuffer.Count;
                        int bytesToAdd = Math.Min(bytesNeeded, data.Length - index);

                        for (int i = 0; i < bytesToAdd; i++)
                        {
                            ctrlDataBuffer.Add(data[index + i]);
                        }
                        index += bytesToAdd;

                        // 检查是否已收集到完整帧
                        if (ctrlDataBuffer.Count == ctrlExpectedFrameLength)
                        {
                            ProcessCompletePowerFrame(ctrlDataBuffer.ToArray());
                            ctrlInFrameCollecting = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理功率板数据错误: {ex.Message}", true);
                ctrlInFrameCollecting = false;
            }
        }

        // 处理完整的显示板数据帧
        private void ProcessCompleteDisplayFrame(byte[] frame)
        {
            try
            {
                if (frame.Length < 3)
                    return;

                byte address = frame[0];
                byte frameLength = frame[1];
                byte functionId = frame[2];

                // 只处理控制消息（0x03）
                if (functionId != FUNCTION_ID_CONTROL || frameLength != CONTROL_FRAME_LENGTH)
                    return;

                // 验证校验和
                byte checksum = CalculateChecksum(frame, 1, frameLength - 2);
                if (checksum != frame[frameLength - 1])
                {
                    LogMessage($"显示板数据校验和错误: 计算值=0x{checksum:X2}，接收值=0x{frame[frameLength - 1]:X2}", true);
                    return;
                }

                // 解析控制消息
                string position = GetPositionFromAddress(address);
                if (string.IsNullOrEmpty(position))
                {
                    LogMessage($"无效的地址: 0x{address:X2}", true);
                    return;
                }

                var displayData = ParseDisplayControlData(frame);
                displayData.Position = position;
                displayData.Timestamp = DateTime.Now;

                // 触发显示板数据事件
                DisplayDataReceived?.Invoke(this, new IHDisplayDataEventArgs(displayData));
            }
            catch (Exception ex)
            {
                LogMessage($"处理显示板帧数据错误: {ex.Message}", true);
            }
        }

        // 处理完整的功率板数据帧
        private void ProcessCompletePowerFrame(byte[] frame)
        {
            try
            {
                if (frame.Length < 3)
                    return;

                byte address = frame[0];
                byte frameLength = frame[1];
                byte functionId = frame[2];

                // 只处理响应消息（0xFC）
                if (functionId != FUNCTION_ID_CTRL_RESP || frameLength != RESPONSE_FRAME_LENGTH)
                    return;

                // 验证校验和
                byte checksum = CalculateChecksum(frame, 1, frameLength - 2);
                if (checksum != frame[frameLength - 1])
                {
                    LogMessage($"功率板数据校验和错误: 计算值=0x{checksum:X2}，接收值=0x{frame[frameLength - 1]:X2}", true);
                    return;
                }

                // 解析响应消息
                string position = GetPositionFromAddress(address);
                if (string.IsNullOrEmpty(position))
                {
                    LogMessage($"无效的地址: 0x{address:X2}", true);
                    return;
                }

                var powerData = ParsePowerResponseData(frame);
                powerData.Position = position;
                powerData.Timestamp = DateTime.Now;

                // 触发功率板数据事件
                PowerDataReceived?.Invoke(this, new IHPowerDataEventArgs(powerData));
            }
            catch (Exception ex)
            {
                LogMessage($"处理功率板帧数据错误: {ex.Message}", true);
            }
        }

        // 解析显示板控制数据
        private IHDisplayData ParseDisplayControlData(byte[] frame)
        {
            var data = new IHDisplayData();

            // D0-D6字节 (frame[3])
            byte flagByte = frame[3];
            data.StoveSwitch = (flagByte & 0x80) != 0;                  // B7 炉头开关标志
            data.PauseFlag = (flagByte & 0x40) != 0;                    // B6 暂停标志
            data.AllowPanDetection = (flagByte & 0x20) != 0;            // B5 允许检锅标志
            data.PPGMode = (flagByte & 0x10) != 0;                      // B4 PPG模式标志
            data.allZone_BridgeHeatFlag = (flagByte & 0x08) != 0;       // B3 无区/桥接标志
            data.InnerOuterRing = (flagByte & 0x04) != 0;               // B2 内外环标志
            data.chefsFunctionOnFlag = (flagByte & 0x02) != 0;          // B1 移锅控工激活标志
            data.HeatingFreqFollow = (flagByte & 0x01) != 0;             // B0 加热频率跟随标志

            // D1 (frame[4]) - 功率高位和加热频率抖频标志
            byte powerH = frame[4];
            int powerReqValueH = powerH & 0x1F;                          // B0-B4
            data.HeatFreqJitterFlag = (powerH & 0x20) != 0;              // B5 加热频率抖频标志 

            data.Disp_ReserveD1B6 = (powerH & 0x40) != 0 ? 1 : 0;            // B6 预留位
            data.Disp_ReserveD1B7 = (powerH & 0x80) != 0 ? 1 : 0;            // B7 预留位

            // D2 (frame[5]) - 功率低位
            int powerReqValueL = frame[5];
            data.RequestPower = (powerReqValueH << 8) | powerReqValueL;  // 功率

            // D3 (frame[6]) - 无区和风扇等级
            byte zoneByte = frame[6];
            data.BridgeControl = zoneByte & 0x1F;                        // 无区/桥接控制
            data.FanLevel = zoneByte >> 5;                               // 风机挡位

            // D4 (frame[7]) - 调试通道
            byte debugByte = frame[7];
            data.DebugChannel = debugByte & 0x1F;                        // DEBUG通道
            data.DebugSubChannel = debugByte >> 5;                       // DEBUG子通道号

            // D5-D6 (frame[8]-frame[9]) - 噪声控制
            data.NoiseControl = (frame[8] << 8) | frame[9];

            // D7 (frame[10]) - 预留
            data.ReserveD7 = (frame[11] << 8) | frame[10];

            // // D8 (frame[11]) - 预留
            // data.ReserveD8 = frame[11];

            return data;
        }

        // 解析功率板响应数据
        private IHPowerData ParsePowerResponseData(byte[] frame)
        {
            var data = new IHPowerData();

            // D0 (frame[3]) - 检锅状态
            byte pollingByte = frame[3];
            if (pollingByte == 0)
                data.PollingState = 0; // 都没有检测到锅
            else if (pollingByte == 1)
                data.PollingState = 1; // 仅主线盘有锅
            else if (pollingByte == 3)
                data.PollingState = 2; // 两个线盘都有锅
            else
                data.PollingState = 0; // 默认

            // D1-D2 (frame[4]-frame[5]) - 功率值和同频标志
            byte powerH = frame[4];
            int powerValueH = powerH & 0x1F;                    // B0-B4
            data.HeatFlag = (powerH & 0x20) != 0 ? 1 : 0;       // B5 同频标志
            data.Power_ReserveD1B6 = (powerH & 0x40) != 0 ? 1 : 0;   // B6 预留位
            data.Power_ReserveD1B7 = (powerH & 0x80) != 0 ? 1 : 0;   // B7 预留位

            int powerValueL = frame[5];                         // D2:B0-B8
            data.Power = (powerValueH << 8) | powerValueL;

            // D3 (frame[6]) - 故障码
            data.ErrorCode = frame[6];

            // D4 (frame[7]) - 锅具受热品质值
            data.PanTemp = frame[7];

            // D5-D6 (frame[8]-frame[9]) - 电压和芯片温度
            data.Voltage = frame[8] + 50;
            data.MCUTemp = frame[9];

            // D7-D10 (frame[10]-frame[13]) - NTC和IGBT温度
            int heatNtc1H = frame[10];
            int heatNtc2H = frame[11];
            int igbtNtc1H = frame[12];
            int igbtNtc2H = frame[13];

            // D11 (frame[14]) - 温度AD扩展位
            byte tempExtByte = frame[14];
            int igbtNtc2L = tempExtByte & 0x03;
            int igbtNtc1L = (tempExtByte >> 2) & 0x03;
            int heatNtc2L = (tempExtByte >> 4) & 0x03;
            int heatNtc1L = (tempExtByte >> 6) & 0x03;

            // 组合10位精度的温度值
            data.HeatNTC1 = (heatNtc1H << 2) | heatNtc1L;
            data.HeatNTC2 = (heatNtc2H << 2) | heatNtc2L;
            data.IGBTNTC1 = (igbtNtc1H << 2) | igbtNtc1L;
            data.IGBTNTC2 = (igbtNtc2H << 2) | igbtNtc2L;

            // D12-D13 (frame[15]-frame[16]) - 加热频率
            byte freqH = frame[15];
            int heatFreqValueH = freqH & 0x7F;
            data.FreqControlFlag = (freqH & 0x80) != 0 ? 1 : 0;
            int heatFreqValueL = frame[16];
            int heatFreqValue = (heatFreqValueH << 8) | heatFreqValueL;
            data.Freq = (int)Math.Round((heatFreqValue * 10.0) / 1000.0);

            // D14 (frame[17]) - 预留
            data.ReserveD14 = frame[17];

            // D15 (frame[18]) - 预留
            data.ReserveD15 = frame[18];

            // D16 (frame[19]) - 预留
            data.ReserveD16 = frame[19];

            return data;
        }

        // 根据地址获取炉头位置
        private string GetPositionFromAddress(byte address)
        {
            switch (address)
            {
                case 0x88: return "LR";  // 左后
                case 0x99: return "LF";  // 左前
                case 0xAA: return "RR";  // 右后
                case 0xBB: return "RF";  // 右前
                case 0xCC: return "CLF"; // 中左前
                case 0xDD: return "CLR"; // 中左后
                default: return "";
            }
        }

        // 计算校验和
        private byte CalculateChecksum(byte[] data, int startIndex, int length)
        {
            uint sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += data[startIndex + i];
            }
            return (byte)((~sum + 1) & 0xFF);
        }

        // 清理显示板端口
        private void CleanupDispPort()
        {
            try
            {
                if (dispSerialPort != null)
                {
                    try
                    {
                        // 先移除事件处理器
                        dispSerialPort.DataReceived -= DispSerialPort_DataReceived;
                    }
                    catch { }

                    try
                    {
                        // 如果端口打开，则关闭它
                        if (dispSerialPort.IsOpen)
                        {
                            dispSerialPort.Close();
                        }
                    }
                    catch { }

                    try
                    {
                        // 释放资源
                        dispSerialPort.Dispose();
                    }
                    catch { }

                    dispSerialPort = null;
                }
            }
            catch (Exception ex)
            {
                LogMessage($"清理显示板端口错误: {ex.Message}", true);
            }
        }

        // 清理功率板端口
        private void CleanupCtrlPort()
        {
            try
            {
                if (ctrlSerialPort != null)
                {
                    try
                    {
                        // 先移除事件处理器
                        ctrlSerialPort.DataReceived -= CtrlSerialPort_DataReceived;
                    }
                    catch { }

                    try
                    {
                        // 如果端口打开，则关闭它
                        if (ctrlSerialPort.IsOpen)
                        {
                            ctrlSerialPort.Close();
                        }
                    }
                    catch { }

                    try
                    {
                        // 释放资源
                        ctrlSerialPort.Dispose();
                    }
                    catch { }

                    ctrlSerialPort = null;
                }
            }
            catch (Exception ex)
            {
                LogMessage($"清理功率板端口错误: {ex.Message}", true);
            }
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

        ~IHDevice()
        {
            Dispose(false);
        }
    }

    // IH显示板数据类
    public class IHDisplayData
    {
        public string Position { get; set; }
        public DateTime Timestamp { get; set; }

        // 15个显示板参数
        public bool HeatingFreqFollow { get; set; }
        public bool chefsFunctionOnFlag { get; set; }
        public bool InnerOuterRing { get; set; }
        public bool allZone_BridgeHeatFlag { get; set; }
        public bool PPGMode { get; set; }
        public bool AllowPanDetection { get; set; }
        public bool PauseFlag { get; set; }
        public bool StoveSwitch { get; set; }

        public int RequestPower { get; set; }
        public bool HeatFreqJitterFlag { get; set; }
        public int BridgeControl { get; set; }
        public int FanLevel { get; set; }
        public int DebugSubChannel { get; set; }
        public int DebugChannel { get; set; }
        public int NoiseControl { get; set; }

        // 预留位参数
        public int Disp_ReserveD1B7 { get; set; }            // 显示板D1字节B7预留位
        public int Disp_ReserveD1B6 { get; set; }            // D1字节B6预留位
        public int ReserveD7 { get; set; }              // D7字节预留
        public int ReserveD8 { get; set; }              // D8字节预留
    }

    // IH功率板数据类
    public class IHPowerData
    {
        public string Position { get; set; }
        public DateTime Timestamp { get; set; }

        // 13个功率板参数
        public int HeatNTC1 { get; set; }
        public int HeatNTC2 { get; set; }
        public int IGBTNTC1 { get; set; }
        public int IGBTNTC2 { get; set; }
        public int PanTemp { get; set; }
        public int Freq { get; set; }
        public int Voltage { get; set; }
        public int Power { get; set; }
        public int MCUTemp { get; set; }
        public int ErrorCode { get; set; }
        public int PollingState { get; set; }
        public int FreqControlFlag { get; set; }
        public int HeatFlag { get; set; }

        // 预留位参数
        public int Power_ReserveD1B7 { get; set; }            // 功率板D1字节B7预留位
        public int Power_ReserveD1B6 { get; set; }            // 功率板D1字节B6预留位
        public int ReserveD14 { get; set; }             // D14字节预留
        public int ReserveD15 { get; set; }             // D15字节预留
        public int ReserveD16 { get; set; }             // D16字节预留
    }

    // IH显示板数据事件参数
    public class IHDisplayDataEventArgs : EventArgs
    {
        public IHDisplayData Data { get; private set; }

        public IHDisplayDataEventArgs(IHDisplayData data)
        {
            Data = data;
        }
    }

    // IH功率板数据事件参数
    public class IHPowerDataEventArgs : EventArgs
    {
        public IHPowerData Data { get; private set; }

        public IHPowerDataEventArgs(IHPowerData data)
        {
            Data = data;
        }
    }

    // IH控件管理类
    public class IHPanelManager : IDisposable
    {
        private readonly DAForm mainForm;
        private readonly ChartManager chartManager;

        private readonly Dictionary<string, string> ihCheckboxTexts = new Dictionary<string, string>();
        private readonly Dictionary<string, string> ihCheckboxOriginalTexts = new Dictionary<string, string>();
        private readonly Dictionary<string, DateTime> ihTextBoxUpdateTimes = new Dictionary<string, DateTime>();
        private readonly object ihPanelLock = new object();

        // IH设备数据批量写入机制
        private Dictionary<string, string> ihDataCache = new Dictionary<string, string>();
        private DateTime lastIHDataSaveTime = DateTime.MinValue;
        private readonly object ihDataCacheLock = new object();

        private readonly System.Windows.Forms.Timer ihDataFreshnessTimer;
        private readonly System.Windows.Forms.Timer doubleClickTimer;
        private CheckBox lastClickedCheckBox;
        private DateTime lastClickTime = DateTime.MinValue;

        // 事件定义
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event Action<string, Dictionary<string, string>> DataCacheRequested;
        public event Action NotifyTreeViewRefresh;

        private static readonly string[] IH_POSITIONS = { "LR", "LF", "RR", "RF", "CLF", "CLR" };

        private static readonly string[] IH_DISPLAY_PARAMS = {
            "HeatingFreqFollow", "PanControlActive", "InnerOuterRing",
            "allZone_BridgeHeatFlag", "PPGMode", "AllowPanDetection", "PauseFlag", "StoveSwitch",
            "RequestPower", "HeatFreqJitterFlag", "BridgeControl", "FanLevel",
            "DebugSubChannel", "DebugChannel", "NoiseControl", "Disp_ReserveD1B6", "Disp_ReserveD1B7",
            "ReserveD7", "ReserveD8"
        };
        private static readonly string[] IH_POWER_PARAMS = {
            "HeatNTC1", "HeatNTC2", "IGBTNTC1", "IGBTNTC2", "PanTemp",
            "Freq", "Voltage", "Power", "MCUTemp", "ErrorCode", "PollingState",
            "FreqControlFlag", "HeatFlag", "Power_ReserveD1B6", "Power_ReserveD1B7", "ReserveD14",
            "ReserveD15", "ReserveD16"
        };

        public IHPanelManager(DAForm form, ChartManager chartManager)
        {
            mainForm = form;
            this.chartManager = chartManager;

            ihDataFreshnessTimer = new System.Windows.Forms.Timer();
            ihDataFreshnessTimer.Interval = 1000;
            ihDataFreshnessTimer.Tick += IHDataFreshnessTimer_Tick;

            doubleClickTimer = new System.Windows.Forms.Timer();
            doubleClickTimer.Interval = System.Windows.Forms.SystemInformation.DoubleClickTime;
            doubleClickTimer.Tick += DoubleClickTimer_Tick;
        }

        public void Initialize()
        {
            InitializeIHCheckboxes();
            ihDataFreshnessTimer.Start();
        }

        public void UpdateDisplayData(IHDisplayData data)
        {
            try
            {
                string position = data.Position;
                var displayMappings = new Dictionary<string, object>
                {
                    ["HeatingFreqFollow"] = data.HeatingFreqFollow ? 1 : 0,
                    ["PanControlActive"] = data.chefsFunctionOnFlag ? 1 : 0,
                    ["InnerOuterRing"] = data.InnerOuterRing ? 1 : 0,
                    ["allZone_BridgeHeatFlag"] = data.allZone_BridgeHeatFlag ? 1 : 0,
                    ["PPGMode"] = data.PPGMode ? 1 : 0,
                    ["AllowPanDetection"] = data.AllowPanDetection ? 1 : 0,
                    ["PauseFlag"] = data.PauseFlag ? 1 : 0,
                    ["StoveSwitch"] = data.StoveSwitch ? 1 : 0,
                    ["RequestPower"] = data.RequestPower,
                    ["HeatFreqJitterFlag"] = data.HeatFreqJitterFlag ? 1 : 0,
                    ["BridgeControl"] = data.BridgeControl,
                    ["FanLevel"] = data.FanLevel,
                    ["DebugSubChannel"] = data.DebugSubChannel,
                    ["DebugChannel"] = data.DebugChannel,
                    ["NoiseControl"] = data.NoiseControl,
                    ["Disp_ReserveD1B6"] = data.Disp_ReserveD1B6,
                    ["Disp_ReserveD1B7"] = data.Disp_ReserveD1B7,
                    ["ReserveD7"] = data.ReserveD7,
                    ["ReserveD8"] = data.ReserveD8,
                };

                UpdateTextBoxes(position, displayMappings);
                UpdateChartForIHData(position, displayMappings);

                // 缓存数据用于数据库存储
                Dictionary<string, string> allDataRecord = new Dictionary<string, string>();
                foreach (var mapping in displayMappings)
                {
                    string dbColumnName = $"{position}_{mapping.Key}";
                    allDataRecord[dbColumnName] = mapping.Value.ToString();
                }

                if (allDataRecord.Count > 0)
                {
                    CacheIHDataForBatchSave(allDataRecord);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"更新IH显示板UI时出错: {ex.Message}", true);
            }
        }

        public void UpdatePowerData(IHPowerData data)
        {
            try
            {
                string position = data.Position;
                var powerMappings = new Dictionary<string, object>
                {
                    ["HeatNTC1"] = data.HeatNTC1,
                    ["HeatNTC2"] = data.HeatNTC2,
                    ["IGBTNTC1"] = data.IGBTNTC1,
                    ["IGBTNTC2"] = data.IGBTNTC2,
                    ["PanTemp"] = data.PanTemp,
                    ["Freq"] = data.Freq,
                    ["Voltage"] = data.Voltage,
                    ["Power"] = data.Power,
                    ["MCUTemp"] = data.MCUTemp,
                    ["ErrorCode"] = $"0x{data.ErrorCode:X2}",
                    ["PollingState"] = data.PollingState,
                    ["FreqControlFlag"] = data.FreqControlFlag,
                    ["HeatFlag"] = data.HeatFlag,
                    ["Power_ReserveD1B6"] = data.Power_ReserveD1B6,
                    ["Power_ReserveD1B7"] = data.Power_ReserveD1B7,
                    ["ReserveD14"] = data.ReserveD14,
                    ["ReserveD15"] = data.ReserveD15,
                    ["ReserveD16"] = data.ReserveD16,
                };

                UpdateTextBoxes(position, powerMappings);
                UpdateChartForIHData(position, powerMappings);

                // 缓存数据用于数据库存储
                Dictionary<string, string> allDataRecord = new Dictionary<string, string>();
                foreach (var mapping in powerMappings)
                {
                    string dbColumnName = $"{position}_{mapping.Key}";
                    allDataRecord[dbColumnName] = mapping.Value.ToString();
                }

                if (allDataRecord.Count > 0)
                {
                    CacheIHDataForBatchSave(allDataRecord);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"更新IH功率板UI时出错: {ex.Message}", true);
            }
        }

        private void UpdateTextBoxes(string position, Dictionary<string, object> mappings)
        {
            foreach (var mapping in mappings)
            {
                string controlName = $"{position}_{mapping.Key}";
                if (IH_DISPLAY_PARAMS.Contains(mapping.Key))
                {
                    controlName += "_TextBox";
                }
                else if (!new[] { "ErrorCode", "PollingState", "FreqControlFlag", "HeatFlag" }.Contains(mapping.Key))
                {
                    controlName += "_TextBox";
                }

                TextBox textBox = mainForm.FindControlByName<TextBox>(controlName);
                if (textBox != null)
                {
                    textBox.Text = mapping.Value.ToString();
                    lock (ihPanelLock)
                    {
                        ihTextBoxUpdateTimes[controlName] = DateTime.Now;
                    }
                }
            }
        }

        public void ClearAllTextBoxes()
        {
            try
            {
                ProcessIHParameters((position, param) =>
                {
                    string textBoxName = $"{position}_{param}";
                    if (IH_DISPLAY_PARAMS.Contains(param))
                    {
                        textBoxName += "_TextBox";
                    }
                    else if (!new[] { "ErrorCode", "PollingState", "FreqControlFlag", "HeatFlag" }.Contains(param))
                    {
                        textBoxName += "_TextBox";
                    }

                    TextBox textBox = mainForm.FindControlByName<TextBox>(textBoxName);
                    if (textBox != null)
                    {
                        textBox.Text = "";
                    }
                });
            }
            catch (Exception ex)
            {
                LogMessage($"清除IH设备数值时出错: {ex.Message}", true);
            }
        }

        public List<string> GetSelectedIHColumns()
        {
            var selectedColumns = new List<string>();
            ProcessIHParameters((position, param) =>
            {
                string checkboxName = $"chk{position}_{param}";
                CheckBox checkbox = mainForm.FindControlByName<CheckBox>(checkboxName);
                if (checkbox != null && checkbox.Checked)
                {
                    string displayText = ihCheckboxTexts.ContainsKey(checkboxName) ?
                                       ihCheckboxTexts[checkboxName] : checkbox.Text;
                    selectedColumns.Add($"{position}_{displayText}");
                }
            });
            return selectedColumns;
        }

        public string GetIHDbColumnNameForDisplay(string displayName)
        {
            foreach (string position in IH_POSITIONS)
            {
                foreach (string param in IH_DISPLAY_PARAMS.Concat(IH_POWER_PARAMS))
                {
                    string checkboxName = $"chk{position}_{param}";
                    if (ihCheckboxTexts.ContainsKey(checkboxName))
                    {
                        string customText = ihCheckboxTexts[checkboxName];
                        if (displayName == $"{position}_{customText}")
                        {
                            return $"{position}_{param}";
                        }
                    }
                    else
                    {
                        CheckBox cb = mainForm.FindControlByName<CheckBox>(checkboxName);
                        if (cb != null && displayName == $"{position}_{cb.Text}")
                        {
                            return $"{position}_{param}";
                        }
                    }
                }
            }
            return displayName;
        }

        // 强制保存IH缓存数据（用于保存CSV时）
        public void ForceFlushIHData()
        {
            try
            {
                lock (ihDataCacheLock)
                {
                    if (ihDataCache.Count > 0)
                    {
                        SaveCachedIHData(DateTime.Now);
                        lastIHDataSaveTime = DateTime.Now; // 更新保存时间
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"强制保存IH数据出错: {ex.Message}", true);
            }
        }

        private void InitializeIHCheckboxes()
        {
            try
            {
                ProcessIHParameters((position, param) =>
                {
                    string checkboxName = $"chk{position}_{param}";
                    CheckBox checkbox = mainForm.FindControlByName<CheckBox>(checkboxName);
                    if (checkbox != null)
                    {
                        // 记录原始文字
                        ihCheckboxOriginalTexts[checkboxName] = checkbox.Text;
                        // 记录当前文字
                        ihCheckboxTexts[checkboxName] = checkbox.Text;
                        checkbox.MouseClick += CheckBox_MouseClick;
                        checkbox.CheckedChanged += IHCheckBox_CheckedChanged;
                    }
                });
            }
            catch (Exception ex)
            {
                LogMessage($"初始化IH设备复选框时出错: {ex.Message}", true);
            }
        }

        private void IHCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox == null) return;

            }
            catch (Exception ex)
            {
                LogMessage($"处理IH设备复选框状态改变时出错: {ex.Message}", true);
            }
        }

        private void CheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox == null || e.Button != MouseButtons.Left) return;

                DateTime now = DateTime.Now;
                if (lastClickedCheckBox == checkBox &&
                    (now - lastClickTime).TotalMilliseconds <= System.Windows.Forms.SystemInformation.DoubleClickTime)
                {
                    doubleClickTimer.Stop();
                    lastClickedCheckBox = null;
                    EditCheckBoxText(checkBox);
                }
                else
                {
                    lastClickedCheckBox = checkBox;
                    lastClickTime = now;
                    doubleClickTimer.Start();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理复选框点击时出错: {ex.Message}", true);
            }
        }

        private void EditCheckBoxText(CheckBox checkBox)
        {
            try
            {
                string currentText = ihCheckboxTexts.ContainsKey(checkBox.Name) ?
                                     ihCheckboxTexts[checkBox.Name] : checkBox.Text;

                using (var inputForm = new Form())
                {
                    inputForm.Text = "编辑参数名称";
                    inputForm.Size = new Size(300, 150);
                    inputForm.StartPosition = FormStartPosition.CenterParent;
                    inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    inputForm.MaximizeBox = false;
                    inputForm.MinimizeBox = false;

                    var label = new Label { Text = "请输入新的参数名称:", Location = new Point(10, 10), AutoSize = true };
                    var textBox = new TextBox { Location = new Point(10, 40), Size = new Size(265, 23), Text = currentText };
                    var okButton = new Button { Text = "确定", DialogResult = DialogResult.OK, Location = new Point(120, 70) };
                    var cancelButton = new Button { Text = "取消", DialogResult = DialogResult.Cancel, Location = new Point(200, 70) };

                    inputForm.Controls.AddRange(new Control[] { label, textBox, okButton, cancelButton });
                    inputForm.AcceptButton = okButton;
                    inputForm.CancelButton = cancelButton;

                    if (inputForm.ShowDialog(mainForm) == DialogResult.OK)
                    {
                        string newText = textBox.Text.Trim();
                        if (!string.IsNullOrEmpty(newText))
                        {
                            UpdateIHCheckBoxText(checkBox, newText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"编辑复选框文字时出错: {ex.Message}", true);
            }
        }

        private void UpdateIHCheckBoxText(CheckBox checkBox, string newText)
        {
            try
            {
                string position = checkBox.Name.Split('_')[0].Substring(3);
                string oldDisplayText = ihCheckboxTexts.ContainsKey(checkBox.Name) ?
                                        ihCheckboxTexts[checkBox.Name] : checkBox.Text;
                string oldSeriesName = $"{position}_{oldDisplayText}";

                ihCheckboxTexts[checkBox.Name] = newText;
                checkBox.Text = newText;

                string newSeriesName = $"{position}_{newText}";
                chartManager.RenameSeries(oldSeriesName, newSeriesName);
                NotifyTreeViewRefresh?.Invoke(); // 触发TreeView刷新
            }
            catch (Exception ex)
            {
                LogMessage($"更新IH复选框文字时出错: {ex.Message}", true);
            }
        }

        private void UpdateChartForIHData(string position, Dictionary<string, object> dataMappings)
        {
            try
            {
                foreach (var mapping in dataMappings)
                {
                    string parameterKey = mapping.Key;
                    string checkboxName = $"chk{position}_{parameterKey}";

                    CheckBox checkBox = mainForm.FindControlByName<CheckBox>(checkboxName);
                    if (checkBox == null || !checkBox.Checked)
                    {
                        continue;
                    }

                    if (parameterKey == "ErrorCode") continue;

                    string seriesName = ihCheckboxTexts.ContainsKey(checkboxName) ?
                                      $"{position}_{ihCheckboxTexts[checkboxName]}" :
                                      $"{position}_{parameterKey}";

                    double value = Convert.ToDouble(mapping.Value);
                    chartManager.AddOrUpdateData(seriesName, DateTime.Now, value, ChartManager.GetAxisTypeForParameter(parameterKey));
                }
            }
            catch (Exception ex)
            {
                LogMessage($"更新IH图表数据时出错: {ex.Message}", true);
            }
        }

        // IH数据批量处理方法
        private void CacheIHDataForBatchSave(Dictionary<string, string> newData)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                bool shouldSave = false;

                lock (ihDataCacheLock)
                {
                    // 更新缓存数据
                    foreach (var kvp in newData)
                    {
                        ihDataCache[kvp.Key] = kvp.Value;
                    }

                    // 检查是否需要保存（1秒间隔）
                    if ((currentTime - lastIHDataSaveTime).TotalSeconds >= 1.0)
                    {
                        shouldSave = true;
                        lastIHDataSaveTime = currentTime;
                    }
                }

                // 如果需要保存，则保存并清空缓存
                if (shouldSave)
                {
                    SaveCachedIHData(currentTime);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"IH数据缓存处理出错: {ex.Message}", true);
            }
        }

        // 保存缓存的IH数据
        private void SaveCachedIHData(DateTime timestamp)
        {
            try
            {
                Dictionary<string, string> dataToSave;

                lock (ihDataCacheLock)
                {
                    if (ihDataCache.Count == 0) return;
                    // 复制当前缓存数据
                    dataToSave = new Dictionary<string, string>(ihDataCache);
                }

                // 异步保存到数据库
                if (dataToSave.Count > 0)
                {
                    DataCacheRequested?.Invoke("IH", dataToSave);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"保存IH缓存数据出错: {ex.Message}", true);
            }
        }

        private void IHDataFreshnessTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                List<string> expiredTextBoxes = new List<string>();

                lock (ihPanelLock)
                {
                    foreach (var kvp in ihTextBoxUpdateTimes.ToList())
                    {
                        if ((now - kvp.Value).TotalSeconds > 5)
                        {
                            expiredTextBoxes.Add(kvp.Key);
                        }
                    }
                }

                foreach (string textBoxName in expiredTextBoxes)
                {
                    TextBox textBox = mainForm.FindControlByName<TextBox>(textBoxName);
                    if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                    {
                        textBox.Text = "";
                    }
                    lock (ihPanelLock)
                    {
                        ihTextBoxUpdateTimes.Remove(textBoxName);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"IH数据过期检测时出错: {ex.Message}", true);
            }
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            doubleClickTimer.Stop();
            lastClickedCheckBox = null;
        }

        private void ProcessIHParameters(Action<string, string> processor)
        {
            foreach (string position in IH_POSITIONS)
            {
                foreach (string param in IH_DISPLAY_PARAMS)
                {
                    processor(position, param);
                }
                foreach (string param in IH_POWER_PARAMS)
                {
                    processor(position, param);
                }
            }
        }

        private void LogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        #region 配置保存和加载

        // 获取IH设备配置
        public List<DAForm.IHDeviceCheckBoxConfig> GetIHConfiguration()
        {
            var config = new List<DAForm.IHDeviceCheckBoxConfig>();

            try
            {
                // 遍历所有IH设备复选框
                ProcessIHParameters((position, param) =>
                {
                    string checkBoxName = $"chk{position}_{param}";
                    CheckBox checkBox = mainForm.FindControlByName<CheckBox>(checkBoxName);
                    if (checkBox != null)
                    {
                        config.Add(new DAForm.IHDeviceCheckBoxConfig
                        {
                            CheckBoxName = checkBoxName,
                            IsChecked = checkBox.Checked,
                            CustomText = ihCheckboxTexts.ContainsKey(checkBoxName) ?
                                         ihCheckboxTexts[checkBoxName] : checkBox.Text
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                LogMessage($"获取IH设备配置时出错: {ex.Message}", true);
            }

            return config;
        }

        // 应用IH设备配置
        public void ApplyIHConfiguration(List<DAForm.IHDeviceCheckBoxConfig> config)
        {
            if (config == null) return;

            try
            {
                foreach (var item in config)
                {
                    CheckBox checkBox = mainForm.FindControlByName<CheckBox>(item.CheckBoxName);
                    if (checkBox != null)
                    {
                        checkBox.Checked = item.IsChecked;

                        // 应用自定义文字
                        if (item.CustomText != null)
                        {
                            UpdateIHCheckBoxText(checkBox, item.CustomText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"应用IH设备配置时出错: {ex.Message}", true);
            }
        }

        // 恢复IH设备默认配置
        public void RestoreDefaultConfiguration()
        {
            try
            {
                int restoredCount = 0;

                // 取消所有IH复选框的选中状态并恢复默认文字
                ProcessIHParameters((position, param) =>
                {
                    string checkBoxName = $"chk{position}_{param}";
                    CheckBox checkBox = mainForm.FindControlByName<CheckBox>(checkBoxName);
                    if (checkBox != null)
                    {
                        checkBox.Checked = false;

                        // 恢复到原始文字
                        if (ihCheckboxOriginalTexts.ContainsKey(checkBoxName))
                        {
                            string originalText = ihCheckboxOriginalTexts[checkBoxName];
                            ihCheckboxTexts[checkBoxName] = originalText;
                            checkBox.Text = originalText;
                        }

                        restoredCount++;
                    }
                });
            }
            catch (Exception ex)
            {
                LogMessage($"恢复IH设备默认配置时出错: {ex.Message}", true);
            }
        }

        // 获取所有可用的图表系列信息
        public List<DAForm.ChartSeriesInfo> GetAvailableSeries()
        {
            var seriesList = new List<DAForm.ChartSeriesInfo>();
            ProcessIHParameters((position, param) =>
            {
                string checkBoxName = $"chk{position}_{param}";
                CheckBox checkBox = mainForm.FindControlByName<CheckBox>(checkBoxName);
                if (checkBox != null)
                {
                    string displayText = ihCheckboxTexts.ContainsKey(checkBoxName) ?
                                         ihCheckboxTexts[checkBoxName] : checkBox.Text;
                    string seriesName = $"{position}_{displayText}";

                    seriesList.Add(new DAForm.ChartSeriesInfo
                    {
                        SeriesName = seriesName,
                        DisplayName = displayText,
                        UniqueID = checkBoxName,
                        AxisType = ChartManager.GetAxisTypeForParameter(param)
                    });
                }
            });
            return seriesList;
        }

        #endregion

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
                    ihDataFreshnessTimer?.Stop();
                    ihDataFreshnessTimer?.Dispose();
                    doubleClickTimer?.Stop();
                    doubleClickTimer?.Dispose();
                }
                disposed = true;
            }
        }
    }
}
