using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;

namespace DA
{
    // 设备连接类 - 管理所有硬件设备的连接和断开逻辑
    public class DeviceConnectionManager
    {
        // 设备实例
        private UsbPcap usbPcap;
        private VirtualPort virtualPort;
        private IHDevice ihDevice;
        private UartProcessSmartMonitor smartMonitor;
        private SerialPort uploadPort;

        // 连接状态标志
        private bool isUSBPcapConnected = false;
        private bool isVirtualConnected = false;
        private bool isIHDispConnected = false;
        private bool isIHCtrlConnected = false;
        private bool isUploadConnected = false;

        // 事件定义
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event EventHandler<string> StatusChanged;

        public DeviceConnectionManager(UsbPcap usbPcap, VirtualPort virtualPort, IHDevice ihDevice,
            UartProcessSmartMonitor smartMonitor)
        {
            this.usbPcap = usbPcap;
            this.virtualPort = virtualPort;
            this.ihDevice = ihDevice;
            this.smartMonitor = smartMonitor;
        }

        // 连接所有选中的设备
        public bool ConnectAllSelectedDevices(DeviceConnectionConfig config)
        {
            bool hasValidSelection = false;
            List<string> connectedDevices = new List<string>();

            try
            {
                // 检查是否有任何设备被选择
                bool hasDADevice = !string.IsNullOrEmpty(config.DADeviceName);
                bool hasPowerDevice = !string.IsNullOrEmpty(config.RealPortName) &&
                                     !string.IsNullOrEmpty(config.VirtualPortName);
                bool hasIHDevice = !string.IsNullOrEmpty(config.IHDispPortName) ||
                                  !string.IsNullOrEmpty(config.IHCtrlPortName);
                bool hasUploadDevice = !string.IsNullOrEmpty(config.UploadPortName);

                if (!hasDADevice && !hasPowerDevice && !hasIHDevice && !hasUploadDevice)
                {
                    OnLogMessage("请至少选择一个设备", true);
                    return false;
                }

                // 1. 连接温升仪设备
                if (hasDADevice)
                {
                    if (ConnectDADevice(config))
                    {
                        isUSBPcapConnected = true;
                        hasValidSelection = true;
                        connectedDevices.Add("温升仪");
                    }
                }

                // 2. 连接功率仪设备
                if (hasPowerDevice)
                {
                    if (ConnectPowerDevice(config))
                    {
                        isVirtualConnected = true;
                        hasValidSelection = true;
                        connectedDevices.Add("功率仪");
                    }
                }

                // 3. 连接IH设备
                if (hasIHDevice)
                {
                    if (ConnectIHDevice(config))
                    {
                        hasValidSelection = true;
                        connectedDevices.Add("IH设备");
                    }
                }

                // 4. 连接上报模块设备
                if (hasUploadDevice)
                {
                    if (ConnectUploadDevice(config))
                    {
                        isUploadConnected = true;
                        hasValidSelection = true;
                        connectedDevices.Add("上报模块");
                    }
                }

                if (hasValidSelection && connectedDevices.Count > 0)
                {
                    OnStatusChanged($"已连接: {string.Join("、", connectedDevices)}");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                OnLogMessage($"连接设备时出错: {ex.Message}", true);
                return false;
            }
        }

        // 断开所有设备连接       
        public void DisconnectAllDevices()
        {
            try
            {
                // 立即重置所有连接标志
                isUSBPcapConnected = false;
                isVirtualConnected = false;
                isIHDispConnected = false;
                isIHCtrlConnected = false;
                isUploadConnected = false;

                // 断开所有设备
                DisconnectDADevice();
                DisconnectPowerDevice();
                DisconnectIHDevice();
                DisconnectUploadDevice();

                OnStatusChanged("已断开连接");
                OnLogMessage("所有设备断开完成");
            }
            catch (Exception ex)
            {
                OnLogMessage($"断开设备连接时出错: {ex.Message}", true);
            }
        }

        #region 温升仪设备连接管理

        private bool ConnectDADevice(DeviceConnectionConfig config)
        {
            try
            {
                if (string.IsNullOrEmpty(config.DADeviceAddress))
                {
                    OnLogMessage("请输入温升仪设备地址", true);
                    return false;
                }

                // 设置设备地址
                usbPcap.SetDeviceAddress(config.DADeviceAddress);

                // 根据选择的温升仪型号设置过滤器
                switch (config.TempDeviceModel)
                {
                    case "DAQ970A":
                        usbPcap.SetFilter(new UsbPcap.FilterConfig
                        {
                            Name = "DAQ970A",
                            Sequence = new byte[] { 0x01, 0x00, 0x00, 0x00 }
                        });
                        break;
                    case "34970A":
                        usbPcap.SetFilter(new UsbPcap.FilterConfig
                        {
                            Name = "34970A"
                        });
                        break;
                    default:
                        usbPcap.SetFilter(UsbPcap.FilterConfig.Default);
                        break;
                }

                // 执行USB连接
                usbPcap.StartCapture(config.DADeviceName);
                OnLogMessage($"温升仪设备 ({config.TempDeviceModel}) 已连接，地址: {config.DADeviceAddress}");
                return true;
            }
            catch (Exception ex)
            {
                OnLogMessage($"温升仪连接失败: {ex.Message}", true);
                return false;
            }
        }

        private void DisconnectDADevice()
        {
            try
            {
                usbPcap?.StopCapture();
            }
            catch (Exception ex)
            {
                OnLogMessage($"断开温升仪连接时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region 功率仪设备连接管理

        private bool ConnectPowerDevice(DeviceConnectionConfig config)
        {
            try
            {
                if (string.IsNullOrEmpty(config.PowerDeviceModel))
                {
                    return false;
                }

                if (config.RealPortName == config.VirtualPortName)
                {
                    OnLogMessage("物理端口和虚拟端口不能相同", true);
                    return false;
                }

                bool connected = virtualPort.Connect(
                    config.RealPortName,
                    config.VirtualPortName,
                    config.PowerDeviceModel, // 传递设备型号
                    9600,
                    Parity.None,
                    8,
                    StopBits.One,
                    Handshake.None);

                if (connected)
                {
                    OnLogMessage($"功率仪设备已连接 - 物理端口: {config.RealPortName}, 虚拟端口: {config.VirtualPortName}");
                    return true;
                }
                else
                {
                    OnLogMessage("功率仪连接失败，请检查串口设置", true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"功率仪连接失败: {ex.Message}", true);
                return false;
            }
        }

        private void DisconnectPowerDevice()
        {
            try
            {
                virtualPort?.Disconnect();
            }
            catch (Exception ex)
            {
                OnLogMessage($"断开功率仪连接时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region IH设备连接管理

        private bool ConnectIHDevice(DeviceConnectionConfig config)
        {
            try
            {
                bool success = true;

                // 检查端口冲突
                if (!string.IsNullOrEmpty(config.IHDispPortName) &&
                    !string.IsNullOrEmpty(config.IHCtrlPortName) &&
                    config.IHDispPortName == config.IHCtrlPortName)
                {
                    OnLogMessage("显示板和功率板不能使用相同的串口", true);
                    return false;
                }

                // 连接显示板
                if (!string.IsNullOrEmpty(config.IHDispPortName))
                {
                    if (ihDevice.ConnectDisplayBoard(config.IHDispPortName, config.IHDispBaudRate))
                    {
                        isIHDispConnected = true;
                        OnLogMessage("IH显示板连接成功");
                    }
                    else
                    {
                        OnLogMessage("IH显示板连接失败", true);
                        success = false;
                    }
                }

                // 连接功率板
                if (!string.IsNullOrEmpty(config.IHCtrlPortName))
                {
                    if (ihDevice.ConnectPowerBoard(config.IHCtrlPortName, config.IHCtrlBaudRate))
                    {
                        isIHCtrlConnected = true;
                        OnLogMessage("IH功率板连接成功");
                    }
                    else
                    {
                        OnLogMessage("IH功率板连接失败", true);
                        success = false;
                    }
                }

                return success;
            }
            catch (Exception ex)
            {
                OnLogMessage($"连接IH设备时出错: {ex.Message}", true);
                return false;
            }
        }

        private void DisconnectIHDevice()
        {
            try
            {
                ihDevice?.Disconnect();
            }
            catch (Exception ex)
            {
                OnLogMessage($"断开IH设备连接时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region 上报模块设备连接管理

        private bool ConnectUploadDevice(DeviceConnectionConfig config)
        {
            try
            {
                if (uploadPort != null && uploadPort.IsOpen)
                {
                    return false;
                }

                if (smartMonitor.IsConnected)
                {
                    return false;
                }

                bool connected = smartMonitor.Connect(config.UploadPortName, config.UploadBaudRate);
                if (connected)
                {
                    OnLogMessage($"上报模块设备已连接 - 端口: {config.UploadPortName}, 波特率: {config.UploadBaudRate}");
                    return true;
                }
                else
                {
                    OnLogMessage("上报模块连接失败", true);
                    return false;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"上报模块连接失败: {ex.Message}", true);
                return false;
            }
        }

        private void DisconnectUploadDevice()
        {
            try
            {
                smartMonitor?.Disconnect();
                if (uploadPort?.IsOpen == true)
                {
                    uploadPort.Close();
                    uploadPort.Dispose();
                    uploadPort = null;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"断开上报模块连接时出错: {ex.Message}", true);
            }
        }

        #endregion

        #region 连接状态查询

        public bool IsAnyDeviceConnected => isUSBPcapConnected || isVirtualConnected ||
                                           isIHDispConnected || isIHCtrlConnected || isUploadConnected;

        public bool IsUSBPcapConnected => isUSBPcapConnected;
        public bool IsVirtualConnected => isVirtualConnected;
        public bool IsIHDispConnected => isIHDispConnected;
        public bool IsIHCtrlConnected => isIHCtrlConnected;
        public bool IsUploadConnected => isUploadConnected;

        #endregion

        #region 事件触发方法

        private void OnLogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        private void OnStatusChanged(string status)
        {
            StatusChanged?.Invoke(this, status);
        }

        #endregion
    }

    // 设备连接配置类   
    public class DeviceConnectionConfig
    {
        // 温升仪配置
        public string DADeviceName { get; set; }
        public string DADeviceAddress { get; set; }
        public string TempDeviceModel { get; set; }

        // 功率仪配置
        public string RealPortName { get; set; }
        public string VirtualPortName { get; set; }
        public string PowerDeviceModel { get; set; }

        // IH设备串口
        public string IHDispPortName { get; set; }
        public int IHDispBaudRate { get; set; } = 4800;
        public string IHCtrlPortName { get; set; }
        public int IHCtrlBaudRate { get; set; } = 4800;

        // 上报模块配置
        public string UploadPortName { get; set; }
        public int UploadBaudRate { get; set; } = 9600;
    }
}
