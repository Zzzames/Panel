using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Collections.Concurrent;
using System.Windows.Forms.DataVisualization.Charting;


namespace DA
{
    public partial class DAForm : Form
    {
        private UsbPcap usbPcap;
        private VirtualPort virtualPort;
        private IHDevice ihDevice;

        private UartProcessSmartMonitor smartMonitor;
        private SQLiteManager sqliteManager;
        private ChartManager chartManager;
        private DeviceConnectionManager deviceConnectionManager;
        private PowerGridManager powerGridManager;
        private CSVExportManager CSVExportManager;
        private TemperaturePanelManager temperaturePanelManager;
        private IHPanelManager ihPanelManager;

        private List<UsbPcap.FilterConfig> filterConfigs = new List<UsbPcap.FilterConfig>();

        // 同步数据记录
        private Dictionary<string, DeviceDataCache> deviceDataCaches = new Dictionary<string, DeviceDataCache>();
        private readonly object syncDataLock = new object();

        // 数据队列处理机制
        private readonly Queue<DataQueueItem> dataQueue = new Queue<DataQueueItem>();
        private readonly object dataQueueLock = new object();
        private readonly Thread dataProcessingThread;
        private volatile bool isDataProcessingActive = false;
        private readonly AutoResetEvent dataAvailableEvent = new AutoResetEvent(false);
        private readonly ManualResetEvent dataProcessingIdleEvent = new ManualResetEvent(true);
        private volatile bool isSaving = false;

        // 批量UI更新机制
        private System.Windows.Forms.Timer uiUpdateTimer;
        private volatile bool hasPendingUIUpdates = false;
        private readonly object uiUpdateLock = new object();

        // 日志清理配置
        private const int MAX_LOG_LINES = 300;
        private const int CLEANUP_LINES = 100;

        // UI更新队列长度限制配置
        private const int MAX_UI_UPDATE_QUEUE_SIZE = 100;
        private const int UI_QUEUE_KEEP_SIZE = 50; // 清理时保留的数量

        private int recordIntervalSeconds = 1; // 默认1秒间隔

        // UI更新数据队列
        private readonly Queue<UIUpdateItem> uiUpdateQueue = new Queue<UIUpdateItem>();

        // UI更新项
        private class UIUpdateItem
        {
            public string Type { get; set; }
            public DateTime Timestamp { get; set; }
            public Dictionary<string, object> Data { get; set; }
            public List<Dictionary<string, object>> BatchedData { get; set; }
        }

        // 数据队列项
        private class DataQueueItem
        {
            public DateTime OriginalTimestamp { get; set; }
            public string DeviceType { get; set; }
            public Dictionary<string, string> Data { get; set; }
        }

        // 设备数据缓存类
        public class DeviceDataCache
        {
            public DateTime LastUpdateTime { get; set; } = DateTime.MinValue;
            public Dictionary<string, string> LatestValues { get; set; } = new Dictionary<string, string>();
            public bool HasData => LatestValues.Count > 0;
        }

        // 温升仪UI更新批处理
        private System.Windows.Forms.Timer tempUpdateTimer;
        private readonly ConcurrentDictionary<int, double> latestTemperatures = new ConcurrentDictionary<int, double>();
        private volatile bool hasPendingTempUpdates = false;

        // 自动断开计时器
        private System.Windows.Forms.Timer autoDisconnectTimer;

        // 扫描周期检测
        private int lastChannelNumber = -1;
        private DateTime currentScanStartTime = DateTime.MinValue;

        // 双击检测相关（仅用于温升仪复选框）
        private System.Windows.Forms.Timer doubleClickTimer;

        public DAForm()
        {
            InitializeComponent();
            InitializeControls();               // 初始化控件
            InitializeUIUpdateTimer();          // 初始化UI更新定时器
            InitializeTempUpdateTimer();        // 初始化温升仪UI更新定时器

            // 初始化数据处理线程
            dataProcessingThread = new Thread(DataProcessingWorker)
            {
                IsBackground = true,
                Name = "DataProcessingThread"
            };
            isDataProcessingActive = true;
            dataProcessingThread.Start();

            // 初始化自动断开计时器
            autoDisconnectTimer = new System.Windows.Forms.Timer();
            autoDisconnectTimer.Tick += (s, e) => { BtnStop_Click(null, null); autoDisconnectTimer.Stop(); };

            // 初始化双击检测计时器
            doubleClickTimer = new System.Windows.Forms.Timer();
            doubleClickTimer.Interval = SystemInformation.DoubleClickTime;
            doubleClickTimer.Tick += DoubleClickTimer_Tick;

            // 监听自动断开输入框变化
            if (txtAutoDisconnect != null)
                txtAutoDisconnect.TextChanged += TxtAutoDisconnect_TextChanged;

            // 监听Debug模式CheckBox变化
            if (cbDebugMode != null)
                cbDebugMode.CheckedChanged += CbDebugMode_CheckedChanged;

        }

        private void InitializeControls()
        {
            // 初始化UsbPcap实例
            usbPcap = new UsbPcap(LogBox, LogBox_Temp);
            // 订阅UsbPcap的日志消息事件
            usbPcap.LogMessageAdded += UsbPcap_LogMessageAdded;
            // 订阅温升仪行数据事件
            usbPcap.TemperatureRowDataReceived += UsbPcap_TemperatureRowDataReceived;
            usbPcap.Initialize(); // 获取USB总线数量

            // 初始化虚拟串口实例
            virtualPort = new VirtualPort();
            virtualPort.PowerDataReceived += VirtualPort_PowerDataReceived;
            virtualPort.LogMessageAdded += VirtualPort_LogMessageAdded;
            // virtualPort.RawDataReceived += VirtualPort_RawDataReceived;

            // 初始化IH设备实例
            ihDevice = new IHDevice();
            ihDevice.DisplayDataReceived += IHDevice_DisplayDataReceived;
            ihDevice.PowerDataReceived += IHDevice_PowerDataReceived;
            ihDevice.LogMessageAdded += IHDevice_LogMessageAdded;
            // ihDevice.RawDataReceived += IHDevice_RawDataReceived;

            // 初始化上报模块实例
            smartMonitor = new UartProcessSmartMonitor(this);
            smartMonitor.LogMessageAdded += SmartMonitor_LogMessageAdded;

            // 初始化SQLite数据库类
            sqliteManager = new SQLiteManager();
            sqliteManager.LogMessageAdded += SQLiteManager_LogMessageAdded;

            // 初始化设备连接类
            deviceConnectionManager = new DeviceConnectionManager(usbPcap, virtualPort, ihDevice, smartMonitor);
            deviceConnectionManager.LogMessageAdded += (s, e) => LogMessage(e.Message, e.IsError);
            deviceConnectionManager.StatusChanged += (s, status) => { if (statusLabel != null) statusLabel.Text = status; };

            // 注册事件处理程序
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnClear.Click += BtnClear_Click;
            btnData.Click += BtnData_Click;
            btnRefreshPorts.Click += BtnRefreshPorts_Click;
            btnaddress.Click += Btnaddress_Click;
            btnCapture.Click += BtnCapture_Click;
            // rbHex.CheckedChanged += DisplayMode_CheckedChanged;
            // rbAscii.CheckedChanged += DisplayMode_CheckedChanged;

            // 初始化功率仪型号下拉框
            if (cmbPowerDevice != null)
            {
                cmbPowerDevice.Items.AddRange(new string[] { "青智8904F", "致远仪器PV300" });
                cmbPowerDevice.SelectedIndex = 0;
            }

            // 初始化温升仪型号下拉框
            if (cmbTempDevice != null)
            {
                cmbTempDevice.Items.AddRange(new string[] { "DAQ970A", "34970A" });
                cmbTempDevice.SelectedIndex = 0;
            }

            // 注册配置保存和加载按钮事件
            if (btnSaveConfigure != null)
                btnSaveConfigure.Click += BtnSaveConfigure_Click;
            if (btnLoadConfigure != null)
                btnLoadConfigure.Click += BtnLoadConfigure_Click;

            // 注册上传名称按钮事件
            if (btUploadName != null)
                btUploadName.Click += BtUploadName_Click;

            // 初始化图表类
            InitializeChartManager();

            // 初始化功率仪表格管理类
            InitializePowerGridManager();

            // 初始化数据保存管理类
            InitializeCSVExportManager();

            // 初始化温升仪控件管理类
            InitializeTemperaturePanelManager();

            // 初始化IH控件管理类
            InitializeIHPanelManager();

            // 初始化图表系列树状图
            InitializeChartSeriesTreeView();

            // 异步加载耗时的初始化操作
            LoadInitialDataAsync();
        }

        // 异步加载耗时的初始化操作
        private async void LoadInitialDataAsync()
        {
            try
            {
                // 更新状态栏显示加载状态
                if (statusLabel != null)
                {
                    statusLabel.Text = "正在加载设备和配置...";
                }

                // 在后台线程执行耗时操作
                await Task.Run(() =>
                {
                    try
                    {
                        // 清理数据库
                        sqliteManager?.ClearDeviceData();
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"清理数据库时出错: {ex.Message}", true);
                    }
                });
                // 设置默认USBPcap路径
                string defaultPath = sqliteManager?.LoadSetting("USBPcapPath", @"D:\USBPcap\USBPcapCMD.exe") ?? @"D:\USBPcap\USBPcapCMD.exe";
                if (tbUSBPcapPath != null)
                {
                    tbUSBPcapPath.Text = defaultPath;
                }
                usbPcap?.SetUsbPcapPath(defaultPath);

                // 设置默认自动断开时间
                string defaultAutoDisconnectTime = sqliteManager?.LoadSetting("AutoDisconnectTime", "120") ?? "120";
                if (txtAutoDisconnect != null)
                {
                    txtAutoDisconnect.Text = defaultAutoDisconnectTime;
                }

                // 初始化波特率下拉框
                InitializeBaudRateComboBoxes();

                // 初始化数据记录间隔控制
                InitializeRecordInterval();

                // 在后台线程执行设备扫描
                await Task.Run(() =>
                {
                    try
                    {
                        // 获取串口列表
                        string[] ports = SerialPort.GetPortNames();

                        // 获取USB设备列表
                        List<string> usbDevices = usbPcap?.GetUsbDevicesList() ?? new List<string>();

                        // 回到UI线程更新控件
                        this.Invoke(new Action(() =>
                        {
                            try
                            {
                                // 更新串口下拉框
                                UpdatePortComboBoxes(ports);

                                // 更新USB设备下拉框
                                UpdateUsbDeviceComboBox(usbDevices);
                            }
                            catch (Exception ex)
                            {
                                LogMessage($"更新设备列表时出错: {ex.Message}", true);
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"扫描设备时出错: {ex.Message}", true);
                    }
                });

                await Task.Delay(100); // UI渲染后再执行配置载入

                // 初始化温升仪复选框功能
                await Task.Run(() =>
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            temperaturePanelManager?.InitializeTemperatureCheckboxes();
                        }));
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"初始化温升仪复选框时出错: {ex.Message}", true);
                    }
                });

                // 初始化IH设备复选框功能
                await Task.Run(() =>
                {
                    try
                    {
                        this.Invoke(new Action(() =>
                        {
                            ihPanelManager?.Initialize();
                        }));
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"初始化IH设备复选框时出错: {ex.Message}", true);
                    }
                });

                // 异步加载配置（这是优化的关键）
                await LoadLastConfigurationAsync();

                // 恢复开始按钮
                if (btnStart != null)
                {
                    btnStart.Enabled = true;
                }

                // 更新状态栏
                if (statusLabel != null)
                {
                    statusLabel.Text = "就绪";
                }
            }
            catch (Exception ex)
            {
                LogMessage($"异步加载时出错: {ex.Message}", true);

                // 确保开始按钮被恢复
                if (btnStart != null)
                {
                    btnStart.Enabled = true;
                }

                if (statusLabel != null)
                {
                    statusLabel.Text = "加载失败";
                }
            }
        }

        // 更新串口下拉框
        private void UpdatePortComboBoxes(string[] ports)
        {
            try
            {
                var comboBoxes = new ComboBox[] { cmbRealPort, cmbVirtualPort1, Disp_comboBoxPortName, Ctrl_comboBoxPortName, cmbUploadPort };

                foreach (var comboBox in comboBoxes)
                {
                    if (comboBox != null)
                    {
                        // 保存当前选择的值
                        string currentSelection = comboBox.SelectedItem?.ToString();

                        // 清空并重新填充
                        comboBox.Items.Clear();
                        comboBox.Items.Add("");
                        comboBox.Items.AddRange(ports);

                        // 如果之前有选择的值，且该值仍然存在，则恢复选择
                        if (!string.IsNullOrEmpty(currentSelection))
                        {
                            bool portStillExists = ports.Contains(currentSelection);
                            if (portStillExists)
                            {
                                comboBox.SelectedItem = currentSelection;
                            }
                            else
                            {
                                // 端口不存在了，清空选择
                                comboBox.SelectedIndex = -1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"更新串口下拉框时出错: {ex.Message}", true);
            }
        }

        // 更新USB设备下拉框
        private void UpdateUsbDeviceComboBox(List<string> devices)
        {
            try
            {
                if (cmbDAList != null)
                {
                    // 保存当前选择的值
                    string currentSelection = cmbDAList.SelectedItem?.ToString();

                    cmbDAList.Items.Clear();
                    cmbDAList.Items.Add(""); // 添加空选项

                    foreach (string device in devices)
                    {
                        cmbDAList.Items.Add(device);
                    }

                    // 如果之前有选择的值，且该值仍然存在，则恢复选择
                    if (!string.IsNullOrEmpty(currentSelection))
                    {
                        bool deviceStillExists = devices.Contains(currentSelection);
                        if (deviceStillExists)
                        {
                            cmbDAList.SelectedItem = currentSelection;
                        }
                        else
                        {
                            cmbDAList.SelectedIndex = -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"更新USB设备下拉框时出错: {ex.Message}", true);
            }
        }

        private void InitializeBaudRateComboBoxes()
        {
            try
            {
                string[] baudRates = { "4800", "9600", "19200", "38400", "57600", "115200" };

                // 初始化IH显示板波特率
                Disp_comboBoxBaudRate.Items.AddRange(baudRates);
                Disp_comboBoxBaudRate.SelectedItem = "4800";

                // 初始化IH功率板波特率
                Ctrl_comboBoxBaudRate.Items.AddRange(baudRates);
                Ctrl_comboBoxBaudRate.SelectedItem = "4800";

                // 初始化上传模块波特率
                cmbUploadBaudRate.Items.AddRange(baudRates);
                cmbUploadBaudRate.SelectedItem = "9600";
            }
            catch (Exception ex)
            {
                LogMessage($"初始化波特率下拉框时出错: {ex.Message}", true);
            }
        }

        private void InitializeRecordInterval()
        {
            try
            {
                // 初始化记录间隔输入框
                txtRecordInterval.Text = recordIntervalSeconds.ToString();
                txtRecordInterval.TextChanged += TxtRecordInterval_TextChanged;

                // 初始化设备数据库
                InitializeDeviceDataCaches();
            }
            catch (Exception ex)
            {
                LogMessage($"初始化记录间隔控制时出错: {ex.Message}", true);
            }
        }

        // 初始化UI更新定时器
        private void InitializeUIUpdateTimer()
        {
            uiUpdateTimer = new System.Windows.Forms.Timer();
            uiUpdateTimer.Interval = 200; // 每200ms更新一次
            uiUpdateTimer.Tick += BatchUpdateUI;
            uiUpdateTimer.Start();
        }

        private void InitializeTempUpdateTimer()
        {
            tempUpdateTimer = new System.Windows.Forms.Timer();
            tempUpdateTimer.Interval = 200; // 每200ms更新一次温升仪UI
            tempUpdateTimer.Tick += TempUpdateTimer_Tick;
            tempUpdateTimer.Start();
        }

        // 初始化图表类
        private void InitializeChartManager()
        {
            try
            {
                chartManager = new ChartManager(this.chart);

            }
            catch (Exception ex)
            {
                LogMessage($"初始化图表类时出错: {ex.Message}", true);
            }
        }

        // 初始化功率仪表格类
        private void InitializePowerGridManager()
        {
            try
            {
                powerGridManager = new PowerGridManager(dgvPower, chartManager);
                powerGridManager.LogMessageAdded += (s, e) => LogMessage(e.Message, e.IsError);
                powerGridManager.ColumnHeaderChanged += (s, message) => LogMessage(message);
                powerGridManager.NotifyTreeViewRefresh += RefreshChartSeriesTreeView;
            }
            catch (Exception ex)
            {
                LogMessage($"初始化功率仪表格类时出错: {ex.Message}", true);
            }
        }

        // 初始化CSV导出服务
        private void InitializeCSVExportManager()
        {
            try
            {
                CSVExportManager = new CSVExportManager(sqliteManager, recordIntervalSeconds);
                CSVExportManager.LogMessageAdded += (s, e) => LogMessage(e.Message, e.IsError);
                CSVExportManager.StatusChanged += (s, status) => { if (statusLabel != null) statusLabel.Text = status; };

                // 设置映射委托
                CSVExportManager.GetDbColumnNameForDisplay = GetDbColumnNameForDisplay;
                CSVExportManager.GetIHDbColumnNameForDisplay = GetIHDbColumnNameForDisplay;
            }
            catch (Exception ex)
            {
                LogMessage($"初始化CSV导出服务时出错: {ex.Message}", true);
            }
        }

        // 初始化温升仪面板类
        private void InitializeTemperaturePanelManager()
        {
            try
            {
                temperaturePanelManager = new TemperaturePanelManager(this, chartManager);
                temperaturePanelManager.LogMessageAdded += (s, e) => LogMessage(e.Message, e.IsError);
                temperaturePanelManager.NotifyTreeViewRefresh += RefreshChartSeriesTreeView;
            }
            catch (Exception ex)
            {
                LogMessage($"初始化温升仪面板类时出错: {ex.Message}", true);
            }
        }

        // 初始化IH面板管理类
        private void InitializeIHPanelManager()
        {
            try
            {
                ihPanelManager = new IHPanelManager(this, chartManager);
                ihPanelManager.LogMessageAdded += (s, e) => LogMessage(e.Message, e.IsError);
                ihPanelManager.DataCacheRequested += (deviceType, data) => EnqueueDataForProcessing(deviceType, DateTime.Now, data);
                ihPanelManager.NotifyTreeViewRefresh += RefreshChartSeriesTreeView;
            }
            catch (Exception ex)
            {
                LogMessage($"初始化IH面板管理类时出错: {ex.Message}", true);
            }
        }

        // 批量更新UI
        private void BatchUpdateUI(object sender, EventArgs e)
        {
            if (!hasPendingUIUpdates) return;

            List<UIUpdateItem> itemsToProcess = new List<UIUpdateItem>();

            lock (uiUpdateLock)
            {
                // 取出所有待更新的UI项
                while (uiUpdateQueue.Count > 0)
                {
                    itemsToProcess.Add(uiUpdateQueue.Dequeue());
                }
                hasPendingUIUpdates = false;
            }

            if (itemsToProcess.Count == 0) return;

            powerGridManager?.SuspendLayout();

            try
            {
                // 批量添加新行
                var groupedItems = itemsToProcess.GroupBy(item => item.Type);
                foreach (var group in groupedItems)
                {
                    switch (group.Key)
                    {
                        case "Power":
                            foreach (var item in group)
                            {
                                AddPowerDataToGridBatch(item);
                            }
                            break;
                    }
                }

                // 批量滚动到底部
                powerGridManager?.ScrollToBottom();
            }
            catch (Exception ex)
            {
                LogMessage($"批量更新UI时出错: {ex.Message}", true);
            }
            finally
            {
                powerGridManager?.ResumeLayout();
            }
        }

        // 初始化设备数据库
        private void InitializeDeviceDataCaches()
        {
            lock (syncDataLock)
            {
                deviceDataCaches.Clear();
                deviceDataCaches["Temperature"] = new DeviceDataCache(); // 温升仪
                deviceDataCaches["Power"] = new DeviceDataCache();       // 功率仪
                deviceDataCaches["IH"] = new DeviceDataCache();          // IH设备
            }
        }

        private void TxtRecordInterval_TextChanged(object sender, EventArgs e)
        {
            // 实时验证输入
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                if (int.TryParse(textBox.Text, out int interval) && interval > 0)
                {
                    textBox.BackColor = Color.White;
                    // 应用设置
                    ApplyRecordInterval(textBox);
                }
                else
                {
                    textBox.BackColor = Color.Red;
                }
            }
        }

        // 应用记录间隔设置的共用方法
        private void ApplyRecordInterval(TextBox textBox)
        {
            if (textBox != null)
            {
                if (int.TryParse(textBox.Text, out int newInterval) && newInterval > 0)
                {
                    if (recordIntervalSeconds != newInterval)
                    {
                        recordIntervalSeconds = newInterval;
                        textBox.BackColor = Color.White;

                        // 更新CSV导出服务的记录间隔
                        CSVExportManager?.UpdateRecordInterval(newInterval);

                        LogMessage($"数据记录间隔已设置为 {newInterval} 秒");
                    }
                }
                else
                {
                    // 输入无效，恢复到之前的值
                    textBox.Text = recordIntervalSeconds.ToString();
                    textBox.BackColor = Color.White;
                    LogMessage("记录间隔必须是大于0的整数，已恢复到之前的设置", true);
                }
            }
        }

        // 处理UsbPcap日志消息事件
        private void UsbPcap_LogMessageAdded(object sender, LogMessageEventArgs e)
        {
            LogMessage(e.Message, e.IsError);
        }

        // 温升仪数据接收事件处理
        private void UsbPcap_TemperatureRowDataReceived(object sender, TemperatureRowDataEventArgs e)
        {
            try
            {
                // 准备数据记录用于数据库保存
                Dictionary<string, string> dataRecord = new Dictionary<string, string>();

                // 遍历所有通道数据
                foreach (var channelData in e.RowData)
                {
                    int channelNumber = channelData.Key;
                    double temperature = channelData.Value;

                    // 扫描周期检测
                    bool isNewScanCycle = IsNewScanCycle(channelNumber);
                    if (isNewScanCycle)
                    {
                        currentScanStartTime = e.LastUpdateTime;
                    }

                    // 将最新数据存入缓存
                    latestTemperatures[channelNumber] = temperature;
                    hasPendingTempUpdates = true;

                    // 使用固定的通道号格式生成列名用于数据库保存
                    string dbColumnName = $"Channel{channelNumber}";
                    dataRecord[dbColumnName] = temperature.ToString("F2");
                }

                // 如果有数据，使用扫描起始时间作为统一时间戳
                if (dataRecord.Count > 0)
                {
                    DateTime unifiedTimestamp = currentScanStartTime != DateTime.MinValue ? currentScanStartTime : e.LastUpdateTime;
                    EnqueueDataForProcessing("Temperature", unifiedTimestamp, dataRecord);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理温升仪数据时出错: {ex.Message}", true);
            }
        }

        // 检测是否为新扫描周期
        private bool IsNewScanCycle(int currentChannel)
        {
            // 第一个数据点，默认为新扫描周期
            if (lastChannelNumber == -1)
            {
                lastChannelNumber = currentChannel;
                return true;
            }

            // 当前通道号小于上一个通道号 = 新扫描周期
            bool isNewCycle = currentChannel < lastChannelNumber;
            lastChannelNumber = currentChannel;
            return isNewCycle;
        }

        // 用于批量更新UI
        private void TempUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (!hasPendingTempUpdates)
            {
                return;
            }

            try
            {
                // 更新所有变动的通道
                foreach (var item in latestTemperatures)
                {
                    UpdateChannelTextBox(item.Key, item.Value);
                }
            }
            finally
            {
                hasPendingTempUpdates = false;
            }
        }

        // 更新通道文本框显示
        private void UpdateChannelTextBox(int channelNumber, double temperature)
        {
            try
            {
                temperaturePanelManager?.UpdateChannelTextBox(channelNumber, temperature);
            }
            catch (Exception ex)
            {
                LogMessage($"更新通道{channelNumber}文本框时出错: {ex.Message}", true);
            }
        }

        // 处理SQLiteManager日志消息事件
        private void SQLiteManager_LogMessageAdded(object sender, LogMessageEventArgs e)
        {
            LogMessage(e.Message, e.IsError);
        }

        // 添加日志消息
        private void LogMessage(string message, bool isError = false)
        {
            try
            {
                if (LogBox.InvokeRequired)
                {
                    LogBox.Invoke(new Action(() => AddLogEntry(message, isError)));
                }
                else
                {
                    AddLogEntry(message, isError);
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"日志系统错误: {ex.Message}";
            }
        }

        private void AddLogEntry(string message, bool isError)
        {
            AddLogEntryWithCleanup(LogBox, message, isError);
        }

        // 日志添加方法
        private void AddLogEntryWithCleanup(RichTextBox logBox, string message, bool isError = false)
        {
            try
            {
                // 检查是否需要清理历史数据
                if (logBox.Lines.Length >= MAX_LOG_LINES)
                {
                    // 保留最新的行，清理旧的行
                    var lines = logBox.Lines;
                    var keepLines = lines.Skip(CLEANUP_LINES).ToArray();

                    logBox.Clear();
                    foreach (string line in keepLines)
                    {
                        if (logBox.TextLength > 0)
                            logBox.AppendText(Environment.NewLine);
                        logBox.AppendText(line);
                    }
                }

                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                string logEntry = $"[{timestamp}] {message}";

                // 添加新日志
                if (logBox.TextLength > 0)
                    logBox.AppendText(Environment.NewLine);

                // 记录当前插入位置
                int startIndex = logBox.TextLength;

                // 添加日志文本
                logBox.AppendText(logEntry);

                // 如果是错误日志，设置红色字体
                if (isError)
                {
                    logBox.SelectionStart = startIndex;
                    logBox.SelectionLength = logEntry.Length;
                    logBox.SelectionColor = Color.Red;

                    // 重置选择位置到末尾
                    logBox.SelectionStart = logBox.TextLength;
                    logBox.SelectionLength = 0;
                    logBox.SelectionColor = logBox.ForeColor; // 恢复默认颜色
                }

                // 自动滚动到最新的日志
                logBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"日志系统错误: {ex.Message}";
            }
        }

        private async void RefreshDevicesList()
        {
            try
            {
                // 更新状态栏显示刷新状态
                if (statusLabel != null)
                {
                    statusLabel.Text = "正在刷新设备列表...";
                }

                // 在后台线程执行设备扫描
                await Task.Run(() =>
                {
                    try
                    {
                        // 获取串口列表
                        string[] ports = SerialPort.GetPortNames();

                        // 获取USB设备列表
                        List<string> usbDevices = usbPcap?.GetUsbDevicesList() ?? new List<string>();

                        // 回到UI线程更新控件
                        this.Invoke(new Action(() =>
                        {
                            try
                            {
                                // 更新串口下拉框
                                UpdatePortComboBoxes(ports);

                                // 更新USB设备下拉框
                                UpdateUsbDeviceComboBox(usbDevices);

                                // 更新状态栏
                                if (cmbDAList != null && cmbDAList.Items.Count > 1) // 大于1因为包含了空选项
                                {
                                    statusLabel.Text = "设备列表已刷新";
                                }
                                else
                                {
                                    statusLabel.Text = "未找到设备";
                                }
                            }
                            catch (Exception ex)
                            {
                                LogMessage($"更新设备列表时出错: {ex.Message}", true);
                                statusLabel.Text = $"刷新设备列表失败: {ex.Message}";
                            }
                        }));
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"扫描设备时出错: {ex.Message}", true);
                        this.Invoke(new Action(() =>
                        {
                            statusLabel.Text = $"刷新设备列表失败: {ex.Message}";
                        }));
                    }
                });
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"刷新设备列表失败: {ex.Message}";
                LogMessage($"刷新设备列表失败: {ex.Message}", true);
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (deviceConnectionManager.IsAnyDeviceConnected)
                {
                    return;
                }

                // 构建设备连接配置
                var config = new DeviceConnectionConfig
                {
                    DADeviceName = cmbDAList.SelectedItem?.ToString(),
                    DADeviceAddress = TbDeviceAddress_DA.Text,
                    TempDeviceModel = cmbTempDevice.SelectedItem?.ToString(),
                    RealPortName = cmbRealPort.SelectedItem?.ToString(),
                    VirtualPortName = cmbVirtualPort1.SelectedItem?.ToString(),
                    PowerDeviceModel = cmbPowerDevice.SelectedItem?.ToString(),
                    IHDispPortName = Disp_comboBoxPortName.SelectedItem?.ToString(),
                    IHDispBaudRate = int.TryParse(Disp_comboBoxBaudRate.SelectedItem?.ToString(), out int dispBaud) ? dispBaud : 4800,
                    IHCtrlPortName = Ctrl_comboBoxPortName.SelectedItem?.ToString(),
                    IHCtrlBaudRate = int.TryParse(Ctrl_comboBoxBaudRate.SelectedItem?.ToString(), out int ctrlBaud) ? ctrlBaud : 4800,
                    UploadPortName = cmbUploadPort.SelectedItem?.ToString(),
                    UploadBaudRate = int.TryParse(cmbUploadBaudRate.SelectedItem?.ToString(), out int uploadBaud) ? uploadBaud : 9600
                };

                // 尝试连接设备
                if (deviceConnectionManager.ConnectAllSelectedDevices(config))
                {
                    // 连接成功，更新UI状态
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    btnRefreshPorts.Enabled = false;

                    // 禁用相关控件
                    cmbDAList.Enabled = false;
                    TbDeviceAddress_DA.Enabled = false;
                    cmbTempDevice.Enabled = false;
                    cmbRealPort.Enabled = false;
                    cmbVirtualPort1.Enabled = false;
                    cmbPowerDevice.Enabled = false;
                    Disp_comboBoxPortName.Enabled = false;
                    Ctrl_comboBoxPortName.Enabled = false;
                    Disp_comboBoxBaudRate.Enabled = false;
                    Ctrl_comboBoxBaudRate.Enabled = false;
                    cmbUploadPort.Enabled = false;
                    cmbUploadBaudRate.Enabled = false;

                    // 启动自动断开计时器
                    int minutes = 120; // 默认连接2小时后自动断开连接
                    if (int.TryParse(txtAutoDisconnect?.Text, out int userMinutes) && userMinutes > 0)
                        minutes = userMinutes;
                    autoDisconnectTimer.Interval = minutes * 60 * 1000;
                    autoDisconnectTimer.Start();
                    LogMessage($"将在 {minutes} 分钟后自动断开连接");
                }
                else
                {
                    // 连接失败，保持UI状态
                    statusLabel.Text = "连接失败";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"启动监听失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "监听失败";
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        // 停止按钮处理逻辑
        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (!deviceConnectionManager.IsAnyDeviceConnected)
            {
                return;
            }

            // 自动保存数据
            AutoSaveData();

            btnStop.Enabled = false;
            btnStart.Enabled = true;

            // 停止自动断开计时器
            autoDisconnectTimer?.Stop();

            // 立即启用所有控件
            cmbDAList.Enabled = true;
            TbDeviceAddress_DA.Enabled = true;
            cmbTempDevice.Enabled = true;
            cmbRealPort.Enabled = true;
            cmbVirtualPort1.Enabled = true;
            cmbPowerDevice.Enabled = true;
            Disp_comboBoxPortName.Enabled = true;
            Ctrl_comboBoxPortName.Enabled = true;
            Disp_comboBoxBaudRate.Enabled = true;
            Ctrl_comboBoxBaudRate.Enabled = true;
            cmbUploadPort.Enabled = true;
            cmbUploadBaudRate.Enabled = true;
            btnRefreshPorts.Enabled = true;

            // 使用异步方式快速断开设备，避免UI阻塞
            Task.Run(() =>
            {
                deviceConnectionManager.DisconnectAllDevices();
            });
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                // 清除所有日志和数据
                usbPcap.ClearLogs();
                LogBox.Clear();
                LogBox_Temp.Clear();
                LogBox_Power.Clear();
                LogBox_IH.Clear();

                // 清除数据表格
                powerGridManager?.ClearGridData();

                // 清除温升仪通道文本框
                ClearTemperatureChannelTextBoxes();

                // 清除IH设备所有数值输入框
                ihPanelManager?.ClearAllTextBoxes();

                // 清除SQLite数据库中的所有数据
                sqliteManager?.ClearDeviceData();

                // 清除设备数据库
                lock (syncDataLock)
                {
                    InitializeDeviceDataCaches();
                }

                // 重置扫描周期检测状态
                lastChannelNumber = -1;
                currentScanStartTime = DateTime.MinValue;

                // 清空图表数据
                chartManager?.Clear();

                // 恢复默认配置
                RestoreAllDefaultConfigurations();
            }
            catch (Exception ex)
            {
                LogMessage($"清除数据失败: {ex.Message}", true);
            }
        }

        // 恢复所有默认配置
        private void RestoreAllDefaultConfigurations()
        {
            try
            {
                // 1. 恢复设备连接配置默认值
                SetComboBoxSelection(cmbDAList, "");
                TbDeviceAddress_DA.Text = "";
                SetComboBoxSelection(cmbTempDevice, "DAQ970A");
                SetComboBoxSelection(cmbRealPort, "");
                SetComboBoxSelection(cmbVirtualPort1, "");
                SetComboBoxSelection(cmbPowerDevice, "青智8904F");
                SetComboBoxSelection(Disp_comboBoxPortName, "");
                SetComboBoxSelection(Disp_comboBoxBaudRate, "4800");
                SetComboBoxSelection(Ctrl_comboBoxPortName, "");
                SetComboBoxSelection(Ctrl_comboBoxBaudRate, "4800");
                SetComboBoxSelection(cmbUploadPort, "");
                SetComboBoxSelection(cmbUploadBaudRate, "9600");

                // 2. 恢复温升仪配置默认值
                temperaturePanelManager?.RestoreDefaultConfiguration();

                // 3. 恢复IH设备配置默认值
                ihPanelManager?.RestoreDefaultConfiguration();

                // 4. 恢复功率仪配置默认值
                powerGridManager?.RestoreDefaultConfiguration();

                // 5. 恢复其他通用设置默认值
                txtRecordInterval.Text = "1";
                ApplyRecordInterval(txtRecordInterval);
                tbUSBPcapPath.Text = @"D:\USBPcap\USBPcapCMD.exe";
                usbPcap?.SetUsbPcapPath(@"D:\USBPcap\USBPcapCMD.exe");
                txtAutoDisconnect.Text = "120";
                if (cbDebugMode != null)
                {
                    cbDebugMode.Checked = false;
                    smartMonitor?.SetDebugMode(false);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"恢复默认配置时出错: {ex.Message}", true);
            }
        }

        // 清除温升仪通道文本框的内容
        private void ClearTemperatureChannelTextBoxes()
        {
            try
            {
                temperaturePanelManager?.ClearTemperatureChannelTextBoxes();
            }
            catch (Exception ex)
            {
                LogMessage($"清除温升仪通道文本框时出错: {ex.Message}", true);
            }
        }

        private async void BtnData_Click(object sender, EventArgs e)
        {
            try
            {
                if (isSaving)
                {
                    return;
                }

                // 收集所有选中的列
                List<string> selectedColumns = GetAllSelectedColumns();

                if (selectedColumns.Count == 0)
                {
                    MessageBox.Show("请至少选择一项数据进行导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                isSaving = true;
                btnData.Enabled = false;

                try
                {
                    // 强制处理队列中的待处理数据，确保最新数据被保存到数据库
                    FlushPendingData();

                    // 导出CSV文件
                    bool result = await CSVExportManager.ExportAsync(selectedColumns);

                    if (result)
                    {
                        LogMessage($"选中列的数据已成功导出");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"保存数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogMessage($"保存数据失败: {ex.Message}", true);
                }
                finally
                {
                    isSaving = false;
                    btnData.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage($"保存数据失败: {ex.Message}", true);

                // 确保状态被重置
                isSaving = false;
                if (btnData != null) btnData.Enabled = true;
            }
        }

        #region 数据保存功能导出
        private void AutoSaveData()
        {
            Task.Run(async () =>
            {
                try
                {
                    List<string> selectedColumns = null;
                    this.Invoke(new Action(() =>
                    {
                        selectedColumns = GetAllSelectedColumns();
                    }));

                    if (selectedColumns == null || selectedColumns.Count == 0)
                    {
                        LogMessage("没有选择任何数据。");
                        return;
                    }

                    // 强制处理队列中的待处理数据，确保最新数据被保存到数据库
                    FlushPendingData();

                    // 使用CSV导出服务进行自动保存
                    bool result = await CSVExportManager.AutoSaveDataAsync(selectedColumns);

                    if (!result)
                    {
                        LogMessage("自动保存数据失败", true);
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"自动保存数据失败: {ex.Message}", true);
                }
            });
        }
        #endregion

        private void BtnRefreshPorts_Click(object sender, EventArgs e)
        {
            // 刷新USB设备列表
            RefreshDevicesList();
        }

        private void Btnaddress_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "选择USBPcapCMD.exe",
                    Filter = "USBPcap Executable (USBPcapCMD.exe)|USBPcapCMD.exe|All files (*.*)|*.*",
                    CheckFileExists = true,
                    CheckPathExists = true
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog.FileName;
                    tbUSBPcapPath.Text = selectedPath;
                    usbPcap.SetUsbPcapPath(selectedPath);

                    // 保存路径到数据库
                    sqliteManager?.SaveSetting("USBPcapPath", selectedPath);

                    statusLabel.Text = "USBPcap路径已更新并保存";
                    LogMessage($"USBPcap路径已更新为: {selectedPath}");

                    // 刷新设备列表
                    RefreshDevicesList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"选择路径失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "选择路径失败";
                LogMessage($"选择路径失败: {ex.Message}", true);
            }
        }

        private void BtnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                if (chart == null)
                {
                    MessageBox.Show("图表未初始化", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 获取系统图片文件夹路径
                string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                // 创建存储图表截图的文件夹
                string FolderPath = Path.Combine(picturesPath, "图表截图");
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // 生成带时间戳的文件名
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"图表截图_{timestamp}.png";
                string fullPath = Path.Combine(FolderPath, fileName);

                // 保存图表为图片
                chart.SaveImage(fullPath, System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);

                statusLabel.Text = "图表截图已保存";
                LogMessage($"图表截图已保存到: {fullPath}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"截图失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "截图失败";
                LogMessage($"截图失败: {ex.Message}", true);
            }
        }

        // 窗体关闭时清理资源
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            LogMessage("程序正在关闭...");

            SaveCurrentConfiguration();

            // 停止所有设备和后台任务
            try
            {
                // 停止数据处理线程
                isDataProcessingActive = false;
                dataAvailableEvent.Set(); // 唤醒线程
                dataProcessingThread?.Join(500); // 等待线程退出

                // 停止所有设备
                deviceConnectionManager?.DisconnectAllDevices();

                if (uiUpdateTimer != null)
                {
                    uiUpdateTimer.Stop();
                    uiUpdateTimer.Dispose();
                }
                if (tempUpdateTimer != null)
                {
                    tempUpdateTimer.Stop();
                    tempUpdateTimer.Dispose();
                }

                // 释放资源
                sqliteManager?.Dispose();
                chartManager = null; // 清理图表管理类
                powerGridManager?.Dispose(); // 清理功率仪表格管理类
                CSVExportManager?.Dispose(); // 清理数据保存管理类
                temperaturePanelManager?.Dispose(); // 清理温升仪控件管理类
                ihPanelManager?.Dispose(); // 清理IH控件管理类
                dataAvailableEvent?.Dispose();
                dataProcessingIdleEvent?.Dispose();
                uiUpdateTimer?.Dispose();
                tempUpdateTimer?.Dispose();
                autoDisconnectTimer?.Dispose();
                doubleClickTimer?.Dispose();
                smartMonitor?.Dispose();

            }
            catch (Exception ex)
            {
                LogMessage($"关闭程序时发生错误: {ex.Message}", true);
            }
            finally
            {
                base.OnFormClosing(e);
            }
        }

        // 虚拟串口事件处理
        private void VirtualPort_PowerDataReceived(object sender, PowerDataEventArgs e)
        {
            try
            {
                // 收集数据到批量更新队列而不是立即更新UI
                EnqueuePowerDataForUI(e);
            }
            catch (Exception ex)
            {
                LogMessage($"处理功率仪数据时出错: {ex.Message}", true);
            }
        }

        private void VirtualPort_LogMessageAdded(object sender, LogMessageEventArgs e)
        {
            LogMessage(e.Message, e.IsError);
        }

        // 处理原始数据接收事件
        private void VirtualPort_RawDataReceived(object sender, RawDataEventArgs e)
        {
            // 功率仪日志框更新
            if (LogBox_Power.InvokeRequired)
            {
                LogBox_Power.Invoke(new Action(() => DisplayRawData(e)));
            }
            else
            {
                DisplayRawData(e);
            }
        }

        // 在LogBox_Power中显示原始数据
        private void DisplayRawData(RawDataEventArgs data)
        {
            try
            {
                // 转换为十六进制字符串
                string hexData = BitConverter.ToString(data.Data).Replace("-", " ");

                // 创建显示文本
                string displayText = $" {data.Direction}: {hexData}";

                AddLogEntryWithCleanup(LogBox_Power, displayText);
            }
            catch (Exception ex)
            {
                LogMessage($"显示原始数据时出错: {ex.Message}", true);
            }
        }

        // 添加功率仪数据到表格
        private void AddPowerDataToGrid(PowerDataEventArgs data)
        {
            try
            {
                // 功率仪日志框更新
                // string logMessage = BuildPowerLogMessage(data);
                // 
                // // 添加到日志
                // if (!string.IsNullOrEmpty(logMessage))
                // {
                //     AddLogEntryWithCleanup(LogBox_Power, logMessage);
                // }

                // 准备功率仪数据
                var powerData = new Dictionary<string, double>
                {
                    ["Ua"] = data.Ua,
                    ["Ub"] = data.Ub,
                    ["Uc"] = data.Uc,
                    ["Ia"] = data.Ia,
                    ["Ib"] = data.Ib,
                    ["Ic"] = data.Ic,
                    ["P"] = data.P,
                    ["Freq"] = data.Freq,
                    ["En"] = data.En
                };

                // 使用PowerGridManager添加数据到表格
                powerGridManager?.AddPowerDataToGrid(data.Timestamp, powerData);

                // 收集非零数据用于数据库存储
                Dictionary<string, string> allDataRecord = new Dictionary<string, string>();
                foreach (var item in powerData)
                {
                    if (item.Value != 0)
                    {
                        string columnName = GetColumnNameForParameter(item.Key);
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            var column = dgvPower.Columns[columnName];
                            if (column != null)
                            {
                                allDataRecord[column.HeaderText] = item.Value.ToString("F2");
                            }
                        }
                    }
                }

                // 添加到处理队列
                if (allDataRecord.Count > 0)
                {
                    EnqueueDataForProcessing("Power", data.Timestamp, allDataRecord);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"在表格中添加功率仪数据时出错: {ex.Message}", true);
            }
        }

        // 根据参数名称获取对应的列名
        private string GetColumnNameForParameter(string parameterName)
        {
            var parameterMappings = new Dictionary<string, string>
            {
                ["Ua"] = "Column_Ua",
                ["Ub"] = "Column_Ub",
                ["Uc"] = "Column_Uc",
                ["Ia"] = "Column_Ia",
                ["Ib"] = "Column_Ib",
                ["Ic"] = "Column_Ic",
                ["P"] = "Column_P",
                ["Freq"] = "Column_Freq",
                ["En"] = "Column_En"
            };

            return parameterMappings.ContainsKey(parameterName) ? parameterMappings[parameterName] : null;
        }

        // 将功率仪数据加入UI更新队列
        private void EnqueuePowerDataForUI(PowerDataEventArgs e)
        {
            try
            {
                var uiData = new Dictionary<string, object>
                {
                    ["Timestamp"] = e.Timestamp,
                    ["Ua"] = e.Ua,
                    ["Ub"] = e.Ub,
                    ["Uc"] = e.Uc,
                    ["Ia"] = e.Ia,
                    ["Ib"] = e.Ib,
                    ["Ic"] = e.Ic,
                    ["P"] = e.P,
                    ["Freq"] = e.Freq,
                    ["En"] = e.En
                };

                lock (uiUpdateLock)
                {
                    // 检查队列长度
                    if (uiUpdateQueue.Count >= MAX_UI_UPDATE_QUEUE_SIZE)
                    {
                        int itemsToRemove = uiUpdateQueue.Count - UI_QUEUE_KEEP_SIZE;
                        for (int i = 0; i < itemsToRemove && uiUpdateQueue.Count > 0; i++)
                        {
                            uiUpdateQueue.Dequeue();
                        }

                    }

                    uiUpdateQueue.Enqueue(new UIUpdateItem
                    {
                        Type = "Power",
                        Timestamp = e.Timestamp,
                        Data = uiData
                    });
                    hasPendingUIUpdates = true;
                }

                // 同时处理数据保存逻辑
                Dictionary<string, string> allDataRecord = new Dictionary<string, string>();

                var powerParameters = new Dictionary<string, double>
                {
                    ["Column_Ua"] = e.Ua,
                    ["Column_Ub"] = e.Ub,
                    ["Column_Uc"] = e.Uc,
                    ["Column_Ia"] = e.Ia,
                    ["Column_Ib"] = e.Ib,
                    ["Column_Ic"] = e.Ic,
                    ["Column_P"] = e.P,
                    ["Column_Freq"] = e.Freq,
                    ["Column_En"] = e.En
                };

                foreach (var param in powerParameters)
                {
                    if (param.Value != 0)
                    {
                        var column = dgvPower.Columns[param.Key];
                        if (column != null)
                        {
                            allDataRecord[column.HeaderText] = param.Value.ToString("F2");
                        }
                    }
                }

                // 添加到处理队列
                if (allDataRecord.Count > 0)
                {
                    EnqueueDataForProcessing("Power", e.Timestamp, allDataRecord);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"将功率仪数据加入UI队列时出错: {ex.Message}", true);
            }
        }

        // 功率仪数据UI更新方法
        private void AddPowerDataToGridBatch(UIUpdateItem item)
        {
            try
            {
                var data = item.Data;

                // 准备功率仪数据
                var powerData = new Dictionary<string, double>();
                string[] columnNames = { "Ua", "Ub", "Uc", "Ia", "Ib", "Ic", "P", "Freq", "En" };
                foreach (string columnName in columnNames)
                {
                    if (data.ContainsKey(columnName))
                    {
                        double value = Convert.ToDouble(data[columnName]);
                        powerData[columnName] = value;
                    }
                }

                // 使用PowerGridManager添加数据到表格
                powerGridManager?.AddPowerDataToGrid(item.Timestamp, powerData);

                // 更新图表数据
                powerGridManager?.UpdateChartForPowerData(item.Timestamp, powerData);
            }
            catch (Exception ex)
            {
                LogMessage($"批量添加功率仪数据到表格时出错: {ex.Message}", true);
            }
        }

        // 添加IH设备事件处理
        private void IHDevice_DisplayDataReceived(object sender, IHDisplayDataEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateIHDisplayData(e.Data)));
                }
                else
                {
                    UpdateIHDisplayData(e.Data);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理IH显示板数据时出错: {ex.Message}", true);
            }
        }

        private void IHDevice_PowerDataReceived(object sender, IHPowerDataEventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => UpdateIHPowerData(e.Data)));
                }
                else
                {
                    UpdateIHPowerData(e.Data);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理IH功率板数据时出错: {ex.Message}", true);
            }
        }

        private void IHDevice_LogMessageAdded(object sender, LogMessageEventArgs e)
        {
            LogMessage(e.Message, e.IsError);
        }

        // 处理IH设备原始数据接收事件
        private void IHDevice_RawDataReceived(object sender, RawDataEventArgs e)
        {
            try
            {
                // 直接访问LogBox_IH控件
                if (LogBox_IH.InvokeRequired)
                {
                    LogBox_IH.Invoke(new Action(() => DisplayIHRawData(e, LogBox_IH)));
                }
                else
                {
                    DisplayIHRawData(e, LogBox_IH);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理IH原始数据时出错: {ex.Message}", true);
            }
        }

        // 显示IH原始数据
        private void DisplayIHRawData(RawDataEventArgs data, RichTextBox targetLogBox)
        {
            try
            {
                // 转换为十六进制字符串
                string hexData = BitConverter.ToString(data.Data).Replace("-", " ");

                // 创建显示文本
                string displayText = $" IH-{data.Direction}: {hexData}";

                // 日志方法
                AddLogEntryWithCleanup(targetLogBox, displayText);
            }
            catch (Exception ex)
            {
                LogMessage($"显示IH原始数据时出错: {ex.Message}", true);
            }
        }

        // 更新IH显示板数据到界面控件
        private void UpdateIHDisplayData(IHDisplayData data)
        {
            try
            {

                ihPanelManager?.UpdateDisplayData(data);
            }
            catch (Exception ex)
            {
                LogMessage($"更新IH显示板数据时出错: {ex.Message}", true);
            }
        }

        // 更新IH功率板数据到界面控件
        private void UpdateIHPowerData(IHPowerData data)
        {
            try
            {

                ihPanelManager?.UpdatePowerData(data);
            }
            catch (Exception ex)
            {
                LogMessage($"更新IH功率板数据时出错: {ex.Message}", true);
            }
        }

        // 通用控件查找方法
        public T FindControlByName<T>(string controlName) where T : Control
        {
            try
            {
                Control[] controls = this.Controls.Find(controlName, true);
                return controls.FirstOrDefault() as T;
            }
            catch (Exception ex)
            {
                LogMessage($"查找控件 {controlName} 时出错: {ex.Message}", true);
                return null;
            }
        }

        // 获取所有选中的温升仪通道
        private List<string> GetSelectedTemperatureChannels()
        {
            return temperaturePanelManager?.GetSelectedTemperatureChannels() ?? new List<string>();
        }

        // 根据显示名称获取对应的数据库列名
        private string GetDbColumnNameForDisplay(string displayName, int[] channels)
        {
            return temperaturePanelManager?.GetDbColumnNameForDisplay(displayName) ?? displayName;
        }

        // 根据IH设备显示名称获取对应的数据库列名
        private string GetIHDbColumnNameForDisplay(string displayName)
        {
            return ihPanelManager?.GetIHDbColumnNameForDisplay(displayName) ?? displayName;
        }

        // 获取所有选中的IH列名
        private List<string> GetSelectedIHColumns()
        {
            return ihPanelManager?.GetSelectedIHColumns() ?? new List<string>();
        }

        // 获取所有选中的列（包括温升仪、功率仪和IH设备）
        private List<string> GetAllSelectedColumns()
        {
            List<string> selectedColumns = new List<string>();

            try
            {
                // 添加功率仪选中的列（使用表格中的列标题）
                var powerSelectedColumns = powerGridManager?.GetSelectedColumnDisplayNames() ?? new List<string>();
                selectedColumns.AddRange(powerSelectedColumns);

                // 添加温升仪选中的通道
                selectedColumns.AddRange(GetSelectedTemperatureChannels());

                // 添加IH设备选中的列
                selectedColumns.AddRange(GetSelectedIHColumns());
            }
            catch (Exception ex)
            {
                LogMessage($"获取选中列时出错: {ex.Message}", true);
            }

            return selectedColumns;
        }

        #region 上报模块设备管理

        // 获取上报模块连接状态
        public bool IsUploadDeviceConnected => deviceConnectionManager.IsUploadConnected;

        // 获取当前选择的上报模块端口
        public string GetSelectedUploadPort()
        {
            return cmbUploadPort.SelectedItem != null ? cmbUploadPort.SelectedItem.ToString() : null;
        }

        // 上报模块日志事件处理
        private void SmartMonitor_LogMessageAdded(object sender, LogMessageEventArgs e)
        {
            LogMessage(e.Message, e.IsError);
        }

        #endregion

        #region 温升仪数据访问接口（UartProcessSmartMonitor使用）
        // 获取温升仪通道的自定义文字
        public string GetTemperatureChannelCustomText(string checkBoxName)
        {
            return temperaturePanelManager?.GetTemperatureChannelCustomText(checkBoxName) ?? "";
        }

        // 获取温升仪通道的温度文本值
        public string GetChannelTemperatureText(int channelNumber)
        {
            return temperaturePanelManager?.GetChannelTemperatureText(channelNumber) ?? "0";
        }

        // 检查温升仪通道复选框是否被勾选
        public bool IsChannelCheckBoxChecked(string checkBoxName)
        {
            return temperaturePanelManager?.IsChannelCheckBoxChecked(checkBoxName) ?? false;
        }

        #endregion

        // 数据处理工作线程
        private void DataProcessingWorker()
        {
            while (isDataProcessingActive)
            {
                try
                {
                    // 等待有数据可处理的信号
                    if (dataAvailableEvent.WaitOne(1000)) // 1秒超时
                    {
                        dataProcessingIdleEvent.Reset(); // 标记为正在处理

                        List<DataQueueItem> itemsToProcess = new List<DataQueueItem>();

                        // 从队列中取出所有待处理项
                        lock (dataQueueLock)
                        {
                            while (dataQueue.Count > 0)
                            {
                                itemsToProcess.Add(dataQueue.Dequeue());
                            }
                        }

                        // 按设备类型和时间戳分组处理数据
                        if (itemsToProcess.Count > 0)
                        {
                            ProcessQueuedData(itemsToProcess);
                        }

                        // 检查队列是否真的空了，如果空了，则标记为空闲
                        lock (dataQueueLock)
                        {
                            if (dataQueue.Count == 0)
                            {
                                dataProcessingIdleEvent.Set(); // 标记为空闲
                            }
                        }
                    }
                    else
                    {
                        // 等待超时，意味着队列在1秒内都是空的，标记为空闲
                        dataProcessingIdleEvent.Set();
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"数据处理线程错误: {ex.Message}", true);
                    dataProcessingIdleEvent.Set();
                    Thread.Sleep(100); // 短暂延迟避免CPU占用过高
                }
            }

            LogMessage("数据处理线程已停止");
        }

        // 处理队列中的数据
        private void ProcessQueuedData(List<DataQueueItem> items)
        {
            try
            {
                // 将数据按秒分组，合并后写入，减少数据库IO次数
                var groupedData = items
                    .GroupBy(i => i.OriginalTimestamp.ToString("yyyy-MM-dd HH:mm:ss"))
                    .Select(g => new
                    {
                        Timestamp = DateTime.Parse(g.Key),
                        // 合并同一秒内的所有数据点
                        Data = g.SelectMany(i => i.Data)
                                .GroupBy(kvp => kvp.Key)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Last().Value)
                    });

                foreach (var group in groupedData)
                {
                    if (group.Data.Any())
                    {
                        SaveDataToSQLiteSync(group.Timestamp, group.Data);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理队列数据时出错: {ex.Message}", true);
            }
        }

        private void SaveDataToSQLiteSync(DateTime timestamp, Dictionary<string, string> data)
        {
            try
            {
                // 使用SQLiteManager保存数据
                sqliteManager?.SaveDeviceData(timestamp, data);
            }
            catch (Exception ex)
            {
                LogMessage($"同步保存数据失败: {ex.Message}", true);
            }
        }

        // 将数据添加到处理队列
        private void EnqueueDataForProcessing(string deviceType, DateTime timestamp, Dictionary<string, string> data)
        {
            try
            {
                lock (dataQueueLock)
                {
                    dataQueue.Enqueue(new DataQueueItem
                    {
                        DeviceType = deviceType,
                        OriginalTimestamp = timestamp,
                        Data = new Dictionary<string, string>(data)
                    });
                }

                // 通知数据处理线程有新数据
                dataAvailableEvent.Set();
            }
            catch (Exception ex)
            {
                LogMessage($"添加数据到队列失败: {ex.Message}", true);
            }
        }

        // 快速处理待处理数据的方法
        private void FlushPendingData()
        {
            try
            {
                // 先强制保存IH缓存数据
                ihPanelManager?.ForceFlushIHData();

                // 唤醒数据处理线程，让它检查一次队列
                dataAvailableEvent.Set();

                // 设置5秒超时以防止死锁
                if (!dataProcessingIdleEvent.WaitOne(5000))
                {
                    if (dataQueue.Count > 0)
                    {
                        LogMessage($"提示：仍有 {dataQueue.Count} 条数据在队列中等待处理记录", true);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"处理待处理数据时出错: {ex.Message}", true);
            }
        }

        // 自动断开时间输入框变化事件
        private void TxtAutoDisconnect_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null && !string.IsNullOrEmpty(textBox.Text))
                {
                    // 验证输入并保存到数据库
                    if (int.TryParse(textBox.Text, out int minutes) && minutes > 0)
                    {
                        // 保存设置到数据库
                        sqliteManager?.SaveSetting("AutoDisconnectTime", textBox.Text);

                        // 只有在设备已连接时才重新设置计时器
                        if (deviceConnectionManager.IsAnyDeviceConnected)
                        {
                            autoDisconnectTimer.Stop();
                            autoDisconnectTimer.Interval = minutes * 60 * 1000;
                            autoDisconnectTimer.Start();
                            LogMessage($"自动断开时间已更新为 {minutes} 分钟");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"更新自动断开时间时出错: {ex.Message}", true);
            }
        }

        // 双击计时器超时事件
        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            doubleClickTimer.Stop();
        }

        // Debug模式CheckBox状态变化事件
        private void CbDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                // 设置上报模块的debug模式
                smartMonitor?.SetDebugMode(checkBox.Checked);

                string status = checkBox.Checked ? "开启" : "关闭";
                LogMessage($"上报模块Debug模式已{status}");
            }
        }
        private void BtUploadName_Click(object sender, EventArgs e)
        {
            if (smartMonitor != null && smartMonitor.IsConnected)
            {
                smartMonitor.UploadActiveChannelNames();
            }
            else
            {
                LogMessage("上报模块未连接或已断开，无法上传通道名称。", true);
            }
        }

        #region 配置保存和加载功能

        // 自动保存当前配置到数据库
        private void SaveCurrentConfiguration()
        {
            try
            {
                var configData = new Dictionary<string, string>();

                // 保存设备连接配置
                SaveDeviceConnectionConfigToDict(configData);

                // 保存其他通用设置
                SaveGeneralSettingsToDict(configData);

                // 将基础配置保存到数据库
                foreach (var kvp in configData)
                {
                    sqliteManager?.SaveSetting($"LastConfig.{kvp.Key}", kvp.Value);
                }
            }
            catch (Exception ex)
            {
                LogMessage($"自动保存基础配置失败: {ex.Message}", true);
            }
        }

        // 保存配置按钮事件
        private void BtnSaveConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "保存配置文件";
                saveFileDialog.Filter = "配置文件 (*.cfg)|*.cfg|所有文件 (*.*)|*.*";
                saveFileDialog.DefaultExt = "cfg";
                saveFileDialog.FileName = $"DA_Config_{DateTime.Now:yyyyMMdd_HHmmss}.cfg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveConfigurationToFile(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 加载配置按钮事件
        private void BtnLoadConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "加载配置文件";
                openFileDialog.Filter = "配置文件 (*.cfg)|*.cfg|所有文件 (*.*)|*.*";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadConfigurationFromFile(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载配置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 保存配置到文件
        private void SaveConfigurationToFile(string filePath)
        {
            try
            {
                var configData = new Dictionary<string, string>();
                // 保存设备连接配置
                SaveDeviceConnectionConfigToDict(configData);

                // 保存其他通用设置
                SaveGeneralSettingsToDict(configData);

                // 保存温升仪配置
                SaveTemperatureConfigToDict(configData);

                // 保存功率仪配置
                SavePowerGridConfigToDict(configData);

                // 保存IH设备配置
                SaveIHDeviceConfigToDict(configData);

                // 写入文件
                var lines = new List<string>();
                foreach (var kvp in configData)
                {
                    lines.Add($"{kvp.Key}={kvp.Value}");
                }
                File.WriteAllLines(filePath, lines, Encoding.UTF8);

                LogMessage("配置已保存到文件");
            }
            catch (Exception ex)
            {
                throw new Exception($"保存配置文件时出错: {ex.Message}");
            }
        }

        // 从文件加载配置
        private void LoadConfigurationFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("配置文件不存在");
                }

                var configData = new Dictionary<string, string>();
                var lines = File.ReadAllLines(filePath, Encoding.UTF8);

                foreach (var line in lines)
                {
                    if (line.Contains("="))
                    {
                        var parts = line.Split(new[] { '=' }, 2);
                        if (parts.Length == 2)
                        {
                            configData[parts[0]] = parts[1];
                        }
                    }
                }

                // 加载设备连接配置
                LoadDeviceConnectionConfigFromDict(configData);

                // 加载其他通用设置
                LoadGeneralSettingsFromDict(configData);

                // 加载温升仪配置
                LoadTemperatureConfigFromDict(configData);

                // 加载功率仪配置
                LoadPowerGridConfigFromDict(configData);

                // 加载IH设备配置
                LoadIHDeviceConfigFromDict(configData);

            }
            catch (Exception ex)
            {
                throw new Exception($"加载配置文件时出错: {ex.Message}");
            }
        }

        // 保存设备连接配置到字典
        private void SaveDeviceConnectionConfigToDict(Dictionary<string, string> configData)
        {
            configData["Connection.DADevice"] = cmbDAList.SelectedItem?.ToString() ?? "";
            configData["Connection.DADeviceAddress"] = TbDeviceAddress_DA.Text ?? "";
            configData["Connection.TempDeviceModel"] = cmbTempDevice.SelectedItem?.ToString() ?? "";
            configData["Connection.RealPort"] = cmbRealPort.SelectedItem?.ToString() ?? "";
            configData["Connection.VirtualPort"] = cmbVirtualPort1.SelectedItem?.ToString() ?? "";
            configData["Connection.PowerDeviceModel"] = cmbPowerDevice.SelectedItem?.ToString() ?? "";
            configData["Connection.IHDispPort"] = Disp_comboBoxPortName.SelectedItem?.ToString() ?? "";
            configData["Connection.IHCtrlPort"] = Ctrl_comboBoxPortName.SelectedItem?.ToString() ?? "";
            configData["Connection.IHDispBaudRate"] = Disp_comboBoxBaudRate.SelectedItem?.ToString() ?? "";
            configData["Connection.IHCtrlBaudRate"] = Ctrl_comboBoxBaudRate.SelectedItem?.ToString() ?? "";
            configData["Connection.UploadPort"] = cmbUploadPort.SelectedItem?.ToString() ?? "";
            configData["Connection.UploadBaudRate"] = cmbUploadBaudRate.SelectedItem?.ToString() ?? "";
        }

        // 从字典加载设备连接配置
        private void LoadDeviceConnectionConfigFromDict(Dictionary<string, string> configData)
        {
            SetComboBoxSelection(cmbDAList, configData.ContainsKey("Connection.DADevice") ? configData["Connection.DADevice"] : "");
            TbDeviceAddress_DA.Text = configData.ContainsKey("Connection.DADeviceAddress") ? configData["Connection.DADeviceAddress"] : "";
            SetComboBoxSelection(cmbTempDevice, configData.ContainsKey("Connection.TempDeviceModel") ? configData["Connection.TempDeviceModel"] : "DAQ970A");
            SetComboBoxSelection(cmbRealPort, configData.ContainsKey("Connection.RealPort") ? configData["Connection.RealPort"] : "");
            SetComboBoxSelection(cmbVirtualPort1, configData.ContainsKey("Connection.VirtualPort") ? configData["Connection.VirtualPort"] : "");
            SetComboBoxSelection(cmbPowerDevice, configData.ContainsKey("Connection.PowerDeviceModel") ? configData["Connection.PowerDeviceModel"] : "青智8904F");
            SetComboBoxSelection(Disp_comboBoxPortName, configData.ContainsKey("Connection.IHDispPort") ? configData["Connection.IHDispPort"] : "");
            SetComboBoxSelection(Disp_comboBoxBaudRate, configData.ContainsKey("Connection.IHDispBaudRate") ? configData["Connection.IHDispBaudRate"] : "");
            SetComboBoxSelection(Ctrl_comboBoxPortName, configData.ContainsKey("Connection.IHCtrlPort") ? configData["Connection.IHCtrlPort"] : "");
            SetComboBoxSelection(Ctrl_comboBoxBaudRate, configData.ContainsKey("Connection.IHCtrlBaudRate") ? configData["Connection.IHCtrlBaudRate"] : "");
            SetComboBoxSelection(cmbUploadPort, configData.ContainsKey("Connection.UploadPort") ? configData["Connection.UploadPort"] : "");
            SetComboBoxSelection(cmbUploadBaudRate, configData.ContainsKey("Connection.UploadBaudRate") ? configData["Connection.UploadBaudRate"] : "");
        }

        // 保存温升仪配置到字典
        private void SaveTemperatureConfigToDict(Dictionary<string, string> configData)
        {
            var config = temperaturePanelManager?.GetTemperatureConfiguration();
            if (config != null)
            {
                string configString = SerializeTemperatureConfig(config);
                configData["Temperature.Config"] = configString;
            }
        }

        // 从字典加载温升仪配置
        private void LoadTemperatureConfigFromDict(Dictionary<string, string> configData)
        {
            if (configData.ContainsKey("Temperature.Config"))
            {
                string configString = configData["Temperature.Config"];
                if (!string.IsNullOrEmpty(configString))
                {
                    var config = DeserializeTemperatureConfig(configString);
                    temperaturePanelManager?.ApplyTemperatureConfiguration(config);
                }
            }
        }

        // 保存IH设备配置到字典
        private void SaveIHDeviceConfigToDict(Dictionary<string, string> configData)
        {
            var config = ihPanelManager?.GetIHConfiguration();
            if (config != null)
            {
                string configString = SerializeIHDeviceConfig(config);
                configData["IHDevice.Config"] = configString;
            }
        }

        // 从字典加载IH设备配置
        private void LoadIHDeviceConfigFromDict(Dictionary<string, string> configData)
        {
            if (configData.ContainsKey("IHDevice.Config"))
            {
                string configString = configData["IHDevice.Config"];
                if (!string.IsNullOrEmpty(configString))
                {
                    var config = DeserializeIHDeviceConfig(configString);
                    ihPanelManager?.ApplyIHConfiguration(config);
                }
            }
        }

        // 保存功率仪配置到字典
        private void SavePowerGridConfigToDict(Dictionary<string, string> configData)
        {
            var config = powerGridManager?.GetPowerGridConfiguration();
            if (config != null)
            {
                string configString = SerializePowerGridConfig(config);
                configData["PowerGrid.Config"] = configString;
            }
        }

        // 从字典加载功率仪配置
        private void LoadPowerGridConfigFromDict(Dictionary<string, string> configData)
        {
            if (configData.ContainsKey("PowerGrid.Config"))
            {
                string configString = configData["PowerGrid.Config"];
                if (!string.IsNullOrEmpty(configString))
                {
                    var config = DeserializePowerGridConfig(configString);
                    powerGridManager?.ApplyPowerGridConfiguration(config);
                }
            }
        }

        // 保存其他通用设置到字典
        private void SaveGeneralSettingsToDict(Dictionary<string, string> configData)
        {
            configData["General.RecordInterval"] = txtRecordInterval.Text ?? "1";
            configData["General.USBPcapPath"] = tbUSBPcapPath.Text ?? "";
            configData["General.AutoDisconnectTime"] = txtAutoDisconnect.Text ?? "120";
            configData["General.DebugMode"] = cbDebugMode?.Checked.ToString() ?? "False";
        }

        // 从字典加载其他通用设置
        private void LoadGeneralSettingsFromDict(Dictionary<string, string> configData)
        {
            // 加载数据记录间隔
            string recordInterval = configData.ContainsKey("General.RecordInterval") ? configData["General.RecordInterval"] : "1";
            txtRecordInterval.Text = recordInterval;
            ApplyRecordInterval(txtRecordInterval);

            // 加载USBPcap路径
            if (configData.ContainsKey("General.USBPcapPath"))
            {
                tbUSBPcapPath.Text = configData["General.USBPcapPath"];
                usbPcap?.SetUsbPcapPath(configData["General.USBPcapPath"]);
            }

            // 加载自动断开时间
            if (configData.ContainsKey("General.AutoDisconnectTime"))
            {
                txtAutoDisconnect.Text = configData["General.AutoDisconnectTime"];
            }

            // 加载Debug模式状态
            if (configData.ContainsKey("General.DebugMode") && cbDebugMode != null)
            {
                bool debugMode = bool.Parse(configData["General.DebugMode"]);
                cbDebugMode.Checked = debugMode;
                smartMonitor?.SetDebugMode(debugMode);
            }
        }

        private void SetComboBoxSelection(ComboBox comboBox, string value)
        {
            if (comboBox != null)
            {
                if (string.IsNullOrEmpty(value))
                {
                    // 设置为空选项（通常是第一项）
                    comboBox.SelectedIndex = -1;
                }
                else
                {
                    for (int i = 0; i < comboBox.Items.Count; i++)
                    {
                        if (comboBox.Items[i].ToString() == value)
                        {
                            comboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region 配置序列化方法

        // 序列化温升仪配置
        private string SerializeTemperatureConfig(List<TemperatureChannelConfig> config)
        {
            var lines = new List<string>();
            foreach (var item in config)
            {
                string customText = item.CustomText?.Replace("|", "&#124;").Replace(";", "&#59;") ?? "";
                lines.Add($"{item.CheckBoxName}|{item.IsChecked}|{customText}");
            }
            return string.Join(";", lines);
        }

        // 反序列化温升仪配置
        private List<TemperatureChannelConfig> DeserializeTemperatureConfig(string configString)
        {
            var config = new List<TemperatureChannelConfig>();
            var lines = configString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 2)
                {
                    config.Add(new TemperatureChannelConfig
                    {
                        CheckBoxName = parts[0],
                        IsChecked = bool.Parse(parts[1]),
                        CustomText = parts.Length >= 3 ? parts[2]?.Replace("&#124;", "|").Replace("&#59;", ";") : null
                    });
                }
            }
            return config;
        }

        // 序列化IH设备配置
        private string SerializeIHDeviceConfig(List<IHDeviceCheckBoxConfig> config)
        {
            var lines = new List<string>();
            foreach (var item in config)
            {
                string customText = item.CustomText?.Replace("|", "&#124;").Replace(";", "&#59;") ?? "";
                lines.Add($"{item.CheckBoxName}|{item.IsChecked}|{customText}");
            }
            return string.Join(";", lines);
        }

        // 反序列化IH设备配置
        private List<IHDeviceCheckBoxConfig> DeserializeIHDeviceConfig(string configString)
        {
            var config = new List<IHDeviceCheckBoxConfig>();
            var lines = configString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 2)
                {
                    config.Add(new IHDeviceCheckBoxConfig
                    {
                        CheckBoxName = parts[0],
                        IsChecked = bool.Parse(parts[1]),
                        CustomText = parts.Length >= 3 ? parts[2]?.Replace("&#124;", "|").Replace("&#59;", ";") : null
                    });
                }
            }
            return config;
        }

        // 序列化功率仪配置
        private string SerializePowerGridConfig(List<PowerGridColumnConfig> config)
        {
            var lines = new List<string>();
            foreach (var item in config)
            {
                string headerText = item.HeaderText?.Replace("|", "&#124;").Replace(";", "&#59;") ?? "";
                lines.Add($"{item.ColumnName}|{item.IsVisible}|{item.IsSelected}|{headerText}");
            }
            return string.Join(";", lines);
        }

        // 反序列化功率仪配置
        private List<PowerGridColumnConfig> DeserializePowerGridConfig(string configString)
        {
            var config = new List<PowerGridColumnConfig>();
            var lines = configString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 3)
                {
                    config.Add(new PowerGridColumnConfig
                    {
                        ColumnName = parts[0],
                        IsVisible = bool.Parse(parts[1]),
                        IsSelected = bool.Parse(parts[2]),
                        HeaderText = parts.Length >= 4 ? parts[3]?.Replace("&#124;", "|").Replace("&#59;", ";") : null
                    });
                }
            }
            return config;
        }

        #endregion

        #region 配置数据结构

        // 温升仪通道配置
        public class TemperatureChannelConfig
        {
            public string CheckBoxName { get; set; }
            public bool IsChecked { get; set; }
            public string CustomText { get; set; }
        }

        // IH设备复选框配置
        public class IHDeviceCheckBoxConfig
        {
            public string CheckBoxName { get; set; }
            public bool IsChecked { get; set; }
            public string CustomText { get; set; }
        }

        // 功率仪表格列配置
        public class PowerGridColumnConfig
        {
            public string ColumnName { get; set; }
            public bool IsVisible { get; set; }
            public bool IsSelected { get; set; }
            public string HeaderText { get; set; }
        }

        #endregion

        #region 图表TreeView管理

        // 图表系列信息
        public class ChartSeriesInfo
        {
            public string SeriesName { get; set; }
            public string DisplayName { get; set; }
            public string UniqueID { get; set; }
            public ChartAxisType AxisType { get; set; }
        }

        // 初始化图表系列树状图
        private void InitializeChartSeriesTreeView()
        {
            if (temperaturePanelManager == null || powerGridManager == null || ihPanelManager == null)
            {
                return;
            }

            treeView1.Nodes.Clear();
            treeView1.CheckBoxes = true;

            // --- 根节点 ---
            TreeNode tempRoot = new TreeNode("温升仪");
            TreeNode powerRoot = new TreeNode("功率仪");
            TreeNode ihRoot = new TreeNode("IH 设备");

            treeView1.Nodes.Add(tempRoot);
            treeView1.Nodes.Add(powerRoot);
            treeView1.Nodes.Add(ihRoot);

            // --- 填充温升仪节点 ---
            var tempSeries = temperaturePanelManager.GetAvailableSeries();
            var tempNode1 = new TreeNode("通道 1 (101-120)");
            var tempNode2 = new TreeNode("通道 2 (201-220)");
            var tempNode3 = new TreeNode("通道 3 (301-320)");
            tempRoot.Nodes.AddRange(new[] { tempNode1, tempNode2, tempNode3 });

            foreach (var seriesInfo in tempSeries)
            {
                int channel = int.Parse(seriesInfo.UniqueID.Replace("chkChannel", ""));
                var node = new TreeNode(seriesInfo.DisplayName) { Tag = seriesInfo };

                if (channel >= 101 && channel <= 120) tempNode1.Nodes.Add(node);
                else if (channel >= 201 && channel <= 220) tempNode2.Nodes.Add(node);
                else if (channel >= 301 && channel <= 320) tempNode3.Nodes.Add(node);
            }

            // --- 填充功率仪节点 ---
            var powerSeries = powerGridManager.GetAvailableSeries();
            foreach (var seriesInfo in powerSeries)
            {
                var node = new TreeNode(seriesInfo.DisplayName) { Tag = seriesInfo };
                powerRoot.Nodes.Add(node);
            }

            // --- 填充IH设备节点 ---
            var ihSeries = ihPanelManager.GetAvailableSeries();
            var positionNodes = new Dictionary<string, TreeNode>();
            string[] IH_POSITIONS = { "LR", "LF", "RR", "RF", "CLF", "CLR" };
            foreach (string pos in IH_POSITIONS)
            {
                var posNode = new TreeNode(pos);
                positionNodes[pos] = posNode;
                ihRoot.Nodes.Add(posNode);
            }

            foreach (var seriesInfo in ihSeries)
            {
                string position = seriesInfo.UniqueID.Split('_')[0].Substring(3);
                if (positionNodes.ContainsKey(position))
                {
                    var node = new TreeNode(seriesInfo.DisplayName) { Tag = seriesInfo };
                    positionNodes[position].Nodes.Add(node);
                }
            }

            // 订阅事件
            treeView1.AfterCheck -= TreeView1_AfterCheck;
            treeView1.AfterCheck += TreeView1_AfterCheck;

            // 默认展开所有节点
            treeView1.ExpandAll();
        }

        // TreeView节点勾选/取消勾选事件
        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            // 更新子节点状态以匹配父节点
            if (e.Action != TreeViewAction.Unknown)
            {
                CheckAllChildNodes(e.Node, e.Node.Checked);
            }

            // 根据节点信息控制复选框和图表
            if (e.Node.Tag is ChartSeriesInfo seriesInfo)
            {
                if (e.Node.Checked)
                {
                    // 勾选对应的复选框
                    SetCheckBoxState(seriesInfo, true);

                    // 显示图表曲线
                    chartManager.ShowSeries(seriesInfo.SeriesName, seriesInfo.AxisType);
                }
                else
                {
                    // 隐藏图表曲线
                    chartManager.HideSeries(seriesInfo.SeriesName);

                    // 取消勾选对应的复选框
                    SetCheckBoxState(seriesInfo, false);
                }
            }
        }

        // 设置对应复选框的状态
        private void SetCheckBoxState(ChartSeriesInfo seriesInfo, bool isChecked)
        {
            try
            {
                // 根据不同设备类型找到对应的复选框
                if (seriesInfo.UniqueID.StartsWith("chkChannel"))
                {
                    // 温升仪复选框
                    CheckBox checkBox = FindControlByName<CheckBox>(seriesInfo.UniqueID);
                    if (checkBox != null)
                    {
                        checkBox.Checked = isChecked;
                    }
                }
                else if (seriesInfo.UniqueID.StartsWith("Column_"))
                {
                    // 功率仪复选框
                    powerGridManager?.SetColumnCheckState(seriesInfo.UniqueID, isChecked);
                }
                else if (seriesInfo.UniqueID.StartsWith("chk") && seriesInfo.UniqueID.Contains("_"))
                {
                    // IH设备复选框
                    CheckBox checkBox = FindControlByName<CheckBox>(seriesInfo.UniqueID);
                    if (checkBox != null)
                    {
                        checkBox.Checked = isChecked;
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"设置复选框状态时出错: {ex.Message}", true);
            }
        }

        // 递归检查或取消检查所有子节点
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
            }
        }

        #endregion

        private void btnToggleSettings_Click(object sender, EventArgs e)
        {
            // 切换Panel1的折叠状态
            splitContainer9.Panel1Collapsed = !splitContainer9.Panel1Collapsed;
        }

        // 刷新图表系列树状图
        private void RefreshChartSeriesTreeView()
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(RefreshChartSeriesTreeView));
                    return;
                }

                InitializeChartSeriesTreeView();
            }
            catch (Exception ex)
            {
                LogMessage($"刷新TreeView时出错: {ex.Message}", true);
            }
        }

        // 异步加载上一次的配置
        private async Task LoadLastConfigurationAsync()
        {
            try
            {
                // 在后台线程批量读取基础配置数据
                var configData = await Task.Run(() =>
                {
                    try
                    {
                        // 检查是否有保存的配置
                        string testKey = sqliteManager?.LoadSetting("LastConfig.Connection.DADevice");
                        if (string.IsNullOrEmpty(testKey))
                        {
                            return new Dictionary<string, string>();
                        }

                        var data = new Dictionary<string, string>();

                        // 读取配置区域的参数
                        var configKeys = new[]
                        {
                            "Connection.DADevice", "Connection.DADeviceAddress", "Connection.TempDeviceModel", "Connection.RealPort", "Connection.VirtualPort",
                            "Connection.PowerDeviceModel",
                            "Connection.IHDispPort", "Connection.IHDispBaudRate", "Connection.IHCtrlPort", "Connection.IHCtrlBaudRate",
                            "Connection.UploadPort", "Connection.UploadBaudRate",
                            "Temperature.Config", "IHDevice.Config", "PowerGrid.Config",
                            "General.RecordInterval", "General.USBPcapPath", "General.AutoDisconnectTime", "General.DebugMode"
                        };

                        // 使用批量读取优化数据库访问
                        if (sqliteManager != null)
                        {
                            var fullKeys = configKeys.Select(key => $"LastConfig.{key}").ToArray();
                            var batchResult = sqliteManager.LoadSettingsBatch(fullKeys);

                            foreach (var kvp in batchResult)
                            {
                                // 移除"LastConfig."前缀
                                string shortKey = kvp.Key.Replace("LastConfig.", "");
                                data[shortKey] = kvp.Value;
                            }
                        }

                        return data;
                    }
                    catch (Exception ex)
                    {
                        LogMessage($"后台读取基础配置数据失败: {ex.Message}", true);
                        return new Dictionary<string, string>();
                    }
                });

                if (configData.Count == 0)
                {
                    return;
                }

                // 设备连接配置
                LoadDeviceConnectionConfigFromDict(configData);

                // 其他通用设置
                LoadGeneralSettingsFromDict(configData);
            }
            catch (Exception ex)
            {
                LogMessage($"异步加载基础配置失败: {ex.Message}", true);
            }
        }
    }
}