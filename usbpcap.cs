using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Text.RegularExpressions;
using System.Globalization;
using System.ComponentModel;
using System.Drawing;

namespace DA
{
    public class UsbPcap : IDisposable
    {
        private Process captureProcess;
        private RichTextBox logTextBox;          // 通用日志
        private RichTextBox tempLogTextBox;      // 温升仪日志
        private bool isHexMode = false;
        private CancellationTokenSource cancelTokenSource;
        private string usbPcapPath;
        private string deviceAddress;    // 温升仪设备地址
        private bool isRunning = false;
        private int usbBusCount = 0;

        // 添加过滤器配置
        private FilterConfig currentFilter = FilterConfig.Default;

        // 扫描状态变量
        private DateTime scanStartTime;           // 扫描起始时间
        private bool waitingForTimeResponse = false; // 是否等待时间响应
        private bool scanStartTimeSet = false;     // 标记扫描起始时间是否已设置

        // 用于检测新扫描周期的变量
        private double lastTimeOffset = -1;       // 上一个时间偏移量

        // 记录当前使用的设备类型
        private DeviceType currentDeviceType = DeviceType.General;

        // 添加日志消息事件
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;

        public event EventHandler<string> DataReceived;

        // 行级数据
        public event EventHandler<TemperatureRowDataEventArgs> TemperatureRowDataReceived;

        // 定义设备类型枚举
        public enum DeviceType
        {
            General,
            TemperatureDevice
        }

        // 构造函数
        public UsbPcap(RichTextBox logTextBox, RichTextBox tempLogTextBox)
        {
            this.logTextBox = logTextBox;
            this.tempLogTextBox = tempLogTextBox;

            // 初始化缓存的委托对象
            cachedTempLogAction = (dataLine, targetTextBox, deviceType) => AppendLogText(dataLine, targetTextBox, deviceType);
            cachedGeneralLogAction = (dataLine, targetTextBox, deviceType) => AppendLogText(dataLine, targetTextBox, deviceType);
        }

        public void Initialize()
        {
            // 查询USB总线数量
            QueryUsbBuses();
        }

        // 用于发送日志消息的方法
        private void LogMessage(string message, bool isError = false)
        {
            // 触发日志消息事件，让DAForm处理
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        public bool IsRunning
        {
            get { return isRunning; }
        }

        public void SetDisplayMode(bool isHexMode)
        {
            this.isHexMode = isHexMode;
        }

        public void SetUsbPcapPath(string path)
        {
            usbPcapPath = path;
        }

        // 设置设备地址
        public void SetDeviceAddress(string address)
        {
            deviceAddress = address;
        }

        public List<string> GetUsbDevicesList()
        {
            List<string> devices = new List<string>();
            try
            {
                // 使用WMI查询USB设备
                string query = "SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID LIKE 'USB%'";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    ManagementObjectCollection collection = searcher.Get();

                    // 遍历查询结果
                    foreach (ManagementObject device in collection)
                    {
                        try
                        {
                            string deviceName = device["Name"]?.ToString() ?? "未知设备";
                            string deviceId = device["DeviceID"]?.ToString() ?? "";
                            string pnpDeviceId = device["PNPDeviceID"]?.ToString() ?? "";

                            // 格式化设备信息以显示在列表中
                            string deviceInfo = $"{deviceName} ({pnpDeviceId})";
                            devices.Add(deviceInfo);
                        }
                        catch
                        {

                        }
                    }
                }

                // 如果没有找到设备，添加一个提示信息
                if (devices.Count == 0)
                {
                    devices.Add("未找到USB设备");
                }
            }
            catch (Exception ex)
            {
                LogMessage($"获取USB设备列表失败: {ex.Message}", true);
            }
            return devices;
        }

        public void QueryUsbBuses()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_USBController"))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    int busCount = collection.Count;
                    this.usbBusCount = busCount;

                    if (busCount > 0)
                    {
                        LogMessage($"检测到 {busCount} 个USB总线。");

                    }
                    else
                    {
                        LogMessage("未检测到USB总线。");
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"查询USB总线失败: {ex.Message}", true);
            }
        }

        // 开始监听
        public void StartCapture(string selectedDevice)
        {
            if (isRunning)
            {
                return;
            }

            if (string.IsNullOrEmpty(usbPcapPath) || !File.Exists(usbPcapPath))
            {
                LogMessage("请设置正确的USBPcap路径", true);
                return;
            }

            if (string.IsNullOrEmpty(deviceAddress))
            {
                LogMessage("请输入设备地址", true);
                return;
            }

            try
            {
                // 在开始捕获前重置扫描状态
                ResetScanningState();

                // 根据当前过滤器确定设备类型
                if (currentFilter.Name == "DAQ970A" || currentFilter.Name == "34970A")
                {
                    currentDeviceType = DeviceType.TemperatureDevice;
                }
                else
                {
                    currentDeviceType = DeviceType.General;
                }

                string arguments;

                // 根据总线数量选择过滤器
                string filterName;
                if (usbBusCount == 1)
                {
                    filterName = "USBPcap1";
                }
                else
                {
                    filterName = "USBPcap3";
                }

                arguments = $"-d \\\\.\\{filterName} -o - --devices {deviceAddress}";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = usbPcapPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                captureProcess = new Process
                {
                    StartInfo = startInfo,
                    EnableRaisingEvents = true
                };

                cancelTokenSource = new CancellationTokenSource();
                captureProcess.Start();

                isRunning = true;

                // 在后台线程中读取输出
                Task.Run(() =>
                {
                    try
                    {
                        using (StreamReader reader = captureProcess.StandardOutput)
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null && !cancelTokenSource.Token.IsCancellationRequested)
                            {
                                string timestamp = GetCachedTimestamp();
                                string dataLine = "[" + timestamp + "] " + line;

                                // 根据设备类型处理数据
                                switch (currentDeviceType)
                                {
                                    case DeviceType.TemperatureDevice:
                                        // 屏蔽温升仪日志框更新，只处理数据解析
                                        // if (tempLogTextBox.InvokeRequired)
                                        // {
                                        //     tempLogTextBox.Invoke(cachedTempLogAction, dataLine, tempLogTextBox, currentDeviceType);
                                        // }
                                        // else
                                        // {
                                        //     AppendLogText(dataLine, tempLogTextBox, currentDeviceType);
                                        // }

                                        // 数据解析
                                        string filteredText = FilterData(dataLine);
                                        if (!string.IsNullOrEmpty(filteredText))
                                        {
                                            ParseAndDispatchTemperatureData(filteredText);
                                        }
                                        break;

                                    default:
                                        if (logTextBox.InvokeRequired)
                                        {
                                            logTextBox.Invoke(cachedGeneralLogAction, dataLine, logTextBox, currentDeviceType);
                                        }
                                        else
                                        {
                                            AppendLogText(dataLine, logTextBox, currentDeviceType);
                                        }
                                        break;
                                }

                                DataReceived?.Invoke(this, line);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!cancelTokenSource.Token.IsCancellationRequested)
                        {
                            LogMessage($"读取数据时出错: {ex.Message}", true);
                        }
                    }
                    finally
                    {
                        isRunning = false;
                    }
                }, cancelTokenSource.Token);
            }
            catch (Exception ex)
            {
                LogMessage($"启动捕获失败: {ex.Message}", true);
                isRunning = false;
            }
        }

        // 停止捕获
        public void StopCapture()
        {
            try
            {

                if (isRunning && captureProcess != null && !captureProcess.HasExited)
                {
                    cancelTokenSource?.Cancel();

                    if (!captureProcess.WaitForExit(1000))
                    {
                        captureProcess.Kill();
                    }

                    captureProcess.Dispose();
                    captureProcess = null;
                }

                // 清理重用缓冲区
                lock (byteBufferLock)
                {
                    // 重置缓冲区为默认大小以释放内存
                    if (reusableByteBuffer.Length > 4096)
                    {
                        reusableByteBuffer = new byte[4096];
                    }
                }

                // 清理时间戳缓存
                lock (timestampLock)
                {
                    cachedTimestamp = null;
                    lastTimestampUpdate = DateTime.MinValue;
                }

                // 清理温升仪重用对象
                lock (reusableDataLock)
                {
                    reusableEventArgs.RowData = null;
                }

                lock (segmentsLock)
                {
                    reusableSegments.Clear();
                    reusableSegments.TrimExcess(); // 释放多余容量
                }

                lock (reusableChannelDataLock)
                {
                    reusableChannelData.Clear();
                }

                // 重置设备类型
                currentDeviceType = DeviceType.General;

                // 重置所有扫描相关状态变量
                ResetScanningState();

                // LogMessage("监听已停止");
            }
            catch (Exception ex)
            {
                LogMessage($"停止捕获失败: {ex.Message}", true);
            }
            finally
            {
                isRunning = false;
            }
        }

        // 状态重置方法
        private void ResetScanningState()
        {
            try
            {
                scanStartTimeSet = false;
                waitingForTimeResponse = false;
                scanStartTime = DateTime.MinValue;
                lastTimeOffset = -1;


                // LogMessage("扫描状态已重置");
            }
            catch (Exception ex)
            {
                LogMessage($"重置扫描状态时出错: {ex.Message}", true);
            }
        }

        private void AppendLogText(string text, RichTextBox targetTextBox, DeviceType deviceType)
        {
            try
            {
                // 过滤数据，只保留符合规则的数据
                string filteredText = FilterData(text);

                // 如果过滤后没有数据，则不显示
                if (string.IsNullOrEmpty(filteredText))
                {
                    return;
                }

                // 根据显示模式格式化文本
                if (isHexMode)
                {
                    // HEX格式显示
                    string hexText = ConvertToHex(filteredText);
                    targetTextBox.AppendText(hexText + Environment.NewLine);
                }
                else
                {
                    // ASCII显示，过滤不可打印字符
                    string cleanText = FilterNonPrintableChars(filteredText);
                    targetTextBox.AppendText(cleanText + Environment.NewLine);
                }

                // 自动滚动到底部
                targetTextBox.ScrollToCaret();

                // 根据设备类型分发数据到不同的DataGridView
                if (deviceType == DeviceType.TemperatureDevice)
                {
                    ParseAndDispatchTemperatureData(filteredText);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"添加日志文本时出错: {ex.Message}");
            }
        }

        // 多种过滤方法
        private string FilterData(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            string result = input;

            if (currentFilter.Name == "34970A")
            {
                return FilterDataA(input);
            }
            // 应用序列过滤
            else if (currentFilter.Name == "DAQ970A")
            {
                result = FilterDataB(input, currentFilter.Sequence);
            }

            // 默认情况：不过滤，直接返回原始数据
            else
            {
                result = input;
            }

            return result;
        }

        // 34970A的过滤方法
        private string FilterDataA(string input)
        {
            return input;
        }

        // DAQ970A的过滤方法
        private string FilterDataB(string input, byte[] targetSequence)
        {
            if (string.IsNullOrEmpty(input) || targetSequence == null || targetSequence.Length == 0)
                return input;

            try
            {
                // 保留时间戳部分
                string timestamp = string.Empty;
                string dataToFilter = input;

                // 如果输入包含时间戳，则分离时间戳和数据部分
                if (input.Contains("]"))
                {
                    int closeBracketIndex = input.IndexOf("]") + 1;
                    timestamp = input.Substring(0, closeBracketIndex);
                    dataToFilter = input.Substring(closeBracketIndex).Trim();
                }

                // 转换成字节 - 直接使用重用缓冲区避免额外数组创建
                int dataLength = dataToFilter.Length;

                lock (byteBufferLock)
                {
                    // 确保缓冲区足够大
                    if (reusableByteBuffer.Length < dataLength)
                    {
                        reusableByteBuffer = new byte[Math.Max(dataLength * 2, 4096)];
                    }

                    // 用for循环替代foreach，避免迭代器创建
                    for (int i = 0; i < dataLength; i++)
                    {
                        reusableByteBuffer[i] = (byte)dataToFilter[i];
                    }

                    // 查找序列在数据中的位置（直接在重用缓冲区中查找）
                    int sequenceIndex = -1;
                    for (int i = 0; i <= dataLength - targetSequence.Length; i++)
                    {
                        bool match = true;
                        for (int j = 0; j < targetSequence.Length; j++)
                        {
                            if (reusableByteBuffer[i + j] != targetSequence[j])
                            {
                                match = false;
                                break;
                            }
                        }

                        if (match)
                        {
                            sequenceIndex = i;
                            break;
                        }
                    }

                    // 没有找到序列，返回空字符串
                    if (sequenceIndex == -1)
                    {
                        return string.Empty;
                    }

                    // 计算序列后的起始位置
                    int startIndex = sequenceIndex + targetSequence.Length;

                    // 如果序列后没有数据了，返回空字符串
                    if (startIndex >= dataLength)
                    {
                        return string.Empty;
                    }

                    // 提取序列之后的数据
                    string filteredData = dataToFilter.Substring(startIndex);

                    // 返回带时间戳的结果
                    return timestamp + filteredData;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"过滤数据时出错: {ex.Message}");
                return string.Empty;
            }
        }

        // 重用StringBuilder实例
        private readonly StringBuilder filterStringBuilder = new StringBuilder(1024);
        private readonly object filterStringBuilderLock = new object();

        // 过滤掉不可打印字符
        private string FilterNonPrintableChars(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            lock (filterStringBuilderLock)
            {
                filterStringBuilder.Clear();

                // 如果文本包含时间戳，则保留时间戳部分
                if (input.Contains("]"))
                {
                    int closeBracketIndex = input.IndexOf("]") + 1;
                    string timestamp = input.Substring(0, closeBracketIndex);
                    string data = input.Substring(closeBracketIndex);

                    filterStringBuilder.Append(timestamp);

                    // 处理数据部分 - 用for循环替代foreach避免迭代器创建
                    for (int i = 0; i < data.Length; i++)
                    {
                        char c = data[i];
                        // 保留可打印ASCII字符、换行、回车和制表符
                        if ((c >= 32 && c <= 126) || c == '\n' || c == '\r' || c == '\t')
                        {
                            filterStringBuilder.Append(c);
                        }
                        else
                        {
                            // 对于不可打印字符，显示为点或特殊表示
                            filterStringBuilder.Append('.');
                        }
                    }
                }
                else
                {
                    // 直接处理整个字符串
                    for (int i = 0; i < input.Length; i++)
                    {
                        char c = input[i];
                        if ((c >= 32 && c <= 126) || c == '\n' || c == '\r' || c == '\t')
                        {
                            filterStringBuilder.Append(c);
                        }
                        else
                        {
                            filterStringBuilder.Append('.');
                        }
                    }
                }

                return filterStringBuilder.ToString();
            }
        }

        // 十六进制转换
        private readonly StringBuilder hexStringBuilder = new StringBuilder(2048);
        private readonly object hexStringBuilderLock = new object();

        // byte数组缓冲区
        private byte[] reusableByteBuffer = new byte[4096];
        private readonly object byteBufferLock = new object();

        // 时间戳缓存
        private string cachedTimestamp;
        private DateTime lastTimestampUpdate = DateTime.MinValue;
        private readonly object timestampLock = new object();

        // 预编译正则表达式
        private static readonly Regex TimeMatchRegex = new Regex(
            @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\](\d{4},\d{2},\d{2},\d{2},\d{2},\d{2}\.\d{3})",
            RegexOptions.Compiled);
        private static readonly Regex TimeParseRegex = new Regex(
            @"(\d{4}),(\d{2}),(\d{2}),(\d{2}),(\d{2}),(\d{2})\.(\d{3})",
            RegexOptions.Compiled);
        private static readonly Regex DataPointRegex = new Regex(
            @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\]\+\d+",
            RegexOptions.Compiled);
        private static readonly Regex QueryRegex = new Regex(
            @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\]R\?\s\d+",
            RegexOptions.Compiled);
        private static readonly Regex TempDataRegex = new Regex(
            @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\]#\d+(.+)",
            RegexOptions.Compiled);

        // 缓存委托对象
        private Action<string, RichTextBox, DeviceType> cachedTempLogAction;
        private Action<string, RichTextBox, DeviceType> cachedGeneralLogAction;

        // 温升仪数据处理对象
        private readonly TemperatureRowDataEventArgs reusableEventArgs = new TemperatureRowDataEventArgs();
        private readonly object reusableDataLock = new object();

        // 字符串分割缓存数组
        private readonly List<string> reusableSegments = new List<string>(64);
        private readonly object segmentsLock = new object();

        // 重用Dictionary避免高频创建（温度数据处理）
        private readonly Dictionary<int, double> reusableChannelData = new Dictionary<int, double>(1);
        private readonly object reusableChannelDataLock = new object();

        private string ConvertToHex(string input)
        {
            try
            {
                lock (hexStringBuilderLock)
                {
                    hexStringBuilder.Clear();

                    // 保留时间戳部分
                    if (input.Contains("]"))
                    {
                        int closeBracketIndex = input.IndexOf("]") + 1;
                        string timestamp = input.Substring(0, closeBracketIndex);
                        string data = input.Substring(closeBracketIndex);

                        // 对数据部分进行十六进制转换 - 用for循环替代foreach避免迭代器创建
                        for (int i = 0; i < data.Length; i++)
                        {
                            hexStringBuilder.AppendFormat("{0:X2} ", (byte)data[i]);
                        }

                        // 避免字符串插值，减少临时对象创建
                        return timestamp + " " + hexStringBuilder.ToString();
                    }
                    else
                    {
                        // 整个文本进行十六进制转换 - 用for循环替代foreach避免迭代器创建
                        for (int i = 0; i < input.Length; i++)
                        {
                            hexStringBuilder.AppendFormat("{0:X2} ", (byte)input[i]);
                        }
                        return hexStringBuilder.ToString();
                    }
                }
            }
            catch
            {
                return input; // 转换失败时返回原始文本
            }
        }

        // 解析数据，不更新UI
        private void ParseAndDispatchTemperatureData(string data)
        {
            try
            {
                // 检查是否是SYSTem:TIME:SCAN?响应
                if (data.Contains("SYSTem:TIME:SCAN?"))
                {
                    if (!scanStartTimeSet)
                    {
                        waitingForTimeResponse = true;
                    }
                    return;
                }

                // 检查是否是时间戳响应 (格式如: 2025,05,16,15,11,04.153)
                if (!scanStartTimeSet && waitingForTimeResponse)
                {
                    Match timeMatch = TimeMatchRegex.Match(data);
                    if (timeMatch.Success)
                    {
                        // 提取响应中的时间戳
                        string timeStr = timeMatch.Groups[1].Value;
                        Match match = TimeParseRegex.Match(timeStr);
                        if (match.Success)
                        {
                            // 解析时间戳
                            int year = int.Parse(match.Groups[1].Value);
                            int month = int.Parse(match.Groups[2].Value);
                            int day = int.Parse(match.Groups[3].Value);
                            int hour = int.Parse(match.Groups[4].Value);
                            int minute = int.Parse(match.Groups[5].Value);
                            int second = int.Parse(match.Groups[6].Value);
                            int millisecond = int.Parse(match.Groups[7].Value);

                            // 创建DateTime对象
                            DateTime scanTime = new DateTime(year, month, day, hour, minute, second, millisecond);

                            // 保存为扫描起始时间
                            scanStartTime = scanTime;
                            waitingForTimeResponse = false;
                            scanStartTimeSet = true;

                            return;
                        }
                    }
                }

                // 如果扫描起始时间未设置，跳过后续处理
                if (!scanStartTimeSet)
                {
                    return;
                }

                // 检查是否是DATA:POIN?查询或响应（跳过）
                if (data.Contains("DATA:POIN?") || DataPointRegex.IsMatch(data))
                {
                    return;
                }

                // 检查是否是R?查询
                if (QueryRegex.IsMatch(data))
                {
                    return;
                }

                // 检查是否是R?的响应 (温度数据，格式如: #279+2.49891981E+01 C,...)
                Match temperatureDataMatch = TempDataRegex.Match(data);
                if (temperatureDataMatch.Success)
                {
                    // 提取实际数据部分
                    string temperatureData = temperatureDataMatch.Groups[1].Value;

                    // 确保数据包含+和C，这是温度数据的标志
                    if (temperatureData.Contains("+") && temperatureData.Contains("C,"))
                    {
                        // 解析温度数据块
                        ParseTemperatureDataBlock(temperatureData);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"解析数据时出错: {ex.Message}");
                LogMessage($"解析数据时出错: {ex.Message}", true);
            }
        }

        // 解析温度数据块
        private void ParseTemperatureDataBlock(string dataBlock)
        {
            try
            {
                // 使用重用的List避免创建新数组
                lock (segmentsLock)
                {
                    reusableSegments.Clear();

                    // 手动分割字符串避免Split创建新数组
                    int start = 0;
                    for (int i = 0; i <= dataBlock.Length; i++)
                    {
                        if (i == dataBlock.Length || dataBlock[i] == ',')
                        {
                            if (i > start)
                            {
                                reusableSegments.Add(dataBlock.Substring(start, i - start));
                            }
                            start = i + 1;
                        }
                    }

                    // 处理每个温度数据段
                    for (int i = 0; i < reusableSegments.Count; i += 4)
                    {
                        if (i + 3 < reusableSegments.Count)
                        {
                            // 提取温度值
                            string tempValueStr = reusableSegments[i].Trim();
                            int endIndex = tempValueStr.IndexOf("C");
                            if (endIndex > 0)
                            {
                                string tempNumStr = tempValueStr.Substring(0, endIndex).Trim();

                                // 转换科学计数法温度为浮点数
                                if (double.TryParse(tempNumStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double tempValue))
                                {
                                    // 提取时间偏移量
                                    if (double.TryParse(reusableSegments[i + 1], NumberStyles.Float, CultureInfo.InvariantCulture, out double timeOffset))
                                    {
                                        // 提取通道号
                                        if (int.TryParse(reusableSegments[i + 2], out int channelNumber))
                                        {
                                            // 扫描状态管理逻辑
                                            ProcessTemperatureDataPoint(channelNumber, tempValue, timeOffset);
                                        }
                                        else
                                        {
                                            Debug.WriteLine($"无法解析通道号: {reusableSegments[i + 2]}");
                                        }
                                    }
                                    else
                                    {
                                        Debug.WriteLine($"无法解析时间偏移量: {reusableSegments[i + 1]}");
                                    }
                                }
                                else
                                {
                                    Debug.WriteLine($"无法解析温度值: {tempNumStr}");
                                }
                            }
                            else
                            {
                                Debug.WriteLine($"未找到温度单位C: {tempValueStr}");
                            }
                        }
                        else
                        {
                            Debug.WriteLine("数据段不完整，无法解析");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"解析温度数据块时出错: {ex.Message}");
                LogMessage($"解析温度数据块时出错: {ex.Message}", true);
            }
        }

        // 温度数据点处理
        private void ProcessTemperatureDataPoint(int channelNumber, double temperature, double timeOffset)
        {
            try
            {
                // 数据有效性验证：检查是否为无穷大、非数字或超出合理范围
                if (double.IsInfinity(temperature) || double.IsNaN(temperature) || Math.Abs(temperature) > 1E+30)
                {
                    return; // 丢弃无效数据
                }

                // 检测新扫描周期：如果时间偏移量明显小于上一次，说明开始了新的扫描周期
                if (lastTimeOffset > 0 && timeOffset < lastTimeOffset && (lastTimeOffset - timeOffset) > 5.0)
                {
                    // 更新扫描起始时间为当前时间减去偏移量
                    scanStartTime = DateTime.Now.AddSeconds(-timeOffset);
                }

                // 更新时间偏移量记录
                lastTimeOffset = timeOffset;

                DateTime dataTime = scanStartTime.AddSeconds(timeOffset);

                // 使用重用的Dictionary避免高频创建
                lock (reusableChannelDataLock)
                {
                    reusableChannelData.Clear();
                    reusableChannelData[channelNumber] = temperature;

                    // 重用EventArgs对象，但填充新的数据
                    lock (reusableDataLock)
                    {
                        reusableEventArgs.LastUpdateTime = dataTime;
                        reusableEventArgs.RowData = reusableChannelData;
                        TemperatureRowDataReceived?.Invoke(this, reusableEventArgs);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"处理温度数据点时出错: {ex.Message}");
                LogMessage($"处理温度数据点时出错: {ex.Message}", true);
            }
        }

        public void ClearLogs()
        {
            try
            {
                // 清除通用日志
                if (logTextBox.InvokeRequired)
                {
                    logTextBox.Invoke(new Action(() => logTextBox.Clear()));
                }
                else
                {
                    logTextBox.Clear();
                }

                // 清除温升仪日志
                // if (tempLogTextBox.InvokeRequired)
                // {
                //     tempLogTextBox.Invoke(new Action(() => tempLogTextBox.Clear()));
                // }
                // else
                // {
                //     tempLogTextBox.Clear();
                // }

                // 重置扫描相关状态
                ResetScanningState();

                LogMessage("日志和数据已清除");
            }
            catch (Exception ex)
            {
                LogMessage($"清除日志失败: {ex.Message}", true);
            }
        }

        // 过滤器配置类
        public class FilterConfig
        {
            public string Name { get; set; }                    // 过滤器名称
            public byte[] Sequence { get; set; }                // 过滤序列
            public bool UseSequenceFilter { get; set; } = false; // 是否使用序列过滤

            // 默认不过滤
            public static FilterConfig Default => new FilterConfig
            {
                Name = "默认",
                UseSequenceFilter = false,
            };
        }

        // 设置过滤器配置
        public void SetFilter(FilterConfig filter)
        {
            currentFilter = filter;
        }

        // 获取缓存的时间戳
        private string GetCachedTimestamp()
        {
            lock (timestampLock)
            {
                var now = DateTime.Now;
                // 只有当时间变化超过10ms时才重新格式化
                if ((now - lastTimestampUpdate).TotalMilliseconds > 10)
                {
                    cachedTimestamp = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    lastTimestampUpdate = now;
                }
                return cachedTimestamp;
            }
        }

        private bool disposed;

        // 释放资源
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
                    StopCapture();
                }

                disposed = true;
            }
        }

        // 析构函数
        ~UsbPcap()
        {
            Dispose(false);
        }
    }

    // 日志消息事件参数类
    public class LogMessageEventArgs : EventArgs
    {
        public string Message { get; }
        public bool IsError { get; }

        public LogMessageEventArgs(string message, bool isError = false)
        {
            Message = message;
            IsError = isError;
        }
    }

    // 温升仪数据事件参数类
    public class TemperatureRowDataEventArgs : EventArgs
    {
        public DateTime LastUpdateTime { get; set; }             // 最后更新时间
        public Dictionary<int, double> RowData { get; set; }     // 所有通道数据：通道号 -> 温度值

        public TemperatureRowDataEventArgs()
        {
            RowData = new Dictionary<int, double>();
        }
    }

    // 温升仪控件管理类
    public class TemperaturePanelManager : IDisposable
    {
        #region 私有字段

        private readonly Form parentForm;
        private readonly ChartManager chartManager;

        // 温升仪复选框自定义文字存储字典
        private readonly Dictionary<string, string> temperatureChannelTexts = new Dictionary<string, string>();

        // 温升仪复选框控件缓存字典
        private readonly Dictionary<string, CheckBox> temperatureCheckBoxCache = new Dictionary<string, CheckBox>();

        // 双击检测相关
        private System.Windows.Forms.Timer doubleClickTimer;
        private CheckBox lastClickedCheckBox;
        private DateTime lastClickTime = DateTime.MinValue;

        // 支持的通道范围
        private static readonly int[] SupportedChannels = {
            101, 102, 103, 104, 105, 106, 107, 108, 109, 110,
            111, 112, 113, 114, 115, 116, 117, 118, 119, 120,
            201, 202, 203, 204, 205, 206, 207, 208, 209, 210,
            211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
            301, 302, 303, 304, 305, 306, 307, 308, 309, 310,
            311, 312, 313, 314, 315, 316, 317, 318, 319, 320
        };

        // 全选复选框列表
        private static readonly string[] SelectAllCheckboxes = { "chkChannel1", "chkChannel2", "chkChannel3" };

        private bool disposed = false;

        #endregion

        #region 事件定义

        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event Action NotifyTreeViewRefresh;
        #endregion

        #region 构造函数

        public TemperaturePanelManager(Form parentForm, ChartManager chartManager)
        {
            this.parentForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));
            this.chartManager = chartManager;

            InitializeDoubleClickTimer();
        }

        #endregion

        #region 初始化方法

        // 初始化温升仪复选框功能
        public void InitializeTemperatureCheckboxes()
        {
            try
            {
                foreach (int channel in SupportedChannels)
                {
                    string checkBoxName = $"chkChannel{channel}";
                    CheckBox checkBox = FindControlByName<CheckBox>(checkBoxName);
                    if (checkBox != null)
                    {
                        // 初始化自定义文字字典，默认使用原文字
                        temperatureChannelTexts[checkBoxName] = checkBox.Text;

                        // 建立控件缓存
                        temperatureCheckBoxCache[checkBoxName] = checkBox;

                        // 绑定事件处理程序
                        checkBox.MouseClick += CheckBox_MouseClick;
                        checkBox.CheckedChanged += TempCheckBox_CheckedChanged;
                    }
                }

                // 初始化全选复选框功能
                InitializeTemperatureSelectAllCheckboxes();
            }
            catch (Exception ex)
            {
                LogMessage($"初始化温升仪复选框时出错: {ex.Message}", true);
            }
        }

        // 初始化温升仪全选复选框功能
        private void InitializeTemperatureSelectAllCheckboxes()
        {
            try
            {
                foreach (string checkboxName in SelectAllCheckboxes)
                {
                    CheckBox selectAllCheckBox = FindControlByName<CheckBox>(checkboxName);
                    if (selectAllCheckBox != null)
                    {
                        // 绑定全选复选框的事件
                        selectAllCheckBox.CheckedChanged += TempSelectAllCheckBox_CheckedChanged;

                        // 初始化自定义文字字典
                        temperatureChannelTexts[checkboxName] = selectAllCheckBox.Text;

                        selectAllCheckBox.MouseClick += CheckBox_MouseClick;
                        selectAllCheckBox.CheckedChanged += TempCheckBox_CheckedChanged;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"初始化温升仪全选复选框时出错: {ex.Message}", true);
            }
        }

        // 初始化双击检测计时器
        private void InitializeDoubleClickTimer()
        {
            doubleClickTimer = new System.Windows.Forms.Timer();
            doubleClickTimer.Interval = SystemInformation.DoubleClickTime;
            doubleClickTimer.Tick += DoubleClickTimer_Tick;
        }

        #endregion

        #region 复选框事件处理

        // 温升仪全选复选框状态改变事件
        private void TempSelectAllCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox selectAllCheckBox = sender as CheckBox;
                if (selectAllCheckBox == null) return;

                // 获取卡号
                int cardNumber = GetCardNumberFromCheckboxName(selectAllCheckBox.Name);
                if (cardNumber == 0) return;

                // 批量设置对应卡的所有通道复选框
                bool isChecked = selectAllCheckBox.Checked;
                for (int i = 1; i <= 20; i++)
                {
                    int channelNumber = cardNumber * 100 + i;
                    string channelCheckBoxName = $"chkChannel{channelNumber}";
                    CheckBox channelCheckBox = FindControlByName<CheckBox>(channelCheckBoxName);
                    if (channelCheckBox != null)
                    {
                        channelCheckBox.Checked = isChecked;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理温升仪全选复选框时出错: {ex.Message}", true);
            }
        }

        // 温升仪复选框状态改变事件
        private void TempCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox == null) return;

                // 排除全选复选框
                if (IsSelectAllCheckbox(checkBox.Name))
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                LogMessage($"处理温升仪复选框状态改变时出错: {ex.Message}", true);
            }
        }

        // 复选框鼠标点击事件 - 用于双击检测
        private void CheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                CheckBox checkBox = sender as CheckBox;
                if (checkBox == null) return;

                // 只处理左键点击
                if (e.Button != MouseButtons.Left) return;

                DateTime now = DateTime.Now;

                if (lastClickedCheckBox == checkBox &&
                    (now - lastClickTime).TotalMilliseconds <= SystemInformation.DoubleClickTime)
                {
                    // 检测到双击
                    doubleClickTimer.Stop();
                    lastClickedCheckBox = null;

                    // 调用编辑功能
                    EditCheckBoxText(checkBox);
                }
                else
                {
                    // 第一次点击
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

        // 双击计时器超时事件
        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            doubleClickTimer.Stop();
            lastClickedCheckBox = null;
        }

        #endregion

        #region 文本编辑功能

        // 编辑复选框文本
        private void EditCheckBoxText(CheckBox checkBox)
        {
            try
            {
                string title = "编辑通道名称";
                string prompt = "请输入新的通道名称:";
                string currentText = temperatureChannelTexts.ContainsKey(checkBox.Name) ?
                                   temperatureChannelTexts[checkBox.Name] : checkBox.Text;

                using (Form inputForm = new Form())
                {
                    inputForm.Text = title;
                    inputForm.Size = new Size(300, 150);
                    inputForm.StartPosition = FormStartPosition.CenterParent;
                    inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    inputForm.MaximizeBox = false;
                    inputForm.MinimizeBox = false;

                    Label label = new Label();
                    label.Text = prompt;
                    label.Location = new Point(10, 10);
                    label.AutoSize = true;

                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(10, 40);
                    textBox.Size = new Size(265, 23);
                    textBox.Text = currentText;

                    Button okButton = new Button();
                    okButton.Text = "确定";
                    okButton.DialogResult = DialogResult.OK;
                    okButton.Location = new Point(120, 70);

                    Button cancelButton = new Button();
                    cancelButton.Text = "取消";
                    cancelButton.DialogResult = DialogResult.Cancel;
                    cancelButton.Location = new Point(200, 70);

                    // 添加控件到表单
                    inputForm.Controls.Add(label);
                    inputForm.Controls.Add(textBox);
                    inputForm.Controls.Add(okButton);
                    inputForm.Controls.Add(cancelButton);

                    inputForm.AcceptButton = okButton;
                    inputForm.CancelButton = cancelButton;

                    // 显示对话框并处理结果
                    if (inputForm.ShowDialog(parentForm) == DialogResult.OK)
                    {
                        string newText = textBox.Text.Trim();
                        if (!string.IsNullOrEmpty(newText))
                        {
                            UpdateCheckBoxText(checkBox, newText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"编辑复选框文字时出错: {ex.Message}", true);
            }
        }

        // 更新复选框文本
        private void UpdateCheckBoxText(CheckBox checkBox, string newText)
        {
            try
            {
                string oldSeriesName = temperatureChannelTexts.ContainsKey(checkBox.Name) ?
                                     temperatureChannelTexts[checkBox.Name] : checkBox.Text;

                temperatureChannelTexts[checkBox.Name] = newText;
                checkBox.Text = newText;

                // 更新图表曲线名称
                if (chartManager != null)
                {
                    chartManager.RenameSeries(oldSeriesName, newText);
                }

                // 通知主窗体刷新TreeView
                NotifyTreeViewRefresh?.Invoke();
            }
            catch (Exception ex)
            {
                LogMessage($"更新复选框文字时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region 数据访问和状态管理

        // 更新通道文本框显示
        public void UpdateChannelTextBox(int channelNumber, double temperature)
        {
            try
            {
                string textBoxName = $"txtChannel{channelNumber}";
                TextBox textBox = FindControlByName<TextBox>(textBoxName);
                if (textBox != null)
                {
                    textBox.Text = temperature.ToString("F2");
                }

                // 更新图表数据
                UpdateChartForTemperatureChannel(channelNumber, temperature);
            }
            catch (Exception ex)
            {
                LogMessage($"更新通道{channelNumber}文本框时出错: {ex.Message}", true);
            }
        }

        // 更新温升仪通道的图表数据
        private void UpdateChartForTemperatureChannel(int channelNumber, double temperature)
        {
            try
            {
                if (chartManager == null) return;

                // 排除全选复选框
                if (channelNumber >= 1 && channelNumber <= 3)
                {
                    return;
                }

                string checkBoxName = $"chkChannel{channelNumber}";

                // 勾选时才绘制曲线
                CheckBox checkBox = FindControlByName<CheckBox>(checkBoxName);
                if (checkBox == null || !checkBox.Checked)
                {
                    return;
                }

                string seriesName = temperatureChannelTexts.ContainsKey(checkBoxName) ?
                                  temperatureChannelTexts[checkBoxName] : $"通道{channelNumber}";

                // 绘制曲线
                chartManager.AddOrUpdateData(seriesName, DateTime.Now, temperature, ChartAxisType.Primary);
            }
            catch (Exception ex)
            {
                LogMessage($"更新通道{channelNumber}图表数据时出错: {ex.Message}", true);
            }
        }

        // 清除温升仪通道文本框的内容
        public void ClearTemperatureChannelTextBoxes()
        {
            try
            {
                foreach (int channel in SupportedChannels)
                {
                    string textBoxName = $"txtChannel{channel}";
                    TextBox textBox = FindControlByName<TextBox>(textBoxName);
                    if (textBox != null)
                    {
                        textBox.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"清除温升仪通道文本框时出错: {ex.Message}", true);
            }
        }

        // 获取所有选中的温升仪通道
        public List<string> GetSelectedTemperatureChannels()
        {
            List<string> selectedChannels = new List<string>();

            foreach (int channel in SupportedChannels)
            {
                string checkBoxName = $"chkChannel{channel}";
                CheckBox checkBox = FindControlByName<CheckBox>(checkBoxName);
                if (checkBox != null && checkBox.Checked)
                {
                    // 使用自定义名称，如果没有则使用原始通道号
                    string displayText = temperatureChannelTexts.ContainsKey(checkBoxName) ?
                                        temperatureChannelTexts[checkBoxName] : $"{channel}";
                    selectedChannels.Add(displayText);
                }
            }

            return selectedChannels;
        }

        // 根据显示名称获取对应的数据库列名
        public string GetDbColumnNameForDisplay(string displayName)
        {
            foreach (int channel in SupportedChannels)
            {
                string checkBoxName = $"chkChannel{channel}";
                if (temperatureChannelTexts.ContainsKey(checkBoxName) &&
                    temperatureChannelTexts[checkBoxName] == displayName)
                {
                    // 跳过全选复选框
                    if (channel >= 1 && channel <= 3)
                    {
                        return displayName;
                    }
                    return $"Channel{channel}";
                }

                // 如果显示名称就是通道号
                if (displayName == channel.ToString())
                {
                    // 跳过全选复选框
                    if (channel >= 1 && channel <= 3)
                    {
                        return displayName;
                    }
                    return $"Channel{channel}";
                }
            }

            // 没找到，返回原显示名称
            return displayName;
        }

        // 获取温升仪通道的自定义文字
        public string GetTemperatureChannelCustomText(string checkBoxName)
        {
            try
            {
                if (temperatureChannelTexts.ContainsKey(checkBoxName))
                {
                    return temperatureChannelTexts[checkBoxName];
                }
                else
                {
                    return ""; // 没有找到时返回空字符串
                }
            }
            catch (Exception ex)
            {
                LogMessage($"获取通道自定义文字时出错: {ex.Message}", true);
                return "";
            }
        }

        // 获取温升仪通道的温度文本值
        public string GetChannelTemperatureText(int channelNumber)
        {
            try
            {
                string textBoxName = $"txtChannel{channelNumber}";
                TextBox textBox = FindControlByName<TextBox>(textBoxName);
                return textBox != null ? textBox.Text : "0";
            }
            catch (Exception ex)
            {
                LogMessage($"获取通道{channelNumber}温度值时出错: {ex.Message}", true);
                return "0";
            }
        }

        // 检查温升仪通道复选框是否被勾选
        public bool IsChannelCheckBoxChecked(string checkBoxName)
        {
            try
            {
                return temperatureCheckBoxCache.ContainsKey(checkBoxName) &&
                       temperatureCheckBoxCache[checkBoxName].Checked;
            }
            catch (Exception ex)
            {
                LogMessage($"检查通道复选框状态时出错: {ex.Message}", true);
                return false;
            }
        }

        #endregion

        #region 辅助方法

        // 通用控件查找方法
        private T FindControlByName<T>(string controlName) where T : Control
        {
            try
            {
                Control[] controls = parentForm.Controls.Find(controlName, true);
                return controls.FirstOrDefault() as T;
            }
            catch (Exception ex)
            {
                LogMessage($"查找控件 {controlName} 时出错: {ex.Message}", true);
                return null;
            }
        }

        // 根据复选框名称获取卡号
        private int GetCardNumberFromCheckboxName(string checkboxName)
        {
            switch (checkboxName)
            {
                case "chkChannel1":
                    return 1;
                case "chkChannel2":
                    return 2;
                case "chkChannel3":
                    return 3;
                default:
                    return 0;
            }
        }

        // 判断是否为全选复选框
        private bool IsSelectAllCheckbox(string checkboxName)
        {
            return checkboxName == "chkChannel1" || checkboxName == "chkChannel2" || checkboxName == "chkChannel3";
        }

        // 发送日志消息
        private void LogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        #endregion

        #region 配置保存和加载

        // 获取温升仪配置
        public List<DAForm.TemperatureChannelConfig> GetTemperatureConfiguration()
        {
            var config = new List<DAForm.TemperatureChannelConfig>();

            try
            {
                // 保存所有支持通道的配置
                foreach (int channel in SupportedChannels)
                {
                    string checkBoxName = $"chkChannel{channel}";
                    CheckBox checkBox = FindControlByName<CheckBox>(checkBoxName);
                    if (checkBox != null)
                    {
                        config.Add(new DAForm.TemperatureChannelConfig
                        {
                            CheckBoxName = checkBoxName,
                            IsChecked = checkBox.Checked,
                            CustomText = temperatureChannelTexts.ContainsKey(checkBoxName) ?
                                        temperatureChannelTexts[checkBoxName] : checkBox.Text
                        });
                    }
                }

                // 保存全选复选框的配置
                foreach (string checkboxName in SelectAllCheckboxes)
                {
                    CheckBox selectAllCheckBox = FindControlByName<CheckBox>(checkboxName);
                    if (selectAllCheckBox != null)
                    {
                        config.Add(new DAForm.TemperatureChannelConfig
                        {
                            CheckBoxName = checkboxName,
                            IsChecked = selectAllCheckBox.Checked,
                            CustomText = temperatureChannelTexts.ContainsKey(checkboxName) ?
                                        temperatureChannelTexts[checkboxName] : selectAllCheckBox.Text
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"获取温升仪配置时出错: {ex.Message}", true);
            }

            return config;
        }

        // 应用温升仪配置
        public void ApplyTemperatureConfiguration(List<DAForm.TemperatureChannelConfig> config)
        {
            if (config == null) return;

            try
            {
                foreach (var channelConfig in config)
                {
                    CheckBox checkBox = FindControlByName<CheckBox>(channelConfig.CheckBoxName);
                    if (checkBox != null)
                    {
                        // 应用复选框状态
                        checkBox.Checked = channelConfig.IsChecked;

                        // 应用自定义文字
                        if (channelConfig.CustomText != null)
                        {
                            UpdateCheckBoxText(checkBox, channelConfig.CustomText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"应用温升仪配置时出错: {ex.Message}", true);
            }
        }

        // 恢复温升仪默认配置
        public void RestoreDefaultConfiguration()
        {
            try
            {
                int restoredCount = 0;

                // 恢复所有支持通道的默认状态
                foreach (int channel in SupportedChannels)
                {
                    string checkBoxName = $"chkChannel{channel}";
                    CheckBox checkBox = FindControlByName<CheckBox>(checkBoxName);
                    if (checkBox != null)
                    {
                        // 取消选中状态
                        checkBox.Checked = false;

                        // 恢复默认文字（通道号）
                        string defaultText = $"{channel}";
                        temperatureChannelTexts[checkBoxName] = defaultText;
                        checkBox.Text = defaultText;

                        restoredCount++;
                    }
                }

                // 恢复全选复选框的默认状态
                foreach (string checkboxName in SelectAllCheckboxes)
                {
                    CheckBox selectAllCheckBox = FindControlByName<CheckBox>(checkboxName);
                    if (selectAllCheckBox != null)
                    {
                        selectAllCheckBox.Checked = false;

                        // 恢复默认文字
                        string defaultText = "";

                        if (!string.IsNullOrEmpty(defaultText))
                        {
                            temperatureChannelTexts[checkboxName] = defaultText;
                            selectAllCheckBox.Text = defaultText;
                        }

                        restoredCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"恢复温升仪默认配置时出错: {ex.Message}", true);
            }
        }

        // 获取所有可用的图表系列信息
        public List<DAForm.ChartSeriesInfo> GetAvailableSeries()
        {
            var seriesList = new List<DAForm.ChartSeriesInfo>();
            foreach (int channel in SupportedChannels)
            {
                string checkBoxName = $"chkChannel{channel}";
                CheckBox checkBox = FindControlByName<CheckBox>(checkBoxName);
                if (checkBox != null)
                {
                    string seriesName = temperatureChannelTexts.ContainsKey(checkBoxName) ?
                                        temperatureChannelTexts[checkBoxName] : checkBox.Text;

                    seriesList.Add(new DAForm.ChartSeriesInfo
                    {
                        SeriesName = seriesName,
                        DisplayName = seriesName,
                        UniqueID = checkBoxName,
                        AxisType = DA.ChartAxisType.Primary
                    });
                }
            }
            return seriesList;
        }

        #endregion

        #region 资源清理

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
                    doubleClickTimer?.Stop();
                    doubleClickTimer?.Dispose();

                    // 清理事件处理程序
                    foreach (var checkBox in temperatureCheckBoxCache.Values)
                    {
                        if (checkBox != null)
                        {
                            checkBox.MouseClick -= CheckBox_MouseClick;
                            checkBox.CheckedChanged -= TempCheckBox_CheckedChanged;
                        }
                    }

                    // 清理全选复选框事件
                    foreach (string checkboxName in SelectAllCheckboxes)
                    {
                        CheckBox selectAllCheckBox = FindControlByName<CheckBox>(checkboxName);
                        if (selectAllCheckBox != null)
                        {
                            selectAllCheckBox.CheckedChanged -= TempSelectAllCheckBox_CheckedChanged;
                            selectAllCheckBox.MouseClick -= CheckBox_MouseClick;
                            selectAllCheckBox.CheckedChanged -= TempCheckBox_CheckedChanged;
                        }
                    }

                    temperatureChannelTexts.Clear();
                    temperatureCheckBoxCache.Clear();
                }

                disposed = true;
            }
        }

        ~TemperaturePanelManager()
        {
            Dispose(false);
        }

        #endregion
    }
}