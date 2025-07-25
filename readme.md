**多设备数据采集上位机技术文档**

# 主要类说明

## UartProcessSmartMonitor
负责与上报模块进行串口通信，用于查询和上传温升仪数据。

### 工作流程

运行机制分为“被动响应”和“主动上报”两个流程。

1.  **实例化与初始化**: `DAForm` 在启动时创建 `UartProcessSmartMonitor` 的实例，并传入自身的引用，以便后续能回调获取数据。当调用 `Connect()` 方法后，模块会打开指定串口并启动一个每秒触发一次的定时器。

2.  **硬件查询**:
      硬件通过串口发送查询指令。
      模块的 `SerialPort_DataReceived` 事件被触发，开始接收数据。
      `ProcessReceivedByte` 方法将零散的字节流组装成一个完整的数据帧，并通过 `VerifyChecksum` 方法进行校验。
      校验通过后，`ProcessCompletePacket` 解析指令，并调用 `ProcessStatusReportRequest` 进一步处理。
      模块遍历指令中请求的每一个“属性”(如通道101的名称、通道102的温度值)。
      对于每个属性请求，它会先调用 `DAForm.IsChannelCheckBoxChecked()` 确认该通道是否在UI上被勾选。只有勾选的通道才会被处理。
      接着，调用 `DAForm.GetTemperatureChannelCustomText()` 或 `DAForm.GetChannelTemperatureText()` 从主界面获取具体数据。
      获取到数据后，按照协议格式构建响应数据包，并通过 `SendResponse` 方法发回给硬件。

3.  **主动上报**:
    *   初始化时创建的定时器每秒触发一次 `AutoReportActiveChannels` 方法。
    *   该方法调用 `GetActiveChannelFuncIds()`，后者通过 `DAForm.IsChannelCheckBoxChecked()` 检查所有通道的勾选状态。
    *   它将所有已勾选的通道的名称汇集成一个列表。
    *   最后，将这个列表按照协议格式封装成一个“主动上报”数据包以5个通道一组分批次发送给硬件。

### 核心方法
- `DataReceivedHandler`: 处理串口接收到的数据 (入口)
- `ProcessReceivedByte`: 状态机实现，将串口的字节流组装成完整的数据帧。
- `ProcessAttributeRequest`: 核心业务逻辑，处理单个属性的查询请求，包括调用 `DAForm` 的方法获取数据和打包成响应格式。
- `GetActiveChannelFuncIds`: 遍历所有可能的通道，通过 `DAForm` 检查其是否被勾选，并返回所有已勾选通道的功能ID列表。这是实现主动上报和查询活动列表功能的基础。
- `AutoReportActiveChannels`: 定时器任务，周期性地将活动通道列表上报给硬件。
- `GetTemperatureChannelCustomText`: 获取通道自定义名称
- `GetChannelTemperatureText`: 获取通道温度值
- `IsChannelCheckBoxChecked`: 检查通道是否被选中

### 与 `DAForm` 的公共接口
- `bool IsChannelCheckBoxChecked(string checkBoxName)`: 检查名为`checkBoxName` (如 "chkChannel101") 的复选框是否被选中。
- `string GetTemperatureChannelCustomText(string checkBoxName)`: 获取通道复选框关联的自定义文本框中的内容（即通道名称）。
- `string GetChannelTemperatureText(int channelNumber)`: 获取指定通道号在UI上显示的温度值文本。

## UsbPcap
负责温升仪数据采集，通过USB数据包捕获方式获取温度数据。

### 工作流程

该模块采用外部工具调用和数据解析的方式实现温升仪数据采集。

1. **初始化与配置**: `DAForm` 创建 `UsbPcap` 实例时，模块会通过WMI查询系统USB总线数量和可用设备列表。根据温升仪型号（DAQ970A、34970A）设置相应的数据过滤器。

2. **USB数据捕获**:
   调用外部 `USBPcapCMD.exe` 工具开始监听指定USB设备的数据包。
   程序在后台线程中持续读取捕获工具的标准输出。
   接收到的原始字节流会根据设备类型进行不同处理。

3. **数据解析与过滤**:
   使用正则表达式识别不同类型的数据包（时间查询、温度数据、状态响应等）。
   对于温度数据，解析扫描起始时间，建立数据时间戳基准。
   从数据流中提取通道号、温度值和时间偏移量。
   通过 `TemperatureRowDataReceived` 事件将解析后的温度数据发送给 `DAForm`。

### 设备适配架构

#### 过滤器配置系统
```csharp
public class FilterConfig
{
    public string Name { get; set; }                    // 设备型号名称
    public byte[] Sequence { get; set; }                // 数据过滤序列
    public bool UseSequenceFilter { get; set; }         // 是否启用序列过滤
}
```

#### 设备型号
- **DAQ970A**: 使用序列过滤 `{0x01, 0x00, 0x00, 0x00}`
- **34970A**: 未适配  

### USB总线检测机制

系统启动时自动检测USB总线数量，并据此选择合适的USBPcap捕获器：
- **单总线系统**: 使用 `USBPcap1` 
- **多总线系统**: 使用 `USBPcap3` 

### 数据解析协议详解

#### 数据包类型识别

使用预编译正则表达式进行高效匹配：

```csharp
// 时间戳响应匹配 (格式: [时间戳]2025,05,16,15,11,04.153)
private static readonly Regex TimeMatchRegex = new Regex(
    @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\](\d{4},\d{2},\d{2},\d{2},\d{2},\d{2}\.\d{3})",
    RegexOptions.Compiled);

// 温度数据匹配 (格式: [时间戳]#279+2.49891981E+01 C,...)
private static readonly Regex TempDataRegex = new Regex(
    @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\]#\d+(.+)",
    RegexOptions.Compiled);

// 数据点查询匹配
private static readonly Regex DataPointRegex = new Regex(
    @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\]\+\d+",
    RegexOptions.Compiled);

// 通用查询匹配  
private static readonly Regex QueryRegex = new Regex(
    @"\[\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}\.\d{3}\]R\?\s\d+",
    RegexOptions.Compiled);
```

#### 温度数据解析流程

1. **扫描起始时间获取**
   - 发送 `SYSTem:TIME:SCAN?` 查询
   - 解析返回的时间戳格式：`YYYY,MM,DD,HH,MM,SS.mmm`
   - 建立数据时间基准

2. **温度数据包解析**
   ```
   数据格式: #279+2.49891981E+01 C,0.123,101,0,...
   解析步骤:
   - 提取温度值: +2.49891981E+01 C -> 24.9891981°C
   - 提取时间偏移: 0.123 秒
   - 提取通道号: 101
   - 第4个字段为是否开启温度报警 (通常为0)
   ```

3. **扫描周期检测**
   - 监控时间偏移量的变化
   - 当通道号开始变小式，判定为新扫描周期
   - 自动更新扫描起始时间

### 数据过滤机制

#### DAQ970A过滤算法
```csharp
private string FilterDataB(string input, byte[] targetSequence)
{
    // 1. 分离时间戳和数据部分
    // 2. 将数据转换为字节数组
    // 3. 在字节流中查找目标序列 {0x01, 0x00, 0x00, 0x00}
    // 4. 提取序列后的有效数据
    // 5. 重新组合时间戳和过滤后的数据
}
```

#### 34970A过滤算法
```csharp
private string FilterDataA(string input)
{
    // 未实现
    return input;
}
```

### 性能优化机制

#### 内存复用策略
- **字节缓冲区复用**: `reusableByteBuffer` 避免频繁内存分配
- **StringBuilder复用**: `hexStringBuilder`, `filterStringBuilder` 减少字符串操作开销
- **集合对象复用**: `reusableSegments`, `reusableChannelData` 避免临时对象创建
- **事件参数复用**: `reusableEventArgs` 减少事件触发时的内存分配

#### 时间戳缓存
```csharp
// 只有当时间变化超过10ms时才重新格式化时间戳
private string GetCachedTimestamp()
{
    if ((now - lastTimestampUpdate).TotalMilliseconds > 10)
    {
        cachedTimestamp = now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        lastTimestampUpdate = now;
    }
    return cachedTimestamp;
}
```

### 新设备型号集成指南

#### 1. 添加设备型号识别
在 `DeviceConnectionManager.ConnectDADevice()` 中添加新的case分支：
```csharp
case "新设备型号":
    usbPcap.SetFilter(new UsbPcap.FilterConfig
    {
        Name = "新设备型号",
        Sequence = new byte[] { /* 设备特定的过滤序列 */ },
        UseSequenceFilter = true  // 根据需要设置
    });
    break;
```

#### 2. 实现设备特定过滤器
在 `FilterData()` 方法中添加新的过滤逻辑：
```csharp
else if (currentFilter.Name == "新设备型号")
{
    result = FilterDataC(input, currentFilter.Sequence);  // 新的过滤方法
}
```

#### 3. 创建专用过滤方法
```csharp
private string FilterDataC(string input, byte[] targetSequence)
{
    // 实现设备特定的数据过滤逻辑
    // 参考 FilterDataB
}
```

#### 4. 调整数据解析逻辑
如果新设备的数据格式不同，需要在 `ParseTemperatureDataBlock()` 中添加设备特定的解析逻辑。

#### 5. 更新正则表达式
如果新设备使用不同的数据包格式，需要添加相应的正则表达式模式。

### 核心方法
- `StartCapture`: 启动USB数据包捕获，配置外部工具参数并开始后台数据读取
- `StopCapture`: 停止数据捕获，清理进程和缓冲区资源
- `GetUsbDevicesList`: 通过WMI查询系统中的USB设备列表
- `ParseTemperatureDataBlock`: 解析温度数据块，提取通道号和温度值
- `ParseAndDispatchTemperatureData`: 解析并分发温度数据，处理不同数据包类型
- `ProcessTemperatureDataPoint`: 处理单个温度数据点，包括扫描周期检测
- `SetFilter`: 设置数据过滤器，支持不同型号温升仪的协议
- `FilterData`: 根据设备型号选择相应的数据过滤方法
- `ResetScanningState`: 重置扫描状态，清理扫描相关变量

### 与外部工具的接口
- 依赖 `USBPcapCMD.exe` 工具进行实际的USB数据包捕获
- 通过命令行参数指定捕获设备和输出格式: `-d \\\\.\\USBPcap[1|3] -o - --devices [设备地址]`
- 支持多种温升仪型号的数据过滤规则
- 自动根据USB总线数量选择合适的捕获驱动


## VirtualPort
负责功率仪数据采集，通过虚拟串口拦截功率仪数据。

### 工作流程
1. **双串口桥接**: 同时打开物理串口和虚拟串口，在两者之间建立数据透传桥接。上位机软件连接虚拟串口，功率仪连接物理串口，所有数据都会被本模块拦截。

2. **数据拦截与缓冲**:
   监听双向数据流（上位机→功率仪、功率仪→上位机）。
   使用消息缓冲机制处理数据分片，确保完整协议帧的接收。
   通过帧头识别（0x55、0xAA）和长度校验确定消息边界。

3. **协议解析**:
   根据功率仪型号（青智8904F、致远仪器PV300）选择相应的解析算法。
   解析不同命令类型（0x34-电压电流功率参数、0x43-有功电能）。
   实现数据合并机制，将分散的电能与电压电流功率等参数合并为完整数据包。
   通过 `PowerDataReceived` 事件向 `DAForm` 发送解析后的功率数据。

### 协议解析详解

#### 帧结构识别
- **上位机请求帧**: 帧头 `0x55`，固定4字节长度
  ```
  结构: [0x55][地址][命令][校验和]
  校验: 除最后一字节外所有字节累加和
  ```

- **设备响应帧**: 帧头 `0xAA`，变长数据
  ```
  0x34命令(电压电流功率): 72字节数据包
  0x43命令(有功电能): 12字节数据包
  其他命令: 4字节基础包
  校验: 除最后一字节外所有字节累加和
  ```

#### 青智8904F数据解析
```csharp
// 0x34命令数据位置映射
Ua: 字节[3-6]    (第4-7字节)
Ub: 字节[19-22]  (第20-23字节)  
Uc: 字节[35-38]  (第36-39字节)
Ia: 字节[7-10]   (第8-11字节)
Ib: 字节[23-26]  (第24-27字节)
Ic: 字节[39-42]  (第40-43字节)
P:  字节[59-62]  (第60-63字节，总功率)
Freq: 字节[67-70] (第68-71字节，频率)

// 0x43命令数据位置映射  
En: 字节[3-6]    (第4-7字节，有功电能)
```

#### 数据合并机制
系统通过定时器实现智能数据合并：
1. **合并策略**: 同一秒内的0x34和0x43命令数据可以合并
2. **超时机制**: 500ms内未收到互补数据则单独发送
3. **数据完整性**: 合并后包含完整的电压、电流、功率和电能信息

### 支持的设备型号
- **青智8904F**: 完整实现，支持0x34和0x43命令解析
- **致远仪器PV300**: 预留接口，待实现

### 核心方法
- `Connect`: 建立双串口连接，支持完整串口参数配置(波特率、数据位、停止位、校验位、握手)
- `Disconnect`: 断开串口连接，清理资源和缓冲区
- `RealPort_DataReceived`: 处理物理端口数据接收，实现设备→上位机数据流
- `VirtualPort_DataReceived`: 处理虚拟端口数据接收，实现上位机→设备数据流
- `ProcessReceivedData`: 处理接收数据，执行协议帧识别和完整性检查
- `ParseDeviceResponse`: 根据功率仪型号分发数据到相应解析方法
- `ParseQingzhi8904F`: 解析青智8904F功率仪的通信协议，支持多命令类型
- `ParseFloat`: 将字节数组转换为IEEE754浮点数值
- `FlushPendingData`: 定时器回调，处理超时未合并的数据
- `GetPairedVirtualPort`: 自动计算虚拟串口对的配对端口号

## IHDevice
负责管理显示板和功率板的双串口通信，实现数据帧的识别、解析和分发。

### 主要特性
- **双板独立连接**: 支持显示板和功率板独立连接，可以单独工作
- **帧数据识别**: 自动识别和组装完整的数据帧
- **数据校验**: 使用校验和验证数据完整性
- **事件驱动**: 通过事件机制分发解析后的数据
- **资源管理**: 实现IDisposable接口，自动清理资源

### 协议常量
```csharp
private const byte FUNCTION_ID_CONTROL = 0x03;      // 显示板控制消息功能码
private const byte FUNCTION_ID_CTRL_RESP = 0xFC;    // 功率板响应消息功能码
private const byte CONTROL_FRAME_LENGTH = 13;       // 控制消息帧长度
private const byte RESPONSE_FRAME_LENGTH = 21;      // 响应消息帧长度
```

### 设备地址映射
```csharp
0x88 → "LR"  // 左后
0x99 → "LF"  // 左前
0xAA → "RR"  // 右后
0xBB → "RF"  // 右前
0xCC → "CLF" // 中左前
0xDD → "CLR" // 中左后
```

### 主要方法

#### 数据处理核心方法
```csharp
// 数据帧处理
private void ProcessDisplayData(byte[] data)        // 处理显示板数据流
private void ProcessPowerData(byte[] data)          // 处理功率板数据流
private void ProcessCompleteDisplayFrame(byte[] frame)  // 处理完整显示板帧
private void ProcessCompletePowerFrame(byte[] frame)    // 处理完整功率板帧

// 数据解析
private IHDisplayData ParseDisplayControlData(byte[] frame)  // 解析显示板控制数据
private IHPowerData ParsePowerResponseData(byte[] frame)     // 解析功率板响应数据

// 工具方法
private string GetPositionFromAddress(byte address)         // 地址转换为位置
private byte CalculateChecksum(byte[] data, int startIndex, int length)  // 计算校验和
```

### 事件定义
```csharp
public event EventHandler<IHDisplayDataEventArgs> DisplayDataReceived;  // 显示板数据接收事件
public event EventHandler<IHPowerDataEventArgs> PowerDataReceived;      // 功率板数据接收事件
public event EventHandler<LogMessageEventArgs> LogMessageAdded;         // 日志消息事件
public event EventHandler<RawDataEventArgs> RawDataReceived;            // 原始数据事件
```


## IHDisplayData - 显示板数据结构

### 功能概述
封装显示板发送的控制消息数据，包含19个参数。

### 主要属性
```csharp
// 基础信息
public string Position { get; set; }     // 炉头位置
public DateTime Timestamp { get; set; }  // 时间戳

// 19个相关参数
public bool HeatingFreqFollow { get; set; }        // 加热频率跟随标志
public bool chefsFunctionOnFlag { get; set; }      // 移锅控工激活标志
public bool InnerOuterRing { get; set; }           // 内外环标志
public bool allZone_BridgeHeatFlag { get; set; }   // 无区/桥接标志
public bool PPGMode { get; set; }                  // PPG模式标志
public bool AllowPanDetection { get; set; }        // 允许检锅标志
public bool PauseFlag { get; set; }                // 暂停标志
public bool StoveSwitch { get; set; }              // 炉头开关标志
public int RequestPower { get; set; }       // 请求功率值
public bool HeatFreqJitterFlag { get; set; } // 加热频率抖频标志
public int BridgeControl { get; set; }      // 无区/桥接控制
public int FanLevel { get; set; }           // 风机档位
public int DebugSubChannel { get; set; }    // DEBUG子通道号
public int DebugChannel { get; set; }       // DEBUG通道
public int NoiseControl { get; set; }       // 噪声控制
public int Disp_ReserveD1B7 { get; set; }  // D1字节B7预留位
public int Disp_ReserveD1B6 { get; set; }  // D1字节B6预留位
public int ReserveD7 { get; set; }          // D7字节预留
public int ReserveD8 { get; set; }          // D8字节预留
```

## IHPowerData - 功率板数据结构

### 功能概述
封装功率板发送的响应消息数据，包含18个参数。

### 主要属性
```csharp
// 基础信息
public string Position { get; set; }     // 炉头位置
public DateTime Timestamp { get; set; }  // 时间戳

// 18个相关参数
public int HeatNTC1 { get; set; }        // 加热盘温度传感器1 (10位精度)
public int HeatNTC2 { get; set; }        // 加热盘温度传感器2 (10位精度)
public int IGBTNTC1 { get; set; }        // IGBT温度传感器1 (10位精度)
public int IGBTNTC2 { get; set; }        // IGBT温度传感器2 (10位精度)
public int PanTemp { get; set; }         // 锅具受热品质值
public int MCUTemp { get; set; }         // 芯片温度
public int Freq { get; set; }            // 加热频率 (kHz)
public int Voltage { get; set; }         // 电压值 (V)
public int Power { get; set; }           // 功率值 (W)
public int ErrorCode { get; set; }       // 故障码
public int PollingState { get; set; }    // 检锅状态 (0=无锅, 1=主线盘有锅, 2=双线盘有锅)
public int FreqControlFlag { get; set; } // 频率控制标志
public int HeatFlag { get; set; }        // 同频标志
public int Power_ReserveD1B7 { get; set; }  // D1字节B7预留位
public int Power_ReserveD1B6 { get; set; }  // D1字节B6预留位
public int ReserveD14 { get; set; }          // D14字节预留
public int ReserveD15 { get; set; }          // D15字节预留
public int ReserveD16 { get; set; }          // D16字节预留
```

## IHPanelManager

### 功能概述
`IHPanelManager`类负责管理IH设备相关的界面控件，包括数据显示、图表更新、配置管理等功能。

### 界面交互功能
- **复选框双击编辑**: 双击复选框可编辑参数名称
- **数据新鲜度检测**: 自动检测数据是否过期（5秒超时）
- **图表集成**: 自动更新图表显示选中的参数
- **批量数据保存**: 默认1秒间隔批量保存数据到数据库

### 主要属性
```csharp
// 界面管理
private readonly DAForm mainForm;
private readonly ChartManager chartManager;

// 复选框管理
private readonly Dictionary<string, string> ihCheckboxTexts;        // 复选框文本映射
private readonly Dictionary<string, string> ihCheckboxOriginalTexts; // 原始文本备份
private readonly Dictionary<string, DateTime> ihTextBoxUpdateTimes;   // 更新时间记录

// 数据缓存
private Dictionary<string, string> ihDataCache;     // 数据缓存
private DateTime lastIHDataSaveTime;               // 最后保存时间
private readonly object ihDataCacheLock;           // 缓存锁

// 定时器
private readonly Timer ihDataFreshnessTimer;       // 数据保留时长定时器，超过5s未更新的数据会删除
private readonly Timer doubleClickTimer;           // 双击检测定时器，防止出发复选框选择导致无法修改名称

// 事件
public event EventHandler<LogMessageEventArgs> LogMessageAdded;           // 日志消息事件
public event Action<string, Dictionary<string, string>> DataCacheRequested;  // 数据缓存请求事件
public event Action NotifyTreeViewRefresh;                                // 树视图刷新通知事件
```

#### 设备位置和参数配置
```csharp
// 支持的设备位置
private static readonly string[] IH_POSITIONS = { "LR", "LF", "RR", "RF", "CLF", "CLR" };

// 显示板参数 (19个参数)
private static readonly string[] IH_DISPLAY_PARAMS = {
    "HeatingFreqFollow", "PanControlActive", "InnerOuterRing", "allZone_BridgeHeatFlag",
    "PPGMode", "AllowPanDetection", "PauseFlag", "StoveSwitch", "RequestPower",
    "HeatFreqJitterFlag", "BridgeControl", "FanLevel", "DebugSubChannel", "DebugChannel",
    "NoiseControl", "Disp_ReserveD1B6", "Disp_ReserveD1B7", "ReserveD7", "ReserveD8"
};

// 功率板参数 (18个参数)
private static readonly string[] IH_POWER_PARAMS = {
    "HeatNTC1", "HeatNTC2", "IGBTNTC1", "IGBTNTC2", "PanTemp", "Freq", "Voltage",
    "Power", "MCUTemp", "ErrorCode", "PollingState", "FreqControlFlag", "HeatFlag",
    "Power_ReserveD1B6", "Power_ReserveD1B7", "ReserveD14", "ReserveD15", "ReserveD16"
};
```

#### 初始化和数据更新
```csharp
public void Initialize()                           // 初始化界面控件
public void UpdateDisplayData(IHDisplayData data)  // 更新显示板数据到界面
public void UpdatePowerData(IHPowerData data)      // 更新功率板数据到界面
public void ClearAllTextBoxes()                   // 清空所有文本框
```

#### 配置管理
```csharp
public List<IHDeviceCheckBoxConfig> GetIHConfiguration()           // 获取配置（当前用户更新的名称和打勾内容）
public void ApplyIHConfiguration(List<IHDeviceCheckBoxConfig> config)  // 应用配置
public void RestoreDefaultConfiguration()                          // 恢复默认配置
```

#### 数据导出和选择
```csharp
public List<string> GetSelectedIHColumns()                        // 获取选中的列
public string GetIHDbColumnNameForDisplay(string displayName)     // 获取数据库列名
public List<ChartSeriesInfo> GetAvailableSeries()                 // 获取可用的图表系列
```

#### 数据缓存管理
```csharp
public void ForceFlushIHData()                                    // 强制刷新缓存数据
private void CacheIHDataForBatchSave(Dictionary<string, string> newData)  // 缓存数据
private void SaveCachedIHData(DateTime timestamp)                 // 保存缓存数据
```

### 基本用法
```csharp
// 创建IH设备实例
using (var ihDevice = new IHDevice())
{
    // 订阅事件
    ihDevice.DisplayDataReceived += OnDisplayDataReceived;
    ihDevice.PowerDataReceived += OnPowerDataReceived;
    
    // 连接设备
    bool dispConnected = ihDevice.ConnectDisplayBoard("COM3");
    bool powerConnected = ihDevice.ConnectPowerBoard("COM4");
    
    // 检查连接状态
    if (ihDevice.IsDispConnected && ihDevice.IsCtrlConnected)
    {
        Console.WriteLine("双板连接成功");
    }
}

// 创建界面管理器
var panelManager = new IHPanelManager(mainForm, chartManager);
panelManager.Initialize();

// 订阅数据更新事件
ihDevice.DisplayDataReceived += (sender, e) => panelManager.UpdateDisplayData(e.Data);
ihDevice.PowerDataReceived += (sender, e) => panelManager.UpdatePowerData(e.Data);
```

### 数据处理示例
```csharp
private void OnDisplayDataReceived(object sender, IHDisplayDataEventArgs e)
{
    var data = e.Data;
    Console.WriteLine($"位置: {data.Position}, 功率: {data.RequestPower}W, 风机: {data.FanLevel}级");
}

private void OnPowerDataReceived(object sender, IHPowerDataEventArgs e)
{
    var data = e.Data;
    Console.WriteLine($"位置: {data.Position}, 实际功率: {data.Power}W, 频率: {data.Freq}kHz");
}
```

## VirtualPort
负责功率仪数据采集，通过虚拟串口拦截功率仪数据。

### 工作流程
1. **双串口桥接**: 同时打开物理串口和虚拟串口，在两者之间建立数据透传桥接。上位机软件连接虚拟串口，功率仪连接物理串口，所有数据都会被本模块拦截。

2. **数据拦截与缓冲**:
   监听双向数据流（上位机→功率仪、功率仪→上位机）。
   使用消息缓冲机制处理数据分片，确保完整协议帧的接收。
   通过帧头识别（0x55、0xAA）和长度校验确定消息边界。

3. **协议解析**:
   根据功率仪型号（青智8904F、致远仪器PV300）选择相应的解析算法。
   解析不同命令类型（0x34-电压电流功率参数、0x43-有功电能）。
   实现数据合并机制，将分散的电能与电压电流功率等参数合并为完整数据包。
   通过 `PowerDataReceived` 事件向 `DAForm` 发送解析后的功率数据。

### 协议解析详解

#### 帧结构识别
- **上位机请求帧**: 帧头 `0x55`，固定4字节长度
  ```
  结构: [0x55][地址][命令][校验和]
  校验: 除最后一字节外所有字节累加和
  ```

- **设备响应帧**: 帧头 `0xAA`，变长数据
  ```
  0x34命令(电压电流功率): 72字节数据包
  0x43命令(有功电能): 12字节数据包
  其他命令: 4字节基础包
  校验: 除最后一字节外所有字节累加和
  ```

#### 青智8904F数据解析
```csharp
// 0x34命令数据位置映射
Ua: 字节[3-6]    (第4-7字节)
Ub: 字节[19-22]  (第20-23字节)  
Uc: 字节[35-38]  (第36-39字节)
Ia: 字节[7-10]   (第8-11字节)
Ib: 字节[23-26]  (第24-27字节)
Ic: 字节[39-42]  (第40-43字节)
P:  字节[59-62]  (第60-63字节，总功率)
Freq: 字节[67-70] (第68-71字节，频率)

// 0x43命令数据位置映射  
En: 字节[3-6]    (第4-7字节，有功电能)
```

#### 数据合并机制
系统通过定时器实现智能数据合并：
1. **合并策略**: 同一秒内的0x34和0x43命令数据可以合并
2. **超时机制**: 500ms内未收到互补数据则单独发送
3. **数据完整性**: 合并后包含完整的电压、电流、功率和电能信息

### 支持的设备型号
- **青智8904F**: 完整实现，支持0x34和0x43命令解析
- **致远仪器PV300**: 预留接口，待实现

### 核心方法
- `Connect`: 建立双串口连接，支持完整串口参数配置(波特率、数据位、停止位、校验位、握手)
- `Disconnect`: 断开串口连接，清理资源和缓冲区
- `RealPort_DataReceived`: 处理物理端口数据接收，实现设备→上位机数据流
- `VirtualPort_DataReceived`: 处理虚拟端口数据接收，实现上位机→设备数据流
- `ProcessReceivedData`: 处理接收数据，执行协议帧识别和完整性检查
- `ParseDeviceResponse`: 根据功率仪型号分发数据到相应解析方法
- `ParseQingzhi8904F`: 解析青智8904F功率仪的通信协议，支持多命令类型
- `ParseFloat`: 将字节数组转换为IEEE754浮点数值
- `FlushPendingData`: 定时器回调，处理超时未合并的数据
- `GetPairedVirtualPort`: 自动计算虚拟串口对的配对端口号



## SQLiteManager
负责所有数据库操作，使用SQLite存储历史数据。

### 工作流程
1. **数据库初始化**: 程序启动时自动创建数据库文件和表结构。

2. **数据存储**:
   接收来自各设备模块的数据并写入相应数据表。
   支持批量数据插入以提高性能。
   自动管理数据表列的动态添加（如新增温升仪通道）。

3. **数据查询与管理**:
   提供按时间范围、设备类型的数据查询接口。
   支持数据导出为CSV格式。
   提供数据清理功能，可按条件删除历史数据。
   管理程序配置信息的保存和加载。

### 核心方法
- `InitializeDatabase`: 初始化数据库，创建必要的表结构
- `SaveDeviceData`: 保存设备数据到数据库，支持多种数据类型
- `LoadDeviceData`: 按条件查询历史数据
- `ClearDeviceData`: 清理指定条件的历史数据
- `SaveSetting`: 保存程序配置到数据库
- `LoadSetting`: 从数据库加载程序配置
- `ExecuteQuery`: 执行SQL查询并返回结果集

### 数据表结构
- 每种设备类型使用独立的数据表存储
- 支持动态列添加适应设备通道变化
- 统一的时间戳字段用于数据关联查询

## ChartManager
负责界面图表显示。

### 工作流程

该模块管理实时数据图表的创建、更新和显示效果。

1. **图表系列管理**: 根据设备数据类型动态创建数据系列（温升仪通道、功率参数、IH参数等）。支持数据系列的显示/隐藏切换。

2. **数据点更新**:
   接收来自各设备的实时数据并添加到对应图表系列。
   实现数据点的时间轴同步显示。
   实现数据点的鼠标悬停显示详细信息。
   支持主副Y轴分离显示不同量程的数据。
   自动管理图表显示范围和缩放。
   
### 核心方法
- `AddOrUpdateData`: 向指定数据系列添加或更新数据点
- `ShowSeries`: 显示指定的数据系列
- `HideSeries`: 隐藏指定的数据系列
- `Clear`: 清空所有图表数据
- `RenameSeries`: 重命名数据系列标签
- `SetAxisConfiguration`: 配置图表轴参数
- `RefreshChart`: 刷新图表显示

## DeviceConnectionManager
统一管理所有设备的连接状态和配置。

### 工作流程
1. **连接状态协调**: 维护所有设备（温升仪、功率仪、IH设备、上报模块）的连接状态。

2. **设备配置管理**:
   根据设备类型应用相应的连接参数（串口、波特率、设备地址等）。
   处理设备特定的初始化设置（如温升仪过滤器配置）。
   管理连接顺序和依赖关系。

3. **状态监控与反馈**:
   实时监控各设备的连接状态变化。
   通过事件机制向主界面报告连接结果和错误信息。
   提供设备连接诊断和故障排除信息。

### 核心方法
- `ConnectAllSelectedDevices`: 连接所有选中的设备，按顺序执行连接流程
- `DisconnectAllDevices`: 断开所有已连接设备
- `IsAnyDeviceConnected`: 检查是否有任何设备处于连接状态
- `ConnectDADevice`: 连接温升仪设备，配置USB捕获参数
- `ConnectPowerDevice`: 连接功率仪设备，建立虚拟串口桥接
- `ConnectIHDevice`: 连接IH设备的显示板和功率板

### 设备连接配置
- 封装各设备的连接参数为统一配置对象
- 支持连接参数的保存和恢复
- 提供连接状态的统一查询接口

## PowerGridManager
管理功率仪数据表格显示和列配置。

### 工作流程
1. **表格列管理**: 动态创建和管理功率仪数据表格的列（电压、电流、功率、频率等）。

2. **数据填充**:
   接收来自 `VirtualPort` 的功率仪数据。
   将数据按列格式化并添加到表格行。
   实现数据的实时更新和历史记录保持。
   支持用户对表格列标题进行重命名。
   
### 核心方法
- `AddPowerDataToGrid`: 向表格添加新的功率仪数据行
- `GetSelectedColumnDisplayNames`: 获取当前选中列的显示名称

## CSVExportManager
处理各类数据的导出功能。

### 工作流程
1. **导出配置**: 提供用户界面让用户选择导出的数据。

2. **数据查询与处理**:
   从SQLite数据库查询指定数据的历史数据。
   对查询结果进行格式化和数据清理。
   处理数据的时间同步和对齐。

### 核心方法
- `ExportAsync`: 显示导出配置对话框并执行数据导出
- `AutoSaveDataAsync`: 自动保存数据，无需用户交互
- `QueryDataForExport`: 从数据库查询需要导出的数据
- `FormatDataForCSV`: 将数据格式化为CSV格式
- `GenerateFileName`: 根据规则生成导出文件名

### 导出配置选项
- 灵活的时间范围选择（绝对时间、相对时间）
- 可选的数据列配置
- 多种文件命名和路径选项

## TemperaturePanelManager
管理温升仪界面控件和用户交互。

### 工作流程
1. **控件动态管理**: 管理所有温升仪通道的复选框和文本框控件。支持通道控件的批量操作（全选、清除等）。处理控件的显示状态和数据绑定。

2. **用户交互处理**:
   响应用户对通道复选框的选择操作。
   支持通道名称的双击编辑功能。
   处理通道数据的实时更新显示。
   与图表管理器协调选中通道的图表显示。

3. **数据同步**:
   将最新的温度数据更新到对应的文本框显示。
   保存用户自定义的通道名称。
   与数据库模块同步通道配置信息。

### 核心方法
- `UpdateChannelTextBox`: 更新指定通道的温度显示值
- `GetSelectedTemperatureChannels`: 获取所有被选中的温度通道列表
- `EditCheckBoxText`: 编辑通道的自定义名称
- `SelectAllChannels`: 全选所有温度通道
- `ClearAllSelections`: 清除所有通道选择
- `SaveChannelConfiguration`: 保存通道配置到数据库

### 界面控件管理
- 支持多卡槽、多通道的复杂界面布局
- 提供直观的用户交互体验
- 与主界面的其他功能模块协调工作

# 控件名称列表

## IH 显示板控件
*以 LF（左前）区域为例，其他区域（LR, RF, RR, CLF, CLR）控件命名与功能类似。*
- `chkLF_HeatingFreqFollow` + `LF_HeatingFreqFollow_TextBox` - 加热频率跟随标志
- `chkLF_PanControlActive` + `LF_PanControlActive_TextBox` - 移锅控功激活标志  
- `chkLF_InnerOuterRing` + `LF_InnerOuterRing_TextBox` - 内外环标志
- `chkLF_allZone_BridgeHeatFlag` + `LF_allZone_BridgeHeatFlag_TextBox` - 无区/桥接标志/三环（红外）
- `chkLF_PPGMode` + `LF_PPGMode_TextBox` - PPG模式标志
- `chkLF_AllowPanDetection` + `LF_AllowPanDetection_TextBox` - 允许检锅标志
- `chkLF_PauseFlag` + `LF_PauseFlag_TextBox` - 暂停标志
- `chkLF_StoveSwitch` + `LF_StoveSwitch_TextBox` - 炉头开关标志
- `chkLF_HeatFreqJitterFlag` + `LF_HeatFreqJitterFlag_TextBox` - 加热频率抖频标志
- `chkLF_NoiseControl` + `LF_NoiseControl_TextBox` - 噪声处理指令
- `chkLF_FanLevel` + `LF_FanLevel_TextBox` - 风机档位
- `chkLF_BridgeControl` + `LF_BridgeControl_TextBox` - 无区/桥接控制指令
- `chkLF_DebugSubChannel` + `LF_DebugSubChannel_TextBox` - Debug子通道号
- `chkLF_DebugChannel` + `LF_DebugChannel_TextBox` - Debug通道号
- `chkLF_RequestPower` + `LF_RequestPower_TextBox` - 请求功率值
- `chkLF_Disp_ReserveD1B7` + `LF_Disp_ReserveD1B7_TextBox` - 预留位
- `chkLF_Disp_ReserveD1B6` + `LF_Disp_ReserveD1B6_TextBox` - 预留位
- `chkLF_ReserveD7` + `LF_ReserveD7_TextBox` - 预留位
- `chkLF_ReserveD8` + `LF_ReserveD8_TextBox` - 预留位

## IH 功率板控件
*以 LF（左前）区域为例。*
- `chkLF_HeatNTC1` + `LF_HeatNTC1_TextBox` - HeatNTC1
- `chkLF_HeatNTC2` + `LF_HeatNTC2_TextBox` - HeatNTC2
- `chkLF_IGBTNTC1` + `LF_IGBTNTC1_TextBox` - IGBTNTC1
- `chkLF_IGBTNTC2` + `LF_IGBTNTC2_TextBox` - IGBTNTC2
- `chkLF_PanTemp` + `LF_PanTemp_TextBox` - 受热品质
- `chkLF_Freq` + `LF_Freq_TextBox` - 加热频率
- `chkLF_Voltage` + `LF_Voltage_TextBox` - 电压
- `chkLF_Power` + `LF_Power_TextBox` - 功率
- `chkLF_MCUTemp` + `LF_MCUTemp_TextBox` - 芯片温度
- `chkLF_ErrorCode` + `LF_ErrorCode` - 错误码
- `chkLF_PollingState` + `LF_PollingState` - 检锅状态
- `chkLF_FreqControlFlag` + `LF_FreqControlFlag` - 频率控制标志
- `chkLF_HeatFlag` + `LF_HeatFlag` - 同频标志
- `chkLF_Power_ReserveD1B7` + `LF_Power_ReserveD1B7_TextBox` - 预留位
- `chkLF_Power_ReserveD1B6` + `LF_Power_ReserveD1B6_TextBox` - 预留位
- `chkLF_ReserveD14` + `LF_ReserveD14_TextBox` - 预留位
- `chkLF_ReserveD15` + `LF_ReserveD15_TextBox` - 预留位
- `chkLF_ReserveD16` + `LF_ReserveD16_TextBox` - 预留位

## 温升仪通道控件
- `chkChannel[1-3]xx` (e.g., `chkChannel101` ... `chkChannel120`): 各设备通道选择复选框。
- `txtChannel[1-3]xx` (e.g., `txtChannel101` ... `txtChannel120`): 各设备通道自定义名称/温度值文本框。

## 连接与配置控件
### 端口与设备配置
- `cmbDAList`: 温升仪USB设备列表。
- `Disp_comboBoxPortName`: IH显示板串口选择。
- `Ctrl_comboBoxPortName`: IH功率板串口选择。
- `cmbRealPort`: 功率仪物理串口选择。
- `cmbVirtualPort1`: 功率仪虚拟串口选择。
- `cmbUploadPort`: 上报模块串口选择。
- `TbDeviceAddress_DA`: 温升仪设备地址。
- `Disp_comboBoxBaudRate`: IH显示板波特率。
- `Ctrl_comboBoxBaudRate`: IH功率板波特率。
- `cmbUploadBaudRate`: 上报模块波特率。
- `cmbTempDevice`: 温升设备类型选择。
- `cmbPowerDevice`: 功率设备类型选择。

### 参数配置
- `tbUSBPcapPath`: USBPcap 工具的可执行文件路径。
- `txtRecordInterval`: 数据自动记录的时间间隔（秒）。
- `txtAutoDisconnect`: 无操作时自动断开连接的时间（分钟）。

### 主要操作按钮
- `btnStart`: 连接所有选定设备。
- `btnStop`: 断开所有设备。
- `btnRefreshPorts`: 刷新可用串口列表。
- `btnSaveConfigure`: 保存当前配置到文件。
- `btnLoadConfigure`: 从文件加载配置。
- `btnCapture`: 截图功能。
- `btnClear`: 清除画面中所有数据以及数据库数据。
- `btnData`: 导出数据。
