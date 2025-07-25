using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace DA
{
    // 上报模块串口通讯类
    public class UartProcessSmartMonitor
    {
        #region 协议常量定义

        // Debug模式
        private bool debugMode = false;
        private string debugFileName = null;

        // 通讯协议常量
        private const int PROCMD_INDEX = 9;                     // 命令索引位置

        // 温升仪属性ID
        private const byte ATTRID_NAME_01 = 0x01;               // 名称
        private const byte ATTRID_VALUE_02 = 0x02;              // 数值

        // 特殊查询功能ID
        private const byte FUNID_QUERYACTIVE = 0x02;            // 查询活动通道功能ID列表
        private const byte ATTRID_ACTIVELIST = 0x00;            // 活动通道列表属性ID

        // 协议限制
        private const int MAX_RX_BUFFER_SIZE = 128;             // 接收缓冲区最大长度

        #endregion

        #region 私有字段

        private SerialPort serialPort;
        private bool isConnected = false;
        private string portName;
        private int baudRate;

        // 接收缓冲区
        private byte[] rxBuffer = new byte[MAX_RX_BUFFER_SIZE];
        private int rxIndex = 0;
        private int rxDataLength = 0;

        // 从主类获取温升仪数据
        private DAForm parentForm;

        // 自动上报定时器
        private System.Threading.Timer autoReportTimer;

        #endregion

        #region 事件定义

        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event EventHandler<RawDataEventArgs> RawDataReceived;

        #endregion

        #region 构造函数

        public UartProcessSmartMonitor(DAForm form)
        {
            parentForm = form;
        }

        #endregion

        #region 公共方法
        // 连接串口
        public bool Connect(string port, int baud = 9600)
        {
            try
            {
                if (isConnected)
                {
                    return false;
                }

                portName = port;
                baudRate = baud;

                serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
                serialPort.Handshake = Handshake.None;
                serialPort.ReadTimeout = 1000;
                serialPort.WriteTimeout = 1000;
                serialPort.DataReceived += SerialPort_DataReceived;
                serialPort.Open();
                isConnected = true;

                // 启动自动上报定时器
                autoReportTimer = new System.Threading.Timer(AutoReportActiveChannels, null, 1000, 1000);

                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"上报模块串口连接失败: {ex.Message}", true);
                return false;
            }
        }

        // 断开串口连接
        public void Disconnect()
        {
            try
            {
                if (debugMode && !string.IsNullOrEmpty(debugFileName))
                {
                    LogMessage($"上报模块Debug数据已导出到: {debugFileName}");
                }

                // 停止自动上报定时器
                autoReportTimer?.Dispose();
                autoReportTimer = null;

                if (serialPort != null)
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }
                    serialPort.DataReceived -= SerialPort_DataReceived;
                    serialPort.Dispose();
                    serialPort = null;
                }

                isConnected = false;
            }
            catch (Exception ex)
            {
                LogMessage($"断开上报模块串口时出错: {ex.Message}", true);
            }
        }

        // 获取连接状态
        public bool IsConnected => isConnected && serialPort?.IsOpen == true;

        // 设置调试模式
        public void SetDebugMode(bool enable)
        {
            debugMode = enable;
            if (enable && string.IsNullOrEmpty(debugFileName))
            {
                debugFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    $"上报模块收发数据记录_{DateTime.Now:yyyyMMddHHmmss}.txt");
            }
            else if (!enable)
            {
                if (!string.IsNullOrEmpty(debugFileName))
                {
                    LogMessage($"上报模块Debug数据已导出到: {debugFileName}");
                }
                debugFileName = null;
            }
        }

        // 手动上传所有活动通道的名称
        public void UploadActiveChannelNames()
        {
            try
            {
                if (!IsConnected)
                {
                    LogMessage("上报模块未连接，无法上传通道名称。", true);
                    return;
                }

                // 获取所有活动通道
                List<int> activeChannels = GetActiveChannelNumbers();

                if (activeChannels.Count == 0)
                {
                    LogMessage("没有活动的通道可供上传名称。", false);
                    return;
                }

                LogMessage($"正在上传 {activeChannels.Count} 个活动通道的名称...", true);

                // 一批最多上报5个通道
                const int maxChannelsPerBatch = 5;
                int totalBatches = (activeChannels.Count + maxChannelsPerBatch - 1) / maxChannelsPerBatch;

                for (int batchIndex = 0; batchIndex < totalBatches; batchIndex++)
                {
                    int startIndex = batchIndex * maxChannelsPerBatch;
                    int endIndex = Math.Min(startIndex + maxChannelsPerBatch, activeChannels.Count);

                    List<int> batchChannels = activeChannels.GetRange(startIndex, endIndex - startIndex);

                    // 构建当前批次的数据包
                    List<byte> response = new List<byte>();
                    response.AddRange(BuildResponseHeader(0x04));
                    response.Add(0xCC);

                    // 为每个通道添加名称属性
                    foreach (int channelNumber in batchChannels)
                    {
                        byte funcId = GetFuncIdByChannelNumber(channelNumber);
                        if (funcId == 0) continue; // 无效通道跳过

                        // 添加通道名称属性
                        response.Add(funcId);
                        response.Add(ATTRID_NAME_01);
                        string channelName = GetChannelNameByNumber(channelNumber);
                        byte[] nameBytes = Encoding.UTF8.GetBytes(channelName);
                        response.Add((byte)nameBytes.Length);
                        response.AddRange(nameBytes);
                    }

                    // 发送当前批次的数据
                    SendResponse(response.ToArray());

                    // 20ms延迟
                    if (batchIndex < totalBatches - 1)
                    {
                        Thread.Sleep(20);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"上传活动通道名称时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region 私有方法 - 串口数据处理

        // 串口数据接收事件
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = sender as SerialPort;
                if (sp == null || !sp.IsOpen) return;

                // 读取所有可用数据
                int bytesToRead = sp.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                int bytesRead = sp.Read(buffer, 0, bytesToRead);

                // 触发原始数据接收事件
                RawDataReceived?.Invoke(this, new RawDataEventArgs(buffer.Take(bytesRead).ToArray(), "RX", DateTime.Now));

                // 保存接收数据到文件
                if (debugMode)
                {
                    SaveDebugData("RX", buffer.Take(bytesRead).ToArray());
                }

                // 处理接收到的每个字节
                for (int i = 0; i < bytesRead; i++)
                {
                    ProcessReceivedByte(buffer[i]);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理串口接收数据时出错: {ex.Message}", true);
            }
        }

        // 处理接收到的单个字节
        private void ProcessReceivedByte(byte data)
        {
            try
            {
                if (rxIndex == 0)
                {
                    // 查找帧头
                    if (data == 0xAA)
                    {
                        rxBuffer[rxIndex++] = data;
                    }
                }
                else if (rxIndex == 1)
                {
                    // 获取数据长度
                    if (data < (MAX_RX_BUFFER_SIZE - 1))
                    {
                        rxBuffer[rxIndex++] = data;
                        rxDataLength = data + 1; // 计算整包数据长度
                    }
                    else
                    {
                        // 长度超过128字节，无效
                        rxIndex = 0;
                        rxDataLength = 0;
                    }
                }
                else
                {
                    // 接收数据内容
                    rxBuffer[rxIndex++] = data;

                    if (rxDataLength > 0 && rxIndex >= rxDataLength)
                    {
                        // 数据接收完成，进行校验和解析
                        if (VerifyChecksum())
                        {
                            ProcessCompletePacket();
                        }
                        else
                        {
                            byte calculatedChecksum = CalculateChecksum(rxBuffer, 1, rxIndex - 2);
                            byte receivedChecksum = rxBuffer[rxIndex - 1];
                            LogMessage($"校验错误 - 计算校验码: 0x{calculatedChecksum:X2}, 接收校验码: 0x{receivedChecksum:X2}", true);
                        }

                        // 重置接收状态
                        rxIndex = 0;
                        rxDataLength = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理接收字节时出错: {ex.Message}", true);
                rxIndex = 0;
                rxDataLength = 0;
            }
        }

        // 校验和验证
        private bool VerifyChecksum()
        {
            if (rxIndex < 2) return false;

            byte calculatedChecksum = CalculateChecksum(rxBuffer, 1, rxIndex - 2);
            byte receivedChecksum = rxBuffer[rxIndex - 1];

            return calculatedChecksum == receivedChecksum;
        }

        // 计算校验和
        private byte CalculateChecksum(byte[] data, int start, int length)
        {
            byte checksum = 0;
            for (int i = start; i < start + length; i++)
            {
                checksum += data[i];
            }
            return (byte)(~checksum + 1);
        }

        // 处理完整的数据包
        private void ProcessCompletePacket()
        {
            try
            {
                if (rxIndex < 10) return; // 最小有效包长度

                byte command = rxBuffer[PROCMD_INDEX];

                if (command == 0x03 || command == 0x04)
                {
                    // 处理查询/上报命令
                    ProcessStatusReportRequest();
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理完整数据包时出错: {ex.Message}", true);
            }
        }

        // 处理状态上报请求
        private void ProcessStatusReportRequest()
        {
            try
            {
                int dataIndex = PROCMD_INDEX + 1;

                if (dataIndex >= rxIndex || rxBuffer[dataIndex] != 0xCC)
                {
                    return;
                }

                dataIndex++;

                // 计算属性数量
                int attributeCount = (rxBuffer[1] - 10) / 2;

                // 构建响应包
                List<byte> response = new List<byte>();

                // 获取请求中的命令ID，用于构建响应包头
                byte requestCommandId = rxBuffer[PROCMD_INDEX];

                // 添加响应包头
                response.AddRange(BuildResponseHeader(requestCommandId));
                response.Add(0XCC);

                // 处理每个属性请求
                for (int i = 0; i < attributeCount && dataIndex + 1 < rxIndex; i++)
                {
                    byte attrFunId = rxBuffer[dataIndex];
                    byte attrId = rxBuffer[dataIndex + 1];

                    byte[] attrResponse = ProcessAttributeRequest(attrFunId, attrId);
                    if (attrResponse != null)
                    {
                        response.AddRange(attrResponse);
                    }

                    dataIndex += 2;
                }

                // 发送响应
                SendResponse(response.ToArray());
            }
            catch (Exception ex)
            {
                LogMessage($"处理状态上报请求时出错: {ex.Message}", true);
            }
        }

        // 构建响应包头
        private byte[] BuildResponseHeader(byte commandId)
        {
            return new byte[]
            {
                0xAA,           // 帧头 [0]
                0,              // 长度 [1]
                0xB9,           // 设备ID [2]
                0,              // 帧同步校验 [3]
                0, 0,           // 保留字节 [4-5]
                0,              // 消息标识 [6]
                0,              // 框架协议版本 [7]
                0x01,           // 家电协议版本 [8]
                commandId,      // 命令ID [9]
            };
        }

        // 处理属性请求
        private byte[] ProcessAttributeRequest(byte attrFuncId, byte attrId)
        {
            try
            {
                List<byte> response = new List<byte>();

                // 查询活动通道列表
                if (attrFuncId == FUNID_QUERYACTIVE)
                {
                    // 回显功能ID和属性ID
                    response.Add(attrFuncId);
                    response.Add(attrId);

                    if (attrId == ATTRID_ACTIVELIST)
                    {
                        // 获取当前勾选通道对应的功能ID列表
                        byte[] activeFuncIds = GetActiveChannelFuncIds();
                        response.Add((byte)activeFuncIds.Length);       // 数据长度
                        response.AddRange(activeFuncIds);               // 功能ID列表
                    }
                    else
                    {
                        LogMessage($"查询活动通道不支持的属性请求: ID=0x{attrId:X2}，仅支持0x00", true);
                        return null;
                    }

                    return response.ToArray();
                }

                // 根据功能ID计算温升仪通道号 (0xB0-0xEB)
                int channelNumber = 0;
                if (attrFuncId >= 0xB0 && attrFuncId <= 0xEB)
                {
                    if (attrFuncId >= 0xB0 && attrFuncId <= 0xC3)
                    {
                        // 卡槽1：通道101-120 (功能ID: 0xB0-0xC3)
                        channelNumber = 101 + (attrFuncId - 0xB0);
                    }
                    else if (attrFuncId >= 0xC4 && attrFuncId <= 0xD7)
                    {
                        // 卡槽2：通道201-220 (功能ID: 0xC4-0xD7)
                        channelNumber = 201 + (attrFuncId - 0xC4);
                    }
                    else
                    {
                        // 卡槽3：通道301-320 (功能ID: 0xD8-0xEB)
                        channelNumber = 301 + (attrFuncId - 0xD8);
                    }
                }
                else
                {
                    // 非温升仪通道功能ID，直接返回null
                    LogMessage($"不支持的功能ID请求: FuncID=0x{attrFuncId:X2}", true);
                    return null;
                }

                // 检查通道是否为活动通道
                string checkBoxName = $"chkChannel{channelNumber}";
                if (!parentForm.IsChannelCheckBoxChecked(checkBoxName))
                {
                    return null; // 非活动通道不回复
                }

                // 回显功能ID和属性ID
                response.Add(attrFuncId);
                response.Add(attrId);

                // 根据属性ID分别处理请求
                if (attrId == ATTRID_NAME_01)
                {
                    // 返回通道名称（字符串类型charN，N为字符串长度）
                    string channelName = GetChannelNameByNumber(channelNumber);
                    byte[] nameBytes = Encoding.UTF8.GetBytes(channelName);
                    response.Add((byte)nameBytes.Length);       // 数据长度
                    response.AddRange(nameBytes);               // 字符串内容
                }
                else if (attrId == ATTRID_VALUE_02)
                {
                    // 返回通道温度数值
                    ushort tempValue = GetChannelTemperatureByNumber(channelNumber);
                    response.Add(2);                                    // 数据长度（2字节）
                    response.Add((byte)(tempValue & 0xFF));             // 低字节
                    response.Add((byte)((tempValue >> 8) & 0xFF));      // 高字节
                }
                else
                {
                    LogMessage($"不支持的属性请求: ID=0x{attrId:X2}, FuncID=0x{attrFuncId:X2}", true);
                    return null;
                }

                return response.ToArray();
            }
            catch (Exception ex)
            {
                LogMessage($"处理属性请求时出错: {ex.Message}", true);
                return null;
            }
        }

        // 根据通道号获取通道名称
        private string GetChannelNameByNumber(int channelNumber)
        {
            try
            {
                if (channelNumber <= 0)
                {
                    return "Unknown";
                }

                if (parentForm != null)
                {
                    // 获取通道的自定义名称
                    string checkBoxName = $"chkChannel{channelNumber}";
                    var customText = parentForm.GetTemperatureChannelCustomText(checkBoxName);

                    if (!string.IsNullOrEmpty(customText))
                    {
                        return customText;
                    }
                }

                // 如果没有自定义名称，返回默认通道号
                return channelNumber.ToString();
            }
            catch (Exception ex)
            {
                LogMessage($"获取通道名称时出错: {ex.Message}", true);
                return "Unknown";
            }
        }

        // 根据通道号获取通道温度数值
        private ushort GetChannelTemperatureByNumber(int channelNumber)
        {
            try
            {
                if (channelNumber <= 0)
                {
                    return 0;
                }

                if (parentForm != null)
                {
                    // 从DAForm获取通道的温度值
                    string tempText = parentForm.GetChannelTemperatureText(channelNumber);

                    if (string.IsNullOrEmpty(tempText) || tempText == "0")
                    {
                        return 0;
                    }

                    if (double.TryParse(tempText, out double temperature))
                    {
                        // 发送数值 = 实际温度值 × 10
                        int convertedValue = (int)(temperature * 10);

                        // 确保在ushort范围内
                        if (convertedValue < 0) convertedValue = 0;
                        if (convertedValue > 65535) convertedValue = 65535;

                        return (ushort)convertedValue;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                LogMessage($"获取通道温度值时出错: {ex.Message}", true);
                return 0;
            }
        }

        // 获取当前勾选通道对应的功能ID列表
        private byte[] GetActiveChannelFuncIds()
        {
            try
            {
                List<byte> funcIds = new List<byte>();

                if (parentForm != null)
                {
                    // 检查卡槽1：通道101-120
                    for (int channel = 101; channel <= 120; channel++)
                    {
                        string checkBoxName = $"chkChannel{channel}";
                        if (parentForm.IsChannelCheckBoxChecked(checkBoxName))
                        {
                            byte funcId = (byte)(0xB0 + (channel - 101));
                            funcIds.Add(funcId);
                        }
                    }

                    // 检查卡槽2：通道201-220
                    for (int channel = 201; channel <= 220; channel++)
                    {
                        string checkBoxName = $"chkChannel{channel}";
                        if (parentForm.IsChannelCheckBoxChecked(checkBoxName))
                        {
                            byte funcId = (byte)(0xC4 + (channel - 201));
                            funcIds.Add(funcId);
                        }
                    }

                    // 检查卡槽3：通道301-320
                    for (int channel = 301; channel <= 320; channel++)
                    {
                        string checkBoxName = $"chkChannel{channel}";
                        if (parentForm.IsChannelCheckBoxChecked(checkBoxName))
                        {
                            byte funcId = (byte)(0xD8 + (channel - 301));
                            funcIds.Add(funcId);
                        }
                    }
                }
                return funcIds.ToArray();
            }
            catch (Exception ex)
            {
                LogMessage($"获取活动通道功能ID列表时出错: {ex.Message}", true);
                return new byte[0];
            }
        }

        // 获取所有活动通道号的列表
        private List<int> GetActiveChannelNumbers()
        {
            try
            {
                List<int> channelNumbers = new List<int>();

                if (parentForm != null)
                {
                    // 检查卡槽1：通道101-120
                    for (int channel = 101; channel <= 120; channel++)
                    {
                        string checkBoxName = $"chkChannel{channel}";
                        if (parentForm.IsChannelCheckBoxChecked(checkBoxName))
                        {
                            channelNumbers.Add(channel);
                        }
                    }

                    // 检查卡槽2：通道201-220
                    for (int channel = 201; channel <= 220; channel++)
                    {
                        string checkBoxName = $"chkChannel{channel}";
                        if (parentForm.IsChannelCheckBoxChecked(checkBoxName))
                        {
                            channelNumbers.Add(channel);
                        }
                    }

                    // 检查卡槽3：通道301-320
                    for (int channel = 301; channel <= 320; channel++)
                    {
                        string checkBoxName = $"chkChannel{channel}";
                        if (parentForm.IsChannelCheckBoxChecked(checkBoxName))
                        {
                            channelNumbers.Add(channel);
                        }
                    }
                }
                return channelNumbers;
            }
            catch (Exception ex)
            {
                LogMessage($"获取活动通道号列表时出错: {ex.Message}", true);
                return new List<int>();
            }
        }

        // 根据通道号获取对应的功能ID
        private byte GetFuncIdByChannelNumber(int channelNumber)
        {
            try
            {
                if (channelNumber >= 101 && channelNumber <= 120)
                {
                    // 卡槽1：通道101-120 → 功能ID 0xB0-0xC3
                    return (byte)(0xB0 + (channelNumber - 101));
                }
                else if (channelNumber >= 201 && channelNumber <= 220)
                {
                    // 卡槽2：通道201-220 → 功能ID 0xC4-0xD7
                    return (byte)(0xC4 + (channelNumber - 201));
                }
                else if (channelNumber >= 301 && channelNumber <= 320)
                {
                    // 卡槽3：通道301-320 → 功能ID 0xD8-0xEB
                    return (byte)(0xD8 + (channelNumber - 301));
                }
                else
                {
                    return 0; // 无效通道号
                }
            }
            catch (Exception ex)
            {
                LogMessage($"根据通道号获取功能ID时出错: {ex.Message}", true);
                return 0;
            }
        }

        // 自动上报活动通道列表
        private void AutoReportActiveChannels(object state)
        {
            try
            {
                if (!IsConnected) return;

                // 获取所有活动通道
                List<int> activeChannels = GetActiveChannelNumbers();

                if (activeChannels.Count == 0)
                {
                    return; // 没有活动通道，不发送任何数据
                }

                // 一次最多上报10个通道
                const int maxChannelsPerBatch = 10;
                int totalBatches = (activeChannels.Count + maxChannelsPerBatch - 1) / maxChannelsPerBatch;

                for (int batchIndex = 0; batchIndex < totalBatches; batchIndex++)
                {
                    int startIndex = batchIndex * maxChannelsPerBatch;
                    int endIndex = Math.Min(startIndex + maxChannelsPerBatch, activeChannels.Count);

                    List<int> batchChannels = activeChannels.GetRange(startIndex, endIndex - startIndex);

                    // 构建当前批次的数据包
                    List<byte> response = new List<byte>();
                    response.AddRange(BuildResponseHeader(0x04));
                    response.Add(0XCC);

                    foreach (int channelNumber in batchChannels)
                    {
                        byte funcId = GetFuncIdByChannelNumber(channelNumber);
                        if (funcId == 0) continue; // 无效通道跳过

                        // 添加通道数值属性
                        response.Add(funcId);
                        response.Add(ATTRID_VALUE_02);
                        ushort tempValue = GetChannelTemperatureByNumber(channelNumber);
                        response.Add(2); // 数据长度（2字节）
                        response.Add((byte)(tempValue & 0xFF));         // 低字节
                        response.Add((byte)((tempValue >> 8) & 0xFF));  // 高字节
                    }

                    // 发送当前批次的数据
                    SendResponse(response.ToArray());

                    // 20ms延迟
                    if (batchIndex < totalBatches - 1)
                    {
                        Thread.Sleep(20);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"自动上报活动通道数据时出错: {ex.Message}", true);
            }
        }

        // 发送响应数据
        private void SendResponse(byte[] responseData)
        {
            try
            {
                if (!IsConnected) return;

                // 设置数据长度
                // responseData[1] = (byte)(responseData.Length - 1);
                responseData[1] = (byte)responseData.Length;

                // 计算并添加校验和
                byte checksum = CalculateChecksum(responseData, 1, responseData.Length - 1);

                byte[] completeResponse = new byte[responseData.Length + 1];
                Array.Copy(responseData, completeResponse, responseData.Length);
                completeResponse[completeResponse.Length - 1] = checksum;

                // 发送数据
                serialPort.Write(completeResponse, 0, completeResponse.Length);

                // 触发发送数据事件
                RawDataReceived?.Invoke(this, new RawDataEventArgs(completeResponse, "TX", DateTime.Now));

                // Debug模式下保存发送数据到文件
                if (debugMode)
                {
                    SaveDebugData("TX", completeResponse);
                }
            }

            catch (Exception ex)
            {
                LogMessage($"发送响应数据时出错: {ex.Message}", true);
            }
        }

        // 记录日志消息
        private void LogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        // 保存Debug数据到文件
        private void SaveDebugData(string direction, byte[] data)
        {
            try
            {
                if (string.IsNullOrEmpty(debugFileName))
                {
                    return;
                }

                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                string hexData = BitConverter.ToString(data).Replace("-", " ");
                string logLine = $"[{timestamp}] {direction}: {hexData}{Environment.NewLine}";

                // 保存到文件
                System.IO.File.AppendAllText(debugFileName, logLine);

                // 日志区显示数据
                LogMessage($"上报模块 {direction}: {hexData}");
            }
            catch (Exception ex)
            {
                LogMessage($"保存Debug数据时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region 资源释放

        public void Dispose()
        {
            Disconnect();
        }

        #endregion
    }
}
