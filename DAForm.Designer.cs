using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace DA
{
    partial class DAForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.mainIHPanel = new System.Windows.Forms.Panel();
            this.panelLF = new System.Windows.Forms.Panel();
            this.lblLF_PollingState = new System.Windows.Forms.Label();
            this.splitContainer6_LFDisp = new System.Windows.Forms.SplitContainer();
            this.groupBoxLF_Display = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LF_ReserveD8_TextBox = new System.Windows.Forms.TextBox();
            this.LF_ReserveD7_TextBox = new System.Windows.Forms.TextBox();
            this.LF_Disp_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.LF_Disp_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_ReserveD8 = new System.Windows.Forms.CheckBox();
            this.chkLF_ReserveD7 = new System.Windows.Forms.CheckBox();
            this.chkLF_Disp_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.LF_RequestPower_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_PanControlActive = new System.Windows.Forms.CheckBox();
            this.chkLF_RequestPower = new System.Windows.Forms.CheckBox();
            this.LF_PanControlActive_TextBox = new System.Windows.Forms.TextBox();
            this.LF_DebugChannel_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_InnerOuterRing = new System.Windows.Forms.CheckBox();
            this.LF_InnerOuterRing_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_DebugChannel = new System.Windows.Forms.CheckBox();
            this.chkLF_PauseFlag = new System.Windows.Forms.CheckBox();
            this.LF_DebugSubChannel_TextBox = new System.Windows.Forms.TextBox();
            this.LF_PauseFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_allZone_BridgeHeatFlag = new System.Windows.Forms.CheckBox();
            this.chkLF_DebugSubChannel = new System.Windows.Forms.CheckBox();
            this.LF_allZone_BridgeHeatFlag_TextBox = new System.Windows.Forms.TextBox();
            this.LF_BridgeControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_PPGMode = new System.Windows.Forms.CheckBox();
            this.chkLF_StoveSwitch = new System.Windows.Forms.CheckBox();
            this.chkLF_BridgeControl = new System.Windows.Forms.CheckBox();
            this.LF_PPGMode_TextBox = new System.Windows.Forms.TextBox();
            this.LF_FanLevel_TextBox = new System.Windows.Forms.TextBox();
            this.LF_StoveSwitch_TextBox = new System.Windows.Forms.TextBox();
            this.LF_AllowPanDetection_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_FanLevel = new System.Windows.Forms.CheckBox();
            this.chkLF_AllowPanDetection = new System.Windows.Forms.CheckBox();
            this.LF_NoiseControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_HeatFreqJitterFlag = new System.Windows.Forms.CheckBox();
            this.LF_HeatFreqJitterFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_NoiseControl = new System.Windows.Forms.CheckBox();
            this.LF_HeatingFreqFollow_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_HeatingFreqFollow = new System.Windows.Forms.CheckBox();
            this.chkLF_Disp_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.splitContainer3_LFControl = new System.Windows.Forms.SplitContainer();
            this.groupBoxLF_Power = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LF_ReserveD16_TextBox = new System.Windows.Forms.TextBox();
            this.LF_ReserveD15_TextBox = new System.Windows.Forms.TextBox();
            this.LF_ReserveD14_TextBox = new System.Windows.Forms.TextBox();
            this.LF_Power_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.LF_Power_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_Power_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.chkLF_PollingState = new System.Windows.Forms.CheckBox();
            this.LF_PollingState = new System.Windows.Forms.TextBox();
            this.chkLF_FreqControlFlag = new System.Windows.Forms.CheckBox();
            this.chkLF_HeatFlag = new System.Windows.Forms.CheckBox();
            this.LF_FreqControlFlag = new System.Windows.Forms.TextBox();
            this.LF_HeatFlag = new System.Windows.Forms.TextBox();
            this.LF_HeatNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_HeatNTC2 = new System.Windows.Forms.CheckBox();
            this.chkLF_HeatNTC1 = new System.Windows.Forms.CheckBox();
            this.LF_HeatNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_IGBTNTC1 = new System.Windows.Forms.CheckBox();
            this.LF_IGBTNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_IGBTNTC2 = new System.Windows.Forms.CheckBox();
            this.LF_ErrorCode = new System.Windows.Forms.TextBox();
            this.LF_IGBTNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_PanTemp = new System.Windows.Forms.CheckBox();
            this.LF_PanTemp_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_Freq = new System.Windows.Forms.CheckBox();
            this.LF_Freq_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_ErrorCode = new System.Windows.Forms.CheckBox();
            this.chkLF_Voltage = new System.Windows.Forms.CheckBox();
            this.LF_MCUTemp_TextBox = new System.Windows.Forms.TextBox();
            this.LF_Voltage_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_Power = new System.Windows.Forms.CheckBox();
            this.chkLF_MCUTemp = new System.Windows.Forms.CheckBox();
            this.LF_Power_TextBox = new System.Windows.Forms.TextBox();
            this.chkLF_Power_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkLF_ReserveD14 = new System.Windows.Forms.CheckBox();
            this.chkLF_ReserveD15 = new System.Windows.Forms.CheckBox();
            this.chkLF_ReserveD16 = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxLR_Display = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.LR_ReserveD8_TextBox = new System.Windows.Forms.TextBox();
            this.LR_ReserveD7_TextBox = new System.Windows.Forms.TextBox();
            this.LR_Disp_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.LR_Disp_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_ReserveD8 = new System.Windows.Forms.CheckBox();
            this.chkLR_ReserveD7 = new System.Windows.Forms.CheckBox();
            this.chkLR_Disp_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkLR_Disp_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.LR_RequestPower_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_HeatingFreqFollow = new System.Windows.Forms.CheckBox();
            this.chkLR_PanControlActive = new System.Windows.Forms.CheckBox();
            this.LR_HeatingFreqFollow_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_RequestPower = new System.Windows.Forms.CheckBox();
            this.LR_PanControlActive_TextBox = new System.Windows.Forms.TextBox();
            this.LR_DebugChannel_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_InnerOuterRing = new System.Windows.Forms.CheckBox();
            this.LR_InnerOuterRing_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_DebugChannel = new System.Windows.Forms.CheckBox();
            this.chkLR_PauseFlag = new System.Windows.Forms.CheckBox();
            this.LR_DebugSubChannel_TextBox = new System.Windows.Forms.TextBox();
            this.LR_PauseFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_allZone_BridgeHeatFlag = new System.Windows.Forms.CheckBox();
            this.chkLR_DebugSubChannel = new System.Windows.Forms.CheckBox();
            this.LR_allZone_BridgeHeatFlag_TextBox = new System.Windows.Forms.TextBox();
            this.LR_BridgeControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_PPGMode = new System.Windows.Forms.CheckBox();
            this.chkLR_StoveSwitch = new System.Windows.Forms.CheckBox();
            this.chkLR_BridgeControl = new System.Windows.Forms.CheckBox();
            this.LR_PPGMode_TextBox = new System.Windows.Forms.TextBox();
            this.LR_FanLevel_TextBox = new System.Windows.Forms.TextBox();
            this.LR_StoveSwitch_TextBox = new System.Windows.Forms.TextBox();
            this.LR_AllowPanDetection_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_FanLevel = new System.Windows.Forms.CheckBox();
            this.chkLR_AllowPanDetection = new System.Windows.Forms.CheckBox();
            this.LR_NoiseControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_HeatFreqJitterFlag = new System.Windows.Forms.CheckBox();
            this.LR_HeatFreqJitterFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_NoiseControl = new System.Windows.Forms.CheckBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxLR_Power = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.LR_ReserveD16_TextBox = new System.Windows.Forms.TextBox();
            this.LR_ReserveD15_TextBox = new System.Windows.Forms.TextBox();
            this.LR_ReserveD14_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_ReserveD16 = new System.Windows.Forms.CheckBox();
            this.chkLR_PollingState = new System.Windows.Forms.CheckBox();
            this.LR_PollingState = new System.Windows.Forms.TextBox();
            this.chkLR_FreqControlFlag = new System.Windows.Forms.CheckBox();
            this.chkLR_HeatFlag = new System.Windows.Forms.CheckBox();
            this.LR_FreqControlFlag = new System.Windows.Forms.TextBox();
            this.LR_HeatFlag = new System.Windows.Forms.TextBox();
            this.LR_HeatNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_HeatNTC2 = new System.Windows.Forms.CheckBox();
            this.chkLR_HeatNTC1 = new System.Windows.Forms.CheckBox();
            this.LR_HeatNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_IGBTNTC1 = new System.Windows.Forms.CheckBox();
            this.LR_IGBTNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_IGBTNTC2 = new System.Windows.Forms.CheckBox();
            this.LR_ErrorCode = new System.Windows.Forms.TextBox();
            this.LR_IGBTNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_PanTemp = new System.Windows.Forms.CheckBox();
            this.LR_PanTemp_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_Freq = new System.Windows.Forms.CheckBox();
            this.LR_Freq_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_ErrorCode = new System.Windows.Forms.CheckBox();
            this.chkLR_Voltage = new System.Windows.Forms.CheckBox();
            this.LR_MCUTemp_TextBox = new System.Windows.Forms.TextBox();
            this.LR_Voltage_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_Power = new System.Windows.Forms.CheckBox();
            this.chkLR_MCUTemp = new System.Windows.Forms.CheckBox();
            this.LR_Power_TextBox = new System.Windows.Forms.TextBox();
            this.chkLR_Power_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.chkLR_Power_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkLR_ReserveD14 = new System.Windows.Forms.CheckBox();
            this.chkLR_ReserveD15 = new System.Windows.Forms.CheckBox();
            this.LR_Power_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.LR_Power_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.RF_ReserveD8_TextBox = new System.Windows.Forms.TextBox();
            this.RF_ReserveD7_TextBox = new System.Windows.Forms.TextBox();
            this.RF_Disp_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.RF_Disp_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_ReserveD8 = new System.Windows.Forms.CheckBox();
            this.chkRF_ReserveD7 = new System.Windows.Forms.CheckBox();
            this.chkRF_Disp_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkRF_Disp_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.RF_RequestPower_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_HeatingFreqFollow = new System.Windows.Forms.CheckBox();
            this.chkRF_PanControlActive = new System.Windows.Forms.CheckBox();
            this.RF_HeatingFreqFollow_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_RequestPower = new System.Windows.Forms.CheckBox();
            this.RF_PanControlActive_TextBox = new System.Windows.Forms.TextBox();
            this.RF_DebugChannel_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_InnerOuterRing = new System.Windows.Forms.CheckBox();
            this.RF_InnerOuterRing_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_DebugChannel = new System.Windows.Forms.CheckBox();
            this.chkRF_PauseFlag = new System.Windows.Forms.CheckBox();
            this.RF_DebugSubChannel_TextBox = new System.Windows.Forms.TextBox();
            this.RF_PauseFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_allZone_BridgeHeatFlag = new System.Windows.Forms.CheckBox();
            this.chkRF_DebugSubChannel = new System.Windows.Forms.CheckBox();
            this.RF_allZone_BridgeHeatFlag_TextBox = new System.Windows.Forms.TextBox();
            this.RF_BridgeControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_PPGMode = new System.Windows.Forms.CheckBox();
            this.chkRF_StoveSwitch = new System.Windows.Forms.CheckBox();
            this.chkRF_BridgeControl = new System.Windows.Forms.CheckBox();
            this.RF_PPGMode_TextBox = new System.Windows.Forms.TextBox();
            this.RF_FanLevel_TextBox = new System.Windows.Forms.TextBox();
            this.RF_StoveSwitch_TextBox = new System.Windows.Forms.TextBox();
            this.RF_AllowPanDetection_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_FanLevel = new System.Windows.Forms.CheckBox();
            this.chkRF_AllowPanDetection = new System.Windows.Forms.CheckBox();
            this.RF_NoiseControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_HeatFreqJitterFlag = new System.Windows.Forms.CheckBox();
            this.RF_HeatFreqJitterFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_NoiseControl = new System.Windows.Forms.CheckBox();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.RF_ReserveD16_TextBox = new System.Windows.Forms.TextBox();
            this.RF_ReserveD15_TextBox = new System.Windows.Forms.TextBox();
            this.RF_ReserveD14_TextBox = new System.Windows.Forms.TextBox();
            this.RF_Power_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.RF_Power_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_ReserveD16 = new System.Windows.Forms.CheckBox();
            this.chkRF_ReserveD15 = new System.Windows.Forms.CheckBox();
            this.chkRF_ReserveD14 = new System.Windows.Forms.CheckBox();
            this.chkRF_Power_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkRF_Power_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.chkRF_PollingState = new System.Windows.Forms.CheckBox();
            this.RF_PollingState = new System.Windows.Forms.TextBox();
            this.chkRF_FreqControlFlag = new System.Windows.Forms.CheckBox();
            this.chkRF_HeatFlag = new System.Windows.Forms.CheckBox();
            this.RF_FreqControlFlag = new System.Windows.Forms.TextBox();
            this.RF_HeatFlag = new System.Windows.Forms.TextBox();
            this.RF_HeatNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_HeatNTC2 = new System.Windows.Forms.CheckBox();
            this.chkRF_HeatNTC1 = new System.Windows.Forms.CheckBox();
            this.chkRF_IGBTNTC1 = new System.Windows.Forms.CheckBox();
            this.RF_IGBTNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_IGBTNTC2 = new System.Windows.Forms.CheckBox();
            this.RF_ErrorCode = new System.Windows.Forms.TextBox();
            this.RF_IGBTNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_PanTemp = new System.Windows.Forms.CheckBox();
            this.RF_PanTemp_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_Freq = new System.Windows.Forms.CheckBox();
            this.RF_Freq_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_ErrorCode = new System.Windows.Forms.CheckBox();
            this.chkRF_Voltage = new System.Windows.Forms.CheckBox();
            this.RF_MCUTemp_TextBox = new System.Windows.Forms.TextBox();
            this.RF_Voltage_TextBox = new System.Windows.Forms.TextBox();
            this.chkRF_Power = new System.Windows.Forms.CheckBox();
            this.chkRF_MCUTemp = new System.Windows.Forms.CheckBox();
            this.RF_Power_TextBox = new System.Windows.Forms.TextBox();
            this.RF_HeatNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.RR_ReserveD8_TextBox = new System.Windows.Forms.TextBox();
            this.RR_ReserveD7_TextBox = new System.Windows.Forms.TextBox();
            this.RR_Disp_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.RR_Disp_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_ReserveD8 = new System.Windows.Forms.CheckBox();
            this.chkRR_ReserveD7 = new System.Windows.Forms.CheckBox();
            this.chkRR_Disp_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkRR_Disp_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.RR_RequestPower_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_HeatingFreqFollow = new System.Windows.Forms.CheckBox();
            this.chkRR_PanControlActive = new System.Windows.Forms.CheckBox();
            this.RR_HeatingFreqFollow_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_RequestPower = new System.Windows.Forms.CheckBox();
            this.RR_PanControlActive_TextBox = new System.Windows.Forms.TextBox();
            this.RR_DebugChannel_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_InnerOuterRing = new System.Windows.Forms.CheckBox();
            this.RR_InnerOuterRing_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_DebugChannel = new System.Windows.Forms.CheckBox();
            this.chkRR_PauseFlag = new System.Windows.Forms.CheckBox();
            this.RR_DebugSubChannel_TextBox = new System.Windows.Forms.TextBox();
            this.RR_PauseFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_allZone_BridgeHeatFlag = new System.Windows.Forms.CheckBox();
            this.chkRR_DebugSubChannel = new System.Windows.Forms.CheckBox();
            this.RR_allZone_BridgeHeatFlag_TextBox = new System.Windows.Forms.TextBox();
            this.RR_BridgeControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_PPGMode = new System.Windows.Forms.CheckBox();
            this.chkRR_StoveSwitch = new System.Windows.Forms.CheckBox();
            this.chkRR_BridgeControl = new System.Windows.Forms.CheckBox();
            this.RR_PPGMode_TextBox = new System.Windows.Forms.TextBox();
            this.RR_FanLevel_TextBox = new System.Windows.Forms.TextBox();
            this.RR_StoveSwitch_TextBox = new System.Windows.Forms.TextBox();
            this.RR_AllowPanDetection_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_FanLevel = new System.Windows.Forms.CheckBox();
            this.chkRR_AllowPanDetection = new System.Windows.Forms.CheckBox();
            this.RR_NoiseControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_HeatFreqJitterFlag = new System.Windows.Forms.CheckBox();
            this.RR_HeatFreqJitterFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_NoiseControl = new System.Windows.Forms.CheckBox();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.RR_ReserveD16_TextBox = new System.Windows.Forms.TextBox();
            this.RR_ReserveD15_TextBox = new System.Windows.Forms.TextBox();
            this.RR_ReserveD14_TextBox = new System.Windows.Forms.TextBox();
            this.RR_Power_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.RR_Power_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_ReserveD16 = new System.Windows.Forms.CheckBox();
            this.chkRR_ReserveD15 = new System.Windows.Forms.CheckBox();
            this.chkRR_ReserveD14 = new System.Windows.Forms.CheckBox();
            this.chkRR_Power_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkRR_Power_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.chkRR_PollingState = new System.Windows.Forms.CheckBox();
            this.chkRR_FreqControlFlag = new System.Windows.Forms.CheckBox();
            this.chkRR_HeatFlag = new System.Windows.Forms.CheckBox();
            this.RR_FreqControlFlag = new System.Windows.Forms.TextBox();
            this.RR_HeatFlag = new System.Windows.Forms.TextBox();
            this.RR_HeatNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_HeatNTC2 = new System.Windows.Forms.CheckBox();
            this.chkRR_HeatNTC1 = new System.Windows.Forms.CheckBox();
            this.RR_HeatNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_IGBTNTC1 = new System.Windows.Forms.CheckBox();
            this.RR_IGBTNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_IGBTNTC2 = new System.Windows.Forms.CheckBox();
            this.RR_ErrorCode = new System.Windows.Forms.TextBox();
            this.RR_IGBTNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_PanTemp = new System.Windows.Forms.CheckBox();
            this.RR_PanTemp_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_Freq = new System.Windows.Forms.CheckBox();
            this.RR_Freq_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_ErrorCode = new System.Windows.Forms.CheckBox();
            this.chkRR_Voltage = new System.Windows.Forms.CheckBox();
            this.RR_MCUTemp_TextBox = new System.Windows.Forms.TextBox();
            this.RR_Voltage_TextBox = new System.Windows.Forms.TextBox();
            this.chkRR_Power = new System.Windows.Forms.CheckBox();
            this.chkRR_MCUTemp = new System.Windows.Forms.CheckBox();
            this.RR_Power_TextBox = new System.Windows.Forms.TextBox();
            this.RR_PollingState = new System.Windows.Forms.TextBox();
            this.splitContainer13 = new System.Windows.Forms.SplitContainer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.CLF_ReserveD8_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_ReserveD7_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_Disp_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_Disp_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_ReserveD8 = new System.Windows.Forms.CheckBox();
            this.chkCLF_ReserveD7 = new System.Windows.Forms.CheckBox();
            this.chkCLF_Disp_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkCLF_Disp_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.CLF_RequestPower_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_HeatingFreqFollow = new System.Windows.Forms.CheckBox();
            this.chkCLF_PanControlActive = new System.Windows.Forms.CheckBox();
            this.CLF_HeatingFreqFollow_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_RequestPower = new System.Windows.Forms.CheckBox();
            this.CLF_PanControlActive_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_DebugChannel_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_InnerOuterRing = new System.Windows.Forms.CheckBox();
            this.CLF_InnerOuterRing_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_DebugChannel = new System.Windows.Forms.CheckBox();
            this.chkCLF_PauseFlag = new System.Windows.Forms.CheckBox();
            this.CLF_DebugSubChannel_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_PauseFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_allZone_BridgeHeatFlag = new System.Windows.Forms.CheckBox();
            this.chkCLF_DebugSubChannel = new System.Windows.Forms.CheckBox();
            this.CLF_allZone_BridgeHeatFlag_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_BridgeControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_PPGMode = new System.Windows.Forms.CheckBox();
            this.chkCLF_StoveSwitch = new System.Windows.Forms.CheckBox();
            this.chkCLF_BridgeControl = new System.Windows.Forms.CheckBox();
            this.CLF_PPGMode_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_FanLevel_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_StoveSwitch_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_AllowPanDetection_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_FanLevel = new System.Windows.Forms.CheckBox();
            this.chkCLF_AllowPanDetection = new System.Windows.Forms.CheckBox();
            this.CLF_NoiseControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_HeatFreqJitterFlag = new System.Windows.Forms.CheckBox();
            this.CLF_HeatFreqJitterFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_NoiseControl = new System.Windows.Forms.CheckBox();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.CLF_ReserveD16_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_ReserveD15_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_ReserveD14_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_Power_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_Power_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_ReserveD16 = new System.Windows.Forms.CheckBox();
            this.chkCLF_ReserveD15 = new System.Windows.Forms.CheckBox();
            this.chkCLF_ReserveD14 = new System.Windows.Forms.CheckBox();
            this.chkCLF_Power_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkCLF_Power_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.chkCLF_PollingState = new System.Windows.Forms.CheckBox();
            this.CLF_PollingState = new System.Windows.Forms.TextBox();
            this.chkCLF_FreqControlFlag = new System.Windows.Forms.CheckBox();
            this.chkCLF_HeatFlag = new System.Windows.Forms.CheckBox();
            this.CLF_FreqControlFlag = new System.Windows.Forms.TextBox();
            this.CLF_HeatFlag = new System.Windows.Forms.TextBox();
            this.CLF_HeatNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_HeatNTC2 = new System.Windows.Forms.CheckBox();
            this.chkCLF_HeatNTC1 = new System.Windows.Forms.CheckBox();
            this.CLF_HeatNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_IGBTNTC1 = new System.Windows.Forms.CheckBox();
            this.CLF_IGBTNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_IGBTNTC2 = new System.Windows.Forms.CheckBox();
            this.CLF_ErrorCode = new System.Windows.Forms.TextBox();
            this.CLF_IGBTNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_PanTemp = new System.Windows.Forms.CheckBox();
            this.CLF_PanTemp_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_Freq = new System.Windows.Forms.CheckBox();
            this.CLF_Freq_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_ErrorCode = new System.Windows.Forms.CheckBox();
            this.chkCLF_Voltage = new System.Windows.Forms.CheckBox();
            this.CLF_MCUTemp_TextBox = new System.Windows.Forms.TextBox();
            this.CLF_Voltage_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLF_Power = new System.Windows.Forms.CheckBox();
            this.chkCLF_MCUTemp = new System.Windows.Forms.CheckBox();
            this.CLF_Power_TextBox = new System.Windows.Forms.TextBox();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.CLR_ReserveD8_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_ReserveD7_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_Disp_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_Disp_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_ReserveD8 = new System.Windows.Forms.CheckBox();
            this.chkCLR_ReserveD7 = new System.Windows.Forms.CheckBox();
            this.chkCLR_Disp_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkCLR_Disp_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.CLR_RequestPower_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_HeatingFreqFollow = new System.Windows.Forms.CheckBox();
            this.chkCLR_PanControlActive = new System.Windows.Forms.CheckBox();
            this.CLR_HeatingFreqFollow_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_RequestPower = new System.Windows.Forms.CheckBox();
            this.CLR_PanControlActive_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_DebugChannel_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_InnerOuterRing = new System.Windows.Forms.CheckBox();
            this.chkCLR_DebugChannel = new System.Windows.Forms.CheckBox();
            this.chkCLR_PauseFlag = new System.Windows.Forms.CheckBox();
            this.CLR_DebugSubChannel_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_PauseFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_allZone_BridgeHeatFlag = new System.Windows.Forms.CheckBox();
            this.chkCLR_DebugSubChannel = new System.Windows.Forms.CheckBox();
            this.CLR_allZone_BridgeHeatFlag_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_BridgeControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_PPGMode = new System.Windows.Forms.CheckBox();
            this.chkCLR_StoveSwitch = new System.Windows.Forms.CheckBox();
            this.chkCLR_BridgeControl = new System.Windows.Forms.CheckBox();
            this.CLR_PPGMode_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_FanLevel_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_StoveSwitch_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_AllowPanDetection_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_FanLevel = new System.Windows.Forms.CheckBox();
            this.chkCLR_AllowPanDetection = new System.Windows.Forms.CheckBox();
            this.CLR_NoiseControl_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_HeatFreqJitterFlag = new System.Windows.Forms.CheckBox();
            this.CLR_HeatFreqJitterFlag_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_NoiseControl = new System.Windows.Forms.CheckBox();
            this.CLR_InnerOuterRing_TextBox = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.CLR_ReserveD16_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_ReserveD15_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_ReserveD14_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_Power_ReserveD1B7_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_Power_ReserveD1B6_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_ReserveD16 = new System.Windows.Forms.CheckBox();
            this.chkCLR_ReserveD15 = new System.Windows.Forms.CheckBox();
            this.chkCLR_ReserveD14 = new System.Windows.Forms.CheckBox();
            this.chkCLR_Power_ReserveD1B7 = new System.Windows.Forms.CheckBox();
            this.chkCLR_Power_ReserveD1B6 = new System.Windows.Forms.CheckBox();
            this.chkCLR_PollingState = new System.Windows.Forms.CheckBox();
            this.CLR_PollingState = new System.Windows.Forms.TextBox();
            this.chkCLR_FreqControlFlag = new System.Windows.Forms.CheckBox();
            this.chkCLR_HeatFlag = new System.Windows.Forms.CheckBox();
            this.CLR_FreqControlFlag = new System.Windows.Forms.TextBox();
            this.CLR_HeatFlag = new System.Windows.Forms.TextBox();
            this.CLR_HeatNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_HeatNTC2 = new System.Windows.Forms.CheckBox();
            this.chkCLR_HeatNTC1 = new System.Windows.Forms.CheckBox();
            this.CLR_HeatNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_IGBTNTC1 = new System.Windows.Forms.CheckBox();
            this.CLR_IGBTNTC1_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_IGBTNTC2 = new System.Windows.Forms.CheckBox();
            this.CLR_ErrorCode = new System.Windows.Forms.TextBox();
            this.CLR_IGBTNTC2_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_PanTemp = new System.Windows.Forms.CheckBox();
            this.CLR_PanTemp_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_Freq = new System.Windows.Forms.CheckBox();
            this.CLR_Freq_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_ErrorCode = new System.Windows.Forms.CheckBox();
            this.chkCLR_Voltage = new System.Windows.Forms.CheckBox();
            this.CLR_MCUTemp_TextBox = new System.Windows.Forms.TextBox();
            this.CLR_Voltage_TextBox = new System.Windows.Forms.TextBox();
            this.chkCLR_Power = new System.Windows.Forms.CheckBox();
            this.chkCLR_MCUTemp = new System.Windows.Forms.CheckBox();
            this.CLR_Power_TextBox = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lblLF_FreqControlFlag = new System.Windows.Forms.Label();
            this.lblLF_ErrorCode = new System.Windows.Forms.Label();
            this.panelLR = new System.Windows.Forms.Panel();
            this.panelCLF = new System.Windows.Forms.Panel();
            this.panelCLR = new System.Windows.Forms.Panel();
            this.panelRF = new System.Windows.Forms.Panel();
            this.panelRR = new System.Windows.Forms.Panel();
            this.lblLF_FanLevel = new System.Windows.Forms.Label();
            this.portGroup = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDA = new System.Windows.Forms.Label();
            this.cmbDAList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRealPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbVirtualPort1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TbDeviceAddress_DA = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbUploadPort = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Disp_comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Ctrl_comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnRefreshPorts = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnLoadConfigure = new System.Windows.Forms.Button();
            this.btnSaveConfigure = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tbUSBPcapPath = new System.Windows.Forms.TextBox();
            this.btnaddress = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTempDevice = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPowerDevice = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Disp_comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Ctrl_comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbUploadBaudRate = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAutoDisconnect = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRecordInterval = new System.Windows.Forms.TextBox();
            this.cbDebugMode = new System.Windows.Forms.CheckBox();
            this.splitContainer2_temppower_IH = new System.Windows.Forms.SplitContainer();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.btUploadName = new System.Windows.Forms.Button();
            this.splitContainer5_temp_power = new System.Windows.Forms.SplitContainer();
            this.groupBoxTemp = new System.Windows.Forms.GroupBox();
            this.panelTempChannelsContainer = new System.Windows.Forms.Panel();
            this.tlpTempChannels = new System.Windows.Forms.TableLayoutPanel();
            this.chkChannel3 = new System.Windows.Forms.CheckBox();
            this.chkChannel2 = new System.Windows.Forms.CheckBox();
            this.chkChannel1 = new System.Windows.Forms.CheckBox();
            this.chkChannel101 = new System.Windows.Forms.CheckBox();
            this.txtChannel101 = new System.Windows.Forms.TextBox();
            this.chkChannel201 = new System.Windows.Forms.CheckBox();
            this.txtChannel201 = new System.Windows.Forms.TextBox();
            this.chkChannel301 = new System.Windows.Forms.CheckBox();
            this.txtChannel301 = new System.Windows.Forms.TextBox();
            this.chkChannel102 = new System.Windows.Forms.CheckBox();
            this.txtChannel102 = new System.Windows.Forms.TextBox();
            this.chkChannel202 = new System.Windows.Forms.CheckBox();
            this.txtChannel202 = new System.Windows.Forms.TextBox();
            this.chkChannel302 = new System.Windows.Forms.CheckBox();
            this.txtChannel302 = new System.Windows.Forms.TextBox();
            this.chkChannel103 = new System.Windows.Forms.CheckBox();
            this.txtChannel103 = new System.Windows.Forms.TextBox();
            this.chkChannel203 = new System.Windows.Forms.CheckBox();
            this.txtChannel203 = new System.Windows.Forms.TextBox();
            this.chkChannel303 = new System.Windows.Forms.CheckBox();
            this.txtChannel303 = new System.Windows.Forms.TextBox();
            this.chkChannel104 = new System.Windows.Forms.CheckBox();
            this.txtChannel104 = new System.Windows.Forms.TextBox();
            this.chkChannel204 = new System.Windows.Forms.CheckBox();
            this.txtChannel204 = new System.Windows.Forms.TextBox();
            this.chkChannel304 = new System.Windows.Forms.CheckBox();
            this.txtChannel304 = new System.Windows.Forms.TextBox();
            this.chkChannel105 = new System.Windows.Forms.CheckBox();
            this.txtChannel105 = new System.Windows.Forms.TextBox();
            this.chkChannel205 = new System.Windows.Forms.CheckBox();
            this.txtChannel205 = new System.Windows.Forms.TextBox();
            this.chkChannel305 = new System.Windows.Forms.CheckBox();
            this.txtChannel305 = new System.Windows.Forms.TextBox();
            this.chkChannel106 = new System.Windows.Forms.CheckBox();
            this.txtChannel106 = new System.Windows.Forms.TextBox();
            this.chkChannel206 = new System.Windows.Forms.CheckBox();
            this.txtChannel206 = new System.Windows.Forms.TextBox();
            this.chkChannel306 = new System.Windows.Forms.CheckBox();
            this.txtChannel306 = new System.Windows.Forms.TextBox();
            this.chkChannel107 = new System.Windows.Forms.CheckBox();
            this.txtChannel107 = new System.Windows.Forms.TextBox();
            this.chkChannel207 = new System.Windows.Forms.CheckBox();
            this.txtChannel207 = new System.Windows.Forms.TextBox();
            this.chkChannel307 = new System.Windows.Forms.CheckBox();
            this.txtChannel307 = new System.Windows.Forms.TextBox();
            this.chkChannel108 = new System.Windows.Forms.CheckBox();
            this.txtChannel108 = new System.Windows.Forms.TextBox();
            this.chkChannel208 = new System.Windows.Forms.CheckBox();
            this.txtChannel208 = new System.Windows.Forms.TextBox();
            this.chkChannel308 = new System.Windows.Forms.CheckBox();
            this.txtChannel308 = new System.Windows.Forms.TextBox();
            this.chkChannel109 = new System.Windows.Forms.CheckBox();
            this.txtChannel109 = new System.Windows.Forms.TextBox();
            this.chkChannel209 = new System.Windows.Forms.CheckBox();
            this.txtChannel209 = new System.Windows.Forms.TextBox();
            this.chkChannel309 = new System.Windows.Forms.CheckBox();
            this.txtChannel309 = new System.Windows.Forms.TextBox();
            this.chkChannel110 = new System.Windows.Forms.CheckBox();
            this.txtChannel110 = new System.Windows.Forms.TextBox();
            this.chkChannel210 = new System.Windows.Forms.CheckBox();
            this.txtChannel210 = new System.Windows.Forms.TextBox();
            this.chkChannel310 = new System.Windows.Forms.CheckBox();
            this.txtChannel310 = new System.Windows.Forms.TextBox();
            this.chkChannel111 = new System.Windows.Forms.CheckBox();
            this.txtChannel111 = new System.Windows.Forms.TextBox();
            this.chkChannel211 = new System.Windows.Forms.CheckBox();
            this.txtChannel211 = new System.Windows.Forms.TextBox();
            this.chkChannel311 = new System.Windows.Forms.CheckBox();
            this.txtChannel311 = new System.Windows.Forms.TextBox();
            this.chkChannel112 = new System.Windows.Forms.CheckBox();
            this.txtChannel112 = new System.Windows.Forms.TextBox();
            this.chkChannel212 = new System.Windows.Forms.CheckBox();
            this.txtChannel212 = new System.Windows.Forms.TextBox();
            this.chkChannel312 = new System.Windows.Forms.CheckBox();
            this.txtChannel312 = new System.Windows.Forms.TextBox();
            this.chkChannel113 = new System.Windows.Forms.CheckBox();
            this.txtChannel113 = new System.Windows.Forms.TextBox();
            this.chkChannel213 = new System.Windows.Forms.CheckBox();
            this.txtChannel213 = new System.Windows.Forms.TextBox();
            this.chkChannel313 = new System.Windows.Forms.CheckBox();
            this.txtChannel313 = new System.Windows.Forms.TextBox();
            this.chkChannel114 = new System.Windows.Forms.CheckBox();
            this.txtChannel114 = new System.Windows.Forms.TextBox();
            this.chkChannel214 = new System.Windows.Forms.CheckBox();
            this.txtChannel214 = new System.Windows.Forms.TextBox();
            this.chkChannel314 = new System.Windows.Forms.CheckBox();
            this.txtChannel314 = new System.Windows.Forms.TextBox();
            this.chkChannel115 = new System.Windows.Forms.CheckBox();
            this.txtChannel115 = new System.Windows.Forms.TextBox();
            this.chkChannel215 = new System.Windows.Forms.CheckBox();
            this.txtChannel215 = new System.Windows.Forms.TextBox();
            this.chkChannel315 = new System.Windows.Forms.CheckBox();
            this.txtChannel315 = new System.Windows.Forms.TextBox();
            this.chkChannel116 = new System.Windows.Forms.CheckBox();
            this.txtChannel116 = new System.Windows.Forms.TextBox();
            this.chkChannel216 = new System.Windows.Forms.CheckBox();
            this.txtChannel216 = new System.Windows.Forms.TextBox();
            this.chkChannel316 = new System.Windows.Forms.CheckBox();
            this.txtChannel316 = new System.Windows.Forms.TextBox();
            this.chkChannel117 = new System.Windows.Forms.CheckBox();
            this.txtChannel117 = new System.Windows.Forms.TextBox();
            this.chkChannel217 = new System.Windows.Forms.CheckBox();
            this.txtChannel217 = new System.Windows.Forms.TextBox();
            this.chkChannel317 = new System.Windows.Forms.CheckBox();
            this.txtChannel317 = new System.Windows.Forms.TextBox();
            this.chkChannel118 = new System.Windows.Forms.CheckBox();
            this.txtChannel118 = new System.Windows.Forms.TextBox();
            this.chkChannel218 = new System.Windows.Forms.CheckBox();
            this.txtChannel218 = new System.Windows.Forms.TextBox();
            this.chkChannel318 = new System.Windows.Forms.CheckBox();
            this.txtChannel318 = new System.Windows.Forms.TextBox();
            this.chkChannel119 = new System.Windows.Forms.CheckBox();
            this.txtChannel119 = new System.Windows.Forms.TextBox();
            this.chkChannel219 = new System.Windows.Forms.CheckBox();
            this.txtChannel219 = new System.Windows.Forms.TextBox();
            this.chkChannel319 = new System.Windows.Forms.CheckBox();
            this.txtChannel319 = new System.Windows.Forms.TextBox();
            this.chkChannel120 = new System.Windows.Forms.CheckBox();
            this.txtChannel120 = new System.Windows.Forms.TextBox();
            this.chkChannel220 = new System.Windows.Forms.CheckBox();
            this.txtChannel220 = new System.Windows.Forms.TextBox();
            this.chkChannel320 = new System.Windows.Forms.CheckBox();
            this.txtChannel320 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPower = new System.Windows.Forms.DataGridView();
            this.Column_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Uc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ib = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Ic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_En = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3_set_log = new System.Windows.Forms.SplitContainer();
            this.splitContainer4_log_status = new System.Windows.Forms.SplitContainer();
            this.LOG = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LogBox_Temp = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LogBox_Power = new System.Windows.Forms.RichTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.LogBox_IH = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.btnToggleSettings = new System.Windows.Forms.Button();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupbox3.SuspendLayout();
            this.mainIHPanel.SuspendLayout();
            this.panelLF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6_LFDisp)).BeginInit();
            this.splitContainer6_LFDisp.Panel1.SuspendLayout();
            this.splitContainer6_LFDisp.Panel2.SuspendLayout();
            this.splitContainer6_LFDisp.SuspendLayout();
            this.groupBoxLF_Display.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3_LFControl)).BeginInit();
            this.splitContainer3_LFControl.Panel1.SuspendLayout();
            this.splitContainer3_LFControl.Panel2.SuspendLayout();
            this.splitContainer3_LFControl.SuspendLayout();
            this.groupBoxLF_Power.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxLR_Display.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxLR_Power.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).BeginInit();
            this.splitContainer13.Panel1.SuspendLayout();
            this.splitContainer13.Panel2.SuspendLayout();
            this.splitContainer13.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel1.SuspendLayout();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.portGroup.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2_temppower_IH)).BeginInit();
            this.splitContainer2_temppower_IH.Panel1.SuspendLayout();
            this.splitContainer2_temppower_IH.Panel2.SuspendLayout();
            this.splitContainer2_temppower_IH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5_temp_power)).BeginInit();
            this.splitContainer5_temp_power.Panel1.SuspendLayout();
            this.splitContainer5_temp_power.Panel2.SuspendLayout();
            this.splitContainer5_temp_power.SuspendLayout();
            this.groupBoxTemp.SuspendLayout();
            this.panelTempChannelsContainer.SuspendLayout();
            this.tlpTempChannels.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPower)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3_set_log)).BeginInit();
            this.splitContainer3_set_log.Panel1.SuspendLayout();
            this.splitContainer3_set_log.Panel2.SuspendLayout();
            this.splitContainer3_set_log.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4_log_status)).BeginInit();
            this.splitContainer4_log_status.Panel1.SuspendLayout();
            this.splitContainer4_log_status.Panel2.SuspendLayout();
            this.splitContainer4_log_status.SuspendLayout();
            this.LOG.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupbox3
            // 
            this.groupbox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox3.Controls.Add(this.mainIHPanel);
            this.groupbox3.Location = new System.Drawing.Point(0, 0);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(1190, 297);
            this.groupbox3.TabIndex = 0;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "IH设备";
            // 
            // mainIHPanel
            // 
            this.mainIHPanel.AutoScroll = true;
            this.mainIHPanel.AutoScrollMinSize = new System.Drawing.Size(2100, 470);
            this.mainIHPanel.Controls.Add(this.panelLF);
            this.mainIHPanel.Controls.Add(this.panelLR);
            this.mainIHPanel.Controls.Add(this.panelCLF);
            this.mainIHPanel.Controls.Add(this.panelCLR);
            this.mainIHPanel.Controls.Add(this.panelRF);
            this.mainIHPanel.Controls.Add(this.panelRR);
            this.mainIHPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainIHPanel.Location = new System.Drawing.Point(3, 17);
            this.mainIHPanel.Name = "mainIHPanel";
            this.mainIHPanel.Size = new System.Drawing.Size(1184, 277);
            this.mainIHPanel.TabIndex = 0;
            // 
            // panelLF
            // 
            this.panelLF.AutoScroll = true;
            this.panelLF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLF.Controls.Add(this.lblLF_PollingState);
            this.panelLF.Controls.Add(this.splitContainer6_LFDisp);
            this.panelLF.Controls.Add(this.lblLF_FreqControlFlag);
            this.panelLF.Controls.Add(this.lblLF_ErrorCode);
            this.panelLF.Location = new System.Drawing.Point(0, 0);
            this.panelLF.Name = "panelLF";
            this.panelLF.Size = new System.Drawing.Size(2800, 600);
            this.panelLF.TabIndex = 0;
            // 
            // lblLF_PollingState
            // 
            this.lblLF_PollingState.AutoSize = true;
            this.lblLF_PollingState.Location = new System.Drawing.Point(533, 266);
            this.lblLF_PollingState.Name = "lblLF_PollingState";
            this.lblLF_PollingState.Size = new System.Drawing.Size(0, 12);
            this.lblLF_PollingState.TabIndex = 30;
            // 
            // splitContainer6_LFDisp
            // 
            this.splitContainer6_LFDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6_LFDisp.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6_LFDisp.Name = "splitContainer6_LFDisp";
            // 
            // splitContainer6_LFDisp.Panel1
            // 
            this.splitContainer6_LFDisp.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer6_LFDisp.Panel1.Controls.Add(this.groupBoxLF_Display);
            // 
            // splitContainer6_LFDisp.Panel2
            // 
            this.splitContainer6_LFDisp.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer6_LFDisp.Panel2.Controls.Add(this.splitContainer3_LFControl);
            this.splitContainer6_LFDisp.Size = new System.Drawing.Size(2798, 598);
            this.splitContainer6_LFDisp.SplitterDistance = 270;
            this.splitContainer6_LFDisp.TabIndex = 0;
            // 
            // groupBoxLF_Display
            // 
            this.groupBoxLF_Display.AutoSize = true;
            this.groupBoxLF_Display.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxLF_Display.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxLF_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLF_Display.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLF_Display.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLF_Display.Name = "groupBoxLF_Display";
            this.groupBoxLF_Display.Size = new System.Drawing.Size(270, 598);
            this.groupBoxLF_Display.TabIndex = 1;
            this.groupBoxLF_Display.TabStop = false;
            this.groupBoxLF_Display.Text = "LF 显示板";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.LF_ReserveD8_TextBox, 1, 18);
            this.tableLayoutPanel1.Controls.Add(this.LF_ReserveD7_TextBox, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.LF_Disp_ReserveD1B7_TextBox, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.LF_Disp_ReserveD1B6_TextBox, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_ReserveD8, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_ReserveD7, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_Disp_ReserveD1B7, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.LF_RequestPower_TextBox, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_PanControlActive, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_RequestPower, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.LF_PanControlActive_TextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LF_DebugChannel_TextBox, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_InnerOuterRing, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LF_InnerOuterRing_TextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_DebugChannel, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_PauseFlag, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.LF_DebugSubChannel_TextBox, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.LF_PauseFlag_TextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_allZone_BridgeHeatFlag, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_DebugSubChannel, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.LF_allZone_BridgeHeatFlag_TextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.LF_BridgeControl_TextBox, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_PPGMode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_StoveSwitch, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_BridgeControl, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.LF_PPGMode_TextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.LF_FanLevel_TextBox, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.LF_StoveSwitch_TextBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.LF_AllowPanDetection_TextBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_FanLevel, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_AllowPanDetection, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.LF_NoiseControl_TextBox, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_HeatFreqJitterFlag, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.LF_HeatFreqJitterFlag_TextBox, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_NoiseControl, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.LF_HeatingFreqFollow_TextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_HeatingFreqFollow, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkLF_Disp_ReserveD1B6, 0, 15);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 20;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(264, 578);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // LF_ReserveD8_TextBox
            // 
            this.LF_ReserveD8_TextBox.Enabled = false;
            this.LF_ReserveD8_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_ReserveD8_TextBox.Location = new System.Drawing.Point(196, 525);
            this.LF_ReserveD8_TextBox.Name = "LF_ReserveD8_TextBox";
            this.LF_ReserveD8_TextBox.ReadOnly = true;
            this.LF_ReserveD8_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_ReserveD8_TextBox.TabIndex = 84;
            // 
            // LF_ReserveD7_TextBox
            // 
            this.LF_ReserveD7_TextBox.Enabled = false;
            this.LF_ReserveD7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_ReserveD7_TextBox.Location = new System.Drawing.Point(196, 496);
            this.LF_ReserveD7_TextBox.Name = "LF_ReserveD7_TextBox";
            this.LF_ReserveD7_TextBox.ReadOnly = true;
            this.LF_ReserveD7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_ReserveD7_TextBox.TabIndex = 84;
            // 
            // LF_Disp_ReserveD1B7_TextBox
            // 
            this.LF_Disp_ReserveD1B7_TextBox.Enabled = false;
            this.LF_Disp_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Disp_ReserveD1B7_TextBox.Location = new System.Drawing.Point(196, 467);
            this.LF_Disp_ReserveD1B7_TextBox.Name = "LF_Disp_ReserveD1B7_TextBox";
            this.LF_Disp_ReserveD1B7_TextBox.ReadOnly = true;
            this.LF_Disp_ReserveD1B7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_Disp_ReserveD1B7_TextBox.TabIndex = 84;
            // 
            // LF_Disp_ReserveD1B6_TextBox
            // 
            this.LF_Disp_ReserveD1B6_TextBox.Enabled = false;
            this.LF_Disp_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Disp_ReserveD1B6_TextBox.Location = new System.Drawing.Point(196, 438);
            this.LF_Disp_ReserveD1B6_TextBox.Name = "LF_Disp_ReserveD1B6_TextBox";
            this.LF_Disp_ReserveD1B6_TextBox.ReadOnly = true;
            this.LF_Disp_ReserveD1B6_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_Disp_ReserveD1B6_TextBox.TabIndex = 84;
            // 
            // chkLF_ReserveD8
            // 
            this.chkLF_ReserveD8.AutoSize = true;
            this.chkLF_ReserveD8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_ReserveD8.Location = new System.Drawing.Point(3, 525);
            this.chkLF_ReserveD8.Name = "chkLF_ReserveD8";
            this.chkLF_ReserveD8.Size = new System.Drawing.Size(187, 23);
            this.chkLF_ReserveD8.TabIndex = 82;
            this.chkLF_ReserveD8.Text = "ReserveD8";
            this.chkLF_ReserveD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_ReserveD8.UseVisualStyleBackColor = true;
            // 
            // chkLF_ReserveD7
            // 
            this.chkLF_ReserveD7.AutoSize = true;
            this.chkLF_ReserveD7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_ReserveD7.Location = new System.Drawing.Point(3, 496);
            this.chkLF_ReserveD7.Name = "chkLF_ReserveD7";
            this.chkLF_ReserveD7.Size = new System.Drawing.Size(187, 23);
            this.chkLF_ReserveD7.TabIndex = 82;
            this.chkLF_ReserveD7.Text = "ReserveD7";
            this.chkLF_ReserveD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_ReserveD7.UseVisualStyleBackColor = true;
            // 
            // chkLF_Disp_ReserveD1B7
            // 
            this.chkLF_Disp_ReserveD1B7.AutoSize = true;
            this.chkLF_Disp_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Disp_ReserveD1B7.Location = new System.Drawing.Point(3, 467);
            this.chkLF_Disp_ReserveD1B7.Name = "chkLF_Disp_ReserveD1B7";
            this.chkLF_Disp_ReserveD1B7.Size = new System.Drawing.Size(187, 23);
            this.chkLF_Disp_ReserveD1B7.TabIndex = 82;
            this.chkLF_Disp_ReserveD1B7.Text = "ReserveD1B7";
            this.chkLF_Disp_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Disp_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // LF_RequestPower_TextBox
            // 
            this.LF_RequestPower_TextBox.Enabled = false;
            this.LF_RequestPower_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_RequestPower_TextBox.Location = new System.Drawing.Point(196, 409);
            this.LF_RequestPower_TextBox.Name = "LF_RequestPower_TextBox";
            this.LF_RequestPower_TextBox.ReadOnly = true;
            this.LF_RequestPower_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_RequestPower_TextBox.TabIndex = 83;
            // 
            // chkLF_PanControlActive
            // 
            this.chkLF_PanControlActive.AutoSize = true;
            this.chkLF_PanControlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_PanControlActive.Location = new System.Drawing.Point(3, 32);
            this.chkLF_PanControlActive.Name = "chkLF_PanControlActive";
            this.chkLF_PanControlActive.Size = new System.Drawing.Size(187, 23);
            this.chkLF_PanControlActive.TabIndex = 42;
            this.chkLF_PanControlActive.Text = "移锅控功激活标志";
            this.chkLF_PanControlActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_PanControlActive.UseVisualStyleBackColor = true;
            // 
            // chkLF_RequestPower
            // 
            this.chkLF_RequestPower.AutoSize = true;
            this.chkLF_RequestPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_RequestPower.Location = new System.Drawing.Point(3, 409);
            this.chkLF_RequestPower.Name = "chkLF_RequestPower";
            this.chkLF_RequestPower.Size = new System.Drawing.Size(187, 23);
            this.chkLF_RequestPower.TabIndex = 81;
            this.chkLF_RequestPower.Text = "请求功率值";
            this.chkLF_RequestPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_RequestPower.UseVisualStyleBackColor = true;
            // 
            // LF_PanControlActive_TextBox
            // 
            this.LF_PanControlActive_TextBox.Enabled = false;
            this.LF_PanControlActive_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_PanControlActive_TextBox.Location = new System.Drawing.Point(196, 32);
            this.LF_PanControlActive_TextBox.Name = "LF_PanControlActive_TextBox";
            this.LF_PanControlActive_TextBox.ReadOnly = true;
            this.LF_PanControlActive_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_PanControlActive_TextBox.TabIndex = 44;
            // 
            // LF_DebugChannel_TextBox
            // 
            this.LF_DebugChannel_TextBox.Enabled = false;
            this.LF_DebugChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_DebugChannel_TextBox.Location = new System.Drawing.Point(196, 380);
            this.LF_DebugChannel_TextBox.Name = "LF_DebugChannel_TextBox";
            this.LF_DebugChannel_TextBox.ReadOnly = true;
            this.LF_DebugChannel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_DebugChannel_TextBox.TabIndex = 80;
            // 
            // chkLF_InnerOuterRing
            // 
            this.chkLF_InnerOuterRing.AutoSize = true;
            this.chkLF_InnerOuterRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_InnerOuterRing.Location = new System.Drawing.Point(3, 61);
            this.chkLF_InnerOuterRing.Name = "chkLF_InnerOuterRing";
            this.chkLF_InnerOuterRing.Size = new System.Drawing.Size(187, 23);
            this.chkLF_InnerOuterRing.TabIndex = 45;
            this.chkLF_InnerOuterRing.Text = "内外环标志";
            this.chkLF_InnerOuterRing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_InnerOuterRing.UseVisualStyleBackColor = true;
            // 
            // LF_InnerOuterRing_TextBox
            // 
            this.LF_InnerOuterRing_TextBox.Enabled = false;
            this.LF_InnerOuterRing_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_InnerOuterRing_TextBox.Location = new System.Drawing.Point(196, 61);
            this.LF_InnerOuterRing_TextBox.Name = "LF_InnerOuterRing_TextBox";
            this.LF_InnerOuterRing_TextBox.ReadOnly = true;
            this.LF_InnerOuterRing_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_InnerOuterRing_TextBox.TabIndex = 48;
            // 
            // chkLF_DebugChannel
            // 
            this.chkLF_DebugChannel.AutoSize = true;
            this.chkLF_DebugChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_DebugChannel.Location = new System.Drawing.Point(3, 380);
            this.chkLF_DebugChannel.Name = "chkLF_DebugChannel";
            this.chkLF_DebugChannel.Size = new System.Drawing.Size(187, 23);
            this.chkLF_DebugChannel.TabIndex = 78;
            this.chkLF_DebugChannel.Text = "Debug通道号";
            this.chkLF_DebugChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_DebugChannel.UseVisualStyleBackColor = true;
            // 
            // chkLF_PauseFlag
            // 
            this.chkLF_PauseFlag.AutoSize = true;
            this.chkLF_PauseFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_PauseFlag.Location = new System.Drawing.Point(3, 177);
            this.chkLF_PauseFlag.Name = "chkLF_PauseFlag";
            this.chkLF_PauseFlag.Size = new System.Drawing.Size(187, 23);
            this.chkLF_PauseFlag.TabIndex = 57;
            this.chkLF_PauseFlag.Text = "暂停标志";
            this.chkLF_PauseFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_PauseFlag.UseVisualStyleBackColor = true;
            // 
            // LF_DebugSubChannel_TextBox
            // 
            this.LF_DebugSubChannel_TextBox.Enabled = false;
            this.LF_DebugSubChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_DebugSubChannel_TextBox.Location = new System.Drawing.Point(196, 351);
            this.LF_DebugSubChannel_TextBox.Name = "LF_DebugSubChannel_TextBox";
            this.LF_DebugSubChannel_TextBox.ReadOnly = true;
            this.LF_DebugSubChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_DebugSubChannel_TextBox.TabIndex = 76;
            // 
            // LF_PauseFlag_TextBox
            // 
            this.LF_PauseFlag_TextBox.Enabled = false;
            this.LF_PauseFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_PauseFlag_TextBox.Location = new System.Drawing.Point(196, 177);
            this.LF_PauseFlag_TextBox.Name = "LF_PauseFlag_TextBox";
            this.LF_PauseFlag_TextBox.ReadOnly = true;
            this.LF_PauseFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_PauseFlag_TextBox.TabIndex = 59;
            // 
            // chkLF_allZone_BridgeHeatFlag
            // 
            this.chkLF_allZone_BridgeHeatFlag.AutoSize = true;
            this.chkLF_allZone_BridgeHeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_allZone_BridgeHeatFlag.Location = new System.Drawing.Point(3, 90);
            this.chkLF_allZone_BridgeHeatFlag.Name = "chkLF_allZone_BridgeHeatFlag";
            this.chkLF_allZone_BridgeHeatFlag.Size = new System.Drawing.Size(187, 23);
            this.chkLF_allZone_BridgeHeatFlag.TabIndex = 48;
            this.chkLF_allZone_BridgeHeatFlag.Text = "无区/桥接标志/三环（红外）";
            this.chkLF_allZone_BridgeHeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_allZone_BridgeHeatFlag.UseVisualStyleBackColor = true;
            // 
            // chkLF_DebugSubChannel
            // 
            this.chkLF_DebugSubChannel.AutoSize = true;
            this.chkLF_DebugSubChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_DebugSubChannel.Location = new System.Drawing.Point(3, 351);
            this.chkLF_DebugSubChannel.Name = "chkLF_DebugSubChannel";
            this.chkLF_DebugSubChannel.Size = new System.Drawing.Size(187, 23);
            this.chkLF_DebugSubChannel.TabIndex = 74;
            this.chkLF_DebugSubChannel.Text = "Debug子通道号";
            this.chkLF_DebugSubChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_DebugSubChannel.UseVisualStyleBackColor = true;
            // 
            // LF_allZone_BridgeHeatFlag_TextBox
            // 
            this.LF_allZone_BridgeHeatFlag_TextBox.Enabled = false;
            this.LF_allZone_BridgeHeatFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_allZone_BridgeHeatFlag_TextBox.Location = new System.Drawing.Point(196, 90);
            this.LF_allZone_BridgeHeatFlag_TextBox.Name = "LF_allZone_BridgeHeatFlag_TextBox";
            this.LF_allZone_BridgeHeatFlag_TextBox.ReadOnly = true;
            this.LF_allZone_BridgeHeatFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_allZone_BridgeHeatFlag_TextBox.TabIndex = 50;
            // 
            // LF_BridgeControl_TextBox
            // 
            this.LF_BridgeControl_TextBox.Enabled = false;
            this.LF_BridgeControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_BridgeControl_TextBox.Location = new System.Drawing.Point(196, 322);
            this.LF_BridgeControl_TextBox.Name = "LF_BridgeControl_TextBox";
            this.LF_BridgeControl_TextBox.ReadOnly = true;
            this.LF_BridgeControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_BridgeControl_TextBox.TabIndex = 73;
            // 
            // chkLF_PPGMode
            // 
            this.chkLF_PPGMode.AutoSize = true;
            this.chkLF_PPGMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_PPGMode.Location = new System.Drawing.Point(3, 119);
            this.chkLF_PPGMode.Name = "chkLF_PPGMode";
            this.chkLF_PPGMode.Size = new System.Drawing.Size(187, 23);
            this.chkLF_PPGMode.TabIndex = 51;
            this.chkLF_PPGMode.Text = "PPG模式标志";
            this.chkLF_PPGMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_PPGMode.UseVisualStyleBackColor = true;
            // 
            // chkLF_StoveSwitch
            // 
            this.chkLF_StoveSwitch.AutoSize = true;
            this.chkLF_StoveSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_StoveSwitch.Location = new System.Drawing.Point(3, 206);
            this.chkLF_StoveSwitch.Name = "chkLF_StoveSwitch";
            this.chkLF_StoveSwitch.Size = new System.Drawing.Size(187, 23);
            this.chkLF_StoveSwitch.TabIndex = 60;
            this.chkLF_StoveSwitch.Text = "炉头开关标志";
            this.chkLF_StoveSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_StoveSwitch.UseVisualStyleBackColor = true;
            // 
            // chkLF_BridgeControl
            // 
            this.chkLF_BridgeControl.AutoSize = true;
            this.chkLF_BridgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_BridgeControl.Location = new System.Drawing.Point(3, 322);
            this.chkLF_BridgeControl.Name = "chkLF_BridgeControl";
            this.chkLF_BridgeControl.Size = new System.Drawing.Size(187, 23);
            this.chkLF_BridgeControl.TabIndex = 71;
            this.chkLF_BridgeControl.Text = "无区/桥接控制指令";
            this.chkLF_BridgeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_BridgeControl.UseVisualStyleBackColor = true;
            // 
            // LF_PPGMode_TextBox
            // 
            this.LF_PPGMode_TextBox.Enabled = false;
            this.LF_PPGMode_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_PPGMode_TextBox.Location = new System.Drawing.Point(196, 119);
            this.LF_PPGMode_TextBox.Name = "LF_PPGMode_TextBox";
            this.LF_PPGMode_TextBox.ReadOnly = true;
            this.LF_PPGMode_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_PPGMode_TextBox.TabIndex = 53;
            // 
            // LF_FanLevel_TextBox
            // 
            this.LF_FanLevel_TextBox.Enabled = false;
            this.LF_FanLevel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_FanLevel_TextBox.Location = new System.Drawing.Point(196, 293);
            this.LF_FanLevel_TextBox.Name = "LF_FanLevel_TextBox";
            this.LF_FanLevel_TextBox.ReadOnly = true;
            this.LF_FanLevel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_FanLevel_TextBox.TabIndex = 70;
            // 
            // LF_StoveSwitch_TextBox
            // 
            this.LF_StoveSwitch_TextBox.Enabled = false;
            this.LF_StoveSwitch_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_StoveSwitch_TextBox.Location = new System.Drawing.Point(196, 206);
            this.LF_StoveSwitch_TextBox.Name = "LF_StoveSwitch_TextBox";
            this.LF_StoveSwitch_TextBox.ReadOnly = true;
            this.LF_StoveSwitch_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_StoveSwitch_TextBox.TabIndex = 61;
            // 
            // LF_AllowPanDetection_TextBox
            // 
            this.LF_AllowPanDetection_TextBox.Enabled = false;
            this.LF_AllowPanDetection_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_AllowPanDetection_TextBox.Location = new System.Drawing.Point(196, 148);
            this.LF_AllowPanDetection_TextBox.Name = "LF_AllowPanDetection_TextBox";
            this.LF_AllowPanDetection_TextBox.ReadOnly = true;
            this.LF_AllowPanDetection_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_AllowPanDetection_TextBox.TabIndex = 56;
            // 
            // chkLF_FanLevel
            // 
            this.chkLF_FanLevel.AutoSize = true;
            this.chkLF_FanLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_FanLevel.Location = new System.Drawing.Point(3, 293);
            this.chkLF_FanLevel.Name = "chkLF_FanLevel";
            this.chkLF_FanLevel.Size = new System.Drawing.Size(187, 23);
            this.chkLF_FanLevel.TabIndex = 68;
            this.chkLF_FanLevel.Text = "风机档位";
            this.chkLF_FanLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_FanLevel.UseVisualStyleBackColor = true;
            // 
            // chkLF_AllowPanDetection
            // 
            this.chkLF_AllowPanDetection.AutoSize = true;
            this.chkLF_AllowPanDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_AllowPanDetection.Location = new System.Drawing.Point(3, 148);
            this.chkLF_AllowPanDetection.Name = "chkLF_AllowPanDetection";
            this.chkLF_AllowPanDetection.Size = new System.Drawing.Size(187, 23);
            this.chkLF_AllowPanDetection.TabIndex = 54;
            this.chkLF_AllowPanDetection.Text = "允许检锅标志";
            this.chkLF_AllowPanDetection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_AllowPanDetection.UseVisualStyleBackColor = true;
            // 
            // LF_NoiseControl_TextBox
            // 
            this.LF_NoiseControl_TextBox.Enabled = false;
            this.LF_NoiseControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_NoiseControl_TextBox.Location = new System.Drawing.Point(196, 264);
            this.LF_NoiseControl_TextBox.Name = "LF_NoiseControl_TextBox";
            this.LF_NoiseControl_TextBox.ReadOnly = true;
            this.LF_NoiseControl_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_NoiseControl_TextBox.TabIndex = 67;
            // 
            // chkLF_HeatFreqJitterFlag
            // 
            this.chkLF_HeatFreqJitterFlag.AutoSize = true;
            this.chkLF_HeatFreqJitterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_HeatFreqJitterFlag.Location = new System.Drawing.Point(3, 235);
            this.chkLF_HeatFreqJitterFlag.Name = "chkLF_HeatFreqJitterFlag";
            this.chkLF_HeatFreqJitterFlag.Size = new System.Drawing.Size(187, 23);
            this.chkLF_HeatFreqJitterFlag.TabIndex = 62;
            this.chkLF_HeatFreqJitterFlag.Text = "加热频率抖频率模式";
            this.chkLF_HeatFreqJitterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_HeatFreqJitterFlag.UseVisualStyleBackColor = true;
            // 
            // LF_HeatFreqJitterFlag_TextBox
            // 
            this.LF_HeatFreqJitterFlag_TextBox.Enabled = false;
            this.LF_HeatFreqJitterFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_HeatFreqJitterFlag_TextBox.Location = new System.Drawing.Point(196, 235);
            this.LF_HeatFreqJitterFlag_TextBox.Name = "LF_HeatFreqJitterFlag_TextBox";
            this.LF_HeatFreqJitterFlag_TextBox.ReadOnly = true;
            this.LF_HeatFreqJitterFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_HeatFreqJitterFlag_TextBox.TabIndex = 64;
            // 
            // chkLF_NoiseControl
            // 
            this.chkLF_NoiseControl.AutoSize = true;
            this.chkLF_NoiseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_NoiseControl.Location = new System.Drawing.Point(3, 264);
            this.chkLF_NoiseControl.Name = "chkLF_NoiseControl";
            this.chkLF_NoiseControl.Size = new System.Drawing.Size(187, 23);
            this.chkLF_NoiseControl.TabIndex = 65;
            this.chkLF_NoiseControl.Text = "噪声处理指令";
            this.chkLF_NoiseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_NoiseControl.UseVisualStyleBackColor = true;
            // 
            // LF_HeatingFreqFollow_TextBox
            // 
            this.LF_HeatingFreqFollow_TextBox.Enabled = false;
            this.LF_HeatingFreqFollow_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LF_HeatingFreqFollow_TextBox.Location = new System.Drawing.Point(196, 3);
            this.LF_HeatingFreqFollow_TextBox.Name = "LF_HeatingFreqFollow_TextBox";
            this.LF_HeatingFreqFollow_TextBox.ReadOnly = true;
            this.LF_HeatingFreqFollow_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LF_HeatingFreqFollow_TextBox.TabIndex = 41;
            // 
            // chkLF_HeatingFreqFollow
            // 
            this.chkLF_HeatingFreqFollow.AutoSize = true;
            this.chkLF_HeatingFreqFollow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_HeatingFreqFollow.Location = new System.Drawing.Point(3, 3);
            this.chkLF_HeatingFreqFollow.Name = "chkLF_HeatingFreqFollow";
            this.chkLF_HeatingFreqFollow.Size = new System.Drawing.Size(187, 23);
            this.chkLF_HeatingFreqFollow.TabIndex = 39;
            this.chkLF_HeatingFreqFollow.Text = "加热频率跟随标志";
            this.chkLF_HeatingFreqFollow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_HeatingFreqFollow.UseVisualStyleBackColor = true;
            // 
            // chkLF_Disp_ReserveD1B6
            // 
            this.chkLF_Disp_ReserveD1B6.AutoSize = true;
            this.chkLF_Disp_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Disp_ReserveD1B6.Location = new System.Drawing.Point(3, 438);
            this.chkLF_Disp_ReserveD1B6.Name = "chkLF_Disp_ReserveD1B6";
            this.chkLF_Disp_ReserveD1B6.Size = new System.Drawing.Size(187, 23);
            this.chkLF_Disp_ReserveD1B6.TabIndex = 84;
            this.chkLF_Disp_ReserveD1B6.Text = "ReserveD1B6";
            this.chkLF_Disp_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Disp_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // splitContainer3_LFControl
            // 
            this.splitContainer3_LFControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3_LFControl.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3_LFControl.Name = "splitContainer3_LFControl";
            // 
            // splitContainer3_LFControl.Panel1
            // 
            this.splitContainer3_LFControl.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.splitContainer3_LFControl.Panel1.Controls.Add(this.groupBoxLF_Power);
            // 
            // splitContainer3_LFControl.Panel2
            // 
            this.splitContainer3_LFControl.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer3_LFControl.Panel2.Controls.Add(this.splitter1);
            this.splitContainer3_LFControl.Size = new System.Drawing.Size(2524, 598);
            this.splitContainer3_LFControl.SplitterDistance = 183;
            this.splitContainer3_LFControl.TabIndex = 0;
            // 
            // groupBoxLF_Power
            // 
            this.groupBoxLF_Power.AutoSize = true;
            this.groupBoxLF_Power.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxLF_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLF_Power.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLF_Power.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLF_Power.Name = "groupBoxLF_Power";
            this.groupBoxLF_Power.Size = new System.Drawing.Size(183, 598);
            this.groupBoxLF_Power.TabIndex = 0;
            this.groupBoxLF_Power.TabStop = false;
            this.groupBoxLF_Power.Text = "LF 功率板";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Controls.Add(this.LF_ReserveD16_TextBox, 1, 17);
            this.tableLayoutPanel2.Controls.Add(this.LF_ReserveD15_TextBox, 1, 16);
            this.tableLayoutPanel2.Controls.Add(this.LF_ReserveD14_TextBox, 1, 15);
            this.tableLayoutPanel2.Controls.Add(this.LF_Power_ReserveD1B7_TextBox, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.LF_Power_ReserveD1B6_TextBox, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_Power_ReserveD1B6, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_PollingState, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.LF_PollingState, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_FreqControlFlag, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_HeatFlag, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.LF_FreqControlFlag, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.LF_HeatFlag, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.LF_HeatNTC2_TextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_HeatNTC2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_HeatNTC1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LF_HeatNTC1_TextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_IGBTNTC1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.LF_IGBTNTC1_TextBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_IGBTNTC2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.LF_ErrorCode, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.LF_IGBTNTC2_TextBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_PanTemp, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.LF_PanTemp_TextBox, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_Freq, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.LF_Freq_TextBox, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_ErrorCode, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_Voltage, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.LF_MCUTemp_TextBox, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.LF_Voltage_TextBox, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_Power, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_MCUTemp, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.LF_Power_TextBox, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_Power_ReserveD1B7, 0, 14);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_ReserveD14, 0, 15);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_ReserveD15, 0, 16);
            this.tableLayoutPanel2.Controls.Add(this.chkLF_ReserveD16, 0, 17);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 19;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(177, 578);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // LF_ReserveD16_TextBox
            // 
            this.LF_ReserveD16_TextBox.Enabled = false;
            this.LF_ReserveD16_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_ReserveD16_TextBox.Location = new System.Drawing.Point(113, 496);
            this.LF_ReserveD16_TextBox.Name = "LF_ReserveD16_TextBox";
            this.LF_ReserveD16_TextBox.ReadOnly = true;
            this.LF_ReserveD16_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_ReserveD16_TextBox.TabIndex = 93;
            // 
            // LF_ReserveD15_TextBox
            // 
            this.LF_ReserveD15_TextBox.Enabled = false;
            this.LF_ReserveD15_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_ReserveD15_TextBox.Location = new System.Drawing.Point(113, 467);
            this.LF_ReserveD15_TextBox.Name = "LF_ReserveD15_TextBox";
            this.LF_ReserveD15_TextBox.ReadOnly = true;
            this.LF_ReserveD15_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_ReserveD15_TextBox.TabIndex = 92;
            // 
            // LF_ReserveD14_TextBox
            // 
            this.LF_ReserveD14_TextBox.Enabled = false;
            this.LF_ReserveD14_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_ReserveD14_TextBox.Location = new System.Drawing.Point(113, 438);
            this.LF_ReserveD14_TextBox.Name = "LF_ReserveD14_TextBox";
            this.LF_ReserveD14_TextBox.ReadOnly = true;
            this.LF_ReserveD14_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_ReserveD14_TextBox.TabIndex = 91;
            // 
            // LF_Power_ReserveD1B7_TextBox
            // 
            this.LF_Power_ReserveD1B7_TextBox.Enabled = false;
            this.LF_Power_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Power_ReserveD1B7_TextBox.Location = new System.Drawing.Point(113, 409);
            this.LF_Power_ReserveD1B7_TextBox.Name = "LF_Power_ReserveD1B7_TextBox";
            this.LF_Power_ReserveD1B7_TextBox.ReadOnly = true;
            this.LF_Power_ReserveD1B7_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_Power_ReserveD1B7_TextBox.TabIndex = 90;
            // 
            // LF_Power_ReserveD1B6_TextBox
            // 
            this.LF_Power_ReserveD1B6_TextBox.Enabled = false;
            this.LF_Power_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Power_ReserveD1B6_TextBox.Location = new System.Drawing.Point(113, 380);
            this.LF_Power_ReserveD1B6_TextBox.Name = "LF_Power_ReserveD1B6_TextBox";
            this.LF_Power_ReserveD1B6_TextBox.ReadOnly = true;
            this.LF_Power_ReserveD1B6_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_Power_ReserveD1B6_TextBox.TabIndex = 85;
            // 
            // chkLF_Power_ReserveD1B6
            // 
            this.chkLF_Power_ReserveD1B6.AutoSize = true;
            this.chkLF_Power_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Power_ReserveD1B6.Location = new System.Drawing.Point(3, 380);
            this.chkLF_Power_ReserveD1B6.Name = "chkLF_Power_ReserveD1B6";
            this.chkLF_Power_ReserveD1B6.Size = new System.Drawing.Size(104, 23);
            this.chkLF_Power_ReserveD1B6.TabIndex = 85;
            this.chkLF_Power_ReserveD1B6.Text = "ReserveD1B6";
            this.chkLF_Power_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Power_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // chkLF_PollingState
            // 
            this.chkLF_PollingState.AutoSize = true;
            this.chkLF_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_PollingState.Location = new System.Drawing.Point(3, 293);
            this.chkLF_PollingState.Name = "chkLF_PollingState";
            this.chkLF_PollingState.Size = new System.Drawing.Size(104, 23);
            this.chkLF_PollingState.TabIndex = 29;
            this.chkLF_PollingState.Text = "检锅状态";
            this.chkLF_PollingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_PollingState.UseVisualStyleBackColor = true;
            // 
            // LF_PollingState
            // 
            this.LF_PollingState.Enabled = false;
            this.LF_PollingState.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_PollingState.Location = new System.Drawing.Point(113, 293);
            this.LF_PollingState.Name = "LF_PollingState";
            this.LF_PollingState.ReadOnly = true;
            this.LF_PollingState.Size = new System.Drawing.Size(61, 20);
            this.LF_PollingState.TabIndex = 31;
            // 
            // chkLF_FreqControlFlag
            // 
            this.chkLF_FreqControlFlag.AutoSize = true;
            this.chkLF_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_FreqControlFlag.Location = new System.Drawing.Point(3, 322);
            this.chkLF_FreqControlFlag.Name = "chkLF_FreqControlFlag";
            this.chkLF_FreqControlFlag.Size = new System.Drawing.Size(104, 23);
            this.chkLF_FreqControlFlag.TabIndex = 32;
            this.chkLF_FreqControlFlag.Text = "同频加热状态";
            this.chkLF_FreqControlFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_FreqControlFlag.UseVisualStyleBackColor = true;
            // 
            // chkLF_HeatFlag
            // 
            this.chkLF_HeatFlag.AutoSize = true;
            this.chkLF_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_HeatFlag.Location = new System.Drawing.Point(3, 351);
            this.chkLF_HeatFlag.Name = "chkLF_HeatFlag";
            this.chkLF_HeatFlag.Size = new System.Drawing.Size(104, 23);
            this.chkLF_HeatFlag.TabIndex = 35;
            this.chkLF_HeatFlag.Text = "主频稳定标志";
            this.chkLF_HeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_HeatFlag.UseVisualStyleBackColor = true;
            // 
            // LF_FreqControlFlag
            // 
            this.LF_FreqControlFlag.Enabled = false;
            this.LF_FreqControlFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_FreqControlFlag.Location = new System.Drawing.Point(113, 322);
            this.LF_FreqControlFlag.Name = "LF_FreqControlFlag";
            this.LF_FreqControlFlag.ReadOnly = true;
            this.LF_FreqControlFlag.Size = new System.Drawing.Size(61, 20);
            this.LF_FreqControlFlag.TabIndex = 34;
            // 
            // LF_HeatFlag
            // 
            this.LF_HeatFlag.Enabled = false;
            this.LF_HeatFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_HeatFlag.Location = new System.Drawing.Point(113, 351);
            this.LF_HeatFlag.Name = "LF_HeatFlag";
            this.LF_HeatFlag.ReadOnly = true;
            this.LF_HeatFlag.Size = new System.Drawing.Size(61, 20);
            this.LF_HeatFlag.TabIndex = 37;
            // 
            // LF_HeatNTC2_TextBox
            // 
            this.LF_HeatNTC2_TextBox.Enabled = false;
            this.LF_HeatNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_HeatNTC2_TextBox.Location = new System.Drawing.Point(113, 32);
            this.LF_HeatNTC2_TextBox.Name = "LF_HeatNTC2_TextBox";
            this.LF_HeatNTC2_TextBox.ReadOnly = true;
            this.LF_HeatNTC2_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_HeatNTC2_TextBox.TabIndex = 5;
            // 
            // chkLF_HeatNTC2
            // 
            this.chkLF_HeatNTC2.AutoSize = true;
            this.chkLF_HeatNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_HeatNTC2.Location = new System.Drawing.Point(3, 32);
            this.chkLF_HeatNTC2.Name = "chkLF_HeatNTC2";
            this.chkLF_HeatNTC2.Size = new System.Drawing.Size(104, 23);
            this.chkLF_HeatNTC2.TabIndex = 3;
            this.chkLF_HeatNTC2.Text = "HeatNTC2";
            this.chkLF_HeatNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_HeatNTC2.UseVisualStyleBackColor = true;
            // 
            // chkLF_HeatNTC1
            // 
            this.chkLF_HeatNTC1.AutoSize = true;
            this.chkLF_HeatNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_HeatNTC1.Location = new System.Drawing.Point(3, 3);
            this.chkLF_HeatNTC1.Name = "chkLF_HeatNTC1";
            this.chkLF_HeatNTC1.Size = new System.Drawing.Size(104, 23);
            this.chkLF_HeatNTC1.TabIndex = 0;
            this.chkLF_HeatNTC1.Text = "HeatNTC1";
            this.chkLF_HeatNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_HeatNTC1.UseVisualStyleBackColor = true;
            // 
            // LF_HeatNTC1_TextBox
            // 
            this.LF_HeatNTC1_TextBox.Enabled = false;
            this.LF_HeatNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_HeatNTC1_TextBox.Location = new System.Drawing.Point(113, 3);
            this.LF_HeatNTC1_TextBox.Name = "LF_HeatNTC1_TextBox";
            this.LF_HeatNTC1_TextBox.ReadOnly = true;
            this.LF_HeatNTC1_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_HeatNTC1_TextBox.TabIndex = 2;
            // 
            // chkLF_IGBTNTC1
            // 
            this.chkLF_IGBTNTC1.AutoSize = true;
            this.chkLF_IGBTNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_IGBTNTC1.Location = new System.Drawing.Point(3, 61);
            this.chkLF_IGBTNTC1.Name = "chkLF_IGBTNTC1";
            this.chkLF_IGBTNTC1.Size = new System.Drawing.Size(104, 23);
            this.chkLF_IGBTNTC1.TabIndex = 6;
            this.chkLF_IGBTNTC1.Text = "IGBTNTC1";
            this.chkLF_IGBTNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_IGBTNTC1.UseVisualStyleBackColor = true;
            // 
            // LF_IGBTNTC1_TextBox
            // 
            this.LF_IGBTNTC1_TextBox.Enabled = false;
            this.LF_IGBTNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_IGBTNTC1_TextBox.Location = new System.Drawing.Point(113, 61);
            this.LF_IGBTNTC1_TextBox.Name = "LF_IGBTNTC1_TextBox";
            this.LF_IGBTNTC1_TextBox.ReadOnly = true;
            this.LF_IGBTNTC1_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_IGBTNTC1_TextBox.TabIndex = 8;
            // 
            // chkLF_IGBTNTC2
            // 
            this.chkLF_IGBTNTC2.AutoSize = true;
            this.chkLF_IGBTNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_IGBTNTC2.Location = new System.Drawing.Point(3, 90);
            this.chkLF_IGBTNTC2.Name = "chkLF_IGBTNTC2";
            this.chkLF_IGBTNTC2.Size = new System.Drawing.Size(104, 23);
            this.chkLF_IGBTNTC2.TabIndex = 9;
            this.chkLF_IGBTNTC2.Text = "IGBTNTC2";
            this.chkLF_IGBTNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_IGBTNTC2.UseVisualStyleBackColor = true;
            // 
            // LF_ErrorCode
            // 
            this.LF_ErrorCode.Enabled = false;
            this.LF_ErrorCode.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_ErrorCode.Location = new System.Drawing.Point(113, 264);
            this.LF_ErrorCode.Name = "LF_ErrorCode";
            this.LF_ErrorCode.ReadOnly = true;
            this.LF_ErrorCode.Size = new System.Drawing.Size(61, 20);
            this.LF_ErrorCode.TabIndex = 28;
            // 
            // LF_IGBTNTC2_TextBox
            // 
            this.LF_IGBTNTC2_TextBox.Enabled = false;
            this.LF_IGBTNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_IGBTNTC2_TextBox.Location = new System.Drawing.Point(113, 90);
            this.LF_IGBTNTC2_TextBox.Name = "LF_IGBTNTC2_TextBox";
            this.LF_IGBTNTC2_TextBox.ReadOnly = true;
            this.LF_IGBTNTC2_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_IGBTNTC2_TextBox.TabIndex = 11;
            // 
            // chkLF_PanTemp
            // 
            this.chkLF_PanTemp.AutoSize = true;
            this.chkLF_PanTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_PanTemp.Location = new System.Drawing.Point(3, 119);
            this.chkLF_PanTemp.Name = "chkLF_PanTemp";
            this.chkLF_PanTemp.Size = new System.Drawing.Size(104, 23);
            this.chkLF_PanTemp.TabIndex = 12;
            this.chkLF_PanTemp.Text = "受热品质";
            this.chkLF_PanTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_PanTemp.UseVisualStyleBackColor = true;
            // 
            // LF_PanTemp_TextBox
            // 
            this.LF_PanTemp_TextBox.Enabled = false;
            this.LF_PanTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_PanTemp_TextBox.Location = new System.Drawing.Point(113, 119);
            this.LF_PanTemp_TextBox.Name = "LF_PanTemp_TextBox";
            this.LF_PanTemp_TextBox.ReadOnly = true;
            this.LF_PanTemp_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_PanTemp_TextBox.TabIndex = 14;
            // 
            // chkLF_Freq
            // 
            this.chkLF_Freq.AutoSize = true;
            this.chkLF_Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Freq.Location = new System.Drawing.Point(3, 148);
            this.chkLF_Freq.Name = "chkLF_Freq";
            this.chkLF_Freq.Size = new System.Drawing.Size(104, 23);
            this.chkLF_Freq.TabIndex = 15;
            this.chkLF_Freq.Text = "加热频率";
            this.chkLF_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Freq.UseVisualStyleBackColor = true;
            // 
            // LF_Freq_TextBox
            // 
            this.LF_Freq_TextBox.Enabled = false;
            this.LF_Freq_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Freq_TextBox.Location = new System.Drawing.Point(113, 148);
            this.LF_Freq_TextBox.Name = "LF_Freq_TextBox";
            this.LF_Freq_TextBox.ReadOnly = true;
            this.LF_Freq_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_Freq_TextBox.TabIndex = 17;
            // 
            // chkLF_ErrorCode
            // 
            this.chkLF_ErrorCode.AutoSize = true;
            this.chkLF_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_ErrorCode.Location = new System.Drawing.Point(3, 264);
            this.chkLF_ErrorCode.Name = "chkLF_ErrorCode";
            this.chkLF_ErrorCode.Size = new System.Drawing.Size(104, 23);
            this.chkLF_ErrorCode.TabIndex = 26;
            this.chkLF_ErrorCode.Text = "错误码";
            this.chkLF_ErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_ErrorCode.UseVisualStyleBackColor = true;
            // 
            // chkLF_Voltage
            // 
            this.chkLF_Voltage.AutoSize = true;
            this.chkLF_Voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Voltage.Location = new System.Drawing.Point(3, 177);
            this.chkLF_Voltage.Name = "chkLF_Voltage";
            this.chkLF_Voltage.Size = new System.Drawing.Size(104, 23);
            this.chkLF_Voltage.TabIndex = 18;
            this.chkLF_Voltage.Text = "电压";
            this.chkLF_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Voltage.UseVisualStyleBackColor = true;
            // 
            // LF_MCUTemp_TextBox
            // 
            this.LF_MCUTemp_TextBox.Enabled = false;
            this.LF_MCUTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_MCUTemp_TextBox.Location = new System.Drawing.Point(113, 235);
            this.LF_MCUTemp_TextBox.Name = "LF_MCUTemp_TextBox";
            this.LF_MCUTemp_TextBox.ReadOnly = true;
            this.LF_MCUTemp_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_MCUTemp_TextBox.TabIndex = 25;
            // 
            // LF_Voltage_TextBox
            // 
            this.LF_Voltage_TextBox.Enabled = false;
            this.LF_Voltage_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Voltage_TextBox.Location = new System.Drawing.Point(113, 177);
            this.LF_Voltage_TextBox.Name = "LF_Voltage_TextBox";
            this.LF_Voltage_TextBox.ReadOnly = true;
            this.LF_Voltage_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_Voltage_TextBox.TabIndex = 20;
            // 
            // chkLF_Power
            // 
            this.chkLF_Power.AutoSize = true;
            this.chkLF_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Power.Location = new System.Drawing.Point(3, 206);
            this.chkLF_Power.Name = "chkLF_Power";
            this.chkLF_Power.Size = new System.Drawing.Size(104, 23);
            this.chkLF_Power.TabIndex = 21;
            this.chkLF_Power.Text = "功率";
            this.chkLF_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Power.UseVisualStyleBackColor = true;
            // 
            // chkLF_MCUTemp
            // 
            this.chkLF_MCUTemp.AutoSize = true;
            this.chkLF_MCUTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_MCUTemp.Location = new System.Drawing.Point(3, 235);
            this.chkLF_MCUTemp.Name = "chkLF_MCUTemp";
            this.chkLF_MCUTemp.Size = new System.Drawing.Size(104, 23);
            this.chkLF_MCUTemp.TabIndex = 23;
            this.chkLF_MCUTemp.Text = "芯片温度";
            this.chkLF_MCUTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_MCUTemp.UseVisualStyleBackColor = true;
            // 
            // LF_Power_TextBox
            // 
            this.LF_Power_TextBox.Enabled = false;
            this.LF_Power_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LF_Power_TextBox.Location = new System.Drawing.Point(113, 206);
            this.LF_Power_TextBox.Name = "LF_Power_TextBox";
            this.LF_Power_TextBox.ReadOnly = true;
            this.LF_Power_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LF_Power_TextBox.TabIndex = 22;
            // 
            // chkLF_Power_ReserveD1B7
            // 
            this.chkLF_Power_ReserveD1B7.AutoSize = true;
            this.chkLF_Power_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_Power_ReserveD1B7.Location = new System.Drawing.Point(3, 409);
            this.chkLF_Power_ReserveD1B7.Name = "chkLF_Power_ReserveD1B7";
            this.chkLF_Power_ReserveD1B7.Size = new System.Drawing.Size(104, 23);
            this.chkLF_Power_ReserveD1B7.TabIndex = 86;
            this.chkLF_Power_ReserveD1B7.Text = "ReserveD1B7";
            this.chkLF_Power_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_Power_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkLF_ReserveD14
            // 
            this.chkLF_ReserveD14.AutoSize = true;
            this.chkLF_ReserveD14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_ReserveD14.Location = new System.Drawing.Point(3, 438);
            this.chkLF_ReserveD14.Name = "chkLF_ReserveD14";
            this.chkLF_ReserveD14.Size = new System.Drawing.Size(104, 23);
            this.chkLF_ReserveD14.TabIndex = 87;
            this.chkLF_ReserveD14.Text = "ReserveD14";
            this.chkLF_ReserveD14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_ReserveD14.UseVisualStyleBackColor = true;
            // 
            // chkLF_ReserveD15
            // 
            this.chkLF_ReserveD15.AutoSize = true;
            this.chkLF_ReserveD15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_ReserveD15.Location = new System.Drawing.Point(3, 467);
            this.chkLF_ReserveD15.Name = "chkLF_ReserveD15";
            this.chkLF_ReserveD15.Size = new System.Drawing.Size(104, 23);
            this.chkLF_ReserveD15.TabIndex = 88;
            this.chkLF_ReserveD15.Text = "ReserveD15";
            this.chkLF_ReserveD15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_ReserveD15.UseVisualStyleBackColor = true;
            // 
            // chkLF_ReserveD16
            // 
            this.chkLF_ReserveD16.AutoSize = true;
            this.chkLF_ReserveD16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLF_ReserveD16.Location = new System.Drawing.Point(3, 496);
            this.chkLF_ReserveD16.Name = "chkLF_ReserveD16";
            this.chkLF_ReserveD16.Size = new System.Drawing.Size(104, 23);
            this.chkLF_ReserveD16.TabIndex = 89;
            this.chkLF_ReserveD16.Text = "ReserveD16";
            this.chkLF_ReserveD16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLF_ReserveD16.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxLR_Display);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(2334, 598);
            this.splitContainer2.SplitterDistance = 264;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBoxLR_Display
            // 
            this.groupBoxLR_Display.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxLR_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLR_Display.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLR_Display.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLR_Display.Name = "groupBoxLR_Display";
            this.groupBoxLR_Display.Size = new System.Drawing.Size(264, 598);
            this.groupBoxLR_Display.TabIndex = 2;
            this.groupBoxLR_Display.TabStop = false;
            this.groupBoxLR_Display.Text = "LR 显示板";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.Controls.Add(this.LR_ReserveD8_TextBox, 1, 18);
            this.tableLayoutPanel3.Controls.Add(this.LR_ReserveD7_TextBox, 1, 17);
            this.tableLayoutPanel3.Controls.Add(this.LR_Disp_ReserveD1B7_TextBox, 1, 16);
            this.tableLayoutPanel3.Controls.Add(this.LR_Disp_ReserveD1B6_TextBox, 1, 15);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_ReserveD8, 0, 18);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_ReserveD7, 0, 17);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_Disp_ReserveD1B7, 0, 16);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_Disp_ReserveD1B6, 0, 15);
            this.tableLayoutPanel3.Controls.Add(this.LR_RequestPower_TextBox, 1, 14);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_HeatingFreqFollow, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_PanControlActive, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.LR_HeatingFreqFollow_TextBox, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_RequestPower, 0, 14);
            this.tableLayoutPanel3.Controls.Add(this.LR_PanControlActive_TextBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.LR_DebugChannel_TextBox, 1, 13);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_InnerOuterRing, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.LR_InnerOuterRing_TextBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_DebugChannel, 0, 13);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_PauseFlag, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.LR_DebugSubChannel_TextBox, 1, 12);
            this.tableLayoutPanel3.Controls.Add(this.LR_PauseFlag_TextBox, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_allZone_BridgeHeatFlag, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_DebugSubChannel, 0, 12);
            this.tableLayoutPanel3.Controls.Add(this.LR_allZone_BridgeHeatFlag_TextBox, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.LR_BridgeControl_TextBox, 1, 11);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_PPGMode, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_StoveSwitch, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_BridgeControl, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.LR_PPGMode_TextBox, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.LR_FanLevel_TextBox, 1, 10);
            this.tableLayoutPanel3.Controls.Add(this.LR_StoveSwitch_TextBox, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.LR_AllowPanDetection_TextBox, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_FanLevel, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_AllowPanDetection, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.LR_NoiseControl_TextBox, 1, 9);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_HeatFreqJitterFlag, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.LR_HeatFreqJitterFlag_TextBox, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.chkLR_NoiseControl, 0, 9);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 20;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(258, 578);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // LR_ReserveD8_TextBox
            // 
            this.LR_ReserveD8_TextBox.Enabled = false;
            this.LR_ReserveD8_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_ReserveD8_TextBox.Location = new System.Drawing.Point(190, 525);
            this.LR_ReserveD8_TextBox.Name = "LR_ReserveD8_TextBox";
            this.LR_ReserveD8_TextBox.ReadOnly = true;
            this.LR_ReserveD8_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_ReserveD8_TextBox.TabIndex = 87;
            // 
            // LR_ReserveD7_TextBox
            // 
            this.LR_ReserveD7_TextBox.Enabled = false;
            this.LR_ReserveD7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_ReserveD7_TextBox.Location = new System.Drawing.Point(190, 496);
            this.LR_ReserveD7_TextBox.Name = "LR_ReserveD7_TextBox";
            this.LR_ReserveD7_TextBox.ReadOnly = true;
            this.LR_ReserveD7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_ReserveD7_TextBox.TabIndex = 86;
            // 
            // LR_Disp_ReserveD1B7_TextBox
            // 
            this.LR_Disp_ReserveD1B7_TextBox.Enabled = false;
            this.LR_Disp_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Disp_ReserveD1B7_TextBox.Location = new System.Drawing.Point(190, 467);
            this.LR_Disp_ReserveD1B7_TextBox.Name = "LR_Disp_ReserveD1B7_TextBox";
            this.LR_Disp_ReserveD1B7_TextBox.ReadOnly = true;
            this.LR_Disp_ReserveD1B7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_Disp_ReserveD1B7_TextBox.TabIndex = 85;
            // 
            // LR_Disp_ReserveD1B6_TextBox
            // 
            this.LR_Disp_ReserveD1B6_TextBox.Enabled = false;
            this.LR_Disp_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Disp_ReserveD1B6_TextBox.Location = new System.Drawing.Point(190, 438);
            this.LR_Disp_ReserveD1B6_TextBox.Name = "LR_Disp_ReserveD1B6_TextBox";
            this.LR_Disp_ReserveD1B6_TextBox.ReadOnly = true;
            this.LR_Disp_ReserveD1B6_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_Disp_ReserveD1B6_TextBox.TabIndex = 85;
            // 
            // chkLR_ReserveD8
            // 
            this.chkLR_ReserveD8.AutoSize = true;
            this.chkLR_ReserveD8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_ReserveD8.Location = new System.Drawing.Point(3, 525);
            this.chkLR_ReserveD8.Name = "chkLR_ReserveD8";
            this.chkLR_ReserveD8.Size = new System.Drawing.Size(181, 23);
            this.chkLR_ReserveD8.TabIndex = 83;
            this.chkLR_ReserveD8.Text = "ReserveD8";
            this.chkLR_ReserveD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_ReserveD8.UseVisualStyleBackColor = true;
            // 
            // chkLR_ReserveD7
            // 
            this.chkLR_ReserveD7.AutoSize = true;
            this.chkLR_ReserveD7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_ReserveD7.Location = new System.Drawing.Point(3, 496);
            this.chkLR_ReserveD7.Name = "chkLR_ReserveD7";
            this.chkLR_ReserveD7.Size = new System.Drawing.Size(181, 23);
            this.chkLR_ReserveD7.TabIndex = 83;
            this.chkLR_ReserveD7.Text = "ReserveD7";
            this.chkLR_ReserveD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_ReserveD7.UseVisualStyleBackColor = true;
            // 
            // chkLR_Disp_ReserveD1B7
            // 
            this.chkLR_Disp_ReserveD1B7.AutoSize = true;
            this.chkLR_Disp_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Disp_ReserveD1B7.Location = new System.Drawing.Point(3, 467);
            this.chkLR_Disp_ReserveD1B7.Name = "chkLR_Disp_ReserveD1B7";
            this.chkLR_Disp_ReserveD1B7.Size = new System.Drawing.Size(181, 23);
            this.chkLR_Disp_ReserveD1B7.TabIndex = 83;
            this.chkLR_Disp_ReserveD1B7.Text = "ReserveD1B7";
            this.chkLR_Disp_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Disp_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkLR_Disp_ReserveD1B6
            // 
            this.chkLR_Disp_ReserveD1B6.AutoSize = true;
            this.chkLR_Disp_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Disp_ReserveD1B6.Location = new System.Drawing.Point(3, 438);
            this.chkLR_Disp_ReserveD1B6.Name = "chkLR_Disp_ReserveD1B6";
            this.chkLR_Disp_ReserveD1B6.Size = new System.Drawing.Size(181, 23);
            this.chkLR_Disp_ReserveD1B6.TabIndex = 85;
            this.chkLR_Disp_ReserveD1B6.Text = "ReserveD1B6";
            this.chkLR_Disp_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Disp_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // LR_RequestPower_TextBox
            // 
            this.LR_RequestPower_TextBox.Enabled = false;
            this.LR_RequestPower_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_RequestPower_TextBox.Location = new System.Drawing.Point(190, 409);
            this.LR_RequestPower_TextBox.Name = "LR_RequestPower_TextBox";
            this.LR_RequestPower_TextBox.ReadOnly = true;
            this.LR_RequestPower_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_RequestPower_TextBox.TabIndex = 83;
            // 
            // chkLR_HeatingFreqFollow
            // 
            this.chkLR_HeatingFreqFollow.AutoSize = true;
            this.chkLR_HeatingFreqFollow.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkLR_HeatingFreqFollow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_HeatingFreqFollow.Location = new System.Drawing.Point(3, 3);
            this.chkLR_HeatingFreqFollow.Name = "chkLR_HeatingFreqFollow";
            this.chkLR_HeatingFreqFollow.Size = new System.Drawing.Size(181, 23);
            this.chkLR_HeatingFreqFollow.TabIndex = 39;
            this.chkLR_HeatingFreqFollow.Text = "加热频率跟随标志";
            this.chkLR_HeatingFreqFollow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_HeatingFreqFollow.UseVisualStyleBackColor = true;
            // 
            // chkLR_PanControlActive
            // 
            this.chkLR_PanControlActive.AutoSize = true;
            this.chkLR_PanControlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_PanControlActive.Location = new System.Drawing.Point(3, 32);
            this.chkLR_PanControlActive.Name = "chkLR_PanControlActive";
            this.chkLR_PanControlActive.Size = new System.Drawing.Size(181, 23);
            this.chkLR_PanControlActive.TabIndex = 42;
            this.chkLR_PanControlActive.Text = "移锅控功激活标志";
            this.chkLR_PanControlActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_PanControlActive.UseVisualStyleBackColor = true;
            // 
            // LR_HeatingFreqFollow_TextBox
            // 
            this.LR_HeatingFreqFollow_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_HeatingFreqFollow_TextBox.Enabled = false;
            this.LR_HeatingFreqFollow_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_HeatingFreqFollow_TextBox.Location = new System.Drawing.Point(190, 3);
            this.LR_HeatingFreqFollow_TextBox.Name = "LR_HeatingFreqFollow_TextBox";
            this.LR_HeatingFreqFollow_TextBox.ReadOnly = true;
            this.LR_HeatingFreqFollow_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_HeatingFreqFollow_TextBox.TabIndex = 41;
            // 
            // chkLR_RequestPower
            // 
            this.chkLR_RequestPower.AutoSize = true;
            this.chkLR_RequestPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_RequestPower.Location = new System.Drawing.Point(3, 409);
            this.chkLR_RequestPower.Name = "chkLR_RequestPower";
            this.chkLR_RequestPower.Size = new System.Drawing.Size(181, 23);
            this.chkLR_RequestPower.TabIndex = 81;
            this.chkLR_RequestPower.Text = "请求功率值";
            this.chkLR_RequestPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_RequestPower.UseVisualStyleBackColor = true;
            // 
            // LR_PanControlActive_TextBox
            // 
            this.LR_PanControlActive_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_PanControlActive_TextBox.Enabled = false;
            this.LR_PanControlActive_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_PanControlActive_TextBox.Location = new System.Drawing.Point(190, 32);
            this.LR_PanControlActive_TextBox.Name = "LR_PanControlActive_TextBox";
            this.LR_PanControlActive_TextBox.ReadOnly = true;
            this.LR_PanControlActive_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_PanControlActive_TextBox.TabIndex = 44;
            // 
            // LR_DebugChannel_TextBox
            // 
            this.LR_DebugChannel_TextBox.Enabled = false;
            this.LR_DebugChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_DebugChannel_TextBox.Location = new System.Drawing.Point(190, 380);
            this.LR_DebugChannel_TextBox.Name = "LR_DebugChannel_TextBox";
            this.LR_DebugChannel_TextBox.ReadOnly = true;
            this.LR_DebugChannel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_DebugChannel_TextBox.TabIndex = 80;
            // 
            // chkLR_InnerOuterRing
            // 
            this.chkLR_InnerOuterRing.AutoSize = true;
            this.chkLR_InnerOuterRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_InnerOuterRing.Location = new System.Drawing.Point(3, 61);
            this.chkLR_InnerOuterRing.Name = "chkLR_InnerOuterRing";
            this.chkLR_InnerOuterRing.Size = new System.Drawing.Size(181, 23);
            this.chkLR_InnerOuterRing.TabIndex = 45;
            this.chkLR_InnerOuterRing.Text = "内外环标志";
            this.chkLR_InnerOuterRing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_InnerOuterRing.UseVisualStyleBackColor = true;
            // 
            // LR_InnerOuterRing_TextBox
            // 
            this.LR_InnerOuterRing_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_InnerOuterRing_TextBox.Enabled = false;
            this.LR_InnerOuterRing_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_InnerOuterRing_TextBox.Location = new System.Drawing.Point(190, 61);
            this.LR_InnerOuterRing_TextBox.Name = "LR_InnerOuterRing_TextBox";
            this.LR_InnerOuterRing_TextBox.ReadOnly = true;
            this.LR_InnerOuterRing_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_InnerOuterRing_TextBox.TabIndex = 48;
            // 
            // chkLR_DebugChannel
            // 
            this.chkLR_DebugChannel.AutoSize = true;
            this.chkLR_DebugChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_DebugChannel.Location = new System.Drawing.Point(3, 380);
            this.chkLR_DebugChannel.Name = "chkLR_DebugChannel";
            this.chkLR_DebugChannel.Size = new System.Drawing.Size(181, 23);
            this.chkLR_DebugChannel.TabIndex = 78;
            this.chkLR_DebugChannel.Text = "Debug通道号";
            this.chkLR_DebugChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_DebugChannel.UseVisualStyleBackColor = true;
            // 
            // chkLR_PauseFlag
            // 
            this.chkLR_PauseFlag.AutoSize = true;
            this.chkLR_PauseFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_PauseFlag.Location = new System.Drawing.Point(3, 177);
            this.chkLR_PauseFlag.Name = "chkLR_PauseFlag";
            this.chkLR_PauseFlag.Size = new System.Drawing.Size(181, 23);
            this.chkLR_PauseFlag.TabIndex = 57;
            this.chkLR_PauseFlag.Text = "暂停标志";
            this.chkLR_PauseFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_PauseFlag.UseVisualStyleBackColor = true;
            // 
            // LR_DebugSubChannel_TextBox
            // 
            this.LR_DebugSubChannel_TextBox.Enabled = false;
            this.LR_DebugSubChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_DebugSubChannel_TextBox.Location = new System.Drawing.Point(190, 351);
            this.LR_DebugSubChannel_TextBox.Name = "LR_DebugSubChannel_TextBox";
            this.LR_DebugSubChannel_TextBox.ReadOnly = true;
            this.LR_DebugSubChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_DebugSubChannel_TextBox.TabIndex = 76;
            // 
            // LR_PauseFlag_TextBox
            // 
            this.LR_PauseFlag_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_PauseFlag_TextBox.Enabled = false;
            this.LR_PauseFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_PauseFlag_TextBox.Location = new System.Drawing.Point(190, 177);
            this.LR_PauseFlag_TextBox.Name = "LR_PauseFlag_TextBox";
            this.LR_PauseFlag_TextBox.ReadOnly = true;
            this.LR_PauseFlag_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_PauseFlag_TextBox.TabIndex = 59;
            // 
            // chkLR_allZone_BridgeHeatFlag
            // 
            this.chkLR_allZone_BridgeHeatFlag.AutoSize = true;
            this.chkLR_allZone_BridgeHeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_allZone_BridgeHeatFlag.Location = new System.Drawing.Point(3, 90);
            this.chkLR_allZone_BridgeHeatFlag.Name = "chkLR_allZone_BridgeHeatFlag";
            this.chkLR_allZone_BridgeHeatFlag.Size = new System.Drawing.Size(181, 23);
            this.chkLR_allZone_BridgeHeatFlag.TabIndex = 48;
            this.chkLR_allZone_BridgeHeatFlag.Text = "无区/桥接标志/三环（红外）";
            this.chkLR_allZone_BridgeHeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_allZone_BridgeHeatFlag.UseVisualStyleBackColor = true;
            // 
            // chkLR_DebugSubChannel
            // 
            this.chkLR_DebugSubChannel.AutoSize = true;
            this.chkLR_DebugSubChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_DebugSubChannel.Location = new System.Drawing.Point(3, 351);
            this.chkLR_DebugSubChannel.Name = "chkLR_DebugSubChannel";
            this.chkLR_DebugSubChannel.Size = new System.Drawing.Size(181, 23);
            this.chkLR_DebugSubChannel.TabIndex = 74;
            this.chkLR_DebugSubChannel.Text = "Debug子通道号";
            this.chkLR_DebugSubChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_DebugSubChannel.UseVisualStyleBackColor = true;
            // 
            // LR_allZone_BridgeHeatFlag_TextBox
            // 
            this.LR_allZone_BridgeHeatFlag_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_allZone_BridgeHeatFlag_TextBox.Enabled = false;
            this.LR_allZone_BridgeHeatFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_allZone_BridgeHeatFlag_TextBox.Location = new System.Drawing.Point(190, 90);
            this.LR_allZone_BridgeHeatFlag_TextBox.Name = "LR_allZone_BridgeHeatFlag_TextBox";
            this.LR_allZone_BridgeHeatFlag_TextBox.ReadOnly = true;
            this.LR_allZone_BridgeHeatFlag_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_allZone_BridgeHeatFlag_TextBox.TabIndex = 50;
            // 
            // LR_BridgeControl_TextBox
            // 
            this.LR_BridgeControl_TextBox.Enabled = false;
            this.LR_BridgeControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_BridgeControl_TextBox.Location = new System.Drawing.Point(190, 322);
            this.LR_BridgeControl_TextBox.Name = "LR_BridgeControl_TextBox";
            this.LR_BridgeControl_TextBox.ReadOnly = true;
            this.LR_BridgeControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_BridgeControl_TextBox.TabIndex = 73;
            // 
            // chkLR_PPGMode
            // 
            this.chkLR_PPGMode.AutoSize = true;
            this.chkLR_PPGMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_PPGMode.Location = new System.Drawing.Point(3, 119);
            this.chkLR_PPGMode.Name = "chkLR_PPGMode";
            this.chkLR_PPGMode.Size = new System.Drawing.Size(181, 23);
            this.chkLR_PPGMode.TabIndex = 51;
            this.chkLR_PPGMode.Text = "PPG模式标志";
            this.chkLR_PPGMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_PPGMode.UseVisualStyleBackColor = true;
            // 
            // chkLR_StoveSwitch
            // 
            this.chkLR_StoveSwitch.AutoSize = true;
            this.chkLR_StoveSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_StoveSwitch.Location = new System.Drawing.Point(3, 206);
            this.chkLR_StoveSwitch.Name = "chkLR_StoveSwitch";
            this.chkLR_StoveSwitch.Size = new System.Drawing.Size(181, 23);
            this.chkLR_StoveSwitch.TabIndex = 60;
            this.chkLR_StoveSwitch.Text = "炉头开关标志";
            this.chkLR_StoveSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_StoveSwitch.UseVisualStyleBackColor = true;
            // 
            // chkLR_BridgeControl
            // 
            this.chkLR_BridgeControl.AutoSize = true;
            this.chkLR_BridgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_BridgeControl.Location = new System.Drawing.Point(3, 322);
            this.chkLR_BridgeControl.Name = "chkLR_BridgeControl";
            this.chkLR_BridgeControl.Size = new System.Drawing.Size(181, 23);
            this.chkLR_BridgeControl.TabIndex = 71;
            this.chkLR_BridgeControl.Text = "无区/桥接控制指令";
            this.chkLR_BridgeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_BridgeControl.UseVisualStyleBackColor = true;
            // 
            // LR_PPGMode_TextBox
            // 
            this.LR_PPGMode_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_PPGMode_TextBox.Enabled = false;
            this.LR_PPGMode_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_PPGMode_TextBox.Location = new System.Drawing.Point(190, 119);
            this.LR_PPGMode_TextBox.Name = "LR_PPGMode_TextBox";
            this.LR_PPGMode_TextBox.ReadOnly = true;
            this.LR_PPGMode_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_PPGMode_TextBox.TabIndex = 53;
            // 
            // LR_FanLevel_TextBox
            // 
            this.LR_FanLevel_TextBox.Enabled = false;
            this.LR_FanLevel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_FanLevel_TextBox.Location = new System.Drawing.Point(190, 293);
            this.LR_FanLevel_TextBox.Name = "LR_FanLevel_TextBox";
            this.LR_FanLevel_TextBox.ReadOnly = true;
            this.LR_FanLevel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_FanLevel_TextBox.TabIndex = 70;
            // 
            // LR_StoveSwitch_TextBox
            // 
            this.LR_StoveSwitch_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_StoveSwitch_TextBox.Enabled = false;
            this.LR_StoveSwitch_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_StoveSwitch_TextBox.Location = new System.Drawing.Point(190, 206);
            this.LR_StoveSwitch_TextBox.Name = "LR_StoveSwitch_TextBox";
            this.LR_StoveSwitch_TextBox.ReadOnly = true;
            this.LR_StoveSwitch_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_StoveSwitch_TextBox.TabIndex = 61;
            // 
            // LR_AllowPanDetection_TextBox
            // 
            this.LR_AllowPanDetection_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_AllowPanDetection_TextBox.Enabled = false;
            this.LR_AllowPanDetection_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_AllowPanDetection_TextBox.Location = new System.Drawing.Point(190, 148);
            this.LR_AllowPanDetection_TextBox.Name = "LR_AllowPanDetection_TextBox";
            this.LR_AllowPanDetection_TextBox.ReadOnly = true;
            this.LR_AllowPanDetection_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_AllowPanDetection_TextBox.TabIndex = 56;
            // 
            // chkLR_FanLevel
            // 
            this.chkLR_FanLevel.AutoSize = true;
            this.chkLR_FanLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_FanLevel.Location = new System.Drawing.Point(3, 293);
            this.chkLR_FanLevel.Name = "chkLR_FanLevel";
            this.chkLR_FanLevel.Size = new System.Drawing.Size(181, 23);
            this.chkLR_FanLevel.TabIndex = 68;
            this.chkLR_FanLevel.Text = "风机档位";
            this.chkLR_FanLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_FanLevel.UseVisualStyleBackColor = true;
            // 
            // chkLR_AllowPanDetection
            // 
            this.chkLR_AllowPanDetection.AutoSize = true;
            this.chkLR_AllowPanDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_AllowPanDetection.Location = new System.Drawing.Point(3, 148);
            this.chkLR_AllowPanDetection.Name = "chkLR_AllowPanDetection";
            this.chkLR_AllowPanDetection.Size = new System.Drawing.Size(181, 23);
            this.chkLR_AllowPanDetection.TabIndex = 54;
            this.chkLR_AllowPanDetection.Text = "允许检锅标志";
            this.chkLR_AllowPanDetection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_AllowPanDetection.UseVisualStyleBackColor = true;
            // 
            // LR_NoiseControl_TextBox
            // 
            this.LR_NoiseControl_TextBox.Enabled = false;
            this.LR_NoiseControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_NoiseControl_TextBox.Location = new System.Drawing.Point(190, 264);
            this.LR_NoiseControl_TextBox.Name = "LR_NoiseControl_TextBox";
            this.LR_NoiseControl_TextBox.ReadOnly = true;
            this.LR_NoiseControl_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_NoiseControl_TextBox.TabIndex = 67;
            // 
            // chkLR_HeatFreqJitterFlag
            // 
            this.chkLR_HeatFreqJitterFlag.AutoSize = true;
            this.chkLR_HeatFreqJitterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_HeatFreqJitterFlag.Location = new System.Drawing.Point(3, 235);
            this.chkLR_HeatFreqJitterFlag.Name = "chkLR_HeatFreqJitterFlag";
            this.chkLR_HeatFreqJitterFlag.Size = new System.Drawing.Size(181, 23);
            this.chkLR_HeatFreqJitterFlag.TabIndex = 62;
            this.chkLR_HeatFreqJitterFlag.Text = "加热频率抖频率模式";
            this.chkLR_HeatFreqJitterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_HeatFreqJitterFlag.UseVisualStyleBackColor = true;
            // 
            // LR_HeatFreqJitterFlag_TextBox
            // 
            this.LR_HeatFreqJitterFlag_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LR_HeatFreqJitterFlag_TextBox.Enabled = false;
            this.LR_HeatFreqJitterFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_HeatFreqJitterFlag_TextBox.Location = new System.Drawing.Point(190, 235);
            this.LR_HeatFreqJitterFlag_TextBox.Name = "LR_HeatFreqJitterFlag_TextBox";
            this.LR_HeatFreqJitterFlag_TextBox.ReadOnly = true;
            this.LR_HeatFreqJitterFlag_TextBox.Size = new System.Drawing.Size(65, 20);
            this.LR_HeatFreqJitterFlag_TextBox.TabIndex = 64;
            // 
            // chkLR_NoiseControl
            // 
            this.chkLR_NoiseControl.AutoSize = true;
            this.chkLR_NoiseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_NoiseControl.Location = new System.Drawing.Point(3, 264);
            this.chkLR_NoiseControl.Name = "chkLR_NoiseControl";
            this.chkLR_NoiseControl.Size = new System.Drawing.Size(181, 23);
            this.chkLR_NoiseControl.TabIndex = 65;
            this.chkLR_NoiseControl.Text = "噪声处理指令";
            this.chkLR_NoiseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_NoiseControl.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBoxLR_Power);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(2066, 598);
            this.splitContainer3.SplitterDistance = 185;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBoxLR_Power
            // 
            this.groupBoxLR_Power.AutoSize = true;
            this.groupBoxLR_Power.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxLR_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLR_Power.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLR_Power.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLR_Power.Name = "groupBoxLR_Power";
            this.groupBoxLR_Power.Size = new System.Drawing.Size(185, 598);
            this.groupBoxLR_Power.TabIndex = 1;
            this.groupBoxLR_Power.TabStop = false;
            this.groupBoxLR_Power.Text = "LR 功率板";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.Controls.Add(this.LR_ReserveD16_TextBox, 1, 17);
            this.tableLayoutPanel4.Controls.Add(this.LR_ReserveD15_TextBox, 1, 16);
            this.tableLayoutPanel4.Controls.Add(this.LR_ReserveD14_TextBox, 1, 15);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_ReserveD16, 0, 17);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_PollingState, 0, 10);
            this.tableLayoutPanel4.Controls.Add(this.LR_PollingState, 1, 10);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_FreqControlFlag, 0, 11);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_HeatFlag, 0, 12);
            this.tableLayoutPanel4.Controls.Add(this.LR_FreqControlFlag, 1, 11);
            this.tableLayoutPanel4.Controls.Add(this.LR_HeatFlag, 1, 12);
            this.tableLayoutPanel4.Controls.Add(this.LR_HeatNTC2_TextBox, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_HeatNTC2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_HeatNTC1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.LR_HeatNTC1_TextBox, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_IGBTNTC1, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.LR_IGBTNTC1_TextBox, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_IGBTNTC2, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.LR_ErrorCode, 1, 9);
            this.tableLayoutPanel4.Controls.Add(this.LR_IGBTNTC2_TextBox, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_PanTemp, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.LR_PanTemp_TextBox, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_Freq, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.LR_Freq_TextBox, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_ErrorCode, 0, 9);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_Voltage, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.LR_MCUTemp_TextBox, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.LR_Voltage_TextBox, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_Power, 0, 7);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_MCUTemp, 0, 8);
            this.tableLayoutPanel4.Controls.Add(this.LR_Power_TextBox, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_Power_ReserveD1B6, 0, 13);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_Power_ReserveD1B7, 0, 14);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_ReserveD14, 0, 15);
            this.tableLayoutPanel4.Controls.Add(this.chkLR_ReserveD15, 0, 16);
            this.tableLayoutPanel4.Controls.Add(this.LR_Power_ReserveD1B6_TextBox, 1, 13);
            this.tableLayoutPanel4.Controls.Add(this.LR_Power_ReserveD1B7_TextBox, 1, 14);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 19;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(179, 578);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // LR_ReserveD16_TextBox
            // 
            this.LR_ReserveD16_TextBox.Enabled = false;
            this.LR_ReserveD16_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_ReserveD16_TextBox.Location = new System.Drawing.Point(113, 496);
            this.LR_ReserveD16_TextBox.Name = "LR_ReserveD16_TextBox";
            this.LR_ReserveD16_TextBox.ReadOnly = true;
            this.LR_ReserveD16_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_ReserveD16_TextBox.TabIndex = 94;
            // 
            // LR_ReserveD15_TextBox
            // 
            this.LR_ReserveD15_TextBox.Enabled = false;
            this.LR_ReserveD15_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_ReserveD15_TextBox.Location = new System.Drawing.Point(113, 467);
            this.LR_ReserveD15_TextBox.Name = "LR_ReserveD15_TextBox";
            this.LR_ReserveD15_TextBox.ReadOnly = true;
            this.LR_ReserveD15_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_ReserveD15_TextBox.TabIndex = 93;
            // 
            // LR_ReserveD14_TextBox
            // 
            this.LR_ReserveD14_TextBox.Enabled = false;
            this.LR_ReserveD14_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_ReserveD14_TextBox.Location = new System.Drawing.Point(113, 438);
            this.LR_ReserveD14_TextBox.Name = "LR_ReserveD14_TextBox";
            this.LR_ReserveD14_TextBox.ReadOnly = true;
            this.LR_ReserveD14_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_ReserveD14_TextBox.TabIndex = 92;
            // 
            // chkLR_ReserveD16
            // 
            this.chkLR_ReserveD16.AutoSize = true;
            this.chkLR_ReserveD16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_ReserveD16.Location = new System.Drawing.Point(3, 496);
            this.chkLR_ReserveD16.Name = "chkLR_ReserveD16";
            this.chkLR_ReserveD16.Size = new System.Drawing.Size(104, 23);
            this.chkLR_ReserveD16.TabIndex = 91;
            this.chkLR_ReserveD16.Text = "ReserveD16";
            this.chkLR_ReserveD16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_ReserveD16.UseVisualStyleBackColor = true;
            // 
            // chkLR_PollingState
            // 
            this.chkLR_PollingState.AutoSize = true;
            this.chkLR_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_PollingState.Location = new System.Drawing.Point(3, 293);
            this.chkLR_PollingState.Name = "chkLR_PollingState";
            this.chkLR_PollingState.Size = new System.Drawing.Size(104, 23);
            this.chkLR_PollingState.TabIndex = 29;
            this.chkLR_PollingState.Text = "检锅状态";
            this.chkLR_PollingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_PollingState.UseVisualStyleBackColor = true;
            // 
            // LR_PollingState
            // 
            this.LR_PollingState.Enabled = false;
            this.LR_PollingState.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_PollingState.Location = new System.Drawing.Point(113, 293);
            this.LR_PollingState.Name = "LR_PollingState";
            this.LR_PollingState.ReadOnly = true;
            this.LR_PollingState.Size = new System.Drawing.Size(61, 20);
            this.LR_PollingState.TabIndex = 31;
            // 
            // chkLR_FreqControlFlag
            // 
            this.chkLR_FreqControlFlag.AutoSize = true;
            this.chkLR_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_FreqControlFlag.Location = new System.Drawing.Point(3, 322);
            this.chkLR_FreqControlFlag.Name = "chkLR_FreqControlFlag";
            this.chkLR_FreqControlFlag.Size = new System.Drawing.Size(104, 23);
            this.chkLR_FreqControlFlag.TabIndex = 32;
            this.chkLR_FreqControlFlag.Text = "同频加热状态";
            this.chkLR_FreqControlFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_FreqControlFlag.UseVisualStyleBackColor = true;
            // 
            // chkLR_HeatFlag
            // 
            this.chkLR_HeatFlag.AutoSize = true;
            this.chkLR_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_HeatFlag.Location = new System.Drawing.Point(3, 351);
            this.chkLR_HeatFlag.Name = "chkLR_HeatFlag";
            this.chkLR_HeatFlag.Size = new System.Drawing.Size(104, 23);
            this.chkLR_HeatFlag.TabIndex = 35;
            this.chkLR_HeatFlag.Text = "主频稳定标志";
            this.chkLR_HeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_HeatFlag.UseVisualStyleBackColor = true;
            // 
            // LR_FreqControlFlag
            // 
            this.LR_FreqControlFlag.Enabled = false;
            this.LR_FreqControlFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_FreqControlFlag.Location = new System.Drawing.Point(113, 322);
            this.LR_FreqControlFlag.Name = "LR_FreqControlFlag";
            this.LR_FreqControlFlag.ReadOnly = true;
            this.LR_FreqControlFlag.Size = new System.Drawing.Size(62, 20);
            this.LR_FreqControlFlag.TabIndex = 34;
            // 
            // LR_HeatFlag
            // 
            this.LR_HeatFlag.Enabled = false;
            this.LR_HeatFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_HeatFlag.Location = new System.Drawing.Point(113, 351);
            this.LR_HeatFlag.Name = "LR_HeatFlag";
            this.LR_HeatFlag.ReadOnly = true;
            this.LR_HeatFlag.Size = new System.Drawing.Size(62, 20);
            this.LR_HeatFlag.TabIndex = 37;
            // 
            // LR_HeatNTC2_TextBox
            // 
            this.LR_HeatNTC2_TextBox.Enabled = false;
            this.LR_HeatNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_HeatNTC2_TextBox.Location = new System.Drawing.Point(113, 32);
            this.LR_HeatNTC2_TextBox.Name = "LR_HeatNTC2_TextBox";
            this.LR_HeatNTC2_TextBox.ReadOnly = true;
            this.LR_HeatNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_HeatNTC2_TextBox.TabIndex = 5;
            // 
            // chkLR_HeatNTC2
            // 
            this.chkLR_HeatNTC2.AutoSize = true;
            this.chkLR_HeatNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_HeatNTC2.Location = new System.Drawing.Point(3, 32);
            this.chkLR_HeatNTC2.Name = "chkLR_HeatNTC2";
            this.chkLR_HeatNTC2.Size = new System.Drawing.Size(104, 23);
            this.chkLR_HeatNTC2.TabIndex = 3;
            this.chkLR_HeatNTC2.Text = "HeatNTC2";
            this.chkLR_HeatNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_HeatNTC2.UseVisualStyleBackColor = true;
            // 
            // chkLR_HeatNTC1
            // 
            this.chkLR_HeatNTC1.AutoSize = true;
            this.chkLR_HeatNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_HeatNTC1.Location = new System.Drawing.Point(3, 3);
            this.chkLR_HeatNTC1.Name = "chkLR_HeatNTC1";
            this.chkLR_HeatNTC1.Size = new System.Drawing.Size(104, 23);
            this.chkLR_HeatNTC1.TabIndex = 0;
            this.chkLR_HeatNTC1.Text = "HeatNTC1";
            this.chkLR_HeatNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_HeatNTC1.UseVisualStyleBackColor = true;
            // 
            // LR_HeatNTC1_TextBox
            // 
            this.LR_HeatNTC1_TextBox.Enabled = false;
            this.LR_HeatNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_HeatNTC1_TextBox.Location = new System.Drawing.Point(113, 3);
            this.LR_HeatNTC1_TextBox.Name = "LR_HeatNTC1_TextBox";
            this.LR_HeatNTC1_TextBox.ReadOnly = true;
            this.LR_HeatNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_HeatNTC1_TextBox.TabIndex = 2;
            // 
            // chkLR_IGBTNTC1
            // 
            this.chkLR_IGBTNTC1.AutoSize = true;
            this.chkLR_IGBTNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_IGBTNTC1.Location = new System.Drawing.Point(3, 61);
            this.chkLR_IGBTNTC1.Name = "chkLR_IGBTNTC1";
            this.chkLR_IGBTNTC1.Size = new System.Drawing.Size(104, 23);
            this.chkLR_IGBTNTC1.TabIndex = 6;
            this.chkLR_IGBTNTC1.Text = "IGBTNTC1";
            this.chkLR_IGBTNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_IGBTNTC1.UseVisualStyleBackColor = true;
            // 
            // LR_IGBTNTC1_TextBox
            // 
            this.LR_IGBTNTC1_TextBox.Enabled = false;
            this.LR_IGBTNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_IGBTNTC1_TextBox.Location = new System.Drawing.Point(113, 61);
            this.LR_IGBTNTC1_TextBox.Name = "LR_IGBTNTC1_TextBox";
            this.LR_IGBTNTC1_TextBox.ReadOnly = true;
            this.LR_IGBTNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_IGBTNTC1_TextBox.TabIndex = 8;
            // 
            // chkLR_IGBTNTC2
            // 
            this.chkLR_IGBTNTC2.AutoSize = true;
            this.chkLR_IGBTNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_IGBTNTC2.Location = new System.Drawing.Point(3, 90);
            this.chkLR_IGBTNTC2.Name = "chkLR_IGBTNTC2";
            this.chkLR_IGBTNTC2.Size = new System.Drawing.Size(104, 23);
            this.chkLR_IGBTNTC2.TabIndex = 9;
            this.chkLR_IGBTNTC2.Text = "IGBTNTC2";
            this.chkLR_IGBTNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_IGBTNTC2.UseVisualStyleBackColor = true;
            // 
            // LR_ErrorCode
            // 
            this.LR_ErrorCode.Enabled = false;
            this.LR_ErrorCode.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_ErrorCode.Location = new System.Drawing.Point(113, 264);
            this.LR_ErrorCode.Name = "LR_ErrorCode";
            this.LR_ErrorCode.ReadOnly = true;
            this.LR_ErrorCode.Size = new System.Drawing.Size(61, 20);
            this.LR_ErrorCode.TabIndex = 28;
            // 
            // LR_IGBTNTC2_TextBox
            // 
            this.LR_IGBTNTC2_TextBox.Enabled = false;
            this.LR_IGBTNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_IGBTNTC2_TextBox.Location = new System.Drawing.Point(113, 90);
            this.LR_IGBTNTC2_TextBox.Name = "LR_IGBTNTC2_TextBox";
            this.LR_IGBTNTC2_TextBox.ReadOnly = true;
            this.LR_IGBTNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_IGBTNTC2_TextBox.TabIndex = 11;
            // 
            // chkLR_PanTemp
            // 
            this.chkLR_PanTemp.AutoSize = true;
            this.chkLR_PanTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_PanTemp.Location = new System.Drawing.Point(3, 119);
            this.chkLR_PanTemp.Name = "chkLR_PanTemp";
            this.chkLR_PanTemp.Size = new System.Drawing.Size(104, 23);
            this.chkLR_PanTemp.TabIndex = 12;
            this.chkLR_PanTemp.Text = "受热品质";
            this.chkLR_PanTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_PanTemp.UseVisualStyleBackColor = true;
            // 
            // LR_PanTemp_TextBox
            // 
            this.LR_PanTemp_TextBox.Enabled = false;
            this.LR_PanTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_PanTemp_TextBox.Location = new System.Drawing.Point(113, 119);
            this.LR_PanTemp_TextBox.Name = "LR_PanTemp_TextBox";
            this.LR_PanTemp_TextBox.ReadOnly = true;
            this.LR_PanTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_PanTemp_TextBox.TabIndex = 14;
            // 
            // chkLR_Freq
            // 
            this.chkLR_Freq.AutoSize = true;
            this.chkLR_Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Freq.Location = new System.Drawing.Point(3, 148);
            this.chkLR_Freq.Name = "chkLR_Freq";
            this.chkLR_Freq.Size = new System.Drawing.Size(104, 23);
            this.chkLR_Freq.TabIndex = 15;
            this.chkLR_Freq.Text = "加热频率";
            this.chkLR_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Freq.UseVisualStyleBackColor = true;
            // 
            // LR_Freq_TextBox
            // 
            this.LR_Freq_TextBox.Enabled = false;
            this.LR_Freq_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Freq_TextBox.Location = new System.Drawing.Point(113, 148);
            this.LR_Freq_TextBox.Name = "LR_Freq_TextBox";
            this.LR_Freq_TextBox.ReadOnly = true;
            this.LR_Freq_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_Freq_TextBox.TabIndex = 17;
            // 
            // chkLR_ErrorCode
            // 
            this.chkLR_ErrorCode.AutoSize = true;
            this.chkLR_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_ErrorCode.Location = new System.Drawing.Point(3, 264);
            this.chkLR_ErrorCode.Name = "chkLR_ErrorCode";
            this.chkLR_ErrorCode.Size = new System.Drawing.Size(104, 23);
            this.chkLR_ErrorCode.TabIndex = 26;
            this.chkLR_ErrorCode.Text = "错误码";
            this.chkLR_ErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_ErrorCode.UseVisualStyleBackColor = true;
            // 
            // chkLR_Voltage
            // 
            this.chkLR_Voltage.AutoSize = true;
            this.chkLR_Voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Voltage.Location = new System.Drawing.Point(3, 177);
            this.chkLR_Voltage.Name = "chkLR_Voltage";
            this.chkLR_Voltage.Size = new System.Drawing.Size(104, 23);
            this.chkLR_Voltage.TabIndex = 18;
            this.chkLR_Voltage.Text = "电压";
            this.chkLR_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Voltage.UseVisualStyleBackColor = true;
            // 
            // LR_MCUTemp_TextBox
            // 
            this.LR_MCUTemp_TextBox.Enabled = false;
            this.LR_MCUTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_MCUTemp_TextBox.Location = new System.Drawing.Point(113, 235);
            this.LR_MCUTemp_TextBox.Name = "LR_MCUTemp_TextBox";
            this.LR_MCUTemp_TextBox.ReadOnly = true;
            this.LR_MCUTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_MCUTemp_TextBox.TabIndex = 25;
            // 
            // LR_Voltage_TextBox
            // 
            this.LR_Voltage_TextBox.Enabled = false;
            this.LR_Voltage_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Voltage_TextBox.Location = new System.Drawing.Point(113, 177);
            this.LR_Voltage_TextBox.Name = "LR_Voltage_TextBox";
            this.LR_Voltage_TextBox.ReadOnly = true;
            this.LR_Voltage_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_Voltage_TextBox.TabIndex = 20;
            // 
            // chkLR_Power
            // 
            this.chkLR_Power.AutoSize = true;
            this.chkLR_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Power.Location = new System.Drawing.Point(3, 206);
            this.chkLR_Power.Name = "chkLR_Power";
            this.chkLR_Power.Size = new System.Drawing.Size(104, 23);
            this.chkLR_Power.TabIndex = 21;
            this.chkLR_Power.Text = "功率";
            this.chkLR_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Power.UseVisualStyleBackColor = true;
            // 
            // chkLR_MCUTemp
            // 
            this.chkLR_MCUTemp.AutoSize = true;
            this.chkLR_MCUTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_MCUTemp.Location = new System.Drawing.Point(3, 235);
            this.chkLR_MCUTemp.Name = "chkLR_MCUTemp";
            this.chkLR_MCUTemp.Size = new System.Drawing.Size(104, 23);
            this.chkLR_MCUTemp.TabIndex = 23;
            this.chkLR_MCUTemp.Text = "芯片温度";
            this.chkLR_MCUTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_MCUTemp.UseVisualStyleBackColor = true;
            // 
            // LR_Power_TextBox
            // 
            this.LR_Power_TextBox.Enabled = false;
            this.LR_Power_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Power_TextBox.Location = new System.Drawing.Point(113, 206);
            this.LR_Power_TextBox.Name = "LR_Power_TextBox";
            this.LR_Power_TextBox.ReadOnly = true;
            this.LR_Power_TextBox.Size = new System.Drawing.Size(62, 20);
            this.LR_Power_TextBox.TabIndex = 22;
            // 
            // chkLR_Power_ReserveD1B6
            // 
            this.chkLR_Power_ReserveD1B6.AutoSize = true;
            this.chkLR_Power_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Power_ReserveD1B6.Location = new System.Drawing.Point(3, 380);
            this.chkLR_Power_ReserveD1B6.Name = "chkLR_Power_ReserveD1B6";
            this.chkLR_Power_ReserveD1B6.Size = new System.Drawing.Size(104, 23);
            this.chkLR_Power_ReserveD1B6.TabIndex = 86;
            this.chkLR_Power_ReserveD1B6.Text = "ReserveD1B6";
            this.chkLR_Power_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Power_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // chkLR_Power_ReserveD1B7
            // 
            this.chkLR_Power_ReserveD1B7.AutoSize = true;
            this.chkLR_Power_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_Power_ReserveD1B7.Location = new System.Drawing.Point(3, 409);
            this.chkLR_Power_ReserveD1B7.Name = "chkLR_Power_ReserveD1B7";
            this.chkLR_Power_ReserveD1B7.Size = new System.Drawing.Size(104, 23);
            this.chkLR_Power_ReserveD1B7.TabIndex = 88;
            this.chkLR_Power_ReserveD1B7.Text = "ReserveD1B7";
            this.chkLR_Power_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_Power_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkLR_ReserveD14
            // 
            this.chkLR_ReserveD14.AutoSize = true;
            this.chkLR_ReserveD14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_ReserveD14.Location = new System.Drawing.Point(3, 438);
            this.chkLR_ReserveD14.Name = "chkLR_ReserveD14";
            this.chkLR_ReserveD14.Size = new System.Drawing.Size(104, 23);
            this.chkLR_ReserveD14.TabIndex = 89;
            this.chkLR_ReserveD14.Text = "ReserveD14";
            this.chkLR_ReserveD14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_ReserveD14.UseVisualStyleBackColor = true;
            // 
            // chkLR_ReserveD15
            // 
            this.chkLR_ReserveD15.AutoSize = true;
            this.chkLR_ReserveD15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLR_ReserveD15.Location = new System.Drawing.Point(3, 467);
            this.chkLR_ReserveD15.Name = "chkLR_ReserveD15";
            this.chkLR_ReserveD15.Size = new System.Drawing.Size(104, 23);
            this.chkLR_ReserveD15.TabIndex = 90;
            this.chkLR_ReserveD15.Text = "ReserveD15";
            this.chkLR_ReserveD15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkLR_ReserveD15.UseVisualStyleBackColor = true;
            // 
            // LR_Power_ReserveD1B6_TextBox
            // 
            this.LR_Power_ReserveD1B6_TextBox.Enabled = false;
            this.LR_Power_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Power_ReserveD1B6_TextBox.Location = new System.Drawing.Point(113, 380);
            this.LR_Power_ReserveD1B6_TextBox.Name = "LR_Power_ReserveD1B6_TextBox";
            this.LR_Power_ReserveD1B6_TextBox.ReadOnly = true;
            this.LR_Power_ReserveD1B6_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_Power_ReserveD1B6_TextBox.TabIndex = 92;
            // 
            // LR_Power_ReserveD1B7_TextBox
            // 
            this.LR_Power_ReserveD1B7_TextBox.Enabled = false;
            this.LR_Power_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.LR_Power_ReserveD1B7_TextBox.Location = new System.Drawing.Point(113, 409);
            this.LR_Power_ReserveD1B7_TextBox.Name = "LR_Power_ReserveD1B7_TextBox";
            this.LR_Power_ReserveD1B7_TextBox.ReadOnly = true;
            this.LR_Power_ReserveD1B7_TextBox.Size = new System.Drawing.Size(61, 20);
            this.LR_Power_ReserveD1B7_TextBox.TabIndex = 93;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox6);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(1877, 598);
            this.splitContainer4.SplitterDistance = 264;
            this.splitContainer4.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(264, 598);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "RF 显示板";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.Controls.Add(this.RF_ReserveD8_TextBox, 1, 18);
            this.tableLayoutPanel5.Controls.Add(this.RF_ReserveD7_TextBox, 1, 17);
            this.tableLayoutPanel5.Controls.Add(this.RF_Disp_ReserveD1B7_TextBox, 1, 16);
            this.tableLayoutPanel5.Controls.Add(this.RF_Disp_ReserveD1B6_TextBox, 1, 15);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_ReserveD8, 0, 18);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_ReserveD7, 0, 17);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_Disp_ReserveD1B7, 0, 16);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_Disp_ReserveD1B6, 0, 15);
            this.tableLayoutPanel5.Controls.Add(this.RF_RequestPower_TextBox, 1, 14);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_HeatingFreqFollow, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_PanControlActive, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.RF_HeatingFreqFollow_TextBox, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_RequestPower, 0, 14);
            this.tableLayoutPanel5.Controls.Add(this.RF_PanControlActive_TextBox, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.RF_DebugChannel_TextBox, 1, 13);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_InnerOuterRing, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.RF_InnerOuterRing_TextBox, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_DebugChannel, 0, 13);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_PauseFlag, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.RF_DebugSubChannel_TextBox, 1, 12);
            this.tableLayoutPanel5.Controls.Add(this.RF_PauseFlag_TextBox, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_allZone_BridgeHeatFlag, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_DebugSubChannel, 0, 12);
            this.tableLayoutPanel5.Controls.Add(this.RF_allZone_BridgeHeatFlag_TextBox, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.RF_BridgeControl_TextBox, 1, 11);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_PPGMode, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_StoveSwitch, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_BridgeControl, 0, 11);
            this.tableLayoutPanel5.Controls.Add(this.RF_PPGMode_TextBox, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.RF_FanLevel_TextBox, 1, 10);
            this.tableLayoutPanel5.Controls.Add(this.RF_StoveSwitch_TextBox, 1, 7);
            this.tableLayoutPanel5.Controls.Add(this.RF_AllowPanDetection_TextBox, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_FanLevel, 0, 10);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_AllowPanDetection, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.RF_NoiseControl_TextBox, 1, 9);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_HeatFreqJitterFlag, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.RF_HeatFreqJitterFlag_TextBox, 1, 8);
            this.tableLayoutPanel5.Controls.Add(this.chkRF_NoiseControl, 0, 9);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 20;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(258, 578);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // RF_ReserveD8_TextBox
            // 
            this.RF_ReserveD8_TextBox.Enabled = false;
            this.RF_ReserveD8_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_ReserveD8_TextBox.Location = new System.Drawing.Point(192, 525);
            this.RF_ReserveD8_TextBox.Name = "RF_ReserveD8_TextBox";
            this.RF_ReserveD8_TextBox.ReadOnly = true;
            this.RF_ReserveD8_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_ReserveD8_TextBox.TabIndex = 88;
            // 
            // RF_ReserveD7_TextBox
            // 
            this.RF_ReserveD7_TextBox.Enabled = false;
            this.RF_ReserveD7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_ReserveD7_TextBox.Location = new System.Drawing.Point(192, 496);
            this.RF_ReserveD7_TextBox.Name = "RF_ReserveD7_TextBox";
            this.RF_ReserveD7_TextBox.ReadOnly = true;
            this.RF_ReserveD7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_ReserveD7_TextBox.TabIndex = 87;
            // 
            // RF_Disp_ReserveD1B7_TextBox
            // 
            this.RF_Disp_ReserveD1B7_TextBox.Enabled = false;
            this.RF_Disp_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Disp_ReserveD1B7_TextBox.Location = new System.Drawing.Point(192, 467);
            this.RF_Disp_ReserveD1B7_TextBox.Name = "RF_Disp_ReserveD1B7_TextBox";
            this.RF_Disp_ReserveD1B7_TextBox.ReadOnly = true;
            this.RF_Disp_ReserveD1B7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_Disp_ReserveD1B7_TextBox.TabIndex = 86;
            // 
            // RF_Disp_ReserveD1B6_TextBox
            // 
            this.RF_Disp_ReserveD1B6_TextBox.Enabled = false;
            this.RF_Disp_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Disp_ReserveD1B6_TextBox.Location = new System.Drawing.Point(192, 438);
            this.RF_Disp_ReserveD1B6_TextBox.Name = "RF_Disp_ReserveD1B6_TextBox";
            this.RF_Disp_ReserveD1B6_TextBox.ReadOnly = true;
            this.RF_Disp_ReserveD1B6_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_Disp_ReserveD1B6_TextBox.TabIndex = 86;
            // 
            // chkRF_ReserveD8
            // 
            this.chkRF_ReserveD8.AutoSize = true;
            this.chkRF_ReserveD8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_ReserveD8.Location = new System.Drawing.Point(3, 525);
            this.chkRF_ReserveD8.Name = "chkRF_ReserveD8";
            this.chkRF_ReserveD8.Size = new System.Drawing.Size(183, 23);
            this.chkRF_ReserveD8.TabIndex = 84;
            this.chkRF_ReserveD8.Text = "ReserveD8";
            this.chkRF_ReserveD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_ReserveD8.UseVisualStyleBackColor = true;
            // 
            // chkRF_ReserveD7
            // 
            this.chkRF_ReserveD7.AutoSize = true;
            this.chkRF_ReserveD7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_ReserveD7.Location = new System.Drawing.Point(3, 496);
            this.chkRF_ReserveD7.Name = "chkRF_ReserveD7";
            this.chkRF_ReserveD7.Size = new System.Drawing.Size(183, 23);
            this.chkRF_ReserveD7.TabIndex = 84;
            this.chkRF_ReserveD7.Text = "ReserveD7";
            this.chkRF_ReserveD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_ReserveD7.UseVisualStyleBackColor = true;
            // 
            // chkRF_Disp_ReserveD1B7
            // 
            this.chkRF_Disp_ReserveD1B7.AutoSize = true;
            this.chkRF_Disp_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Disp_ReserveD1B7.Location = new System.Drawing.Point(3, 467);
            this.chkRF_Disp_ReserveD1B7.Name = "chkRF_Disp_ReserveD1B7";
            this.chkRF_Disp_ReserveD1B7.Size = new System.Drawing.Size(183, 23);
            this.chkRF_Disp_ReserveD1B7.TabIndex = 84;
            this.chkRF_Disp_ReserveD1B7.Text = "ReserveD1B7";
            this.chkRF_Disp_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Disp_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkRF_Disp_ReserveD1B6
            // 
            this.chkRF_Disp_ReserveD1B6.AutoSize = true;
            this.chkRF_Disp_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Disp_ReserveD1B6.Location = new System.Drawing.Point(3, 438);
            this.chkRF_Disp_ReserveD1B6.Name = "chkRF_Disp_ReserveD1B6";
            this.chkRF_Disp_ReserveD1B6.Size = new System.Drawing.Size(183, 23);
            this.chkRF_Disp_ReserveD1B6.TabIndex = 86;
            this.chkRF_Disp_ReserveD1B6.Text = "ReserveD1B6";
            this.chkRF_Disp_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Disp_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // RF_RequestPower_TextBox
            // 
            this.RF_RequestPower_TextBox.Enabled = false;
            this.RF_RequestPower_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_RequestPower_TextBox.Location = new System.Drawing.Point(192, 409);
            this.RF_RequestPower_TextBox.Name = "RF_RequestPower_TextBox";
            this.RF_RequestPower_TextBox.ReadOnly = true;
            this.RF_RequestPower_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_RequestPower_TextBox.TabIndex = 83;
            // 
            // chkRF_HeatingFreqFollow
            // 
            this.chkRF_HeatingFreqFollow.AutoSize = true;
            this.chkRF_HeatingFreqFollow.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkRF_HeatingFreqFollow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_HeatingFreqFollow.Location = new System.Drawing.Point(3, 3);
            this.chkRF_HeatingFreqFollow.Name = "chkRF_HeatingFreqFollow";
            this.chkRF_HeatingFreqFollow.Size = new System.Drawing.Size(183, 23);
            this.chkRF_HeatingFreqFollow.TabIndex = 39;
            this.chkRF_HeatingFreqFollow.Text = "加热频率跟随标志";
            this.chkRF_HeatingFreqFollow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_HeatingFreqFollow.UseVisualStyleBackColor = true;
            // 
            // chkRF_PanControlActive
            // 
            this.chkRF_PanControlActive.AutoSize = true;
            this.chkRF_PanControlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_PanControlActive.Location = new System.Drawing.Point(3, 32);
            this.chkRF_PanControlActive.Name = "chkRF_PanControlActive";
            this.chkRF_PanControlActive.Size = new System.Drawing.Size(183, 23);
            this.chkRF_PanControlActive.TabIndex = 42;
            this.chkRF_PanControlActive.Text = "移锅控功激活标志";
            this.chkRF_PanControlActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_PanControlActive.UseVisualStyleBackColor = true;
            // 
            // RF_HeatingFreqFollow_TextBox
            // 
            this.RF_HeatingFreqFollow_TextBox.Enabled = false;
            this.RF_HeatingFreqFollow_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_HeatingFreqFollow_TextBox.Location = new System.Drawing.Point(192, 3);
            this.RF_HeatingFreqFollow_TextBox.Name = "RF_HeatingFreqFollow_TextBox";
            this.RF_HeatingFreqFollow_TextBox.ReadOnly = true;
            this.RF_HeatingFreqFollow_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_HeatingFreqFollow_TextBox.TabIndex = 41;
            // 
            // chkRF_RequestPower
            // 
            this.chkRF_RequestPower.AutoSize = true;
            this.chkRF_RequestPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_RequestPower.Location = new System.Drawing.Point(3, 409);
            this.chkRF_RequestPower.Name = "chkRF_RequestPower";
            this.chkRF_RequestPower.Size = new System.Drawing.Size(183, 23);
            this.chkRF_RequestPower.TabIndex = 81;
            this.chkRF_RequestPower.Text = "请求功率值";
            this.chkRF_RequestPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_RequestPower.UseVisualStyleBackColor = true;
            // 
            // RF_PanControlActive_TextBox
            // 
            this.RF_PanControlActive_TextBox.Enabled = false;
            this.RF_PanControlActive_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_PanControlActive_TextBox.Location = new System.Drawing.Point(192, 32);
            this.RF_PanControlActive_TextBox.Name = "RF_PanControlActive_TextBox";
            this.RF_PanControlActive_TextBox.ReadOnly = true;
            this.RF_PanControlActive_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_PanControlActive_TextBox.TabIndex = 44;
            // 
            // RF_DebugChannel_TextBox
            // 
            this.RF_DebugChannel_TextBox.Enabled = false;
            this.RF_DebugChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_DebugChannel_TextBox.Location = new System.Drawing.Point(192, 380);
            this.RF_DebugChannel_TextBox.Name = "RF_DebugChannel_TextBox";
            this.RF_DebugChannel_TextBox.ReadOnly = true;
            this.RF_DebugChannel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_DebugChannel_TextBox.TabIndex = 80;
            // 
            // chkRF_InnerOuterRing
            // 
            this.chkRF_InnerOuterRing.AutoSize = true;
            this.chkRF_InnerOuterRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_InnerOuterRing.Location = new System.Drawing.Point(3, 61);
            this.chkRF_InnerOuterRing.Name = "chkRF_InnerOuterRing";
            this.chkRF_InnerOuterRing.Size = new System.Drawing.Size(183, 23);
            this.chkRF_InnerOuterRing.TabIndex = 45;
            this.chkRF_InnerOuterRing.Text = "内外环标志";
            this.chkRF_InnerOuterRing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_InnerOuterRing.UseVisualStyleBackColor = true;
            // 
            // RF_InnerOuterRing_TextBox
            // 
            this.RF_InnerOuterRing_TextBox.Enabled = false;
            this.RF_InnerOuterRing_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_InnerOuterRing_TextBox.Location = new System.Drawing.Point(192, 61);
            this.RF_InnerOuterRing_TextBox.Name = "RF_InnerOuterRing_TextBox";
            this.RF_InnerOuterRing_TextBox.ReadOnly = true;
            this.RF_InnerOuterRing_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_InnerOuterRing_TextBox.TabIndex = 48;
            // 
            // chkRF_DebugChannel
            // 
            this.chkRF_DebugChannel.AutoSize = true;
            this.chkRF_DebugChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_DebugChannel.Location = new System.Drawing.Point(3, 380);
            this.chkRF_DebugChannel.Name = "chkRF_DebugChannel";
            this.chkRF_DebugChannel.Size = new System.Drawing.Size(183, 23);
            this.chkRF_DebugChannel.TabIndex = 78;
            this.chkRF_DebugChannel.Text = "Debug通道号";
            this.chkRF_DebugChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_DebugChannel.UseVisualStyleBackColor = true;
            // 
            // chkRF_PauseFlag
            // 
            this.chkRF_PauseFlag.AutoSize = true;
            this.chkRF_PauseFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_PauseFlag.Location = new System.Drawing.Point(3, 177);
            this.chkRF_PauseFlag.Name = "chkRF_PauseFlag";
            this.chkRF_PauseFlag.Size = new System.Drawing.Size(183, 23);
            this.chkRF_PauseFlag.TabIndex = 57;
            this.chkRF_PauseFlag.Text = "暂停标志";
            this.chkRF_PauseFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_PauseFlag.UseVisualStyleBackColor = true;
            // 
            // RF_DebugSubChannel_TextBox
            // 
            this.RF_DebugSubChannel_TextBox.Enabled = false;
            this.RF_DebugSubChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_DebugSubChannel_TextBox.Location = new System.Drawing.Point(192, 351);
            this.RF_DebugSubChannel_TextBox.Name = "RF_DebugSubChannel_TextBox";
            this.RF_DebugSubChannel_TextBox.ReadOnly = true;
            this.RF_DebugSubChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_DebugSubChannel_TextBox.TabIndex = 76;
            // 
            // RF_PauseFlag_TextBox
            // 
            this.RF_PauseFlag_TextBox.Enabled = false;
            this.RF_PauseFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_PauseFlag_TextBox.Location = new System.Drawing.Point(192, 177);
            this.RF_PauseFlag_TextBox.Name = "RF_PauseFlag_TextBox";
            this.RF_PauseFlag_TextBox.ReadOnly = true;
            this.RF_PauseFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_PauseFlag_TextBox.TabIndex = 59;
            // 
            // chkRF_allZone_BridgeHeatFlag
            // 
            this.chkRF_allZone_BridgeHeatFlag.AutoSize = true;
            this.chkRF_allZone_BridgeHeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_allZone_BridgeHeatFlag.Location = new System.Drawing.Point(3, 90);
            this.chkRF_allZone_BridgeHeatFlag.Name = "chkRF_allZone_BridgeHeatFlag";
            this.chkRF_allZone_BridgeHeatFlag.Size = new System.Drawing.Size(183, 23);
            this.chkRF_allZone_BridgeHeatFlag.TabIndex = 48;
            this.chkRF_allZone_BridgeHeatFlag.Text = "无区/桥接标志/三环（红外）";
            this.chkRF_allZone_BridgeHeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_allZone_BridgeHeatFlag.UseVisualStyleBackColor = true;
            // 
            // chkRF_DebugSubChannel
            // 
            this.chkRF_DebugSubChannel.AutoSize = true;
            this.chkRF_DebugSubChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_DebugSubChannel.Location = new System.Drawing.Point(3, 351);
            this.chkRF_DebugSubChannel.Name = "chkRF_DebugSubChannel";
            this.chkRF_DebugSubChannel.Size = new System.Drawing.Size(183, 23);
            this.chkRF_DebugSubChannel.TabIndex = 74;
            this.chkRF_DebugSubChannel.Text = "Debug子通道号";
            this.chkRF_DebugSubChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_DebugSubChannel.UseVisualStyleBackColor = true;
            // 
            // RF_allZone_BridgeHeatFlag_TextBox
            // 
            this.RF_allZone_BridgeHeatFlag_TextBox.Enabled = false;
            this.RF_allZone_BridgeHeatFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_allZone_BridgeHeatFlag_TextBox.Location = new System.Drawing.Point(192, 90);
            this.RF_allZone_BridgeHeatFlag_TextBox.Name = "RF_allZone_BridgeHeatFlag_TextBox";
            this.RF_allZone_BridgeHeatFlag_TextBox.ReadOnly = true;
            this.RF_allZone_BridgeHeatFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_allZone_BridgeHeatFlag_TextBox.TabIndex = 50;
            // 
            // RF_BridgeControl_TextBox
            // 
            this.RF_BridgeControl_TextBox.Enabled = false;
            this.RF_BridgeControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_BridgeControl_TextBox.Location = new System.Drawing.Point(192, 322);
            this.RF_BridgeControl_TextBox.Name = "RF_BridgeControl_TextBox";
            this.RF_BridgeControl_TextBox.ReadOnly = true;
            this.RF_BridgeControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_BridgeControl_TextBox.TabIndex = 73;
            // 
            // chkRF_PPGMode
            // 
            this.chkRF_PPGMode.AutoSize = true;
            this.chkRF_PPGMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_PPGMode.Location = new System.Drawing.Point(3, 119);
            this.chkRF_PPGMode.Name = "chkRF_PPGMode";
            this.chkRF_PPGMode.Size = new System.Drawing.Size(183, 23);
            this.chkRF_PPGMode.TabIndex = 51;
            this.chkRF_PPGMode.Text = "PPG模式标志";
            this.chkRF_PPGMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_PPGMode.UseVisualStyleBackColor = true;
            // 
            // chkRF_StoveSwitch
            // 
            this.chkRF_StoveSwitch.AutoSize = true;
            this.chkRF_StoveSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_StoveSwitch.Location = new System.Drawing.Point(3, 206);
            this.chkRF_StoveSwitch.Name = "chkRF_StoveSwitch";
            this.chkRF_StoveSwitch.Size = new System.Drawing.Size(183, 23);
            this.chkRF_StoveSwitch.TabIndex = 60;
            this.chkRF_StoveSwitch.Text = "炉头开关标志";
            this.chkRF_StoveSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_StoveSwitch.UseVisualStyleBackColor = true;
            // 
            // chkRF_BridgeControl
            // 
            this.chkRF_BridgeControl.AutoSize = true;
            this.chkRF_BridgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_BridgeControl.Location = new System.Drawing.Point(3, 322);
            this.chkRF_BridgeControl.Name = "chkRF_BridgeControl";
            this.chkRF_BridgeControl.Size = new System.Drawing.Size(183, 23);
            this.chkRF_BridgeControl.TabIndex = 71;
            this.chkRF_BridgeControl.Text = "无区/桥接控制指令";
            this.chkRF_BridgeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_BridgeControl.UseVisualStyleBackColor = true;
            // 
            // RF_PPGMode_TextBox
            // 
            this.RF_PPGMode_TextBox.Enabled = false;
            this.RF_PPGMode_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_PPGMode_TextBox.Location = new System.Drawing.Point(192, 119);
            this.RF_PPGMode_TextBox.Name = "RF_PPGMode_TextBox";
            this.RF_PPGMode_TextBox.ReadOnly = true;
            this.RF_PPGMode_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_PPGMode_TextBox.TabIndex = 53;
            // 
            // RF_FanLevel_TextBox
            // 
            this.RF_FanLevel_TextBox.Enabled = false;
            this.RF_FanLevel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_FanLevel_TextBox.Location = new System.Drawing.Point(192, 293);
            this.RF_FanLevel_TextBox.Name = "RF_FanLevel_TextBox";
            this.RF_FanLevel_TextBox.ReadOnly = true;
            this.RF_FanLevel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_FanLevel_TextBox.TabIndex = 70;
            // 
            // RF_StoveSwitch_TextBox
            // 
            this.RF_StoveSwitch_TextBox.Enabled = false;
            this.RF_StoveSwitch_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_StoveSwitch_TextBox.Location = new System.Drawing.Point(192, 206);
            this.RF_StoveSwitch_TextBox.Name = "RF_StoveSwitch_TextBox";
            this.RF_StoveSwitch_TextBox.ReadOnly = true;
            this.RF_StoveSwitch_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_StoveSwitch_TextBox.TabIndex = 61;
            // 
            // RF_AllowPanDetection_TextBox
            // 
            this.RF_AllowPanDetection_TextBox.Enabled = false;
            this.RF_AllowPanDetection_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_AllowPanDetection_TextBox.Location = new System.Drawing.Point(192, 148);
            this.RF_AllowPanDetection_TextBox.Name = "RF_AllowPanDetection_TextBox";
            this.RF_AllowPanDetection_TextBox.ReadOnly = true;
            this.RF_AllowPanDetection_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_AllowPanDetection_TextBox.TabIndex = 56;
            // 
            // chkRF_FanLevel
            // 
            this.chkRF_FanLevel.AutoSize = true;
            this.chkRF_FanLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_FanLevel.Location = new System.Drawing.Point(3, 293);
            this.chkRF_FanLevel.Name = "chkRF_FanLevel";
            this.chkRF_FanLevel.Size = new System.Drawing.Size(183, 23);
            this.chkRF_FanLevel.TabIndex = 68;
            this.chkRF_FanLevel.Text = "风机档位";
            this.chkRF_FanLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_FanLevel.UseVisualStyleBackColor = true;
            // 
            // chkRF_AllowPanDetection
            // 
            this.chkRF_AllowPanDetection.AutoSize = true;
            this.chkRF_AllowPanDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_AllowPanDetection.Location = new System.Drawing.Point(3, 148);
            this.chkRF_AllowPanDetection.Name = "chkRF_AllowPanDetection";
            this.chkRF_AllowPanDetection.Size = new System.Drawing.Size(183, 23);
            this.chkRF_AllowPanDetection.TabIndex = 54;
            this.chkRF_AllowPanDetection.Text = "允许检锅标志";
            this.chkRF_AllowPanDetection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_AllowPanDetection.UseVisualStyleBackColor = true;
            // 
            // RF_NoiseControl_TextBox
            // 
            this.RF_NoiseControl_TextBox.Enabled = false;
            this.RF_NoiseControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_NoiseControl_TextBox.Location = new System.Drawing.Point(192, 264);
            this.RF_NoiseControl_TextBox.Name = "RF_NoiseControl_TextBox";
            this.RF_NoiseControl_TextBox.ReadOnly = true;
            this.RF_NoiseControl_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_NoiseControl_TextBox.TabIndex = 67;
            // 
            // chkRF_HeatFreqJitterFlag
            // 
            this.chkRF_HeatFreqJitterFlag.AutoSize = true;
            this.chkRF_HeatFreqJitterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_HeatFreqJitterFlag.Location = new System.Drawing.Point(3, 235);
            this.chkRF_HeatFreqJitterFlag.Name = "chkRF_HeatFreqJitterFlag";
            this.chkRF_HeatFreqJitterFlag.Size = new System.Drawing.Size(183, 23);
            this.chkRF_HeatFreqJitterFlag.TabIndex = 62;
            this.chkRF_HeatFreqJitterFlag.Text = "加热频率抖频率模式";
            this.chkRF_HeatFreqJitterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_HeatFreqJitterFlag.UseVisualStyleBackColor = true;
            // 
            // RF_HeatFreqJitterFlag_TextBox
            // 
            this.RF_HeatFreqJitterFlag_TextBox.Enabled = false;
            this.RF_HeatFreqJitterFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_HeatFreqJitterFlag_TextBox.Location = new System.Drawing.Point(192, 235);
            this.RF_HeatFreqJitterFlag_TextBox.Name = "RF_HeatFreqJitterFlag_TextBox";
            this.RF_HeatFreqJitterFlag_TextBox.ReadOnly = true;
            this.RF_HeatFreqJitterFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_HeatFreqJitterFlag_TextBox.TabIndex = 64;
            // 
            // chkRF_NoiseControl
            // 
            this.chkRF_NoiseControl.AutoSize = true;
            this.chkRF_NoiseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_NoiseControl.Location = new System.Drawing.Point(3, 264);
            this.chkRF_NoiseControl.Name = "chkRF_NoiseControl";
            this.chkRF_NoiseControl.Size = new System.Drawing.Size(183, 23);
            this.chkRF_NoiseControl.TabIndex = 65;
            this.chkRF_NoiseControl.Text = "噪声处理指令";
            this.chkRF_NoiseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_NoiseControl.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.groupBox13);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(1609, 598);
            this.splitContainer5.SplitterDistance = 185;
            this.splitContainer5.TabIndex = 0;
            // 
            // groupBox13
            // 
            this.groupBox13.AutoSize = true;
            this.groupBox13.Controls.Add(this.tableLayoutPanel6);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(0, 0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(185, 598);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "RF 功率板";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoScroll = true;
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel6.Controls.Add(this.RF_ReserveD16_TextBox, 1, 17);
            this.tableLayoutPanel6.Controls.Add(this.RF_ReserveD15_TextBox, 1, 16);
            this.tableLayoutPanel6.Controls.Add(this.RF_ReserveD14_TextBox, 1, 15);
            this.tableLayoutPanel6.Controls.Add(this.RF_Power_ReserveD1B7_TextBox, 1, 14);
            this.tableLayoutPanel6.Controls.Add(this.RF_Power_ReserveD1B6_TextBox, 1, 13);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_ReserveD16, 0, 17);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_ReserveD15, 0, 16);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_ReserveD14, 0, 15);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_Power_ReserveD1B7, 0, 14);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_Power_ReserveD1B6, 0, 13);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_PollingState, 0, 10);
            this.tableLayoutPanel6.Controls.Add(this.RF_PollingState, 1, 10);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_FreqControlFlag, 0, 11);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_HeatFlag, 0, 12);
            this.tableLayoutPanel6.Controls.Add(this.RF_FreqControlFlag, 1, 11);
            this.tableLayoutPanel6.Controls.Add(this.RF_HeatFlag, 1, 12);
            this.tableLayoutPanel6.Controls.Add(this.RF_HeatNTC2_TextBox, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_HeatNTC2, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_HeatNTC1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_IGBTNTC1, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.RF_IGBTNTC1_TextBox, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_IGBTNTC2, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.RF_ErrorCode, 1, 9);
            this.tableLayoutPanel6.Controls.Add(this.RF_IGBTNTC2_TextBox, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_PanTemp, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.RF_PanTemp_TextBox, 1, 4);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_Freq, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.RF_Freq_TextBox, 1, 5);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_ErrorCode, 0, 9);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_Voltage, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.RF_MCUTemp_TextBox, 1, 8);
            this.tableLayoutPanel6.Controls.Add(this.RF_Voltage_TextBox, 1, 6);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_Power, 0, 7);
            this.tableLayoutPanel6.Controls.Add(this.chkRF_MCUTemp, 0, 8);
            this.tableLayoutPanel6.Controls.Add(this.RF_Power_TextBox, 1, 7);
            this.tableLayoutPanel6.Controls.Add(this.RF_HeatNTC1_TextBox, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 19;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(179, 578);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // RF_ReserveD16_TextBox
            // 
            this.RF_ReserveD16_TextBox.Enabled = false;
            this.RF_ReserveD16_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_ReserveD16_TextBox.Location = new System.Drawing.Point(112, 496);
            this.RF_ReserveD16_TextBox.Name = "RF_ReserveD16_TextBox";
            this.RF_ReserveD16_TextBox.ReadOnly = true;
            this.RF_ReserveD16_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_ReserveD16_TextBox.TabIndex = 95;
            // 
            // RF_ReserveD15_TextBox
            // 
            this.RF_ReserveD15_TextBox.Enabled = false;
            this.RF_ReserveD15_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_ReserveD15_TextBox.Location = new System.Drawing.Point(112, 467);
            this.RF_ReserveD15_TextBox.Name = "RF_ReserveD15_TextBox";
            this.RF_ReserveD15_TextBox.ReadOnly = true;
            this.RF_ReserveD15_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_ReserveD15_TextBox.TabIndex = 94;
            // 
            // RF_ReserveD14_TextBox
            // 
            this.RF_ReserveD14_TextBox.Enabled = false;
            this.RF_ReserveD14_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_ReserveD14_TextBox.Location = new System.Drawing.Point(112, 438);
            this.RF_ReserveD14_TextBox.Name = "RF_ReserveD14_TextBox";
            this.RF_ReserveD14_TextBox.ReadOnly = true;
            this.RF_ReserveD14_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_ReserveD14_TextBox.TabIndex = 93;
            // 
            // RF_Power_ReserveD1B7_TextBox
            // 
            this.RF_Power_ReserveD1B7_TextBox.Enabled = false;
            this.RF_Power_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Power_ReserveD1B7_TextBox.Location = new System.Drawing.Point(112, 409);
            this.RF_Power_ReserveD1B7_TextBox.Name = "RF_Power_ReserveD1B7_TextBox";
            this.RF_Power_ReserveD1B7_TextBox.ReadOnly = true;
            this.RF_Power_ReserveD1B7_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_Power_ReserveD1B7_TextBox.TabIndex = 94;
            // 
            // RF_Power_ReserveD1B6_TextBox
            // 
            this.RF_Power_ReserveD1B6_TextBox.Enabled = false;
            this.RF_Power_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Power_ReserveD1B6_TextBox.Location = new System.Drawing.Point(112, 380);
            this.RF_Power_ReserveD1B6_TextBox.Name = "RF_Power_ReserveD1B6_TextBox";
            this.RF_Power_ReserveD1B6_TextBox.ReadOnly = true;
            this.RF_Power_ReserveD1B6_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RF_Power_ReserveD1B6_TextBox.TabIndex = 93;
            // 
            // chkRF_ReserveD16
            // 
            this.chkRF_ReserveD16.AutoSize = true;
            this.chkRF_ReserveD16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_ReserveD16.Location = new System.Drawing.Point(3, 496);
            this.chkRF_ReserveD16.Name = "chkRF_ReserveD16";
            this.chkRF_ReserveD16.Size = new System.Drawing.Size(103, 23);
            this.chkRF_ReserveD16.TabIndex = 92;
            this.chkRF_ReserveD16.Text = "ReserveD16";
            this.chkRF_ReserveD16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_ReserveD16.UseVisualStyleBackColor = true;
            // 
            // chkRF_ReserveD15
            // 
            this.chkRF_ReserveD15.AutoSize = true;
            this.chkRF_ReserveD15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_ReserveD15.Location = new System.Drawing.Point(3, 467);
            this.chkRF_ReserveD15.Name = "chkRF_ReserveD15";
            this.chkRF_ReserveD15.Size = new System.Drawing.Size(103, 23);
            this.chkRF_ReserveD15.TabIndex = 91;
            this.chkRF_ReserveD15.Text = "ReserveD15";
            this.chkRF_ReserveD15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_ReserveD15.UseVisualStyleBackColor = true;
            // 
            // chkRF_ReserveD14
            // 
            this.chkRF_ReserveD14.AutoSize = true;
            this.chkRF_ReserveD14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_ReserveD14.Location = new System.Drawing.Point(3, 438);
            this.chkRF_ReserveD14.Name = "chkRF_ReserveD14";
            this.chkRF_ReserveD14.Size = new System.Drawing.Size(103, 23);
            this.chkRF_ReserveD14.TabIndex = 90;
            this.chkRF_ReserveD14.Text = "ReserveD14";
            this.chkRF_ReserveD14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_ReserveD14.UseVisualStyleBackColor = true;
            // 
            // chkRF_Power_ReserveD1B7
            // 
            this.chkRF_Power_ReserveD1B7.AutoSize = true;
            this.chkRF_Power_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Power_ReserveD1B7.Location = new System.Drawing.Point(3, 409);
            this.chkRF_Power_ReserveD1B7.Name = "chkRF_Power_ReserveD1B7";
            this.chkRF_Power_ReserveD1B7.Size = new System.Drawing.Size(103, 23);
            this.chkRF_Power_ReserveD1B7.TabIndex = 89;
            this.chkRF_Power_ReserveD1B7.Text = "ReserveD1B7";
            this.chkRF_Power_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Power_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkRF_Power_ReserveD1B6
            // 
            this.chkRF_Power_ReserveD1B6.AutoSize = true;
            this.chkRF_Power_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Power_ReserveD1B6.Location = new System.Drawing.Point(3, 380);
            this.chkRF_Power_ReserveD1B6.Name = "chkRF_Power_ReserveD1B6";
            this.chkRF_Power_ReserveD1B6.Size = new System.Drawing.Size(103, 23);
            this.chkRF_Power_ReserveD1B6.TabIndex = 87;
            this.chkRF_Power_ReserveD1B6.Text = "ReserveD1B6";
            this.chkRF_Power_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Power_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // chkRF_PollingState
            // 
            this.chkRF_PollingState.AutoSize = true;
            this.chkRF_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_PollingState.Location = new System.Drawing.Point(3, 293);
            this.chkRF_PollingState.Name = "chkRF_PollingState";
            this.chkRF_PollingState.Size = new System.Drawing.Size(103, 23);
            this.chkRF_PollingState.TabIndex = 29;
            this.chkRF_PollingState.Text = "检锅状态";
            this.chkRF_PollingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_PollingState.UseVisualStyleBackColor = true;
            // 
            // RF_PollingState
            // 
            this.RF_PollingState.Enabled = false;
            this.RF_PollingState.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_PollingState.Location = new System.Drawing.Point(112, 293);
            this.RF_PollingState.Name = "RF_PollingState";
            this.RF_PollingState.ReadOnly = true;
            this.RF_PollingState.Size = new System.Drawing.Size(61, 20);
            this.RF_PollingState.TabIndex = 31;
            // 
            // chkRF_FreqControlFlag
            // 
            this.chkRF_FreqControlFlag.AutoSize = true;
            this.chkRF_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_FreqControlFlag.Location = new System.Drawing.Point(3, 322);
            this.chkRF_FreqControlFlag.Name = "chkRF_FreqControlFlag";
            this.chkRF_FreqControlFlag.Size = new System.Drawing.Size(103, 23);
            this.chkRF_FreqControlFlag.TabIndex = 32;
            this.chkRF_FreqControlFlag.Text = "同频加热状态";
            this.chkRF_FreqControlFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_FreqControlFlag.UseVisualStyleBackColor = true;
            // 
            // chkRF_HeatFlag
            // 
            this.chkRF_HeatFlag.AutoSize = true;
            this.chkRF_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_HeatFlag.Location = new System.Drawing.Point(3, 351);
            this.chkRF_HeatFlag.Name = "chkRF_HeatFlag";
            this.chkRF_HeatFlag.Size = new System.Drawing.Size(103, 23);
            this.chkRF_HeatFlag.TabIndex = 35;
            this.chkRF_HeatFlag.Text = "主频稳定标志";
            this.chkRF_HeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_HeatFlag.UseVisualStyleBackColor = true;
            // 
            // RF_FreqControlFlag
            // 
            this.RF_FreqControlFlag.Enabled = false;
            this.RF_FreqControlFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_FreqControlFlag.Location = new System.Drawing.Point(112, 322);
            this.RF_FreqControlFlag.Name = "RF_FreqControlFlag";
            this.RF_FreqControlFlag.ReadOnly = true;
            this.RF_FreqControlFlag.Size = new System.Drawing.Size(62, 20);
            this.RF_FreqControlFlag.TabIndex = 34;
            // 
            // RF_HeatFlag
            // 
            this.RF_HeatFlag.Enabled = false;
            this.RF_HeatFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_HeatFlag.Location = new System.Drawing.Point(112, 351);
            this.RF_HeatFlag.Name = "RF_HeatFlag";
            this.RF_HeatFlag.ReadOnly = true;
            this.RF_HeatFlag.Size = new System.Drawing.Size(62, 20);
            this.RF_HeatFlag.TabIndex = 37;
            // 
            // RF_HeatNTC2_TextBox
            // 
            this.RF_HeatNTC2_TextBox.Enabled = false;
            this.RF_HeatNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_HeatNTC2_TextBox.Location = new System.Drawing.Point(112, 32);
            this.RF_HeatNTC2_TextBox.Name = "RF_HeatNTC2_TextBox";
            this.RF_HeatNTC2_TextBox.ReadOnly = true;
            this.RF_HeatNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_HeatNTC2_TextBox.TabIndex = 5;
            // 
            // chkRF_HeatNTC2
            // 
            this.chkRF_HeatNTC2.AutoSize = true;
            this.chkRF_HeatNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_HeatNTC2.Location = new System.Drawing.Point(3, 32);
            this.chkRF_HeatNTC2.Name = "chkRF_HeatNTC2";
            this.chkRF_HeatNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkRF_HeatNTC2.TabIndex = 3;
            this.chkRF_HeatNTC2.Text = "HeatNTC2";
            this.chkRF_HeatNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_HeatNTC2.UseVisualStyleBackColor = true;
            // 
            // chkRF_HeatNTC1
            // 
            this.chkRF_HeatNTC1.AutoSize = true;
            this.chkRF_HeatNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_HeatNTC1.Location = new System.Drawing.Point(3, 3);
            this.chkRF_HeatNTC1.Name = "chkRF_HeatNTC1";
            this.chkRF_HeatNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkRF_HeatNTC1.TabIndex = 0;
            this.chkRF_HeatNTC1.Text = "HeatNTC1";
            this.chkRF_HeatNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_HeatNTC1.UseVisualStyleBackColor = true;
            // 
            // chkRF_IGBTNTC1
            // 
            this.chkRF_IGBTNTC1.AutoSize = true;
            this.chkRF_IGBTNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_IGBTNTC1.Location = new System.Drawing.Point(3, 61);
            this.chkRF_IGBTNTC1.Name = "chkRF_IGBTNTC1";
            this.chkRF_IGBTNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkRF_IGBTNTC1.TabIndex = 6;
            this.chkRF_IGBTNTC1.Text = "IGBTNTC1";
            this.chkRF_IGBTNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_IGBTNTC1.UseVisualStyleBackColor = true;
            // 
            // RF_IGBTNTC1_TextBox
            // 
            this.RF_IGBTNTC1_TextBox.Enabled = false;
            this.RF_IGBTNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_IGBTNTC1_TextBox.Location = new System.Drawing.Point(112, 61);
            this.RF_IGBTNTC1_TextBox.Name = "RF_IGBTNTC1_TextBox";
            this.RF_IGBTNTC1_TextBox.ReadOnly = true;
            this.RF_IGBTNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_IGBTNTC1_TextBox.TabIndex = 8;
            // 
            // chkRF_IGBTNTC2
            // 
            this.chkRF_IGBTNTC2.AutoSize = true;
            this.chkRF_IGBTNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_IGBTNTC2.Location = new System.Drawing.Point(3, 90);
            this.chkRF_IGBTNTC2.Name = "chkRF_IGBTNTC2";
            this.chkRF_IGBTNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkRF_IGBTNTC2.TabIndex = 9;
            this.chkRF_IGBTNTC2.Text = "IGBTNTC2";
            this.chkRF_IGBTNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_IGBTNTC2.UseVisualStyleBackColor = true;
            // 
            // RF_ErrorCode
            // 
            this.RF_ErrorCode.Enabled = false;
            this.RF_ErrorCode.Font = new System.Drawing.Font("宋体", 8F);
            this.RF_ErrorCode.Location = new System.Drawing.Point(112, 264);
            this.RF_ErrorCode.Name = "RF_ErrorCode";
            this.RF_ErrorCode.ReadOnly = true;
            this.RF_ErrorCode.Size = new System.Drawing.Size(61, 20);
            this.RF_ErrorCode.TabIndex = 28;
            // 
            // RF_IGBTNTC2_TextBox
            // 
            this.RF_IGBTNTC2_TextBox.Enabled = false;
            this.RF_IGBTNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_IGBTNTC2_TextBox.Location = new System.Drawing.Point(112, 90);
            this.RF_IGBTNTC2_TextBox.Name = "RF_IGBTNTC2_TextBox";
            this.RF_IGBTNTC2_TextBox.ReadOnly = true;
            this.RF_IGBTNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_IGBTNTC2_TextBox.TabIndex = 11;
            // 
            // chkRF_PanTemp
            // 
            this.chkRF_PanTemp.AutoSize = true;
            this.chkRF_PanTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_PanTemp.Location = new System.Drawing.Point(3, 119);
            this.chkRF_PanTemp.Name = "chkRF_PanTemp";
            this.chkRF_PanTemp.Size = new System.Drawing.Size(103, 23);
            this.chkRF_PanTemp.TabIndex = 12;
            this.chkRF_PanTemp.Text = "受热品质";
            this.chkRF_PanTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_PanTemp.UseVisualStyleBackColor = true;
            // 
            // RF_PanTemp_TextBox
            // 
            this.RF_PanTemp_TextBox.Enabled = false;
            this.RF_PanTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_PanTemp_TextBox.Location = new System.Drawing.Point(112, 119);
            this.RF_PanTemp_TextBox.Name = "RF_PanTemp_TextBox";
            this.RF_PanTemp_TextBox.ReadOnly = true;
            this.RF_PanTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_PanTemp_TextBox.TabIndex = 14;
            // 
            // chkRF_Freq
            // 
            this.chkRF_Freq.AutoSize = true;
            this.chkRF_Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Freq.Location = new System.Drawing.Point(3, 148);
            this.chkRF_Freq.Name = "chkRF_Freq";
            this.chkRF_Freq.Size = new System.Drawing.Size(103, 23);
            this.chkRF_Freq.TabIndex = 15;
            this.chkRF_Freq.Text = "加热频率";
            this.chkRF_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Freq.UseVisualStyleBackColor = true;
            // 
            // RF_Freq_TextBox
            // 
            this.RF_Freq_TextBox.Enabled = false;
            this.RF_Freq_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Freq_TextBox.Location = new System.Drawing.Point(112, 148);
            this.RF_Freq_TextBox.Name = "RF_Freq_TextBox";
            this.RF_Freq_TextBox.ReadOnly = true;
            this.RF_Freq_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_Freq_TextBox.TabIndex = 17;
            // 
            // chkRF_ErrorCode
            // 
            this.chkRF_ErrorCode.AutoSize = true;
            this.chkRF_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_ErrorCode.Location = new System.Drawing.Point(3, 264);
            this.chkRF_ErrorCode.Name = "chkRF_ErrorCode";
            this.chkRF_ErrorCode.Size = new System.Drawing.Size(103, 23);
            this.chkRF_ErrorCode.TabIndex = 26;
            this.chkRF_ErrorCode.Text = "错误码";
            this.chkRF_ErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_ErrorCode.UseVisualStyleBackColor = true;
            // 
            // chkRF_Voltage
            // 
            this.chkRF_Voltage.AutoSize = true;
            this.chkRF_Voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Voltage.Location = new System.Drawing.Point(3, 177);
            this.chkRF_Voltage.Name = "chkRF_Voltage";
            this.chkRF_Voltage.Size = new System.Drawing.Size(103, 23);
            this.chkRF_Voltage.TabIndex = 18;
            this.chkRF_Voltage.Text = "电压";
            this.chkRF_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Voltage.UseVisualStyleBackColor = true;
            // 
            // RF_MCUTemp_TextBox
            // 
            this.RF_MCUTemp_TextBox.Enabled = false;
            this.RF_MCUTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_MCUTemp_TextBox.Location = new System.Drawing.Point(112, 235);
            this.RF_MCUTemp_TextBox.Name = "RF_MCUTemp_TextBox";
            this.RF_MCUTemp_TextBox.ReadOnly = true;
            this.RF_MCUTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_MCUTemp_TextBox.TabIndex = 25;
            // 
            // RF_Voltage_TextBox
            // 
            this.RF_Voltage_TextBox.Enabled = false;
            this.RF_Voltage_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Voltage_TextBox.Location = new System.Drawing.Point(112, 177);
            this.RF_Voltage_TextBox.Name = "RF_Voltage_TextBox";
            this.RF_Voltage_TextBox.ReadOnly = true;
            this.RF_Voltage_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_Voltage_TextBox.TabIndex = 20;
            // 
            // chkRF_Power
            // 
            this.chkRF_Power.AutoSize = true;
            this.chkRF_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_Power.Location = new System.Drawing.Point(3, 206);
            this.chkRF_Power.Name = "chkRF_Power";
            this.chkRF_Power.Size = new System.Drawing.Size(103, 23);
            this.chkRF_Power.TabIndex = 21;
            this.chkRF_Power.Text = "功率";
            this.chkRF_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_Power.UseVisualStyleBackColor = true;
            // 
            // chkRF_MCUTemp
            // 
            this.chkRF_MCUTemp.AutoSize = true;
            this.chkRF_MCUTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRF_MCUTemp.Location = new System.Drawing.Point(3, 235);
            this.chkRF_MCUTemp.Name = "chkRF_MCUTemp";
            this.chkRF_MCUTemp.Size = new System.Drawing.Size(103, 23);
            this.chkRF_MCUTemp.TabIndex = 23;
            this.chkRF_MCUTemp.Text = "芯片温度";
            this.chkRF_MCUTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRF_MCUTemp.UseVisualStyleBackColor = true;
            // 
            // RF_Power_TextBox
            // 
            this.RF_Power_TextBox.Enabled = false;
            this.RF_Power_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_Power_TextBox.Location = new System.Drawing.Point(112, 206);
            this.RF_Power_TextBox.Name = "RF_Power_TextBox";
            this.RF_Power_TextBox.ReadOnly = true;
            this.RF_Power_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_Power_TextBox.TabIndex = 22;
            // 
            // RF_HeatNTC1_TextBox
            // 
            this.RF_HeatNTC1_TextBox.Enabled = false;
            this.RF_HeatNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RF_HeatNTC1_TextBox.Location = new System.Drawing.Point(112, 3);
            this.RF_HeatNTC1_TextBox.Name = "RF_HeatNTC1_TextBox";
            this.RF_HeatNTC1_TextBox.ReadOnly = true;
            this.RF_HeatNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RF_HeatNTC1_TextBox.TabIndex = 2;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.groupBox14);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.splitContainer12);
            this.splitContainer6.Size = new System.Drawing.Size(1420, 598);
            this.splitContainer6.SplitterDistance = 263;
            this.splitContainer6.TabIndex = 0;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.tableLayoutPanel7);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(0, 0);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(263, 598);
            this.groupBox14.TabIndex = 4;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "RR 显示板";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 188F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel7.Controls.Add(this.RR_ReserveD8_TextBox, 1, 18);
            this.tableLayoutPanel7.Controls.Add(this.RR_ReserveD7_TextBox, 1, 17);
            this.tableLayoutPanel7.Controls.Add(this.RR_Disp_ReserveD1B7_TextBox, 1, 16);
            this.tableLayoutPanel7.Controls.Add(this.RR_Disp_ReserveD1B6_TextBox, 1, 15);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_ReserveD8, 0, 18);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_ReserveD7, 0, 17);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_Disp_ReserveD1B7, 0, 16);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_Disp_ReserveD1B6, 0, 15);
            this.tableLayoutPanel7.Controls.Add(this.RR_RequestPower_TextBox, 1, 14);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_HeatingFreqFollow, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_PanControlActive, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.RR_HeatingFreqFollow_TextBox, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_RequestPower, 0, 14);
            this.tableLayoutPanel7.Controls.Add(this.RR_PanControlActive_TextBox, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.RR_DebugChannel_TextBox, 1, 13);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_InnerOuterRing, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.RR_InnerOuterRing_TextBox, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_DebugChannel, 0, 13);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_PauseFlag, 0, 6);
            this.tableLayoutPanel7.Controls.Add(this.RR_DebugSubChannel_TextBox, 1, 12);
            this.tableLayoutPanel7.Controls.Add(this.RR_PauseFlag_TextBox, 1, 6);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_allZone_BridgeHeatFlag, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_DebugSubChannel, 0, 12);
            this.tableLayoutPanel7.Controls.Add(this.RR_allZone_BridgeHeatFlag_TextBox, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.RR_BridgeControl_TextBox, 1, 11);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_PPGMode, 0, 4);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_StoveSwitch, 0, 7);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_BridgeControl, 0, 11);
            this.tableLayoutPanel7.Controls.Add(this.RR_PPGMode_TextBox, 1, 4);
            this.tableLayoutPanel7.Controls.Add(this.RR_FanLevel_TextBox, 1, 10);
            this.tableLayoutPanel7.Controls.Add(this.RR_StoveSwitch_TextBox, 1, 7);
            this.tableLayoutPanel7.Controls.Add(this.RR_AllowPanDetection_TextBox, 1, 5);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_FanLevel, 0, 10);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_AllowPanDetection, 0, 5);
            this.tableLayoutPanel7.Controls.Add(this.RR_NoiseControl_TextBox, 1, 9);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_HeatFreqJitterFlag, 0, 8);
            this.tableLayoutPanel7.Controls.Add(this.RR_HeatFreqJitterFlag_TextBox, 1, 8);
            this.tableLayoutPanel7.Controls.Add(this.chkRR_NoiseControl, 0, 9);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 20;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(257, 578);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // RR_ReserveD8_TextBox
            // 
            this.RR_ReserveD8_TextBox.Enabled = false;
            this.RR_ReserveD8_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_ReserveD8_TextBox.Location = new System.Drawing.Point(191, 525);
            this.RR_ReserveD8_TextBox.Name = "RR_ReserveD8_TextBox";
            this.RR_ReserveD8_TextBox.ReadOnly = true;
            this.RR_ReserveD8_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_ReserveD8_TextBox.TabIndex = 89;
            // 
            // RR_ReserveD7_TextBox
            // 
            this.RR_ReserveD7_TextBox.Enabled = false;
            this.RR_ReserveD7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_ReserveD7_TextBox.Location = new System.Drawing.Point(191, 496);
            this.RR_ReserveD7_TextBox.Name = "RR_ReserveD7_TextBox";
            this.RR_ReserveD7_TextBox.ReadOnly = true;
            this.RR_ReserveD7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_ReserveD7_TextBox.TabIndex = 88;
            // 
            // RR_Disp_ReserveD1B7_TextBox
            // 
            this.RR_Disp_ReserveD1B7_TextBox.Enabled = false;
            this.RR_Disp_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_Disp_ReserveD1B7_TextBox.Location = new System.Drawing.Point(191, 467);
            this.RR_Disp_ReserveD1B7_TextBox.Name = "RR_Disp_ReserveD1B7_TextBox";
            this.RR_Disp_ReserveD1B7_TextBox.ReadOnly = true;
            this.RR_Disp_ReserveD1B7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_Disp_ReserveD1B7_TextBox.TabIndex = 87;
            // 
            // RR_Disp_ReserveD1B6_TextBox
            // 
            this.RR_Disp_ReserveD1B6_TextBox.Enabled = false;
            this.RR_Disp_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_Disp_ReserveD1B6_TextBox.Location = new System.Drawing.Point(191, 438);
            this.RR_Disp_ReserveD1B6_TextBox.Name = "RR_Disp_ReserveD1B6_TextBox";
            this.RR_Disp_ReserveD1B6_TextBox.ReadOnly = true;
            this.RR_Disp_ReserveD1B6_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_Disp_ReserveD1B6_TextBox.TabIndex = 87;
            // 
            // chkRR_ReserveD8
            // 
            this.chkRR_ReserveD8.AutoSize = true;
            this.chkRR_ReserveD8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_ReserveD8.Location = new System.Drawing.Point(3, 525);
            this.chkRR_ReserveD8.Name = "chkRR_ReserveD8";
            this.chkRR_ReserveD8.Size = new System.Drawing.Size(182, 23);
            this.chkRR_ReserveD8.TabIndex = 85;
            this.chkRR_ReserveD8.Text = "ReserveD8";
            this.chkRR_ReserveD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_ReserveD8.UseVisualStyleBackColor = true;
            // 
            // chkRR_ReserveD7
            // 
            this.chkRR_ReserveD7.AutoSize = true;
            this.chkRR_ReserveD7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_ReserveD7.Location = new System.Drawing.Point(3, 496);
            this.chkRR_ReserveD7.Name = "chkRR_ReserveD7";
            this.chkRR_ReserveD7.Size = new System.Drawing.Size(182, 23);
            this.chkRR_ReserveD7.TabIndex = 85;
            this.chkRR_ReserveD7.Text = "ReserveD7";
            this.chkRR_ReserveD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_ReserveD7.UseVisualStyleBackColor = true;
            // 
            // chkRR_Disp_ReserveD1B7
            // 
            this.chkRR_Disp_ReserveD1B7.AutoSize = true;
            this.chkRR_Disp_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Disp_ReserveD1B7.Location = new System.Drawing.Point(3, 467);
            this.chkRR_Disp_ReserveD1B7.Name = "chkRR_Disp_ReserveD1B7";
            this.chkRR_Disp_ReserveD1B7.Size = new System.Drawing.Size(182, 23);
            this.chkRR_Disp_ReserveD1B7.TabIndex = 85;
            this.chkRR_Disp_ReserveD1B7.Text = "ReserveD1B7";
            this.chkRR_Disp_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Disp_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkRR_Disp_ReserveD1B6
            // 
            this.chkRR_Disp_ReserveD1B6.AutoSize = true;
            this.chkRR_Disp_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Disp_ReserveD1B6.Location = new System.Drawing.Point(3, 438);
            this.chkRR_Disp_ReserveD1B6.Name = "chkRR_Disp_ReserveD1B6";
            this.chkRR_Disp_ReserveD1B6.Size = new System.Drawing.Size(182, 23);
            this.chkRR_Disp_ReserveD1B6.TabIndex = 87;
            this.chkRR_Disp_ReserveD1B6.Text = "ReserveD1B6";
            this.chkRR_Disp_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Disp_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // RR_RequestPower_TextBox
            // 
            this.RR_RequestPower_TextBox.Enabled = false;
            this.RR_RequestPower_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_RequestPower_TextBox.Location = new System.Drawing.Point(191, 409);
            this.RR_RequestPower_TextBox.Name = "RR_RequestPower_TextBox";
            this.RR_RequestPower_TextBox.ReadOnly = true;
            this.RR_RequestPower_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_RequestPower_TextBox.TabIndex = 83;
            // 
            // chkRR_HeatingFreqFollow
            // 
            this.chkRR_HeatingFreqFollow.AutoSize = true;
            this.chkRR_HeatingFreqFollow.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkRR_HeatingFreqFollow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_HeatingFreqFollow.Location = new System.Drawing.Point(3, 3);
            this.chkRR_HeatingFreqFollow.Name = "chkRR_HeatingFreqFollow";
            this.chkRR_HeatingFreqFollow.Size = new System.Drawing.Size(182, 23);
            this.chkRR_HeatingFreqFollow.TabIndex = 39;
            this.chkRR_HeatingFreqFollow.Text = "加热频率跟随标志";
            this.chkRR_HeatingFreqFollow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_HeatingFreqFollow.UseVisualStyleBackColor = true;
            // 
            // chkRR_PanControlActive
            // 
            this.chkRR_PanControlActive.AutoSize = true;
            this.chkRR_PanControlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_PanControlActive.Location = new System.Drawing.Point(3, 32);
            this.chkRR_PanControlActive.Name = "chkRR_PanControlActive";
            this.chkRR_PanControlActive.Size = new System.Drawing.Size(182, 23);
            this.chkRR_PanControlActive.TabIndex = 42;
            this.chkRR_PanControlActive.Text = "移锅控功激活标志";
            this.chkRR_PanControlActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_PanControlActive.UseVisualStyleBackColor = true;
            // 
            // RR_HeatingFreqFollow_TextBox
            // 
            this.RR_HeatingFreqFollow_TextBox.Enabled = false;
            this.RR_HeatingFreqFollow_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_HeatingFreqFollow_TextBox.Location = new System.Drawing.Point(191, 3);
            this.RR_HeatingFreqFollow_TextBox.Name = "RR_HeatingFreqFollow_TextBox";
            this.RR_HeatingFreqFollow_TextBox.ReadOnly = true;
            this.RR_HeatingFreqFollow_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_HeatingFreqFollow_TextBox.TabIndex = 41;
            // 
            // chkRR_RequestPower
            // 
            this.chkRR_RequestPower.AutoSize = true;
            this.chkRR_RequestPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_RequestPower.Location = new System.Drawing.Point(3, 409);
            this.chkRR_RequestPower.Name = "chkRR_RequestPower";
            this.chkRR_RequestPower.Size = new System.Drawing.Size(182, 23);
            this.chkRR_RequestPower.TabIndex = 81;
            this.chkRR_RequestPower.Text = "请求功率值";
            this.chkRR_RequestPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_RequestPower.UseVisualStyleBackColor = true;
            // 
            // RR_PanControlActive_TextBox
            // 
            this.RR_PanControlActive_TextBox.Enabled = false;
            this.RR_PanControlActive_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_PanControlActive_TextBox.Location = new System.Drawing.Point(191, 32);
            this.RR_PanControlActive_TextBox.Name = "RR_PanControlActive_TextBox";
            this.RR_PanControlActive_TextBox.ReadOnly = true;
            this.RR_PanControlActive_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_PanControlActive_TextBox.TabIndex = 44;
            // 
            // RR_DebugChannel_TextBox
            // 
            this.RR_DebugChannel_TextBox.Enabled = false;
            this.RR_DebugChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_DebugChannel_TextBox.Location = new System.Drawing.Point(191, 380);
            this.RR_DebugChannel_TextBox.Name = "RR_DebugChannel_TextBox";
            this.RR_DebugChannel_TextBox.ReadOnly = true;
            this.RR_DebugChannel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_DebugChannel_TextBox.TabIndex = 80;
            // 
            // chkRR_InnerOuterRing
            // 
            this.chkRR_InnerOuterRing.AutoSize = true;
            this.chkRR_InnerOuterRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_InnerOuterRing.Location = new System.Drawing.Point(3, 61);
            this.chkRR_InnerOuterRing.Name = "chkRR_InnerOuterRing";
            this.chkRR_InnerOuterRing.Size = new System.Drawing.Size(182, 23);
            this.chkRR_InnerOuterRing.TabIndex = 45;
            this.chkRR_InnerOuterRing.Text = "内外环标志";
            this.chkRR_InnerOuterRing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_InnerOuterRing.UseVisualStyleBackColor = true;
            // 
            // RR_InnerOuterRing_TextBox
            // 
            this.RR_InnerOuterRing_TextBox.Enabled = false;
            this.RR_InnerOuterRing_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_InnerOuterRing_TextBox.Location = new System.Drawing.Point(191, 61);
            this.RR_InnerOuterRing_TextBox.Name = "RR_InnerOuterRing_TextBox";
            this.RR_InnerOuterRing_TextBox.ReadOnly = true;
            this.RR_InnerOuterRing_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_InnerOuterRing_TextBox.TabIndex = 48;
            // 
            // chkRR_DebugChannel
            // 
            this.chkRR_DebugChannel.AutoSize = true;
            this.chkRR_DebugChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_DebugChannel.Location = new System.Drawing.Point(3, 380);
            this.chkRR_DebugChannel.Name = "chkRR_DebugChannel";
            this.chkRR_DebugChannel.Size = new System.Drawing.Size(182, 23);
            this.chkRR_DebugChannel.TabIndex = 78;
            this.chkRR_DebugChannel.Text = "Debug通道号";
            this.chkRR_DebugChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_DebugChannel.UseVisualStyleBackColor = true;
            // 
            // chkRR_PauseFlag
            // 
            this.chkRR_PauseFlag.AutoSize = true;
            this.chkRR_PauseFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_PauseFlag.Location = new System.Drawing.Point(3, 177);
            this.chkRR_PauseFlag.Name = "chkRR_PauseFlag";
            this.chkRR_PauseFlag.Size = new System.Drawing.Size(182, 23);
            this.chkRR_PauseFlag.TabIndex = 57;
            this.chkRR_PauseFlag.Text = "暂停标志";
            this.chkRR_PauseFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_PauseFlag.UseVisualStyleBackColor = true;
            // 
            // RR_DebugSubChannel_TextBox
            // 
            this.RR_DebugSubChannel_TextBox.Enabled = false;
            this.RR_DebugSubChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_DebugSubChannel_TextBox.Location = new System.Drawing.Point(191, 351);
            this.RR_DebugSubChannel_TextBox.Name = "RR_DebugSubChannel_TextBox";
            this.RR_DebugSubChannel_TextBox.ReadOnly = true;
            this.RR_DebugSubChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_DebugSubChannel_TextBox.TabIndex = 76;
            // 
            // RR_PauseFlag_TextBox
            // 
            this.RR_PauseFlag_TextBox.Enabled = false;
            this.RR_PauseFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_PauseFlag_TextBox.Location = new System.Drawing.Point(191, 177);
            this.RR_PauseFlag_TextBox.Name = "RR_PauseFlag_TextBox";
            this.RR_PauseFlag_TextBox.ReadOnly = true;
            this.RR_PauseFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_PauseFlag_TextBox.TabIndex = 59;
            // 
            // chkRR_allZone_BridgeHeatFlag
            // 
            this.chkRR_allZone_BridgeHeatFlag.AutoSize = true;
            this.chkRR_allZone_BridgeHeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_allZone_BridgeHeatFlag.Location = new System.Drawing.Point(3, 90);
            this.chkRR_allZone_BridgeHeatFlag.Name = "chkRR_allZone_BridgeHeatFlag";
            this.chkRR_allZone_BridgeHeatFlag.Size = new System.Drawing.Size(182, 23);
            this.chkRR_allZone_BridgeHeatFlag.TabIndex = 48;
            this.chkRR_allZone_BridgeHeatFlag.Text = "无区/桥接标志/三环（红外）";
            this.chkRR_allZone_BridgeHeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_allZone_BridgeHeatFlag.UseVisualStyleBackColor = true;
            // 
            // chkRR_DebugSubChannel
            // 
            this.chkRR_DebugSubChannel.AutoSize = true;
            this.chkRR_DebugSubChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_DebugSubChannel.Location = new System.Drawing.Point(3, 351);
            this.chkRR_DebugSubChannel.Name = "chkRR_DebugSubChannel";
            this.chkRR_DebugSubChannel.Size = new System.Drawing.Size(182, 23);
            this.chkRR_DebugSubChannel.TabIndex = 74;
            this.chkRR_DebugSubChannel.Text = "Debug子通道号";
            this.chkRR_DebugSubChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_DebugSubChannel.UseVisualStyleBackColor = true;
            // 
            // RR_allZone_BridgeHeatFlag_TextBox
            // 
            this.RR_allZone_BridgeHeatFlag_TextBox.Enabled = false;
            this.RR_allZone_BridgeHeatFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_allZone_BridgeHeatFlag_TextBox.Location = new System.Drawing.Point(191, 90);
            this.RR_allZone_BridgeHeatFlag_TextBox.Name = "RR_allZone_BridgeHeatFlag_TextBox";
            this.RR_allZone_BridgeHeatFlag_TextBox.ReadOnly = true;
            this.RR_allZone_BridgeHeatFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_allZone_BridgeHeatFlag_TextBox.TabIndex = 50;
            // 
            // RR_BridgeControl_TextBox
            // 
            this.RR_BridgeControl_TextBox.Enabled = false;
            this.RR_BridgeControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_BridgeControl_TextBox.Location = new System.Drawing.Point(191, 322);
            this.RR_BridgeControl_TextBox.Name = "RR_BridgeControl_TextBox";
            this.RR_BridgeControl_TextBox.ReadOnly = true;
            this.RR_BridgeControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_BridgeControl_TextBox.TabIndex = 73;
            // 
            // chkRR_PPGMode
            // 
            this.chkRR_PPGMode.AutoSize = true;
            this.chkRR_PPGMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_PPGMode.Location = new System.Drawing.Point(3, 119);
            this.chkRR_PPGMode.Name = "chkRR_PPGMode";
            this.chkRR_PPGMode.Size = new System.Drawing.Size(182, 23);
            this.chkRR_PPGMode.TabIndex = 51;
            this.chkRR_PPGMode.Text = "PPG模式标志";
            this.chkRR_PPGMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_PPGMode.UseVisualStyleBackColor = true;
            // 
            // chkRR_StoveSwitch
            // 
            this.chkRR_StoveSwitch.AutoSize = true;
            this.chkRR_StoveSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_StoveSwitch.Location = new System.Drawing.Point(3, 206);
            this.chkRR_StoveSwitch.Name = "chkRR_StoveSwitch";
            this.chkRR_StoveSwitch.Size = new System.Drawing.Size(182, 23);
            this.chkRR_StoveSwitch.TabIndex = 60;
            this.chkRR_StoveSwitch.Text = "炉头开关标志";
            this.chkRR_StoveSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_StoveSwitch.UseVisualStyleBackColor = true;
            // 
            // chkRR_BridgeControl
            // 
            this.chkRR_BridgeControl.AutoSize = true;
            this.chkRR_BridgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_BridgeControl.Location = new System.Drawing.Point(3, 322);
            this.chkRR_BridgeControl.Name = "chkRR_BridgeControl";
            this.chkRR_BridgeControl.Size = new System.Drawing.Size(182, 23);
            this.chkRR_BridgeControl.TabIndex = 71;
            this.chkRR_BridgeControl.Text = "无区/桥接控制指令";
            this.chkRR_BridgeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_BridgeControl.UseVisualStyleBackColor = true;
            // 
            // RR_PPGMode_TextBox
            // 
            this.RR_PPGMode_TextBox.Enabled = false;
            this.RR_PPGMode_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_PPGMode_TextBox.Location = new System.Drawing.Point(191, 119);
            this.RR_PPGMode_TextBox.Name = "RR_PPGMode_TextBox";
            this.RR_PPGMode_TextBox.ReadOnly = true;
            this.RR_PPGMode_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_PPGMode_TextBox.TabIndex = 53;
            // 
            // RR_FanLevel_TextBox
            // 
            this.RR_FanLevel_TextBox.Enabled = false;
            this.RR_FanLevel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_FanLevel_TextBox.Location = new System.Drawing.Point(191, 293);
            this.RR_FanLevel_TextBox.Name = "RR_FanLevel_TextBox";
            this.RR_FanLevel_TextBox.ReadOnly = true;
            this.RR_FanLevel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_FanLevel_TextBox.TabIndex = 70;
            // 
            // RR_StoveSwitch_TextBox
            // 
            this.RR_StoveSwitch_TextBox.Enabled = false;
            this.RR_StoveSwitch_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_StoveSwitch_TextBox.Location = new System.Drawing.Point(191, 206);
            this.RR_StoveSwitch_TextBox.Name = "RR_StoveSwitch_TextBox";
            this.RR_StoveSwitch_TextBox.ReadOnly = true;
            this.RR_StoveSwitch_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_StoveSwitch_TextBox.TabIndex = 61;
            // 
            // RR_AllowPanDetection_TextBox
            // 
            this.RR_AllowPanDetection_TextBox.Enabled = false;
            this.RR_AllowPanDetection_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_AllowPanDetection_TextBox.Location = new System.Drawing.Point(191, 148);
            this.RR_AllowPanDetection_TextBox.Name = "RR_AllowPanDetection_TextBox";
            this.RR_AllowPanDetection_TextBox.ReadOnly = true;
            this.RR_AllowPanDetection_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_AllowPanDetection_TextBox.TabIndex = 56;
            // 
            // chkRR_FanLevel
            // 
            this.chkRR_FanLevel.AutoSize = true;
            this.chkRR_FanLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_FanLevel.Location = new System.Drawing.Point(3, 293);
            this.chkRR_FanLevel.Name = "chkRR_FanLevel";
            this.chkRR_FanLevel.Size = new System.Drawing.Size(182, 23);
            this.chkRR_FanLevel.TabIndex = 68;
            this.chkRR_FanLevel.Text = "风机档位";
            this.chkRR_FanLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_FanLevel.UseVisualStyleBackColor = true;
            // 
            // chkRR_AllowPanDetection
            // 
            this.chkRR_AllowPanDetection.AutoSize = true;
            this.chkRR_AllowPanDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_AllowPanDetection.Location = new System.Drawing.Point(3, 148);
            this.chkRR_AllowPanDetection.Name = "chkRR_AllowPanDetection";
            this.chkRR_AllowPanDetection.Size = new System.Drawing.Size(182, 23);
            this.chkRR_AllowPanDetection.TabIndex = 54;
            this.chkRR_AllowPanDetection.Text = "允许检锅标志";
            this.chkRR_AllowPanDetection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_AllowPanDetection.UseVisualStyleBackColor = true;
            // 
            // RR_NoiseControl_TextBox
            // 
            this.RR_NoiseControl_TextBox.Enabled = false;
            this.RR_NoiseControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_NoiseControl_TextBox.Location = new System.Drawing.Point(191, 264);
            this.RR_NoiseControl_TextBox.Name = "RR_NoiseControl_TextBox";
            this.RR_NoiseControl_TextBox.ReadOnly = true;
            this.RR_NoiseControl_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_NoiseControl_TextBox.TabIndex = 67;
            // 
            // chkRR_HeatFreqJitterFlag
            // 
            this.chkRR_HeatFreqJitterFlag.AutoSize = true;
            this.chkRR_HeatFreqJitterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_HeatFreqJitterFlag.Location = new System.Drawing.Point(3, 235);
            this.chkRR_HeatFreqJitterFlag.Name = "chkRR_HeatFreqJitterFlag";
            this.chkRR_HeatFreqJitterFlag.Size = new System.Drawing.Size(182, 23);
            this.chkRR_HeatFreqJitterFlag.TabIndex = 62;
            this.chkRR_HeatFreqJitterFlag.Text = "加热频率抖频率模式";
            this.chkRR_HeatFreqJitterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_HeatFreqJitterFlag.UseVisualStyleBackColor = true;
            // 
            // RR_HeatFreqJitterFlag_TextBox
            // 
            this.RR_HeatFreqJitterFlag_TextBox.Enabled = false;
            this.RR_HeatFreqJitterFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_HeatFreqJitterFlag_TextBox.Location = new System.Drawing.Point(191, 235);
            this.RR_HeatFreqJitterFlag_TextBox.Name = "RR_HeatFreqJitterFlag_TextBox";
            this.RR_HeatFreqJitterFlag_TextBox.ReadOnly = true;
            this.RR_HeatFreqJitterFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_HeatFreqJitterFlag_TextBox.TabIndex = 64;
            // 
            // chkRR_NoiseControl
            // 
            this.chkRR_NoiseControl.AutoSize = true;
            this.chkRR_NoiseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_NoiseControl.Location = new System.Drawing.Point(3, 264);
            this.chkRR_NoiseControl.Name = "chkRR_NoiseControl";
            this.chkRR_NoiseControl.Size = new System.Drawing.Size(182, 23);
            this.chkRR_NoiseControl.TabIndex = 65;
            this.chkRR_NoiseControl.Text = "噪声处理指令";
            this.chkRR_NoiseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_NoiseControl.UseVisualStyleBackColor = true;
            // 
            // splitContainer12
            // 
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.Location = new System.Drawing.Point(0, 0);
            this.splitContainer12.Name = "splitContainer12";
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.Controls.Add(this.groupBox15);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.splitContainer13);
            this.splitContainer12.Size = new System.Drawing.Size(1153, 598);
            this.splitContainer12.SplitterDistance = 186;
            this.splitContainer12.TabIndex = 0;
            // 
            // groupBox15
            // 
            this.groupBox15.AutoSize = true;
            this.groupBox15.Controls.Add(this.tableLayoutPanel8);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox15.Location = new System.Drawing.Point(0, 0);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(186, 598);
            this.groupBox15.TabIndex = 3;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "RR 功率板";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel8.Controls.Add(this.RR_ReserveD16_TextBox, 1, 17);
            this.tableLayoutPanel8.Controls.Add(this.RR_ReserveD15_TextBox, 1, 16);
            this.tableLayoutPanel8.Controls.Add(this.RR_ReserveD14_TextBox, 1, 15);
            this.tableLayoutPanel8.Controls.Add(this.RR_Power_ReserveD1B7_TextBox, 1, 14);
            this.tableLayoutPanel8.Controls.Add(this.RR_Power_ReserveD1B6_TextBox, 1, 13);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_ReserveD16, 0, 17);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_ReserveD15, 0, 16);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_ReserveD14, 0, 15);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_Power_ReserveD1B7, 0, 14);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_Power_ReserveD1B6, 0, 13);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_PollingState, 0, 10);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_FreqControlFlag, 0, 11);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_HeatFlag, 0, 12);
            this.tableLayoutPanel8.Controls.Add(this.RR_FreqControlFlag, 1, 11);
            this.tableLayoutPanel8.Controls.Add(this.RR_HeatFlag, 1, 12);
            this.tableLayoutPanel8.Controls.Add(this.RR_HeatNTC2_TextBox, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_HeatNTC2, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_HeatNTC1, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.RR_HeatNTC1_TextBox, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_IGBTNTC1, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.RR_IGBTNTC1_TextBox, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_IGBTNTC2, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.RR_ErrorCode, 1, 9);
            this.tableLayoutPanel8.Controls.Add(this.RR_IGBTNTC2_TextBox, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_PanTemp, 0, 4);
            this.tableLayoutPanel8.Controls.Add(this.RR_PanTemp_TextBox, 1, 4);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_Freq, 0, 5);
            this.tableLayoutPanel8.Controls.Add(this.RR_Freq_TextBox, 1, 5);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_ErrorCode, 0, 9);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_Voltage, 0, 6);
            this.tableLayoutPanel8.Controls.Add(this.RR_MCUTemp_TextBox, 1, 8);
            this.tableLayoutPanel8.Controls.Add(this.RR_Voltage_TextBox, 1, 6);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_Power, 0, 7);
            this.tableLayoutPanel8.Controls.Add(this.chkRR_MCUTemp, 0, 8);
            this.tableLayoutPanel8.Controls.Add(this.RR_Power_TextBox, 1, 7);
            this.tableLayoutPanel8.Controls.Add(this.RR_PollingState, 1, 10);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 19;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(180, 578);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // RR_ReserveD16_TextBox
            // 
            this.RR_ReserveD16_TextBox.Enabled = false;
            this.RR_ReserveD16_TextBox.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_ReserveD16_TextBox.Location = new System.Drawing.Point(112, 496);
            this.RR_ReserveD16_TextBox.Name = "RR_ReserveD16_TextBox";
            this.RR_ReserveD16_TextBox.ReadOnly = true;
            this.RR_ReserveD16_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_ReserveD16_TextBox.TabIndex = 96;
            // 
            // RR_ReserveD15_TextBox
            // 
            this.RR_ReserveD15_TextBox.Enabled = false;
            this.RR_ReserveD15_TextBox.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_ReserveD15_TextBox.Location = new System.Drawing.Point(112, 467);
            this.RR_ReserveD15_TextBox.Name = "RR_ReserveD15_TextBox";
            this.RR_ReserveD15_TextBox.ReadOnly = true;
            this.RR_ReserveD15_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_ReserveD15_TextBox.TabIndex = 95;
            // 
            // RR_ReserveD14_TextBox
            // 
            this.RR_ReserveD14_TextBox.Enabled = false;
            this.RR_ReserveD14_TextBox.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_ReserveD14_TextBox.Location = new System.Drawing.Point(112, 438);
            this.RR_ReserveD14_TextBox.Name = "RR_ReserveD14_TextBox";
            this.RR_ReserveD14_TextBox.ReadOnly = true;
            this.RR_ReserveD14_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_ReserveD14_TextBox.TabIndex = 94;
            // 
            // RR_Power_ReserveD1B7_TextBox
            // 
            this.RR_Power_ReserveD1B7_TextBox.Enabled = false;
            this.RR_Power_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_Power_ReserveD1B7_TextBox.Location = new System.Drawing.Point(112, 409);
            this.RR_Power_ReserveD1B7_TextBox.Name = "RR_Power_ReserveD1B7_TextBox";
            this.RR_Power_ReserveD1B7_TextBox.ReadOnly = true;
            this.RR_Power_ReserveD1B7_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_Power_ReserveD1B7_TextBox.TabIndex = 95;
            // 
            // RR_Power_ReserveD1B6_TextBox
            // 
            this.RR_Power_ReserveD1B6_TextBox.Enabled = false;
            this.RR_Power_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_Power_ReserveD1B6_TextBox.Location = new System.Drawing.Point(112, 380);
            this.RR_Power_ReserveD1B6_TextBox.Name = "RR_Power_ReserveD1B6_TextBox";
            this.RR_Power_ReserveD1B6_TextBox.ReadOnly = true;
            this.RR_Power_ReserveD1B6_TextBox.Size = new System.Drawing.Size(61, 20);
            this.RR_Power_ReserveD1B6_TextBox.TabIndex = 94;
            // 
            // chkRR_ReserveD16
            // 
            this.chkRR_ReserveD16.AutoSize = true;
            this.chkRR_ReserveD16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_ReserveD16.Location = new System.Drawing.Point(3, 496);
            this.chkRR_ReserveD16.Name = "chkRR_ReserveD16";
            this.chkRR_ReserveD16.Size = new System.Drawing.Size(103, 23);
            this.chkRR_ReserveD16.TabIndex = 93;
            this.chkRR_ReserveD16.Text = "ReserveD16";
            this.chkRR_ReserveD16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_ReserveD16.UseVisualStyleBackColor = true;
            // 
            // chkRR_ReserveD15
            // 
            this.chkRR_ReserveD15.AutoSize = true;
            this.chkRR_ReserveD15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_ReserveD15.Location = new System.Drawing.Point(3, 467);
            this.chkRR_ReserveD15.Name = "chkRR_ReserveD15";
            this.chkRR_ReserveD15.Size = new System.Drawing.Size(103, 23);
            this.chkRR_ReserveD15.TabIndex = 92;
            this.chkRR_ReserveD15.Text = "ReserveD15";
            this.chkRR_ReserveD15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_ReserveD15.UseVisualStyleBackColor = true;
            // 
            // chkRR_ReserveD14
            // 
            this.chkRR_ReserveD14.AutoSize = true;
            this.chkRR_ReserveD14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_ReserveD14.Location = new System.Drawing.Point(3, 438);
            this.chkRR_ReserveD14.Name = "chkRR_ReserveD14";
            this.chkRR_ReserveD14.Size = new System.Drawing.Size(103, 23);
            this.chkRR_ReserveD14.TabIndex = 91;
            this.chkRR_ReserveD14.Text = "ReserveD14";
            this.chkRR_ReserveD14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_ReserveD14.UseVisualStyleBackColor = true;
            // 
            // chkRR_Power_ReserveD1B7
            // 
            this.chkRR_Power_ReserveD1B7.AutoSize = true;
            this.chkRR_Power_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Power_ReserveD1B7.Location = new System.Drawing.Point(3, 409);
            this.chkRR_Power_ReserveD1B7.Name = "chkRR_Power_ReserveD1B7";
            this.chkRR_Power_ReserveD1B7.Size = new System.Drawing.Size(103, 23);
            this.chkRR_Power_ReserveD1B7.TabIndex = 90;
            this.chkRR_Power_ReserveD1B7.Text = "ReserveD1B7";
            this.chkRR_Power_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Power_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkRR_Power_ReserveD1B6
            // 
            this.chkRR_Power_ReserveD1B6.AutoSize = true;
            this.chkRR_Power_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Power_ReserveD1B6.Location = new System.Drawing.Point(3, 380);
            this.chkRR_Power_ReserveD1B6.Name = "chkRR_Power_ReserveD1B6";
            this.chkRR_Power_ReserveD1B6.Size = new System.Drawing.Size(103, 23);
            this.chkRR_Power_ReserveD1B6.TabIndex = 88;
            this.chkRR_Power_ReserveD1B6.Text = "ReserveD1B6";
            this.chkRR_Power_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Power_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // chkRR_PollingState
            // 
            this.chkRR_PollingState.AutoSize = true;
            this.chkRR_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_PollingState.Location = new System.Drawing.Point(3, 293);
            this.chkRR_PollingState.Name = "chkRR_PollingState";
            this.chkRR_PollingState.Size = new System.Drawing.Size(103, 23);
            this.chkRR_PollingState.TabIndex = 29;
            this.chkRR_PollingState.Text = "检锅状态";
            this.chkRR_PollingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_PollingState.UseVisualStyleBackColor = true;
            // 
            // chkRR_FreqControlFlag
            // 
            this.chkRR_FreqControlFlag.AutoSize = true;
            this.chkRR_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_FreqControlFlag.Location = new System.Drawing.Point(3, 322);
            this.chkRR_FreqControlFlag.Name = "chkRR_FreqControlFlag";
            this.chkRR_FreqControlFlag.Size = new System.Drawing.Size(103, 23);
            this.chkRR_FreqControlFlag.TabIndex = 32;
            this.chkRR_FreqControlFlag.Text = "同频加热状态";
            this.chkRR_FreqControlFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_FreqControlFlag.UseVisualStyleBackColor = true;
            // 
            // chkRR_HeatFlag
            // 
            this.chkRR_HeatFlag.AutoSize = true;
            this.chkRR_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_HeatFlag.Location = new System.Drawing.Point(3, 351);
            this.chkRR_HeatFlag.Name = "chkRR_HeatFlag";
            this.chkRR_HeatFlag.Size = new System.Drawing.Size(103, 23);
            this.chkRR_HeatFlag.TabIndex = 35;
            this.chkRR_HeatFlag.Text = "主频稳定标志";
            this.chkRR_HeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_HeatFlag.UseVisualStyleBackColor = true;
            // 
            // RR_FreqControlFlag
            // 
            this.RR_FreqControlFlag.Enabled = false;
            this.RR_FreqControlFlag.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_FreqControlFlag.Location = new System.Drawing.Point(112, 322);
            this.RR_FreqControlFlag.Name = "RR_FreqControlFlag";
            this.RR_FreqControlFlag.ReadOnly = true;
            this.RR_FreqControlFlag.Size = new System.Drawing.Size(62, 20);
            this.RR_FreqControlFlag.TabIndex = 34;
            // 
            // RR_HeatFlag
            // 
            this.RR_HeatFlag.Enabled = false;
            this.RR_HeatFlag.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_HeatFlag.Location = new System.Drawing.Point(112, 351);
            this.RR_HeatFlag.Name = "RR_HeatFlag";
            this.RR_HeatFlag.ReadOnly = true;
            this.RR_HeatFlag.Size = new System.Drawing.Size(62, 20);
            this.RR_HeatFlag.TabIndex = 37;
            // 
            // RR_HeatNTC2_TextBox
            // 
            this.RR_HeatNTC2_TextBox.Enabled = false;
            this.RR_HeatNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_HeatNTC2_TextBox.Location = new System.Drawing.Point(112, 32);
            this.RR_HeatNTC2_TextBox.Name = "RR_HeatNTC2_TextBox";
            this.RR_HeatNTC2_TextBox.ReadOnly = true;
            this.RR_HeatNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_HeatNTC2_TextBox.TabIndex = 5;
            // 
            // chkRR_HeatNTC2
            // 
            this.chkRR_HeatNTC2.AutoSize = true;
            this.chkRR_HeatNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_HeatNTC2.Location = new System.Drawing.Point(3, 32);
            this.chkRR_HeatNTC2.Name = "chkRR_HeatNTC2";
            this.chkRR_HeatNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkRR_HeatNTC2.TabIndex = 3;
            this.chkRR_HeatNTC2.Text = "HeatNTC2";
            this.chkRR_HeatNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_HeatNTC2.UseVisualStyleBackColor = true;
            // 
            // chkRR_HeatNTC1
            // 
            this.chkRR_HeatNTC1.AutoSize = true;
            this.chkRR_HeatNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_HeatNTC1.Location = new System.Drawing.Point(3, 3);
            this.chkRR_HeatNTC1.Name = "chkRR_HeatNTC1";
            this.chkRR_HeatNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkRR_HeatNTC1.TabIndex = 0;
            this.chkRR_HeatNTC1.Text = "HeatNTC1";
            this.chkRR_HeatNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_HeatNTC1.UseVisualStyleBackColor = true;
            // 
            // RR_HeatNTC1_TextBox
            // 
            this.RR_HeatNTC1_TextBox.Enabled = false;
            this.RR_HeatNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_HeatNTC1_TextBox.Location = new System.Drawing.Point(112, 3);
            this.RR_HeatNTC1_TextBox.Name = "RR_HeatNTC1_TextBox";
            this.RR_HeatNTC1_TextBox.ReadOnly = true;
            this.RR_HeatNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_HeatNTC1_TextBox.TabIndex = 2;
            // 
            // chkRR_IGBTNTC1
            // 
            this.chkRR_IGBTNTC1.AutoSize = true;
            this.chkRR_IGBTNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_IGBTNTC1.Location = new System.Drawing.Point(3, 61);
            this.chkRR_IGBTNTC1.Name = "chkRR_IGBTNTC1";
            this.chkRR_IGBTNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkRR_IGBTNTC1.TabIndex = 6;
            this.chkRR_IGBTNTC1.Text = "IGBTNTC1";
            this.chkRR_IGBTNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_IGBTNTC1.UseVisualStyleBackColor = true;
            // 
            // RR_IGBTNTC1_TextBox
            // 
            this.RR_IGBTNTC1_TextBox.Enabled = false;
            this.RR_IGBTNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_IGBTNTC1_TextBox.Location = new System.Drawing.Point(112, 61);
            this.RR_IGBTNTC1_TextBox.Name = "RR_IGBTNTC1_TextBox";
            this.RR_IGBTNTC1_TextBox.ReadOnly = true;
            this.RR_IGBTNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_IGBTNTC1_TextBox.TabIndex = 8;
            // 
            // chkRR_IGBTNTC2
            // 
            this.chkRR_IGBTNTC2.AutoSize = true;
            this.chkRR_IGBTNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_IGBTNTC2.Location = new System.Drawing.Point(3, 90);
            this.chkRR_IGBTNTC2.Name = "chkRR_IGBTNTC2";
            this.chkRR_IGBTNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkRR_IGBTNTC2.TabIndex = 9;
            this.chkRR_IGBTNTC2.Text = "IGBTNTC2";
            this.chkRR_IGBTNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_IGBTNTC2.UseVisualStyleBackColor = true;
            // 
            // RR_ErrorCode
            // 
            this.RR_ErrorCode.Enabled = false;
            this.RR_ErrorCode.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_ErrorCode.Location = new System.Drawing.Point(112, 264);
            this.RR_ErrorCode.Name = "RR_ErrorCode";
            this.RR_ErrorCode.ReadOnly = true;
            this.RR_ErrorCode.Size = new System.Drawing.Size(61, 20);
            this.RR_ErrorCode.TabIndex = 28;
            // 
            // RR_IGBTNTC2_TextBox
            // 
            this.RR_IGBTNTC2_TextBox.Enabled = false;
            this.RR_IGBTNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_IGBTNTC2_TextBox.Location = new System.Drawing.Point(112, 90);
            this.RR_IGBTNTC2_TextBox.Name = "RR_IGBTNTC2_TextBox";
            this.RR_IGBTNTC2_TextBox.ReadOnly = true;
            this.RR_IGBTNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_IGBTNTC2_TextBox.TabIndex = 11;
            // 
            // chkRR_PanTemp
            // 
            this.chkRR_PanTemp.AutoSize = true;
            this.chkRR_PanTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_PanTemp.Location = new System.Drawing.Point(3, 119);
            this.chkRR_PanTemp.Name = "chkRR_PanTemp";
            this.chkRR_PanTemp.Size = new System.Drawing.Size(103, 23);
            this.chkRR_PanTemp.TabIndex = 12;
            this.chkRR_PanTemp.Text = "受热品质";
            this.chkRR_PanTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_PanTemp.UseVisualStyleBackColor = true;
            // 
            // RR_PanTemp_TextBox
            // 
            this.RR_PanTemp_TextBox.Enabled = false;
            this.RR_PanTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_PanTemp_TextBox.Location = new System.Drawing.Point(112, 119);
            this.RR_PanTemp_TextBox.Name = "RR_PanTemp_TextBox";
            this.RR_PanTemp_TextBox.ReadOnly = true;
            this.RR_PanTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_PanTemp_TextBox.TabIndex = 14;
            // 
            // chkRR_Freq
            // 
            this.chkRR_Freq.AutoSize = true;
            this.chkRR_Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Freq.Location = new System.Drawing.Point(3, 148);
            this.chkRR_Freq.Name = "chkRR_Freq";
            this.chkRR_Freq.Size = new System.Drawing.Size(103, 23);
            this.chkRR_Freq.TabIndex = 15;
            this.chkRR_Freq.Text = "加热频率";
            this.chkRR_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Freq.UseVisualStyleBackColor = true;
            // 
            // RR_Freq_TextBox
            // 
            this.RR_Freq_TextBox.Enabled = false;
            this.RR_Freq_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_Freq_TextBox.Location = new System.Drawing.Point(112, 148);
            this.RR_Freq_TextBox.Name = "RR_Freq_TextBox";
            this.RR_Freq_TextBox.ReadOnly = true;
            this.RR_Freq_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_Freq_TextBox.TabIndex = 17;
            // 
            // chkRR_ErrorCode
            // 
            this.chkRR_ErrorCode.AutoSize = true;
            this.chkRR_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_ErrorCode.Location = new System.Drawing.Point(3, 264);
            this.chkRR_ErrorCode.Name = "chkRR_ErrorCode";
            this.chkRR_ErrorCode.Size = new System.Drawing.Size(103, 23);
            this.chkRR_ErrorCode.TabIndex = 26;
            this.chkRR_ErrorCode.Text = "错误码";
            this.chkRR_ErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_ErrorCode.UseVisualStyleBackColor = true;
            // 
            // chkRR_Voltage
            // 
            this.chkRR_Voltage.AutoSize = true;
            this.chkRR_Voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Voltage.Location = new System.Drawing.Point(3, 177);
            this.chkRR_Voltage.Name = "chkRR_Voltage";
            this.chkRR_Voltage.Size = new System.Drawing.Size(103, 23);
            this.chkRR_Voltage.TabIndex = 18;
            this.chkRR_Voltage.Text = "电压";
            this.chkRR_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Voltage.UseVisualStyleBackColor = true;
            // 
            // RR_MCUTemp_TextBox
            // 
            this.RR_MCUTemp_TextBox.Enabled = false;
            this.RR_MCUTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_MCUTemp_TextBox.Location = new System.Drawing.Point(112, 235);
            this.RR_MCUTemp_TextBox.Name = "RR_MCUTemp_TextBox";
            this.RR_MCUTemp_TextBox.ReadOnly = true;
            this.RR_MCUTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_MCUTemp_TextBox.TabIndex = 25;
            // 
            // RR_Voltage_TextBox
            // 
            this.RR_Voltage_TextBox.Enabled = false;
            this.RR_Voltage_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_Voltage_TextBox.Location = new System.Drawing.Point(112, 177);
            this.RR_Voltage_TextBox.Name = "RR_Voltage_TextBox";
            this.RR_Voltage_TextBox.ReadOnly = true;
            this.RR_Voltage_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_Voltage_TextBox.TabIndex = 20;
            // 
            // chkRR_Power
            // 
            this.chkRR_Power.AutoSize = true;
            this.chkRR_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_Power.Location = new System.Drawing.Point(3, 206);
            this.chkRR_Power.Name = "chkRR_Power";
            this.chkRR_Power.Size = new System.Drawing.Size(103, 23);
            this.chkRR_Power.TabIndex = 21;
            this.chkRR_Power.Text = "功率";
            this.chkRR_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_Power.UseVisualStyleBackColor = true;
            // 
            // chkRR_MCUTemp
            // 
            this.chkRR_MCUTemp.AutoSize = true;
            this.chkRR_MCUTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkRR_MCUTemp.Location = new System.Drawing.Point(3, 235);
            this.chkRR_MCUTemp.Name = "chkRR_MCUTemp";
            this.chkRR_MCUTemp.Size = new System.Drawing.Size(103, 23);
            this.chkRR_MCUTemp.TabIndex = 23;
            this.chkRR_MCUTemp.Text = "芯片温度";
            this.chkRR_MCUTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkRR_MCUTemp.UseVisualStyleBackColor = true;
            // 
            // RR_Power_TextBox
            // 
            this.RR_Power_TextBox.Enabled = false;
            this.RR_Power_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.RR_Power_TextBox.Location = new System.Drawing.Point(112, 206);
            this.RR_Power_TextBox.Name = "RR_Power_TextBox";
            this.RR_Power_TextBox.ReadOnly = true;
            this.RR_Power_TextBox.Size = new System.Drawing.Size(62, 20);
            this.RR_Power_TextBox.TabIndex = 22;
            // 
            // RR_PollingState
            // 
            this.RR_PollingState.Enabled = false;
            this.RR_PollingState.Font = new System.Drawing.Font("宋体", 8F);
            this.RR_PollingState.Location = new System.Drawing.Point(112, 293);
            this.RR_PollingState.Name = "RR_PollingState";
            this.RR_PollingState.ReadOnly = true;
            this.RR_PollingState.Size = new System.Drawing.Size(61, 20);
            this.RR_PollingState.TabIndex = 31;
            // 
            // splitContainer13
            // 
            this.splitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer13.Location = new System.Drawing.Point(0, 0);
            this.splitContainer13.Name = "splitContainer13";
            // 
            // splitContainer13.Panel1
            // 
            this.splitContainer13.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer13.Panel2
            // 
            this.splitContainer13.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer13.Size = new System.Drawing.Size(963, 598);
            this.splitContainer13.SplitterDistance = 266;
            this.splitContainer13.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel9);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(266, 598);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "CLF 显示板";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel9.Controls.Add(this.CLF_ReserveD8_TextBox, 1, 18);
            this.tableLayoutPanel9.Controls.Add(this.CLF_ReserveD7_TextBox, 1, 17);
            this.tableLayoutPanel9.Controls.Add(this.CLF_Disp_ReserveD1B7_TextBox, 1, 16);
            this.tableLayoutPanel9.Controls.Add(this.CLF_Disp_ReserveD1B6_TextBox, 1, 15);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_ReserveD8, 0, 18);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_ReserveD7, 0, 17);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_Disp_ReserveD1B7, 0, 16);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_Disp_ReserveD1B6, 0, 15);
            this.tableLayoutPanel9.Controls.Add(this.CLF_RequestPower_TextBox, 1, 14);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_HeatingFreqFollow, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_PanControlActive, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.CLF_HeatingFreqFollow_TextBox, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_RequestPower, 0, 14);
            this.tableLayoutPanel9.Controls.Add(this.CLF_PanControlActive_TextBox, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.CLF_DebugChannel_TextBox, 1, 13);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_InnerOuterRing, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.CLF_InnerOuterRing_TextBox, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_DebugChannel, 0, 13);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_PauseFlag, 0, 6);
            this.tableLayoutPanel9.Controls.Add(this.CLF_DebugSubChannel_TextBox, 1, 12);
            this.tableLayoutPanel9.Controls.Add(this.CLF_PauseFlag_TextBox, 1, 6);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_allZone_BridgeHeatFlag, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_DebugSubChannel, 0, 12);
            this.tableLayoutPanel9.Controls.Add(this.CLF_allZone_BridgeHeatFlag_TextBox, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.CLF_BridgeControl_TextBox, 1, 11);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_PPGMode, 0, 4);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_StoveSwitch, 0, 7);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_BridgeControl, 0, 11);
            this.tableLayoutPanel9.Controls.Add(this.CLF_PPGMode_TextBox, 1, 4);
            this.tableLayoutPanel9.Controls.Add(this.CLF_FanLevel_TextBox, 1, 10);
            this.tableLayoutPanel9.Controls.Add(this.CLF_StoveSwitch_TextBox, 1, 7);
            this.tableLayoutPanel9.Controls.Add(this.CLF_AllowPanDetection_TextBox, 1, 5);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_FanLevel, 0, 10);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_AllowPanDetection, 0, 5);
            this.tableLayoutPanel9.Controls.Add(this.CLF_NoiseControl_TextBox, 1, 9);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_HeatFreqJitterFlag, 0, 8);
            this.tableLayoutPanel9.Controls.Add(this.CLF_HeatFreqJitterFlag_TextBox, 1, 8);
            this.tableLayoutPanel9.Controls.Add(this.chkCLF_NoiseControl, 0, 9);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 20;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(260, 578);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // CLF_ReserveD8_TextBox
            // 
            this.CLF_ReserveD8_TextBox.Enabled = false;
            this.CLF_ReserveD8_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_ReserveD8_TextBox.Location = new System.Drawing.Point(193, 525);
            this.CLF_ReserveD8_TextBox.Name = "CLF_ReserveD8_TextBox";
            this.CLF_ReserveD8_TextBox.ReadOnly = true;
            this.CLF_ReserveD8_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_ReserveD8_TextBox.TabIndex = 90;
            // 
            // CLF_ReserveD7_TextBox
            // 
            this.CLF_ReserveD7_TextBox.Enabled = false;
            this.CLF_ReserveD7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_ReserveD7_TextBox.Location = new System.Drawing.Point(193, 496);
            this.CLF_ReserveD7_TextBox.Name = "CLF_ReserveD7_TextBox";
            this.CLF_ReserveD7_TextBox.ReadOnly = true;
            this.CLF_ReserveD7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_ReserveD7_TextBox.TabIndex = 89;
            // 
            // CLF_Disp_ReserveD1B7_TextBox
            // 
            this.CLF_Disp_ReserveD1B7_TextBox.Enabled = false;
            this.CLF_Disp_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Disp_ReserveD1B7_TextBox.Location = new System.Drawing.Point(193, 467);
            this.CLF_Disp_ReserveD1B7_TextBox.Name = "CLF_Disp_ReserveD1B7_TextBox";
            this.CLF_Disp_ReserveD1B7_TextBox.ReadOnly = true;
            this.CLF_Disp_ReserveD1B7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_Disp_ReserveD1B7_TextBox.TabIndex = 88;
            // 
            // CLF_Disp_ReserveD1B6_TextBox
            // 
            this.CLF_Disp_ReserveD1B6_TextBox.Enabled = false;
            this.CLF_Disp_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Disp_ReserveD1B6_TextBox.Location = new System.Drawing.Point(193, 438);
            this.CLF_Disp_ReserveD1B6_TextBox.Name = "CLF_Disp_ReserveD1B6_TextBox";
            this.CLF_Disp_ReserveD1B6_TextBox.ReadOnly = true;
            this.CLF_Disp_ReserveD1B6_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_Disp_ReserveD1B6_TextBox.TabIndex = 88;
            // 
            // chkCLF_ReserveD8
            // 
            this.chkCLF_ReserveD8.AutoSize = true;
            this.chkCLF_ReserveD8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_ReserveD8.Location = new System.Drawing.Point(3, 525);
            this.chkCLF_ReserveD8.Name = "chkCLF_ReserveD8";
            this.chkCLF_ReserveD8.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_ReserveD8.TabIndex = 86;
            this.chkCLF_ReserveD8.Text = "ReserveD8";
            this.chkCLF_ReserveD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_ReserveD8.UseVisualStyleBackColor = true;
            // 
            // chkCLF_ReserveD7
            // 
            this.chkCLF_ReserveD7.AutoSize = true;
            this.chkCLF_ReserveD7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_ReserveD7.Location = new System.Drawing.Point(3, 496);
            this.chkCLF_ReserveD7.Name = "chkCLF_ReserveD7";
            this.chkCLF_ReserveD7.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_ReserveD7.TabIndex = 86;
            this.chkCLF_ReserveD7.Text = "ReserveD7";
            this.chkCLF_ReserveD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_ReserveD7.UseVisualStyleBackColor = true;
            // 
            // chkCLF_Disp_ReserveD1B7
            // 
            this.chkCLF_Disp_ReserveD1B7.AutoSize = true;
            this.chkCLF_Disp_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Disp_ReserveD1B7.Location = new System.Drawing.Point(3, 467);
            this.chkCLF_Disp_ReserveD1B7.Name = "chkCLF_Disp_ReserveD1B7";
            this.chkCLF_Disp_ReserveD1B7.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_Disp_ReserveD1B7.TabIndex = 86;
            this.chkCLF_Disp_ReserveD1B7.Text = "ReserveD1B7";
            this.chkCLF_Disp_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Disp_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkCLF_Disp_ReserveD1B6
            // 
            this.chkCLF_Disp_ReserveD1B6.AutoSize = true;
            this.chkCLF_Disp_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Disp_ReserveD1B6.Location = new System.Drawing.Point(3, 438);
            this.chkCLF_Disp_ReserveD1B6.Name = "chkCLF_Disp_ReserveD1B6";
            this.chkCLF_Disp_ReserveD1B6.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_Disp_ReserveD1B6.TabIndex = 88;
            this.chkCLF_Disp_ReserveD1B6.Text = "ReserveD1B6";
            this.chkCLF_Disp_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Disp_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // CLF_RequestPower_TextBox
            // 
            this.CLF_RequestPower_TextBox.Enabled = false;
            this.CLF_RequestPower_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_RequestPower_TextBox.Location = new System.Drawing.Point(193, 409);
            this.CLF_RequestPower_TextBox.Name = "CLF_RequestPower_TextBox";
            this.CLF_RequestPower_TextBox.ReadOnly = true;
            this.CLF_RequestPower_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_RequestPower_TextBox.TabIndex = 83;
            // 
            // chkCLF_HeatingFreqFollow
            // 
            this.chkCLF_HeatingFreqFollow.AutoSize = true;
            this.chkCLF_HeatingFreqFollow.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCLF_HeatingFreqFollow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_HeatingFreqFollow.Location = new System.Drawing.Point(3, 3);
            this.chkCLF_HeatingFreqFollow.Name = "chkCLF_HeatingFreqFollow";
            this.chkCLF_HeatingFreqFollow.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_HeatingFreqFollow.TabIndex = 39;
            this.chkCLF_HeatingFreqFollow.Text = "加热频率跟随标志";
            this.chkCLF_HeatingFreqFollow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_HeatingFreqFollow.UseVisualStyleBackColor = true;
            // 
            // chkCLF_PanControlActive
            // 
            this.chkCLF_PanControlActive.AutoSize = true;
            this.chkCLF_PanControlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_PanControlActive.Location = new System.Drawing.Point(3, 32);
            this.chkCLF_PanControlActive.Name = "chkCLF_PanControlActive";
            this.chkCLF_PanControlActive.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_PanControlActive.TabIndex = 42;
            this.chkCLF_PanControlActive.Text = "移锅控功激活标志";
            this.chkCLF_PanControlActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_PanControlActive.UseVisualStyleBackColor = true;
            // 
            // CLF_HeatingFreqFollow_TextBox
            // 
            this.CLF_HeatingFreqFollow_TextBox.Enabled = false;
            this.CLF_HeatingFreqFollow_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_HeatingFreqFollow_TextBox.Location = new System.Drawing.Point(193, 3);
            this.CLF_HeatingFreqFollow_TextBox.Name = "CLF_HeatingFreqFollow_TextBox";
            this.CLF_HeatingFreqFollow_TextBox.ReadOnly = true;
            this.CLF_HeatingFreqFollow_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_HeatingFreqFollow_TextBox.TabIndex = 41;
            // 
            // chkCLF_RequestPower
            // 
            this.chkCLF_RequestPower.AutoSize = true;
            this.chkCLF_RequestPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_RequestPower.Location = new System.Drawing.Point(3, 409);
            this.chkCLF_RequestPower.Name = "chkCLF_RequestPower";
            this.chkCLF_RequestPower.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_RequestPower.TabIndex = 81;
            this.chkCLF_RequestPower.Text = "请求功率值";
            this.chkCLF_RequestPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_RequestPower.UseVisualStyleBackColor = true;
            // 
            // CLF_PanControlActive_TextBox
            // 
            this.CLF_PanControlActive_TextBox.Enabled = false;
            this.CLF_PanControlActive_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_PanControlActive_TextBox.Location = new System.Drawing.Point(193, 32);
            this.CLF_PanControlActive_TextBox.Name = "CLF_PanControlActive_TextBox";
            this.CLF_PanControlActive_TextBox.ReadOnly = true;
            this.CLF_PanControlActive_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_PanControlActive_TextBox.TabIndex = 44;
            // 
            // CLF_DebugChannel_TextBox
            // 
            this.CLF_DebugChannel_TextBox.Enabled = false;
            this.CLF_DebugChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_DebugChannel_TextBox.Location = new System.Drawing.Point(193, 380);
            this.CLF_DebugChannel_TextBox.Name = "CLF_DebugChannel_TextBox";
            this.CLF_DebugChannel_TextBox.ReadOnly = true;
            this.CLF_DebugChannel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_DebugChannel_TextBox.TabIndex = 80;
            // 
            // chkCLF_InnerOuterRing
            // 
            this.chkCLF_InnerOuterRing.AutoSize = true;
            this.chkCLF_InnerOuterRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_InnerOuterRing.Location = new System.Drawing.Point(3, 61);
            this.chkCLF_InnerOuterRing.Name = "chkCLF_InnerOuterRing";
            this.chkCLF_InnerOuterRing.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_InnerOuterRing.TabIndex = 45;
            this.chkCLF_InnerOuterRing.Text = "内外环标志";
            this.chkCLF_InnerOuterRing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_InnerOuterRing.UseVisualStyleBackColor = true;
            // 
            // CLF_InnerOuterRing_TextBox
            // 
            this.CLF_InnerOuterRing_TextBox.Enabled = false;
            this.CLF_InnerOuterRing_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_InnerOuterRing_TextBox.Location = new System.Drawing.Point(193, 61);
            this.CLF_InnerOuterRing_TextBox.Name = "CLF_InnerOuterRing_TextBox";
            this.CLF_InnerOuterRing_TextBox.ReadOnly = true;
            this.CLF_InnerOuterRing_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_InnerOuterRing_TextBox.TabIndex = 48;
            // 
            // chkCLF_DebugChannel
            // 
            this.chkCLF_DebugChannel.AutoSize = true;
            this.chkCLF_DebugChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_DebugChannel.Location = new System.Drawing.Point(3, 380);
            this.chkCLF_DebugChannel.Name = "chkCLF_DebugChannel";
            this.chkCLF_DebugChannel.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_DebugChannel.TabIndex = 78;
            this.chkCLF_DebugChannel.Text = "Debug通道号";
            this.chkCLF_DebugChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_DebugChannel.UseVisualStyleBackColor = true;
            // 
            // chkCLF_PauseFlag
            // 
            this.chkCLF_PauseFlag.AutoSize = true;
            this.chkCLF_PauseFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_PauseFlag.Location = new System.Drawing.Point(3, 177);
            this.chkCLF_PauseFlag.Name = "chkCLF_PauseFlag";
            this.chkCLF_PauseFlag.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_PauseFlag.TabIndex = 57;
            this.chkCLF_PauseFlag.Text = "暂停标志";
            this.chkCLF_PauseFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_PauseFlag.UseVisualStyleBackColor = true;
            // 
            // CLF_DebugSubChannel_TextBox
            // 
            this.CLF_DebugSubChannel_TextBox.Enabled = false;
            this.CLF_DebugSubChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_DebugSubChannel_TextBox.Location = new System.Drawing.Point(193, 351);
            this.CLF_DebugSubChannel_TextBox.Name = "CLF_DebugSubChannel_TextBox";
            this.CLF_DebugSubChannel_TextBox.ReadOnly = true;
            this.CLF_DebugSubChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_DebugSubChannel_TextBox.TabIndex = 76;
            // 
            // CLF_PauseFlag_TextBox
            // 
            this.CLF_PauseFlag_TextBox.Enabled = false;
            this.CLF_PauseFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_PauseFlag_TextBox.Location = new System.Drawing.Point(193, 177);
            this.CLF_PauseFlag_TextBox.Name = "CLF_PauseFlag_TextBox";
            this.CLF_PauseFlag_TextBox.ReadOnly = true;
            this.CLF_PauseFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_PauseFlag_TextBox.TabIndex = 59;
            // 
            // chkCLF_allZone_BridgeHeatFlag
            // 
            this.chkCLF_allZone_BridgeHeatFlag.AutoSize = true;
            this.chkCLF_allZone_BridgeHeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_allZone_BridgeHeatFlag.Location = new System.Drawing.Point(3, 90);
            this.chkCLF_allZone_BridgeHeatFlag.Name = "chkCLF_allZone_BridgeHeatFlag";
            this.chkCLF_allZone_BridgeHeatFlag.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_allZone_BridgeHeatFlag.TabIndex = 48;
            this.chkCLF_allZone_BridgeHeatFlag.Text = "无区/桥接标志/三环（红外）";
            this.chkCLF_allZone_BridgeHeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_allZone_BridgeHeatFlag.UseVisualStyleBackColor = true;
            // 
            // chkCLF_DebugSubChannel
            // 
            this.chkCLF_DebugSubChannel.AutoSize = true;
            this.chkCLF_DebugSubChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_DebugSubChannel.Location = new System.Drawing.Point(3, 351);
            this.chkCLF_DebugSubChannel.Name = "chkCLF_DebugSubChannel";
            this.chkCLF_DebugSubChannel.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_DebugSubChannel.TabIndex = 74;
            this.chkCLF_DebugSubChannel.Text = "Debug子通道号";
            this.chkCLF_DebugSubChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_DebugSubChannel.UseVisualStyleBackColor = true;
            // 
            // CLF_allZone_BridgeHeatFlag_TextBox
            // 
            this.CLF_allZone_BridgeHeatFlag_TextBox.Enabled = false;
            this.CLF_allZone_BridgeHeatFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_allZone_BridgeHeatFlag_TextBox.Location = new System.Drawing.Point(193, 90);
            this.CLF_allZone_BridgeHeatFlag_TextBox.Name = "CLF_allZone_BridgeHeatFlag_TextBox";
            this.CLF_allZone_BridgeHeatFlag_TextBox.ReadOnly = true;
            this.CLF_allZone_BridgeHeatFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_allZone_BridgeHeatFlag_TextBox.TabIndex = 50;
            // 
            // CLF_BridgeControl_TextBox
            // 
            this.CLF_BridgeControl_TextBox.Enabled = false;
            this.CLF_BridgeControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_BridgeControl_TextBox.Location = new System.Drawing.Point(193, 322);
            this.CLF_BridgeControl_TextBox.Name = "CLF_BridgeControl_TextBox";
            this.CLF_BridgeControl_TextBox.ReadOnly = true;
            this.CLF_BridgeControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_BridgeControl_TextBox.TabIndex = 73;
            // 
            // chkCLF_PPGMode
            // 
            this.chkCLF_PPGMode.AutoSize = true;
            this.chkCLF_PPGMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_PPGMode.Location = new System.Drawing.Point(3, 119);
            this.chkCLF_PPGMode.Name = "chkCLF_PPGMode";
            this.chkCLF_PPGMode.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_PPGMode.TabIndex = 51;
            this.chkCLF_PPGMode.Text = "PPG模式标志";
            this.chkCLF_PPGMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_PPGMode.UseVisualStyleBackColor = true;
            // 
            // chkCLF_StoveSwitch
            // 
            this.chkCLF_StoveSwitch.AutoSize = true;
            this.chkCLF_StoveSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_StoveSwitch.Location = new System.Drawing.Point(3, 206);
            this.chkCLF_StoveSwitch.Name = "chkCLF_StoveSwitch";
            this.chkCLF_StoveSwitch.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_StoveSwitch.TabIndex = 60;
            this.chkCLF_StoveSwitch.Text = "炉头开关标志";
            this.chkCLF_StoveSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_StoveSwitch.UseVisualStyleBackColor = true;
            // 
            // chkCLF_BridgeControl
            // 
            this.chkCLF_BridgeControl.AutoSize = true;
            this.chkCLF_BridgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_BridgeControl.Location = new System.Drawing.Point(3, 322);
            this.chkCLF_BridgeControl.Name = "chkCLF_BridgeControl";
            this.chkCLF_BridgeControl.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_BridgeControl.TabIndex = 71;
            this.chkCLF_BridgeControl.Text = "无区/桥接控制指令";
            this.chkCLF_BridgeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_BridgeControl.UseVisualStyleBackColor = true;
            // 
            // CLF_PPGMode_TextBox
            // 
            this.CLF_PPGMode_TextBox.Enabled = false;
            this.CLF_PPGMode_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_PPGMode_TextBox.Location = new System.Drawing.Point(193, 119);
            this.CLF_PPGMode_TextBox.Name = "CLF_PPGMode_TextBox";
            this.CLF_PPGMode_TextBox.ReadOnly = true;
            this.CLF_PPGMode_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_PPGMode_TextBox.TabIndex = 53;
            // 
            // CLF_FanLevel_TextBox
            // 
            this.CLF_FanLevel_TextBox.Enabled = false;
            this.CLF_FanLevel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_FanLevel_TextBox.Location = new System.Drawing.Point(193, 293);
            this.CLF_FanLevel_TextBox.Name = "CLF_FanLevel_TextBox";
            this.CLF_FanLevel_TextBox.ReadOnly = true;
            this.CLF_FanLevel_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_FanLevel_TextBox.TabIndex = 70;
            // 
            // CLF_StoveSwitch_TextBox
            // 
            this.CLF_StoveSwitch_TextBox.Enabled = false;
            this.CLF_StoveSwitch_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_StoveSwitch_TextBox.Location = new System.Drawing.Point(193, 206);
            this.CLF_StoveSwitch_TextBox.Name = "CLF_StoveSwitch_TextBox";
            this.CLF_StoveSwitch_TextBox.ReadOnly = true;
            this.CLF_StoveSwitch_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_StoveSwitch_TextBox.TabIndex = 61;
            // 
            // CLF_AllowPanDetection_TextBox
            // 
            this.CLF_AllowPanDetection_TextBox.Enabled = false;
            this.CLF_AllowPanDetection_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_AllowPanDetection_TextBox.Location = new System.Drawing.Point(193, 148);
            this.CLF_AllowPanDetection_TextBox.Name = "CLF_AllowPanDetection_TextBox";
            this.CLF_AllowPanDetection_TextBox.ReadOnly = true;
            this.CLF_AllowPanDetection_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_AllowPanDetection_TextBox.TabIndex = 56;
            // 
            // chkCLF_FanLevel
            // 
            this.chkCLF_FanLevel.AutoSize = true;
            this.chkCLF_FanLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_FanLevel.Location = new System.Drawing.Point(3, 293);
            this.chkCLF_FanLevel.Name = "chkCLF_FanLevel";
            this.chkCLF_FanLevel.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_FanLevel.TabIndex = 68;
            this.chkCLF_FanLevel.Text = "风机档位";
            this.chkCLF_FanLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_FanLevel.UseVisualStyleBackColor = true;
            // 
            // chkCLF_AllowPanDetection
            // 
            this.chkCLF_AllowPanDetection.AutoSize = true;
            this.chkCLF_AllowPanDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_AllowPanDetection.Location = new System.Drawing.Point(3, 148);
            this.chkCLF_AllowPanDetection.Name = "chkCLF_AllowPanDetection";
            this.chkCLF_AllowPanDetection.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_AllowPanDetection.TabIndex = 54;
            this.chkCLF_AllowPanDetection.Text = "允许检锅标志";
            this.chkCLF_AllowPanDetection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_AllowPanDetection.UseVisualStyleBackColor = true;
            // 
            // CLF_NoiseControl_TextBox
            // 
            this.CLF_NoiseControl_TextBox.Enabled = false;
            this.CLF_NoiseControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_NoiseControl_TextBox.Location = new System.Drawing.Point(193, 264);
            this.CLF_NoiseControl_TextBox.Name = "CLF_NoiseControl_TextBox";
            this.CLF_NoiseControl_TextBox.ReadOnly = true;
            this.CLF_NoiseControl_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_NoiseControl_TextBox.TabIndex = 67;
            // 
            // chkCLF_HeatFreqJitterFlag
            // 
            this.chkCLF_HeatFreqJitterFlag.AutoSize = true;
            this.chkCLF_HeatFreqJitterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_HeatFreqJitterFlag.Location = new System.Drawing.Point(3, 235);
            this.chkCLF_HeatFreqJitterFlag.Name = "chkCLF_HeatFreqJitterFlag";
            this.chkCLF_HeatFreqJitterFlag.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_HeatFreqJitterFlag.TabIndex = 62;
            this.chkCLF_HeatFreqJitterFlag.Text = "加热频率抖频率模式";
            this.chkCLF_HeatFreqJitterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_HeatFreqJitterFlag.UseVisualStyleBackColor = true;
            // 
            // CLF_HeatFreqJitterFlag_TextBox
            // 
            this.CLF_HeatFreqJitterFlag_TextBox.Enabled = false;
            this.CLF_HeatFreqJitterFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_HeatFreqJitterFlag_TextBox.Location = new System.Drawing.Point(193, 235);
            this.CLF_HeatFreqJitterFlag_TextBox.Name = "CLF_HeatFreqJitterFlag_TextBox";
            this.CLF_HeatFreqJitterFlag_TextBox.ReadOnly = true;
            this.CLF_HeatFreqJitterFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_HeatFreqJitterFlag_TextBox.TabIndex = 64;
            // 
            // chkCLF_NoiseControl
            // 
            this.chkCLF_NoiseControl.AutoSize = true;
            this.chkCLF_NoiseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_NoiseControl.Location = new System.Drawing.Point(3, 264);
            this.chkCLF_NoiseControl.Name = "chkCLF_NoiseControl";
            this.chkCLF_NoiseControl.Size = new System.Drawing.Size(184, 23);
            this.chkCLF_NoiseControl.TabIndex = 65;
            this.chkCLF_NoiseControl.Text = "噪声处理指令";
            this.chkCLF_NoiseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_NoiseControl.UseVisualStyleBackColor = true;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.groupBox7);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer7.Size = new System.Drawing.Size(693, 598);
            this.splitContainer7.SplitterDistance = 186;
            this.splitContainer7.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSize = true;
            this.groupBox7.Controls.Add(this.tableLayoutPanel10);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(186, 598);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "CLF 功率板";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoScroll = true;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel10.Controls.Add(this.CLF_ReserveD16_TextBox, 1, 17);
            this.tableLayoutPanel10.Controls.Add(this.CLF_ReserveD15_TextBox, 1, 16);
            this.tableLayoutPanel10.Controls.Add(this.CLF_ReserveD14_TextBox, 1, 15);
            this.tableLayoutPanel10.Controls.Add(this.CLF_Power_ReserveD1B7_TextBox, 1, 14);
            this.tableLayoutPanel10.Controls.Add(this.CLF_Power_ReserveD1B6_TextBox, 1, 13);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_ReserveD16, 0, 17);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_ReserveD15, 0, 16);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_ReserveD14, 0, 15);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_Power_ReserveD1B7, 0, 14);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_Power_ReserveD1B6, 0, 13);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_PollingState, 0, 10);
            this.tableLayoutPanel10.Controls.Add(this.CLF_PollingState, 1, 10);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_FreqControlFlag, 0, 11);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_HeatFlag, 0, 12);
            this.tableLayoutPanel10.Controls.Add(this.CLF_FreqControlFlag, 1, 11);
            this.tableLayoutPanel10.Controls.Add(this.CLF_HeatFlag, 1, 12);
            this.tableLayoutPanel10.Controls.Add(this.CLF_HeatNTC2_TextBox, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_HeatNTC2, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_HeatNTC1, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.CLF_HeatNTC1_TextBox, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_IGBTNTC1, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.CLF_IGBTNTC1_TextBox, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_IGBTNTC2, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.CLF_ErrorCode, 1, 9);
            this.tableLayoutPanel10.Controls.Add(this.CLF_IGBTNTC2_TextBox, 1, 3);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_PanTemp, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.CLF_PanTemp_TextBox, 1, 4);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_Freq, 0, 5);
            this.tableLayoutPanel10.Controls.Add(this.CLF_Freq_TextBox, 1, 5);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_ErrorCode, 0, 9);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_Voltage, 0, 6);
            this.tableLayoutPanel10.Controls.Add(this.CLF_MCUTemp_TextBox, 1, 8);
            this.tableLayoutPanel10.Controls.Add(this.CLF_Voltage_TextBox, 1, 6);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_Power, 0, 7);
            this.tableLayoutPanel10.Controls.Add(this.chkCLF_MCUTemp, 0, 8);
            this.tableLayoutPanel10.Controls.Add(this.CLF_Power_TextBox, 1, 7);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 19;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(180, 578);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // CLF_ReserveD16_TextBox
            // 
            this.CLF_ReserveD16_TextBox.Enabled = false;
            this.CLF_ReserveD16_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_ReserveD16_TextBox.Location = new System.Drawing.Point(112, 496);
            this.CLF_ReserveD16_TextBox.Name = "CLF_ReserveD16_TextBox";
            this.CLF_ReserveD16_TextBox.ReadOnly = true;
            this.CLF_ReserveD16_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_ReserveD16_TextBox.TabIndex = 99;
            // 
            // CLF_ReserveD15_TextBox
            // 
            this.CLF_ReserveD15_TextBox.Enabled = false;
            this.CLF_ReserveD15_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_ReserveD15_TextBox.Location = new System.Drawing.Point(112, 467);
            this.CLF_ReserveD15_TextBox.Name = "CLF_ReserveD15_TextBox";
            this.CLF_ReserveD15_TextBox.ReadOnly = true;
            this.CLF_ReserveD15_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_ReserveD15_TextBox.TabIndex = 98;
            // 
            // CLF_ReserveD14_TextBox
            // 
            this.CLF_ReserveD14_TextBox.Enabled = false;
            this.CLF_ReserveD14_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_ReserveD14_TextBox.Location = new System.Drawing.Point(112, 438);
            this.CLF_ReserveD14_TextBox.Name = "CLF_ReserveD14_TextBox";
            this.CLF_ReserveD14_TextBox.ReadOnly = true;
            this.CLF_ReserveD14_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_ReserveD14_TextBox.TabIndex = 97;
            // 
            // CLF_Power_ReserveD1B7_TextBox
            // 
            this.CLF_Power_ReserveD1B7_TextBox.Enabled = false;
            this.CLF_Power_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Power_ReserveD1B7_TextBox.Location = new System.Drawing.Point(112, 409);
            this.CLF_Power_ReserveD1B7_TextBox.Name = "CLF_Power_ReserveD1B7_TextBox";
            this.CLF_Power_ReserveD1B7_TextBox.ReadOnly = true;
            this.CLF_Power_ReserveD1B7_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_Power_ReserveD1B7_TextBox.TabIndex = 96;
            // 
            // CLF_Power_ReserveD1B6_TextBox
            // 
            this.CLF_Power_ReserveD1B6_TextBox.Enabled = false;
            this.CLF_Power_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Power_ReserveD1B6_TextBox.Location = new System.Drawing.Point(112, 380);
            this.CLF_Power_ReserveD1B6_TextBox.Name = "CLF_Power_ReserveD1B6_TextBox";
            this.CLF_Power_ReserveD1B6_TextBox.ReadOnly = true;
            this.CLF_Power_ReserveD1B6_TextBox.Size = new System.Drawing.Size(61, 20);
            this.CLF_Power_ReserveD1B6_TextBox.TabIndex = 95;
            // 
            // chkCLF_ReserveD16
            // 
            this.chkCLF_ReserveD16.AutoSize = true;
            this.chkCLF_ReserveD16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_ReserveD16.Location = new System.Drawing.Point(3, 496);
            this.chkCLF_ReserveD16.Name = "chkCLF_ReserveD16";
            this.chkCLF_ReserveD16.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_ReserveD16.TabIndex = 94;
            this.chkCLF_ReserveD16.Text = "ReserveD16";
            this.chkCLF_ReserveD16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_ReserveD16.UseVisualStyleBackColor = true;
            // 
            // chkCLF_ReserveD15
            // 
            this.chkCLF_ReserveD15.AutoSize = true;
            this.chkCLF_ReserveD15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_ReserveD15.Location = new System.Drawing.Point(3, 467);
            this.chkCLF_ReserveD15.Name = "chkCLF_ReserveD15";
            this.chkCLF_ReserveD15.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_ReserveD15.TabIndex = 93;
            this.chkCLF_ReserveD15.Text = "ReserveD15";
            this.chkCLF_ReserveD15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_ReserveD15.UseVisualStyleBackColor = true;
            // 
            // chkCLF_ReserveD14
            // 
            this.chkCLF_ReserveD14.AutoSize = true;
            this.chkCLF_ReserveD14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_ReserveD14.Location = new System.Drawing.Point(3, 438);
            this.chkCLF_ReserveD14.Name = "chkCLF_ReserveD14";
            this.chkCLF_ReserveD14.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_ReserveD14.TabIndex = 92;
            this.chkCLF_ReserveD14.Text = "ReserveD14";
            this.chkCLF_ReserveD14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_ReserveD14.UseVisualStyleBackColor = true;
            // 
            // chkCLF_Power_ReserveD1B7
            // 
            this.chkCLF_Power_ReserveD1B7.AutoSize = true;
            this.chkCLF_Power_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Power_ReserveD1B7.Location = new System.Drawing.Point(3, 409);
            this.chkCLF_Power_ReserveD1B7.Name = "chkCLF_Power_ReserveD1B7";
            this.chkCLF_Power_ReserveD1B7.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_Power_ReserveD1B7.TabIndex = 91;
            this.chkCLF_Power_ReserveD1B7.Text = "ReserveD1B7";
            this.chkCLF_Power_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Power_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkCLF_Power_ReserveD1B6
            // 
            this.chkCLF_Power_ReserveD1B6.AutoSize = true;
            this.chkCLF_Power_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Power_ReserveD1B6.Location = new System.Drawing.Point(3, 380);
            this.chkCLF_Power_ReserveD1B6.Name = "chkCLF_Power_ReserveD1B6";
            this.chkCLF_Power_ReserveD1B6.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_Power_ReserveD1B6.TabIndex = 89;
            this.chkCLF_Power_ReserveD1B6.Text = "ReserveD1B6";
            this.chkCLF_Power_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Power_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // chkCLF_PollingState
            // 
            this.chkCLF_PollingState.AutoSize = true;
            this.chkCLF_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_PollingState.Location = new System.Drawing.Point(3, 293);
            this.chkCLF_PollingState.Name = "chkCLF_PollingState";
            this.chkCLF_PollingState.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_PollingState.TabIndex = 29;
            this.chkCLF_PollingState.Text = "检锅状态";
            this.chkCLF_PollingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_PollingState.UseVisualStyleBackColor = true;
            // 
            // CLF_PollingState
            // 
            this.CLF_PollingState.Enabled = false;
            this.CLF_PollingState.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_PollingState.Location = new System.Drawing.Point(112, 293);
            this.CLF_PollingState.Name = "CLF_PollingState";
            this.CLF_PollingState.ReadOnly = true;
            this.CLF_PollingState.Size = new System.Drawing.Size(62, 20);
            this.CLF_PollingState.TabIndex = 31;
            // 
            // chkCLF_FreqControlFlag
            // 
            this.chkCLF_FreqControlFlag.AutoSize = true;
            this.chkCLF_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_FreqControlFlag.Location = new System.Drawing.Point(3, 322);
            this.chkCLF_FreqControlFlag.Name = "chkCLF_FreqControlFlag";
            this.chkCLF_FreqControlFlag.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_FreqControlFlag.TabIndex = 32;
            this.chkCLF_FreqControlFlag.Text = "同频加热状态";
            this.chkCLF_FreqControlFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_FreqControlFlag.UseVisualStyleBackColor = true;
            // 
            // chkCLF_HeatFlag
            // 
            this.chkCLF_HeatFlag.AutoSize = true;
            this.chkCLF_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_HeatFlag.Location = new System.Drawing.Point(3, 351);
            this.chkCLF_HeatFlag.Name = "chkCLF_HeatFlag";
            this.chkCLF_HeatFlag.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_HeatFlag.TabIndex = 35;
            this.chkCLF_HeatFlag.Text = "主频稳定标志";
            this.chkCLF_HeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_HeatFlag.UseVisualStyleBackColor = true;
            // 
            // CLF_FreqControlFlag
            // 
            this.CLF_FreqControlFlag.Enabled = false;
            this.CLF_FreqControlFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_FreqControlFlag.Location = new System.Drawing.Point(112, 322);
            this.CLF_FreqControlFlag.Name = "CLF_FreqControlFlag";
            this.CLF_FreqControlFlag.ReadOnly = true;
            this.CLF_FreqControlFlag.Size = new System.Drawing.Size(62, 20);
            this.CLF_FreqControlFlag.TabIndex = 34;
            // 
            // CLF_HeatFlag
            // 
            this.CLF_HeatFlag.Enabled = false;
            this.CLF_HeatFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_HeatFlag.Location = new System.Drawing.Point(112, 351);
            this.CLF_HeatFlag.Name = "CLF_HeatFlag";
            this.CLF_HeatFlag.ReadOnly = true;
            this.CLF_HeatFlag.Size = new System.Drawing.Size(62, 20);
            this.CLF_HeatFlag.TabIndex = 37;
            // 
            // CLF_HeatNTC2_TextBox
            // 
            this.CLF_HeatNTC2_TextBox.Enabled = false;
            this.CLF_HeatNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_HeatNTC2_TextBox.Location = new System.Drawing.Point(112, 32);
            this.CLF_HeatNTC2_TextBox.Name = "CLF_HeatNTC2_TextBox";
            this.CLF_HeatNTC2_TextBox.ReadOnly = true;
            this.CLF_HeatNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_HeatNTC2_TextBox.TabIndex = 5;
            // 
            // chkCLF_HeatNTC2
            // 
            this.chkCLF_HeatNTC2.AutoSize = true;
            this.chkCLF_HeatNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_HeatNTC2.Location = new System.Drawing.Point(3, 32);
            this.chkCLF_HeatNTC2.Name = "chkCLF_HeatNTC2";
            this.chkCLF_HeatNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_HeatNTC2.TabIndex = 3;
            this.chkCLF_HeatNTC2.Text = "HeatNTC2";
            this.chkCLF_HeatNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_HeatNTC2.UseVisualStyleBackColor = true;
            // 
            // chkCLF_HeatNTC1
            // 
            this.chkCLF_HeatNTC1.AutoSize = true;
            this.chkCLF_HeatNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_HeatNTC1.Location = new System.Drawing.Point(3, 3);
            this.chkCLF_HeatNTC1.Name = "chkCLF_HeatNTC1";
            this.chkCLF_HeatNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_HeatNTC1.TabIndex = 0;
            this.chkCLF_HeatNTC1.Text = "HeatNTC1";
            this.chkCLF_HeatNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_HeatNTC1.UseVisualStyleBackColor = true;
            // 
            // CLF_HeatNTC1_TextBox
            // 
            this.CLF_HeatNTC1_TextBox.Enabled = false;
            this.CLF_HeatNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_HeatNTC1_TextBox.Location = new System.Drawing.Point(112, 3);
            this.CLF_HeatNTC1_TextBox.Name = "CLF_HeatNTC1_TextBox";
            this.CLF_HeatNTC1_TextBox.ReadOnly = true;
            this.CLF_HeatNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_HeatNTC1_TextBox.TabIndex = 2;
            // 
            // chkCLF_IGBTNTC1
            // 
            this.chkCLF_IGBTNTC1.AutoSize = true;
            this.chkCLF_IGBTNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_IGBTNTC1.Location = new System.Drawing.Point(3, 61);
            this.chkCLF_IGBTNTC1.Name = "chkCLF_IGBTNTC1";
            this.chkCLF_IGBTNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_IGBTNTC1.TabIndex = 6;
            this.chkCLF_IGBTNTC1.Text = "IGBTNTC1";
            this.chkCLF_IGBTNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_IGBTNTC1.UseVisualStyleBackColor = true;
            // 
            // CLF_IGBTNTC1_TextBox
            // 
            this.CLF_IGBTNTC1_TextBox.Enabled = false;
            this.CLF_IGBTNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_IGBTNTC1_TextBox.Location = new System.Drawing.Point(112, 61);
            this.CLF_IGBTNTC1_TextBox.Name = "CLF_IGBTNTC1_TextBox";
            this.CLF_IGBTNTC1_TextBox.ReadOnly = true;
            this.CLF_IGBTNTC1_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_IGBTNTC1_TextBox.TabIndex = 8;
            // 
            // chkCLF_IGBTNTC2
            // 
            this.chkCLF_IGBTNTC2.AutoSize = true;
            this.chkCLF_IGBTNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_IGBTNTC2.Location = new System.Drawing.Point(3, 90);
            this.chkCLF_IGBTNTC2.Name = "chkCLF_IGBTNTC2";
            this.chkCLF_IGBTNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_IGBTNTC2.TabIndex = 9;
            this.chkCLF_IGBTNTC2.Text = "IGBTNTC2";
            this.chkCLF_IGBTNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_IGBTNTC2.UseVisualStyleBackColor = true;
            // 
            // CLF_ErrorCode
            // 
            this.CLF_ErrorCode.Enabled = false;
            this.CLF_ErrorCode.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_ErrorCode.Location = new System.Drawing.Point(112, 264);
            this.CLF_ErrorCode.Name = "CLF_ErrorCode";
            this.CLF_ErrorCode.ReadOnly = true;
            this.CLF_ErrorCode.Size = new System.Drawing.Size(62, 20);
            this.CLF_ErrorCode.TabIndex = 28;
            // 
            // CLF_IGBTNTC2_TextBox
            // 
            this.CLF_IGBTNTC2_TextBox.Enabled = false;
            this.CLF_IGBTNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_IGBTNTC2_TextBox.Location = new System.Drawing.Point(112, 90);
            this.CLF_IGBTNTC2_TextBox.Name = "CLF_IGBTNTC2_TextBox";
            this.CLF_IGBTNTC2_TextBox.ReadOnly = true;
            this.CLF_IGBTNTC2_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_IGBTNTC2_TextBox.TabIndex = 11;
            // 
            // chkCLF_PanTemp
            // 
            this.chkCLF_PanTemp.AutoSize = true;
            this.chkCLF_PanTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_PanTemp.Location = new System.Drawing.Point(3, 119);
            this.chkCLF_PanTemp.Name = "chkCLF_PanTemp";
            this.chkCLF_PanTemp.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_PanTemp.TabIndex = 12;
            this.chkCLF_PanTemp.Text = "受热品质";
            this.chkCLF_PanTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_PanTemp.UseVisualStyleBackColor = true;
            // 
            // CLF_PanTemp_TextBox
            // 
            this.CLF_PanTemp_TextBox.Enabled = false;
            this.CLF_PanTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_PanTemp_TextBox.Location = new System.Drawing.Point(112, 119);
            this.CLF_PanTemp_TextBox.Name = "CLF_PanTemp_TextBox";
            this.CLF_PanTemp_TextBox.ReadOnly = true;
            this.CLF_PanTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_PanTemp_TextBox.TabIndex = 14;
            // 
            // chkCLF_Freq
            // 
            this.chkCLF_Freq.AutoSize = true;
            this.chkCLF_Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Freq.Location = new System.Drawing.Point(3, 148);
            this.chkCLF_Freq.Name = "chkCLF_Freq";
            this.chkCLF_Freq.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_Freq.TabIndex = 15;
            this.chkCLF_Freq.Text = "加热频率";
            this.chkCLF_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Freq.UseVisualStyleBackColor = true;
            // 
            // CLF_Freq_TextBox
            // 
            this.CLF_Freq_TextBox.Enabled = false;
            this.CLF_Freq_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Freq_TextBox.Location = new System.Drawing.Point(112, 148);
            this.CLF_Freq_TextBox.Name = "CLF_Freq_TextBox";
            this.CLF_Freq_TextBox.ReadOnly = true;
            this.CLF_Freq_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_Freq_TextBox.TabIndex = 17;
            // 
            // chkCLF_ErrorCode
            // 
            this.chkCLF_ErrorCode.AutoSize = true;
            this.chkCLF_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_ErrorCode.Location = new System.Drawing.Point(3, 264);
            this.chkCLF_ErrorCode.Name = "chkCLF_ErrorCode";
            this.chkCLF_ErrorCode.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_ErrorCode.TabIndex = 26;
            this.chkCLF_ErrorCode.Text = "错误码";
            this.chkCLF_ErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_ErrorCode.UseVisualStyleBackColor = true;
            // 
            // chkCLF_Voltage
            // 
            this.chkCLF_Voltage.AutoSize = true;
            this.chkCLF_Voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Voltage.Location = new System.Drawing.Point(3, 177);
            this.chkCLF_Voltage.Name = "chkCLF_Voltage";
            this.chkCLF_Voltage.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_Voltage.TabIndex = 18;
            this.chkCLF_Voltage.Text = "电压";
            this.chkCLF_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Voltage.UseVisualStyleBackColor = true;
            // 
            // CLF_MCUTemp_TextBox
            // 
            this.CLF_MCUTemp_TextBox.Enabled = false;
            this.CLF_MCUTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_MCUTemp_TextBox.Location = new System.Drawing.Point(112, 235);
            this.CLF_MCUTemp_TextBox.Name = "CLF_MCUTemp_TextBox";
            this.CLF_MCUTemp_TextBox.ReadOnly = true;
            this.CLF_MCUTemp_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_MCUTemp_TextBox.TabIndex = 25;
            // 
            // CLF_Voltage_TextBox
            // 
            this.CLF_Voltage_TextBox.Enabled = false;
            this.CLF_Voltage_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Voltage_TextBox.Location = new System.Drawing.Point(112, 177);
            this.CLF_Voltage_TextBox.Name = "CLF_Voltage_TextBox";
            this.CLF_Voltage_TextBox.ReadOnly = true;
            this.CLF_Voltage_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_Voltage_TextBox.TabIndex = 20;
            // 
            // chkCLF_Power
            // 
            this.chkCLF_Power.AutoSize = true;
            this.chkCLF_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_Power.Location = new System.Drawing.Point(3, 206);
            this.chkCLF_Power.Name = "chkCLF_Power";
            this.chkCLF_Power.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_Power.TabIndex = 21;
            this.chkCLF_Power.Text = "功率";
            this.chkCLF_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_Power.UseVisualStyleBackColor = true;
            // 
            // chkCLF_MCUTemp
            // 
            this.chkCLF_MCUTemp.AutoSize = true;
            this.chkCLF_MCUTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLF_MCUTemp.Location = new System.Drawing.Point(3, 235);
            this.chkCLF_MCUTemp.Name = "chkCLF_MCUTemp";
            this.chkCLF_MCUTemp.Size = new System.Drawing.Size(103, 23);
            this.chkCLF_MCUTemp.TabIndex = 23;
            this.chkCLF_MCUTemp.Text = "芯片温度";
            this.chkCLF_MCUTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLF_MCUTemp.UseVisualStyleBackColor = true;
            // 
            // CLF_Power_TextBox
            // 
            this.CLF_Power_TextBox.Enabled = false;
            this.CLF_Power_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLF_Power_TextBox.Location = new System.Drawing.Point(112, 206);
            this.CLF_Power_TextBox.Name = "CLF_Power_TextBox";
            this.CLF_Power_TextBox.ReadOnly = true;
            this.CLF_Power_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLF_Power_TextBox.TabIndex = 22;
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.Controls.Add(this.groupBox8);
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.Controls.Add(this.groupBox9);
            this.splitContainer8.Size = new System.Drawing.Size(503, 598);
            this.splitContainer8.SplitterDistance = 265;
            this.splitContainer8.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.tableLayoutPanel11);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(265, 598);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "CLR 显示板";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel11.Controls.Add(this.CLR_ReserveD8_TextBox, 1, 18);
            this.tableLayoutPanel11.Controls.Add(this.CLR_ReserveD7_TextBox, 1, 17);
            this.tableLayoutPanel11.Controls.Add(this.CLR_Disp_ReserveD1B7_TextBox, 1, 16);
            this.tableLayoutPanel11.Controls.Add(this.CLR_Disp_ReserveD1B6_TextBox, 1, 15);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_ReserveD8, 0, 18);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_ReserveD7, 0, 17);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_Disp_ReserveD1B7, 0, 16);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_Disp_ReserveD1B6, 0, 15);
            this.tableLayoutPanel11.Controls.Add(this.CLR_RequestPower_TextBox, 1, 14);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_HeatingFreqFollow, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_PanControlActive, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.CLR_HeatingFreqFollow_TextBox, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_RequestPower, 0, 14);
            this.tableLayoutPanel11.Controls.Add(this.CLR_PanControlActive_TextBox, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.CLR_DebugChannel_TextBox, 1, 13);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_InnerOuterRing, 0, 2);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_DebugChannel, 0, 13);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_PauseFlag, 0, 6);
            this.tableLayoutPanel11.Controls.Add(this.CLR_DebugSubChannel_TextBox, 1, 12);
            this.tableLayoutPanel11.Controls.Add(this.CLR_PauseFlag_TextBox, 1, 6);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_allZone_BridgeHeatFlag, 0, 3);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_DebugSubChannel, 0, 12);
            this.tableLayoutPanel11.Controls.Add(this.CLR_allZone_BridgeHeatFlag_TextBox, 1, 3);
            this.tableLayoutPanel11.Controls.Add(this.CLR_BridgeControl_TextBox, 1, 11);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_PPGMode, 0, 4);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_StoveSwitch, 0, 7);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_BridgeControl, 0, 11);
            this.tableLayoutPanel11.Controls.Add(this.CLR_PPGMode_TextBox, 1, 4);
            this.tableLayoutPanel11.Controls.Add(this.CLR_FanLevel_TextBox, 1, 10);
            this.tableLayoutPanel11.Controls.Add(this.CLR_StoveSwitch_TextBox, 1, 7);
            this.tableLayoutPanel11.Controls.Add(this.CLR_AllowPanDetection_TextBox, 1, 5);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_FanLevel, 0, 10);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_AllowPanDetection, 0, 5);
            this.tableLayoutPanel11.Controls.Add(this.CLR_NoiseControl_TextBox, 1, 9);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_HeatFreqJitterFlag, 0, 8);
            this.tableLayoutPanel11.Controls.Add(this.CLR_HeatFreqJitterFlag_TextBox, 1, 8);
            this.tableLayoutPanel11.Controls.Add(this.chkCLR_NoiseControl, 0, 9);
            this.tableLayoutPanel11.Controls.Add(this.CLR_InnerOuterRing_TextBox, 1, 2);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 20;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(259, 578);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // CLR_ReserveD8_TextBox
            // 
            this.CLR_ReserveD8_TextBox.Enabled = false;
            this.CLR_ReserveD8_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_ReserveD8_TextBox.Location = new System.Drawing.Point(189, 525);
            this.CLR_ReserveD8_TextBox.Name = "CLR_ReserveD8_TextBox";
            this.CLR_ReserveD8_TextBox.ReadOnly = true;
            this.CLR_ReserveD8_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_ReserveD8_TextBox.TabIndex = 92;
            // 
            // CLR_ReserveD7_TextBox
            // 
            this.CLR_ReserveD7_TextBox.Enabled = false;
            this.CLR_ReserveD7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_ReserveD7_TextBox.Location = new System.Drawing.Point(189, 496);
            this.CLR_ReserveD7_TextBox.Name = "CLR_ReserveD7_TextBox";
            this.CLR_ReserveD7_TextBox.ReadOnly = true;
            this.CLR_ReserveD7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_ReserveD7_TextBox.TabIndex = 91;
            // 
            // CLR_Disp_ReserveD1B7_TextBox
            // 
            this.CLR_Disp_ReserveD1B7_TextBox.Enabled = false;
            this.CLR_Disp_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Disp_ReserveD1B7_TextBox.Location = new System.Drawing.Point(189, 467);
            this.CLR_Disp_ReserveD1B7_TextBox.Name = "CLR_Disp_ReserveD1B7_TextBox";
            this.CLR_Disp_ReserveD1B7_TextBox.ReadOnly = true;
            this.CLR_Disp_ReserveD1B7_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_Disp_ReserveD1B7_TextBox.TabIndex = 90;
            // 
            // CLR_Disp_ReserveD1B6_TextBox
            // 
            this.CLR_Disp_ReserveD1B6_TextBox.Enabled = false;
            this.CLR_Disp_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Disp_ReserveD1B6_TextBox.Location = new System.Drawing.Point(189, 438);
            this.CLR_Disp_ReserveD1B6_TextBox.Name = "CLR_Disp_ReserveD1B6_TextBox";
            this.CLR_Disp_ReserveD1B6_TextBox.ReadOnly = true;
            this.CLR_Disp_ReserveD1B6_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_Disp_ReserveD1B6_TextBox.TabIndex = 89;
            // 
            // chkCLR_ReserveD8
            // 
            this.chkCLR_ReserveD8.AutoSize = true;
            this.chkCLR_ReserveD8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_ReserveD8.Location = new System.Drawing.Point(3, 525);
            this.chkCLR_ReserveD8.Name = "chkCLR_ReserveD8";
            this.chkCLR_ReserveD8.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_ReserveD8.TabIndex = 87;
            this.chkCLR_ReserveD8.Text = "ReserveD8";
            this.chkCLR_ReserveD8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_ReserveD8.UseVisualStyleBackColor = true;
            // 
            // chkCLR_ReserveD7
            // 
            this.chkCLR_ReserveD7.AutoSize = true;
            this.chkCLR_ReserveD7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_ReserveD7.Location = new System.Drawing.Point(3, 496);
            this.chkCLR_ReserveD7.Name = "chkCLR_ReserveD7";
            this.chkCLR_ReserveD7.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_ReserveD7.TabIndex = 87;
            this.chkCLR_ReserveD7.Text = "ReserveD7";
            this.chkCLR_ReserveD7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_ReserveD7.UseVisualStyleBackColor = true;
            // 
            // chkCLR_Disp_ReserveD1B7
            // 
            this.chkCLR_Disp_ReserveD1B7.AutoSize = true;
            this.chkCLR_Disp_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Disp_ReserveD1B7.Location = new System.Drawing.Point(3, 467);
            this.chkCLR_Disp_ReserveD1B7.Name = "chkCLR_Disp_ReserveD1B7";
            this.chkCLR_Disp_ReserveD1B7.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_Disp_ReserveD1B7.TabIndex = 87;
            this.chkCLR_Disp_ReserveD1B7.Text = "ReserveD1B7";
            this.chkCLR_Disp_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Disp_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkCLR_Disp_ReserveD1B6
            // 
            this.chkCLR_Disp_ReserveD1B6.AutoSize = true;
            this.chkCLR_Disp_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Disp_ReserveD1B6.Location = new System.Drawing.Point(3, 438);
            this.chkCLR_Disp_ReserveD1B6.Name = "chkCLR_Disp_ReserveD1B6";
            this.chkCLR_Disp_ReserveD1B6.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_Disp_ReserveD1B6.TabIndex = 89;
            this.chkCLR_Disp_ReserveD1B6.Text = "ReserveD1B6";
            this.chkCLR_Disp_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Disp_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // CLR_RequestPower_TextBox
            // 
            this.CLR_RequestPower_TextBox.Enabled = false;
            this.CLR_RequestPower_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_RequestPower_TextBox.Location = new System.Drawing.Point(189, 409);
            this.CLR_RequestPower_TextBox.Name = "CLR_RequestPower_TextBox";
            this.CLR_RequestPower_TextBox.ReadOnly = true;
            this.CLR_RequestPower_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_RequestPower_TextBox.TabIndex = 83;
            // 
            // chkCLR_HeatingFreqFollow
            // 
            this.chkCLR_HeatingFreqFollow.AutoSize = true;
            this.chkCLR_HeatingFreqFollow.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.chkCLR_HeatingFreqFollow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_HeatingFreqFollow.Location = new System.Drawing.Point(3, 3);
            this.chkCLR_HeatingFreqFollow.Name = "chkCLR_HeatingFreqFollow";
            this.chkCLR_HeatingFreqFollow.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_HeatingFreqFollow.TabIndex = 39;
            this.chkCLR_HeatingFreqFollow.Text = "加热频率跟随标志";
            this.chkCLR_HeatingFreqFollow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_HeatingFreqFollow.UseVisualStyleBackColor = true;
            // 
            // chkCLR_PanControlActive
            // 
            this.chkCLR_PanControlActive.AutoSize = true;
            this.chkCLR_PanControlActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_PanControlActive.Location = new System.Drawing.Point(3, 32);
            this.chkCLR_PanControlActive.Name = "chkCLR_PanControlActive";
            this.chkCLR_PanControlActive.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_PanControlActive.TabIndex = 42;
            this.chkCLR_PanControlActive.Text = "移锅控功激活标志";
            this.chkCLR_PanControlActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_PanControlActive.UseVisualStyleBackColor = true;
            // 
            // CLR_HeatingFreqFollow_TextBox
            // 
            this.CLR_HeatingFreqFollow_TextBox.Enabled = false;
            this.CLR_HeatingFreqFollow_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_HeatingFreqFollow_TextBox.Location = new System.Drawing.Point(189, 3);
            this.CLR_HeatingFreqFollow_TextBox.Name = "CLR_HeatingFreqFollow_TextBox";
            this.CLR_HeatingFreqFollow_TextBox.ReadOnly = true;
            this.CLR_HeatingFreqFollow_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_HeatingFreqFollow_TextBox.TabIndex = 41;
            // 
            // chkCLR_RequestPower
            // 
            this.chkCLR_RequestPower.AutoSize = true;
            this.chkCLR_RequestPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_RequestPower.Location = new System.Drawing.Point(3, 409);
            this.chkCLR_RequestPower.Name = "chkCLR_RequestPower";
            this.chkCLR_RequestPower.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_RequestPower.TabIndex = 81;
            this.chkCLR_RequestPower.Text = "请求功率值";
            this.chkCLR_RequestPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_RequestPower.UseVisualStyleBackColor = true;
            // 
            // CLR_PanControlActive_TextBox
            // 
            this.CLR_PanControlActive_TextBox.Enabled = false;
            this.CLR_PanControlActive_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_PanControlActive_TextBox.Location = new System.Drawing.Point(189, 32);
            this.CLR_PanControlActive_TextBox.Name = "CLR_PanControlActive_TextBox";
            this.CLR_PanControlActive_TextBox.ReadOnly = true;
            this.CLR_PanControlActive_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_PanControlActive_TextBox.TabIndex = 44;
            // 
            // CLR_DebugChannel_TextBox
            // 
            this.CLR_DebugChannel_TextBox.Enabled = false;
            this.CLR_DebugChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_DebugChannel_TextBox.Location = new System.Drawing.Point(189, 380);
            this.CLR_DebugChannel_TextBox.Name = "CLR_DebugChannel_TextBox";
            this.CLR_DebugChannel_TextBox.ReadOnly = true;
            this.CLR_DebugChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_DebugChannel_TextBox.TabIndex = 80;
            // 
            // chkCLR_InnerOuterRing
            // 
            this.chkCLR_InnerOuterRing.AutoSize = true;
            this.chkCLR_InnerOuterRing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_InnerOuterRing.Location = new System.Drawing.Point(3, 61);
            this.chkCLR_InnerOuterRing.Name = "chkCLR_InnerOuterRing";
            this.chkCLR_InnerOuterRing.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_InnerOuterRing.TabIndex = 45;
            this.chkCLR_InnerOuterRing.Text = "内外环标志";
            this.chkCLR_InnerOuterRing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_InnerOuterRing.UseVisualStyleBackColor = true;
            // 
            // chkCLR_DebugChannel
            // 
            this.chkCLR_DebugChannel.AutoSize = true;
            this.chkCLR_DebugChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_DebugChannel.Location = new System.Drawing.Point(3, 380);
            this.chkCLR_DebugChannel.Name = "chkCLR_DebugChannel";
            this.chkCLR_DebugChannel.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_DebugChannel.TabIndex = 78;
            this.chkCLR_DebugChannel.Text = "Debug通道号";
            this.chkCLR_DebugChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_DebugChannel.UseVisualStyleBackColor = true;
            // 
            // chkCLR_PauseFlag
            // 
            this.chkCLR_PauseFlag.AutoSize = true;
            this.chkCLR_PauseFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_PauseFlag.Location = new System.Drawing.Point(3, 177);
            this.chkCLR_PauseFlag.Name = "chkCLR_PauseFlag";
            this.chkCLR_PauseFlag.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_PauseFlag.TabIndex = 57;
            this.chkCLR_PauseFlag.Text = "暂停标志";
            this.chkCLR_PauseFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_PauseFlag.UseVisualStyleBackColor = true;
            // 
            // CLR_DebugSubChannel_TextBox
            // 
            this.CLR_DebugSubChannel_TextBox.Enabled = false;
            this.CLR_DebugSubChannel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_DebugSubChannel_TextBox.Location = new System.Drawing.Point(189, 351);
            this.CLR_DebugSubChannel_TextBox.Name = "CLR_DebugSubChannel_TextBox";
            this.CLR_DebugSubChannel_TextBox.ReadOnly = true;
            this.CLR_DebugSubChannel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_DebugSubChannel_TextBox.TabIndex = 76;
            // 
            // CLR_PauseFlag_TextBox
            // 
            this.CLR_PauseFlag_TextBox.Enabled = false;
            this.CLR_PauseFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_PauseFlag_TextBox.Location = new System.Drawing.Point(189, 177);
            this.CLR_PauseFlag_TextBox.Name = "CLR_PauseFlag_TextBox";
            this.CLR_PauseFlag_TextBox.ReadOnly = true;
            this.CLR_PauseFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_PauseFlag_TextBox.TabIndex = 59;
            // 
            // chkCLR_allZone_BridgeHeatFlag
            // 
            this.chkCLR_allZone_BridgeHeatFlag.AutoSize = true;
            this.chkCLR_allZone_BridgeHeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_allZone_BridgeHeatFlag.Location = new System.Drawing.Point(3, 90);
            this.chkCLR_allZone_BridgeHeatFlag.Name = "chkCLR_allZone_BridgeHeatFlag";
            this.chkCLR_allZone_BridgeHeatFlag.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_allZone_BridgeHeatFlag.TabIndex = 48;
            this.chkCLR_allZone_BridgeHeatFlag.Text = "无区/桥接标志/三环（红外）";
            this.chkCLR_allZone_BridgeHeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_allZone_BridgeHeatFlag.UseVisualStyleBackColor = true;
            // 
            // chkCLR_DebugSubChannel
            // 
            this.chkCLR_DebugSubChannel.AutoSize = true;
            this.chkCLR_DebugSubChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_DebugSubChannel.Location = new System.Drawing.Point(3, 351);
            this.chkCLR_DebugSubChannel.Name = "chkCLR_DebugSubChannel";
            this.chkCLR_DebugSubChannel.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_DebugSubChannel.TabIndex = 74;
            this.chkCLR_DebugSubChannel.Text = "Debug子通道号";
            this.chkCLR_DebugSubChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_DebugSubChannel.UseVisualStyleBackColor = true;
            // 
            // CLR_allZone_BridgeHeatFlag_TextBox
            // 
            this.CLR_allZone_BridgeHeatFlag_TextBox.Enabled = false;
            this.CLR_allZone_BridgeHeatFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_allZone_BridgeHeatFlag_TextBox.Location = new System.Drawing.Point(189, 90);
            this.CLR_allZone_BridgeHeatFlag_TextBox.Name = "CLR_allZone_BridgeHeatFlag_TextBox";
            this.CLR_allZone_BridgeHeatFlag_TextBox.ReadOnly = true;
            this.CLR_allZone_BridgeHeatFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_allZone_BridgeHeatFlag_TextBox.TabIndex = 50;
            // 
            // CLR_BridgeControl_TextBox
            // 
            this.CLR_BridgeControl_TextBox.Enabled = false;
            this.CLR_BridgeControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_BridgeControl_TextBox.Location = new System.Drawing.Point(189, 322);
            this.CLR_BridgeControl_TextBox.Name = "CLR_BridgeControl_TextBox";
            this.CLR_BridgeControl_TextBox.ReadOnly = true;
            this.CLR_BridgeControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_BridgeControl_TextBox.TabIndex = 73;
            // 
            // chkCLR_PPGMode
            // 
            this.chkCLR_PPGMode.AutoSize = true;
            this.chkCLR_PPGMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_PPGMode.Location = new System.Drawing.Point(3, 119);
            this.chkCLR_PPGMode.Name = "chkCLR_PPGMode";
            this.chkCLR_PPGMode.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_PPGMode.TabIndex = 51;
            this.chkCLR_PPGMode.Text = "PPG模式标志";
            this.chkCLR_PPGMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_PPGMode.UseVisualStyleBackColor = true;
            // 
            // chkCLR_StoveSwitch
            // 
            this.chkCLR_StoveSwitch.AutoSize = true;
            this.chkCLR_StoveSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_StoveSwitch.Location = new System.Drawing.Point(3, 206);
            this.chkCLR_StoveSwitch.Name = "chkCLR_StoveSwitch";
            this.chkCLR_StoveSwitch.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_StoveSwitch.TabIndex = 60;
            this.chkCLR_StoveSwitch.Text = "炉头开关标志";
            this.chkCLR_StoveSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_StoveSwitch.UseVisualStyleBackColor = true;
            // 
            // chkCLR_BridgeControl
            // 
            this.chkCLR_BridgeControl.AutoSize = true;
            this.chkCLR_BridgeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_BridgeControl.Location = new System.Drawing.Point(3, 322);
            this.chkCLR_BridgeControl.Name = "chkCLR_BridgeControl";
            this.chkCLR_BridgeControl.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_BridgeControl.TabIndex = 71;
            this.chkCLR_BridgeControl.Text = "无区/桥接控制指令";
            this.chkCLR_BridgeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_BridgeControl.UseVisualStyleBackColor = true;
            // 
            // CLR_PPGMode_TextBox
            // 
            this.CLR_PPGMode_TextBox.Enabled = false;
            this.CLR_PPGMode_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_PPGMode_TextBox.Location = new System.Drawing.Point(189, 119);
            this.CLR_PPGMode_TextBox.Name = "CLR_PPGMode_TextBox";
            this.CLR_PPGMode_TextBox.ReadOnly = true;
            this.CLR_PPGMode_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_PPGMode_TextBox.TabIndex = 53;
            // 
            // CLR_FanLevel_TextBox
            // 
            this.CLR_FanLevel_TextBox.Enabled = false;
            this.CLR_FanLevel_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_FanLevel_TextBox.Location = new System.Drawing.Point(189, 293);
            this.CLR_FanLevel_TextBox.Name = "CLR_FanLevel_TextBox";
            this.CLR_FanLevel_TextBox.ReadOnly = true;
            this.CLR_FanLevel_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_FanLevel_TextBox.TabIndex = 70;
            // 
            // CLR_StoveSwitch_TextBox
            // 
            this.CLR_StoveSwitch_TextBox.Enabled = false;
            this.CLR_StoveSwitch_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_StoveSwitch_TextBox.Location = new System.Drawing.Point(189, 206);
            this.CLR_StoveSwitch_TextBox.Name = "CLR_StoveSwitch_TextBox";
            this.CLR_StoveSwitch_TextBox.ReadOnly = true;
            this.CLR_StoveSwitch_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_StoveSwitch_TextBox.TabIndex = 61;
            // 
            // CLR_AllowPanDetection_TextBox
            // 
            this.CLR_AllowPanDetection_TextBox.Enabled = false;
            this.CLR_AllowPanDetection_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_AllowPanDetection_TextBox.Location = new System.Drawing.Point(189, 148);
            this.CLR_AllowPanDetection_TextBox.Name = "CLR_AllowPanDetection_TextBox";
            this.CLR_AllowPanDetection_TextBox.ReadOnly = true;
            this.CLR_AllowPanDetection_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_AllowPanDetection_TextBox.TabIndex = 56;
            // 
            // chkCLR_FanLevel
            // 
            this.chkCLR_FanLevel.AutoSize = true;
            this.chkCLR_FanLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_FanLevel.Location = new System.Drawing.Point(3, 293);
            this.chkCLR_FanLevel.Name = "chkCLR_FanLevel";
            this.chkCLR_FanLevel.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_FanLevel.TabIndex = 68;
            this.chkCLR_FanLevel.Text = "风机档位";
            this.chkCLR_FanLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_FanLevel.UseVisualStyleBackColor = true;
            // 
            // chkCLR_AllowPanDetection
            // 
            this.chkCLR_AllowPanDetection.AutoSize = true;
            this.chkCLR_AllowPanDetection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_AllowPanDetection.Location = new System.Drawing.Point(3, 148);
            this.chkCLR_AllowPanDetection.Name = "chkCLR_AllowPanDetection";
            this.chkCLR_AllowPanDetection.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_AllowPanDetection.TabIndex = 54;
            this.chkCLR_AllowPanDetection.Text = "允许检锅标志";
            this.chkCLR_AllowPanDetection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_AllowPanDetection.UseVisualStyleBackColor = true;
            // 
            // CLR_NoiseControl_TextBox
            // 
            this.CLR_NoiseControl_TextBox.Enabled = false;
            this.CLR_NoiseControl_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_NoiseControl_TextBox.Location = new System.Drawing.Point(189, 264);
            this.CLR_NoiseControl_TextBox.Name = "CLR_NoiseControl_TextBox";
            this.CLR_NoiseControl_TextBox.ReadOnly = true;
            this.CLR_NoiseControl_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_NoiseControl_TextBox.TabIndex = 67;
            // 
            // chkCLR_HeatFreqJitterFlag
            // 
            this.chkCLR_HeatFreqJitterFlag.AutoSize = true;
            this.chkCLR_HeatFreqJitterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_HeatFreqJitterFlag.Location = new System.Drawing.Point(3, 235);
            this.chkCLR_HeatFreqJitterFlag.Name = "chkCLR_HeatFreqJitterFlag";
            this.chkCLR_HeatFreqJitterFlag.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_HeatFreqJitterFlag.TabIndex = 62;
            this.chkCLR_HeatFreqJitterFlag.Text = "加热频率抖频率模式";
            this.chkCLR_HeatFreqJitterFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_HeatFreqJitterFlag.UseVisualStyleBackColor = true;
            // 
            // CLR_HeatFreqJitterFlag_TextBox
            // 
            this.CLR_HeatFreqJitterFlag_TextBox.Enabled = false;
            this.CLR_HeatFreqJitterFlag_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_HeatFreqJitterFlag_TextBox.Location = new System.Drawing.Point(189, 235);
            this.CLR_HeatFreqJitterFlag_TextBox.Name = "CLR_HeatFreqJitterFlag_TextBox";
            this.CLR_HeatFreqJitterFlag_TextBox.ReadOnly = true;
            this.CLR_HeatFreqJitterFlag_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_HeatFreqJitterFlag_TextBox.TabIndex = 64;
            // 
            // chkCLR_NoiseControl
            // 
            this.chkCLR_NoiseControl.AutoSize = true;
            this.chkCLR_NoiseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_NoiseControl.Location = new System.Drawing.Point(3, 264);
            this.chkCLR_NoiseControl.Name = "chkCLR_NoiseControl";
            this.chkCLR_NoiseControl.Size = new System.Drawing.Size(180, 23);
            this.chkCLR_NoiseControl.TabIndex = 65;
            this.chkCLR_NoiseControl.Text = "噪声处理指令";
            this.chkCLR_NoiseControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_NoiseControl.UseVisualStyleBackColor = true;
            // 
            // CLR_InnerOuterRing_TextBox
            // 
            this.CLR_InnerOuterRing_TextBox.Enabled = false;
            this.CLR_InnerOuterRing_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_InnerOuterRing_TextBox.Location = new System.Drawing.Point(189, 61);
            this.CLR_InnerOuterRing_TextBox.Name = "CLR_InnerOuterRing_TextBox";
            this.CLR_InnerOuterRing_TextBox.ReadOnly = true;
            this.CLR_InnerOuterRing_TextBox.Size = new System.Drawing.Size(62, 20);
            this.CLR_InnerOuterRing_TextBox.TabIndex = 48;
            // 
            // groupBox9
            // 
            this.groupBox9.AutoSize = true;
            this.groupBox9.Controls.Add(this.tableLayoutPanel12);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(234, 598);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "CLR 功率板";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoScroll = true;
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel12.Controls.Add(this.CLR_ReserveD16_TextBox, 1, 17);
            this.tableLayoutPanel12.Controls.Add(this.CLR_ReserveD15_TextBox, 1, 16);
            this.tableLayoutPanel12.Controls.Add(this.CLR_ReserveD14_TextBox, 1, 15);
            this.tableLayoutPanel12.Controls.Add(this.CLR_Power_ReserveD1B7_TextBox, 1, 14);
            this.tableLayoutPanel12.Controls.Add(this.CLR_Power_ReserveD1B6_TextBox, 1, 13);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_ReserveD16, 0, 17);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_ReserveD15, 0, 16);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_ReserveD14, 0, 15);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_Power_ReserveD1B7, 0, 14);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_Power_ReserveD1B6, 0, 13);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_PollingState, 0, 10);
            this.tableLayoutPanel12.Controls.Add(this.CLR_PollingState, 1, 10);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_FreqControlFlag, 0, 11);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_HeatFlag, 0, 12);
            this.tableLayoutPanel12.Controls.Add(this.CLR_FreqControlFlag, 1, 11);
            this.tableLayoutPanel12.Controls.Add(this.CLR_HeatFlag, 1, 12);
            this.tableLayoutPanel12.Controls.Add(this.CLR_HeatNTC2_TextBox, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_HeatNTC2, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_HeatNTC1, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.CLR_HeatNTC1_TextBox, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_IGBTNTC1, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.CLR_IGBTNTC1_TextBox, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_IGBTNTC2, 0, 3);
            this.tableLayoutPanel12.Controls.Add(this.CLR_ErrorCode, 1, 9);
            this.tableLayoutPanel12.Controls.Add(this.CLR_IGBTNTC2_TextBox, 1, 3);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_PanTemp, 0, 4);
            this.tableLayoutPanel12.Controls.Add(this.CLR_PanTemp_TextBox, 1, 4);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_Freq, 0, 5);
            this.tableLayoutPanel12.Controls.Add(this.CLR_Freq_TextBox, 1, 5);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_ErrorCode, 0, 9);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_Voltage, 0, 6);
            this.tableLayoutPanel12.Controls.Add(this.CLR_MCUTemp_TextBox, 1, 8);
            this.tableLayoutPanel12.Controls.Add(this.CLR_Voltage_TextBox, 1, 6);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_Power, 0, 7);
            this.tableLayoutPanel12.Controls.Add(this.chkCLR_MCUTemp, 0, 8);
            this.tableLayoutPanel12.Controls.Add(this.CLR_Power_TextBox, 1, 7);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 19;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(228, 578);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // CLR_ReserveD16_TextBox
            // 
            this.CLR_ReserveD16_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_ReserveD16_TextBox.Enabled = false;
            this.CLR_ReserveD16_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_ReserveD16_TextBox.Location = new System.Drawing.Point(112, 496);
            this.CLR_ReserveD16_TextBox.Name = "CLR_ReserveD16_TextBox";
            this.CLR_ReserveD16_TextBox.ReadOnly = true;
            this.CLR_ReserveD16_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_ReserveD16_TextBox.TabIndex = 100;
            // 
            // CLR_ReserveD15_TextBox
            // 
            this.CLR_ReserveD15_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_ReserveD15_TextBox.Enabled = false;
            this.CLR_ReserveD15_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_ReserveD15_TextBox.Location = new System.Drawing.Point(112, 467);
            this.CLR_ReserveD15_TextBox.Name = "CLR_ReserveD15_TextBox";
            this.CLR_ReserveD15_TextBox.ReadOnly = true;
            this.CLR_ReserveD15_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_ReserveD15_TextBox.TabIndex = 99;
            // 
            // CLR_ReserveD14_TextBox
            // 
            this.CLR_ReserveD14_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_ReserveD14_TextBox.Enabled = false;
            this.CLR_ReserveD14_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_ReserveD14_TextBox.Location = new System.Drawing.Point(112, 438);
            this.CLR_ReserveD14_TextBox.Name = "CLR_ReserveD14_TextBox";
            this.CLR_ReserveD14_TextBox.ReadOnly = true;
            this.CLR_ReserveD14_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_ReserveD14_TextBox.TabIndex = 98;
            // 
            // CLR_Power_ReserveD1B7_TextBox
            // 
            this.CLR_Power_ReserveD1B7_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_Power_ReserveD1B7_TextBox.Enabled = false;
            this.CLR_Power_ReserveD1B7_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Power_ReserveD1B7_TextBox.Location = new System.Drawing.Point(112, 409);
            this.CLR_Power_ReserveD1B7_TextBox.Name = "CLR_Power_ReserveD1B7_TextBox";
            this.CLR_Power_ReserveD1B7_TextBox.ReadOnly = true;
            this.CLR_Power_ReserveD1B7_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_Power_ReserveD1B7_TextBox.TabIndex = 97;
            // 
            // CLR_Power_ReserveD1B6_TextBox
            // 
            this.CLR_Power_ReserveD1B6_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_Power_ReserveD1B6_TextBox.Enabled = false;
            this.CLR_Power_ReserveD1B6_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Power_ReserveD1B6_TextBox.Location = new System.Drawing.Point(112, 380);
            this.CLR_Power_ReserveD1B6_TextBox.Name = "CLR_Power_ReserveD1B6_TextBox";
            this.CLR_Power_ReserveD1B6_TextBox.ReadOnly = true;
            this.CLR_Power_ReserveD1B6_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_Power_ReserveD1B6_TextBox.TabIndex = 96;
            // 
            // chkCLR_ReserveD16
            // 
            this.chkCLR_ReserveD16.AutoSize = true;
            this.chkCLR_ReserveD16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_ReserveD16.Location = new System.Drawing.Point(3, 496);
            this.chkCLR_ReserveD16.Name = "chkCLR_ReserveD16";
            this.chkCLR_ReserveD16.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_ReserveD16.TabIndex = 95;
            this.chkCLR_ReserveD16.Text = "ReserveD16";
            this.chkCLR_ReserveD16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_ReserveD16.UseVisualStyleBackColor = true;
            // 
            // chkCLR_ReserveD15
            // 
            this.chkCLR_ReserveD15.AutoSize = true;
            this.chkCLR_ReserveD15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_ReserveD15.Location = new System.Drawing.Point(3, 467);
            this.chkCLR_ReserveD15.Name = "chkCLR_ReserveD15";
            this.chkCLR_ReserveD15.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_ReserveD15.TabIndex = 94;
            this.chkCLR_ReserveD15.Text = "ReserveD15";
            this.chkCLR_ReserveD15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_ReserveD15.UseVisualStyleBackColor = true;
            // 
            // chkCLR_ReserveD14
            // 
            this.chkCLR_ReserveD14.AutoSize = true;
            this.chkCLR_ReserveD14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_ReserveD14.Location = new System.Drawing.Point(3, 438);
            this.chkCLR_ReserveD14.Name = "chkCLR_ReserveD14";
            this.chkCLR_ReserveD14.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_ReserveD14.TabIndex = 93;
            this.chkCLR_ReserveD14.Text = "ReserveD14";
            this.chkCLR_ReserveD14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_ReserveD14.UseVisualStyleBackColor = true;
            // 
            // chkCLR_Power_ReserveD1B7
            // 
            this.chkCLR_Power_ReserveD1B7.AutoSize = true;
            this.chkCLR_Power_ReserveD1B7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Power_ReserveD1B7.Location = new System.Drawing.Point(3, 409);
            this.chkCLR_Power_ReserveD1B7.Name = "chkCLR_Power_ReserveD1B7";
            this.chkCLR_Power_ReserveD1B7.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_Power_ReserveD1B7.TabIndex = 92;
            this.chkCLR_Power_ReserveD1B7.Text = "ReserveD1B7";
            this.chkCLR_Power_ReserveD1B7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Power_ReserveD1B7.UseVisualStyleBackColor = true;
            // 
            // chkCLR_Power_ReserveD1B6
            // 
            this.chkCLR_Power_ReserveD1B6.AutoSize = true;
            this.chkCLR_Power_ReserveD1B6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Power_ReserveD1B6.Location = new System.Drawing.Point(3, 380);
            this.chkCLR_Power_ReserveD1B6.Name = "chkCLR_Power_ReserveD1B6";
            this.chkCLR_Power_ReserveD1B6.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_Power_ReserveD1B6.TabIndex = 90;
            this.chkCLR_Power_ReserveD1B6.Text = "ReserveD1B6";
            this.chkCLR_Power_ReserveD1B6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Power_ReserveD1B6.UseVisualStyleBackColor = true;
            // 
            // chkCLR_PollingState
            // 
            this.chkCLR_PollingState.AutoSize = true;
            this.chkCLR_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_PollingState.Location = new System.Drawing.Point(3, 293);
            this.chkCLR_PollingState.Name = "chkCLR_PollingState";
            this.chkCLR_PollingState.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_PollingState.TabIndex = 29;
            this.chkCLR_PollingState.Text = "检锅状态";
            this.chkCLR_PollingState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_PollingState.UseVisualStyleBackColor = true;
            // 
            // CLR_PollingState
            // 
            this.CLR_PollingState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_PollingState.Enabled = false;
            this.CLR_PollingState.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_PollingState.Location = new System.Drawing.Point(112, 293);
            this.CLR_PollingState.Name = "CLR_PollingState";
            this.CLR_PollingState.ReadOnly = true;
            this.CLR_PollingState.Size = new System.Drawing.Size(113, 20);
            this.CLR_PollingState.TabIndex = 31;
            // 
            // chkCLR_FreqControlFlag
            // 
            this.chkCLR_FreqControlFlag.AutoSize = true;
            this.chkCLR_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_FreqControlFlag.Location = new System.Drawing.Point(3, 322);
            this.chkCLR_FreqControlFlag.Name = "chkCLR_FreqControlFlag";
            this.chkCLR_FreqControlFlag.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_FreqControlFlag.TabIndex = 32;
            this.chkCLR_FreqControlFlag.Text = "同频加热状态";
            this.chkCLR_FreqControlFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_FreqControlFlag.UseVisualStyleBackColor = true;
            // 
            // chkCLR_HeatFlag
            // 
            this.chkCLR_HeatFlag.AutoSize = true;
            this.chkCLR_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_HeatFlag.Location = new System.Drawing.Point(3, 351);
            this.chkCLR_HeatFlag.Name = "chkCLR_HeatFlag";
            this.chkCLR_HeatFlag.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_HeatFlag.TabIndex = 35;
            this.chkCLR_HeatFlag.Text = "主频稳定标志";
            this.chkCLR_HeatFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_HeatFlag.UseVisualStyleBackColor = true;
            // 
            // CLR_FreqControlFlag
            // 
            this.CLR_FreqControlFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_FreqControlFlag.Enabled = false;
            this.CLR_FreqControlFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_FreqControlFlag.Location = new System.Drawing.Point(112, 322);
            this.CLR_FreqControlFlag.Name = "CLR_FreqControlFlag";
            this.CLR_FreqControlFlag.ReadOnly = true;
            this.CLR_FreqControlFlag.Size = new System.Drawing.Size(113, 20);
            this.CLR_FreqControlFlag.TabIndex = 34;
            // 
            // CLR_HeatFlag
            // 
            this.CLR_HeatFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_HeatFlag.Enabled = false;
            this.CLR_HeatFlag.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_HeatFlag.Location = new System.Drawing.Point(112, 351);
            this.CLR_HeatFlag.Name = "CLR_HeatFlag";
            this.CLR_HeatFlag.ReadOnly = true;
            this.CLR_HeatFlag.Size = new System.Drawing.Size(113, 20);
            this.CLR_HeatFlag.TabIndex = 37;
            // 
            // CLR_HeatNTC2_TextBox
            // 
            this.CLR_HeatNTC2_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_HeatNTC2_TextBox.Enabled = false;
            this.CLR_HeatNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_HeatNTC2_TextBox.Location = new System.Drawing.Point(112, 32);
            this.CLR_HeatNTC2_TextBox.Name = "CLR_HeatNTC2_TextBox";
            this.CLR_HeatNTC2_TextBox.ReadOnly = true;
            this.CLR_HeatNTC2_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_HeatNTC2_TextBox.TabIndex = 5;
            // 
            // chkCLR_HeatNTC2
            // 
            this.chkCLR_HeatNTC2.AutoSize = true;
            this.chkCLR_HeatNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_HeatNTC2.Location = new System.Drawing.Point(3, 32);
            this.chkCLR_HeatNTC2.Name = "chkCLR_HeatNTC2";
            this.chkCLR_HeatNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_HeatNTC2.TabIndex = 3;
            this.chkCLR_HeatNTC2.Text = "HeatNTC2";
            this.chkCLR_HeatNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_HeatNTC2.UseVisualStyleBackColor = true;
            // 
            // chkCLR_HeatNTC1
            // 
            this.chkCLR_HeatNTC1.AutoSize = true;
            this.chkCLR_HeatNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_HeatNTC1.Location = new System.Drawing.Point(3, 3);
            this.chkCLR_HeatNTC1.Name = "chkCLR_HeatNTC1";
            this.chkCLR_HeatNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_HeatNTC1.TabIndex = 0;
            this.chkCLR_HeatNTC1.Text = "HeatNTC1";
            this.chkCLR_HeatNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_HeatNTC1.UseVisualStyleBackColor = true;
            // 
            // CLR_HeatNTC1_TextBox
            // 
            this.CLR_HeatNTC1_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_HeatNTC1_TextBox.Enabled = false;
            this.CLR_HeatNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_HeatNTC1_TextBox.Location = new System.Drawing.Point(112, 3);
            this.CLR_HeatNTC1_TextBox.Name = "CLR_HeatNTC1_TextBox";
            this.CLR_HeatNTC1_TextBox.ReadOnly = true;
            this.CLR_HeatNTC1_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_HeatNTC1_TextBox.TabIndex = 2;
            // 
            // chkCLR_IGBTNTC1
            // 
            this.chkCLR_IGBTNTC1.AutoSize = true;
            this.chkCLR_IGBTNTC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_IGBTNTC1.Location = new System.Drawing.Point(3, 61);
            this.chkCLR_IGBTNTC1.Name = "chkCLR_IGBTNTC1";
            this.chkCLR_IGBTNTC1.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_IGBTNTC1.TabIndex = 6;
            this.chkCLR_IGBTNTC1.Text = "IGBTNTC1";
            this.chkCLR_IGBTNTC1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_IGBTNTC1.UseVisualStyleBackColor = true;
            // 
            // CLR_IGBTNTC1_TextBox
            // 
            this.CLR_IGBTNTC1_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_IGBTNTC1_TextBox.Enabled = false;
            this.CLR_IGBTNTC1_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_IGBTNTC1_TextBox.Location = new System.Drawing.Point(112, 61);
            this.CLR_IGBTNTC1_TextBox.Name = "CLR_IGBTNTC1_TextBox";
            this.CLR_IGBTNTC1_TextBox.ReadOnly = true;
            this.CLR_IGBTNTC1_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_IGBTNTC1_TextBox.TabIndex = 8;
            // 
            // chkCLR_IGBTNTC2
            // 
            this.chkCLR_IGBTNTC2.AutoSize = true;
            this.chkCLR_IGBTNTC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_IGBTNTC2.Location = new System.Drawing.Point(3, 90);
            this.chkCLR_IGBTNTC2.Name = "chkCLR_IGBTNTC2";
            this.chkCLR_IGBTNTC2.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_IGBTNTC2.TabIndex = 9;
            this.chkCLR_IGBTNTC2.Text = "IGBTNTC2";
            this.chkCLR_IGBTNTC2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_IGBTNTC2.UseVisualStyleBackColor = true;
            // 
            // CLR_ErrorCode
            // 
            this.CLR_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_ErrorCode.Enabled = false;
            this.CLR_ErrorCode.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_ErrorCode.Location = new System.Drawing.Point(112, 264);
            this.CLR_ErrorCode.Name = "CLR_ErrorCode";
            this.CLR_ErrorCode.ReadOnly = true;
            this.CLR_ErrorCode.Size = new System.Drawing.Size(113, 20);
            this.CLR_ErrorCode.TabIndex = 28;
            // 
            // CLR_IGBTNTC2_TextBox
            // 
            this.CLR_IGBTNTC2_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_IGBTNTC2_TextBox.Enabled = false;
            this.CLR_IGBTNTC2_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_IGBTNTC2_TextBox.Location = new System.Drawing.Point(112, 90);
            this.CLR_IGBTNTC2_TextBox.Name = "CLR_IGBTNTC2_TextBox";
            this.CLR_IGBTNTC2_TextBox.ReadOnly = true;
            this.CLR_IGBTNTC2_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_IGBTNTC2_TextBox.TabIndex = 11;
            // 
            // chkCLR_PanTemp
            // 
            this.chkCLR_PanTemp.AutoSize = true;
            this.chkCLR_PanTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_PanTemp.Location = new System.Drawing.Point(3, 119);
            this.chkCLR_PanTemp.Name = "chkCLR_PanTemp";
            this.chkCLR_PanTemp.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_PanTemp.TabIndex = 12;
            this.chkCLR_PanTemp.Text = "受热品质";
            this.chkCLR_PanTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_PanTemp.UseVisualStyleBackColor = true;
            // 
            // CLR_PanTemp_TextBox
            // 
            this.CLR_PanTemp_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_PanTemp_TextBox.Enabled = false;
            this.CLR_PanTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_PanTemp_TextBox.Location = new System.Drawing.Point(112, 119);
            this.CLR_PanTemp_TextBox.Name = "CLR_PanTemp_TextBox";
            this.CLR_PanTemp_TextBox.ReadOnly = true;
            this.CLR_PanTemp_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_PanTemp_TextBox.TabIndex = 14;
            // 
            // chkCLR_Freq
            // 
            this.chkCLR_Freq.AutoSize = true;
            this.chkCLR_Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Freq.Location = new System.Drawing.Point(3, 148);
            this.chkCLR_Freq.Name = "chkCLR_Freq";
            this.chkCLR_Freq.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_Freq.TabIndex = 15;
            this.chkCLR_Freq.Text = "加热频率";
            this.chkCLR_Freq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Freq.UseVisualStyleBackColor = true;
            // 
            // CLR_Freq_TextBox
            // 
            this.CLR_Freq_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_Freq_TextBox.Enabled = false;
            this.CLR_Freq_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Freq_TextBox.Location = new System.Drawing.Point(112, 148);
            this.CLR_Freq_TextBox.Name = "CLR_Freq_TextBox";
            this.CLR_Freq_TextBox.ReadOnly = true;
            this.CLR_Freq_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_Freq_TextBox.TabIndex = 17;
            // 
            // chkCLR_ErrorCode
            // 
            this.chkCLR_ErrorCode.AutoSize = true;
            this.chkCLR_ErrorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_ErrorCode.Location = new System.Drawing.Point(3, 264);
            this.chkCLR_ErrorCode.Name = "chkCLR_ErrorCode";
            this.chkCLR_ErrorCode.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_ErrorCode.TabIndex = 26;
            this.chkCLR_ErrorCode.Text = "错误码";
            this.chkCLR_ErrorCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_ErrorCode.UseVisualStyleBackColor = true;
            // 
            // chkCLR_Voltage
            // 
            this.chkCLR_Voltage.AutoSize = true;
            this.chkCLR_Voltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Voltage.Location = new System.Drawing.Point(3, 177);
            this.chkCLR_Voltage.Name = "chkCLR_Voltage";
            this.chkCLR_Voltage.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_Voltage.TabIndex = 18;
            this.chkCLR_Voltage.Text = "电压";
            this.chkCLR_Voltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Voltage.UseVisualStyleBackColor = true;
            // 
            // CLR_MCUTemp_TextBox
            // 
            this.CLR_MCUTemp_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_MCUTemp_TextBox.Enabled = false;
            this.CLR_MCUTemp_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_MCUTemp_TextBox.Location = new System.Drawing.Point(112, 235);
            this.CLR_MCUTemp_TextBox.Name = "CLR_MCUTemp_TextBox";
            this.CLR_MCUTemp_TextBox.ReadOnly = true;
            this.CLR_MCUTemp_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_MCUTemp_TextBox.TabIndex = 25;
            // 
            // CLR_Voltage_TextBox
            // 
            this.CLR_Voltage_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_Voltage_TextBox.Enabled = false;
            this.CLR_Voltage_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Voltage_TextBox.Location = new System.Drawing.Point(112, 177);
            this.CLR_Voltage_TextBox.Name = "CLR_Voltage_TextBox";
            this.CLR_Voltage_TextBox.ReadOnly = true;
            this.CLR_Voltage_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_Voltage_TextBox.TabIndex = 20;
            // 
            // chkCLR_Power
            // 
            this.chkCLR_Power.AutoSize = true;
            this.chkCLR_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_Power.Location = new System.Drawing.Point(3, 206);
            this.chkCLR_Power.Name = "chkCLR_Power";
            this.chkCLR_Power.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_Power.TabIndex = 21;
            this.chkCLR_Power.Text = "功率";
            this.chkCLR_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_Power.UseVisualStyleBackColor = true;
            // 
            // chkCLR_MCUTemp
            // 
            this.chkCLR_MCUTemp.AutoSize = true;
            this.chkCLR_MCUTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCLR_MCUTemp.Location = new System.Drawing.Point(3, 235);
            this.chkCLR_MCUTemp.Name = "chkCLR_MCUTemp";
            this.chkCLR_MCUTemp.Size = new System.Drawing.Size(103, 23);
            this.chkCLR_MCUTemp.TabIndex = 23;
            this.chkCLR_MCUTemp.Text = "芯片温度";
            this.chkCLR_MCUTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkCLR_MCUTemp.UseVisualStyleBackColor = true;
            // 
            // CLR_Power_TextBox
            // 
            this.CLR_Power_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLR_Power_TextBox.Enabled = false;
            this.CLR_Power_TextBox.Font = new System.Drawing.Font("宋体", 8.25F, System.Drawing.FontStyle.Bold);
            this.CLR_Power_TextBox.Location = new System.Drawing.Point(112, 206);
            this.CLR_Power_TextBox.Name = "CLR_Power_TextBox";
            this.CLR_Power_TextBox.ReadOnly = true;
            this.CLR_Power_TextBox.Size = new System.Drawing.Size(113, 20);
            this.CLR_Power_TextBox.TabIndex = 22;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 598);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // lblLF_FreqControlFlag
            // 
            this.lblLF_FreqControlFlag.AutoSize = true;
            this.lblLF_FreqControlFlag.Location = new System.Drawing.Point(533, 293);
            this.lblLF_FreqControlFlag.Name = "lblLF_FreqControlFlag";
            this.lblLF_FreqControlFlag.Size = new System.Drawing.Size(0, 12);
            this.lblLF_FreqControlFlag.TabIndex = 33;
            // 
            // lblLF_ErrorCode
            // 
            this.lblLF_ErrorCode.AutoSize = true;
            this.lblLF_ErrorCode.Location = new System.Drawing.Point(533, 238);
            this.lblLF_ErrorCode.Name = "lblLF_ErrorCode";
            this.lblLF_ErrorCode.Size = new System.Drawing.Size(0, 12);
            this.lblLF_ErrorCode.TabIndex = 27;
            // 
            // panelLR
            // 
            this.panelLR.AutoScroll = true;
            this.panelLR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLR.Location = new System.Drawing.Point(0, 0);
            this.panelLR.Name = "panelLR";
            this.panelLR.Size = new System.Drawing.Size(2800, 600);
            this.panelLR.TabIndex = 1;
            // 
            // panelCLF
            // 
            this.panelCLF.AutoScroll = true;
            this.panelCLF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCLF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCLF.Location = new System.Drawing.Point(0, 0);
            this.panelCLF.Name = "panelCLF";
            this.panelCLF.Size = new System.Drawing.Size(2800, 600);
            this.panelCLF.TabIndex = 2;
            // 
            // panelCLR
            // 
            this.panelCLR.AutoScroll = true;
            this.panelCLR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCLR.Location = new System.Drawing.Point(0, 0);
            this.panelCLR.Name = "panelCLR";
            this.panelCLR.Size = new System.Drawing.Size(2800, 600);
            this.panelCLR.TabIndex = 3;
            // 
            // panelRF
            // 
            this.panelRF.AutoScroll = true;
            this.panelRF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRF.Location = new System.Drawing.Point(0, 0);
            this.panelRF.Name = "panelRF";
            this.panelRF.Size = new System.Drawing.Size(2800, 600);
            this.panelRF.TabIndex = 4;
            // 
            // panelRR
            // 
            this.panelRR.AutoScroll = true;
            this.panelRR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRR.Location = new System.Drawing.Point(0, 0);
            this.panelRR.Name = "panelRR";
            this.panelRR.Size = new System.Drawing.Size(2800, 600);
            this.panelRR.TabIndex = 5;
            // 
            // lblLF_FanLevel
            // 
            this.lblLF_FanLevel.AutoSize = true;
            this.lblLF_FanLevel.Location = new System.Drawing.Point(174, 50);
            this.lblLF_FanLevel.Name = "lblLF_FanLevel";
            this.lblLF_FanLevel.Size = new System.Drawing.Size(0, 12);
            this.lblLF_FanLevel.TabIndex = 69;
            // 
            // portGroup
            // 
            this.portGroup.Controls.Add(this.tabControl2);
            this.portGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portGroup.Location = new System.Drawing.Point(0, 0);
            this.portGroup.Name = "portGroup";
            this.portGroup.Size = new System.Drawing.Size(326, 230);
            this.portGroup.TabIndex = 0;
            this.portGroup.TabStop = false;
            this.portGroup.Text = "配置";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Controls.Add(this.tabPage8);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 17);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(320, 210);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tableLayoutPanel13);
            this.tabPage7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(312, 184);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "端口";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 4;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel13.Controls.Add(this.lblDA, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.cmbDAList, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.cmbRealPort, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.label3, 2, 2);
            this.tableLayoutPanel13.Controls.Add(this.cmbVirtualPort1, 3, 2);
            this.tableLayoutPanel13.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.TbDeviceAddress_DA, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel13.Controls.Add(this.cmbUploadPort, 3, 1);
            this.tableLayoutPanel13.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.Disp_comboBoxPortName, 1, 3);
            this.tableLayoutPanel13.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel13.Controls.Add(this.Ctrl_comboBoxPortName, 3, 3);
            this.tableLayoutPanel13.Controls.Add(this.btnStart, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.btnRefreshPorts, 1, 4);
            this.tableLayoutPanel13.Controls.Add(this.btnStop, 2, 4);
            this.tableLayoutPanel13.Controls.Add(this.btnCapture, 3, 4);
            this.tableLayoutPanel13.Controls.Add(this.btnLoadConfigure, 0, 5);
            this.tableLayoutPanel13.Controls.Add(this.btnSaveConfigure, 1, 5);
            this.tableLayoutPanel13.Controls.Add(this.btnData, 3, 5);
            this.tableLayoutPanel13.Controls.Add(this.btnClear, 2, 5);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 11;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(306, 178);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // lblDA
            // 
            this.lblDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDA.Location = new System.Drawing.Point(3, 0);
            this.lblDA.Name = "lblDA";
            this.lblDA.Size = new System.Drawing.Size(65, 29);
            this.lblDA.TabIndex = 0;
            this.lblDA.Text = "温升仪\r\n 端口:";
            this.lblDA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbDAList
            // 
            this.tableLayoutPanel13.SetColumnSpan(this.cmbDAList, 3);
            this.cmbDAList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDAList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDAList.Location = new System.Drawing.Point(74, 3);
            this.cmbDAList.Name = "cmbDAList";
            this.cmbDAList.Size = new System.Drawing.Size(229, 20);
            this.cmbDAList.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Cursor = System.Windows.Forms.Cursors.No;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 29);
            this.label6.TabIndex = 27;
            this.label6.Text = "功率仪\r\n 物理端口:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRealPort
            // 
            this.cmbRealPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRealPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRealPort.Location = new System.Drawing.Point(74, 61);
            this.cmbRealPort.Name = "cmbRealPort";
            this.cmbRealPort.Size = new System.Drawing.Size(72, 20);
            this.cmbRealPort.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(152, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 29);
            this.label3.TabIndex = 29;
            this.label3.Text = "功率仪\r\n 虚拟端口:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbVirtualPort1
            // 
            this.cmbVirtualPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbVirtualPort1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVirtualPort1.Location = new System.Drawing.Point(234, 61);
            this.cmbVirtualPort1.Name = "cmbVirtualPort1";
            this.cmbVirtualPort1.Size = new System.Drawing.Size(69, 20);
            this.cmbVirtualPort1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "温升仪\r\n 设备地址:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbDeviceAddress_DA
            // 
            this.TbDeviceAddress_DA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbDeviceAddress_DA.Location = new System.Drawing.Point(74, 32);
            this.TbDeviceAddress_DA.Name = "TbDeviceAddress_DA";
            this.TbDeviceAddress_DA.Size = new System.Drawing.Size(72, 21);
            this.TbDeviceAddress_DA.TabIndex = 17;
            this.TbDeviceAddress_DA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(152, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 29);
            this.label4.TabIndex = 23;
            this.label4.Text = "上报模块\r\n 端口:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUploadPort
            // 
            this.cmbUploadPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUploadPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUploadPort.Location = new System.Drawing.Point(234, 32);
            this.cmbUploadPort.Name = "cmbUploadPort";
            this.cmbUploadPort.Size = new System.Drawing.Size(69, 20);
            this.cmbUploadPort.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 29);
            this.label7.TabIndex = 31;
            this.label7.Text = "显示板\r\n 端口:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Disp_comboBoxPortName
            // 
            this.Disp_comboBoxPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Disp_comboBoxPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Disp_comboBoxPortName.Location = new System.Drawing.Point(74, 90);
            this.Disp_comboBoxPortName.Name = "Disp_comboBoxPortName";
            this.Disp_comboBoxPortName.Size = new System.Drawing.Size(72, 20);
            this.Disp_comboBoxPortName.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(152, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 29);
            this.label5.TabIndex = 33;
            this.label5.Text = "功率板\r\n 端口:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ctrl_comboBoxPortName
            // 
            this.Ctrl_comboBoxPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_comboBoxPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ctrl_comboBoxPortName.Location = new System.Drawing.Point(234, 90);
            this.Ctrl_comboBoxPortName.Name = "Ctrl_comboBoxPortName";
            this.Ctrl_comboBoxPortName.Size = new System.Drawing.Size(69, 20);
            this.Ctrl_comboBoxPortName.TabIndex = 34;
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 119);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "连接";
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnRefreshPorts
            // 
            this.btnRefreshPorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefreshPorts.Location = new System.Drawing.Point(74, 119);
            this.btnRefreshPorts.Name = "btnRefreshPorts";
            this.btnRefreshPorts.Size = new System.Drawing.Size(72, 23);
            this.btnRefreshPorts.TabIndex = 0;
            this.btnRefreshPorts.Text = "刷新";
            // 
            // btnStop
            // 
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(152, 119);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(76, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "断开";
            // 
            // btnCapture
            // 
            this.btnCapture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapture.Location = new System.Drawing.Point(234, 119);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(69, 23);
            this.btnCapture.TabIndex = 39;
            this.btnCapture.Text = "截图";
            // 
            // btnLoadConfigure
            // 
            this.btnLoadConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadConfigure.Location = new System.Drawing.Point(3, 148);
            this.btnLoadConfigure.Name = "btnLoadConfigure";
            this.btnLoadConfigure.Size = new System.Drawing.Size(65, 23);
            this.btnLoadConfigure.TabIndex = 47;
            this.btnLoadConfigure.Text = "加载配置";
            // 
            // btnSaveConfigure
            // 
            this.btnSaveConfigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveConfigure.Location = new System.Drawing.Point(74, 148);
            this.btnSaveConfigure.Name = "btnSaveConfigure";
            this.btnSaveConfigure.Size = new System.Drawing.Size(72, 23);
            this.btnSaveConfigure.TabIndex = 46;
            this.btnSaveConfigure.Text = "保存配置";
            // 
            // btnData
            // 
            this.btnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnData.Location = new System.Drawing.Point(234, 148);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(69, 23);
            this.btnData.TabIndex = 1;
            this.btnData.Text = "保存结果";
            this.btnData.Click += new System.EventHandler(this.BtnData_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(152, 148);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "恢复默认";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.tableLayoutPanel14);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(312, 184);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "参数";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 4;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel14.Controls.Add(this.tbUSBPcapPath, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.btnaddress, 3, 0);
            this.tableLayoutPanel14.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.cmbTempDevice, 1, 1);
            this.tableLayoutPanel14.Controls.Add(this.label14, 2, 1);
            this.tableLayoutPanel14.Controls.Add(this.cmbPowerDevice, 3, 1);
            this.tableLayoutPanel14.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel14.Controls.Add(this.Disp_comboBoxBaudRate, 1, 2);
            this.tableLayoutPanel14.Controls.Add(this.label11, 2, 2);
            this.tableLayoutPanel14.Controls.Add(this.Ctrl_comboBoxBaudRate, 3, 2);
            this.tableLayoutPanel14.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel14.Controls.Add(this.cmbUploadBaudRate, 1, 3);
            this.tableLayoutPanel14.Controls.Add(this.label9, 2, 3);
            this.tableLayoutPanel14.Controls.Add(this.txtAutoDisconnect, 3, 3);
            this.tableLayoutPanel14.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel14.Controls.Add(this.txtRecordInterval, 1, 4);
            this.tableLayoutPanel14.Controls.Add(this.cbDebugMode, 2, 4);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 11;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(306, 178);
            this.tableLayoutPanel14.TabIndex = 1;
            // 
            // tbUSBPcapPath
            // 
            this.tableLayoutPanel14.SetColumnSpan(this.tbUSBPcapPath, 2);
            this.tbUSBPcapPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUSBPcapPath.Enabled = false;
            this.tbUSBPcapPath.Location = new System.Drawing.Point(70, 3);
            this.tbUSBPcapPath.Name = "tbUSBPcapPath";
            this.tbUSBPcapPath.Size = new System.Drawing.Size(149, 21);
            this.tbUSBPcapPath.TabIndex = 49;
            // 
            // btnaddress
            // 
            this.btnaddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnaddress.Location = new System.Drawing.Point(225, 3);
            this.btnaddress.Name = "btnaddress";
            this.btnaddress.Size = new System.Drawing.Size(78, 23);
            this.btnaddress.TabIndex = 50;
            this.btnaddress.Text = "浏览";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 29);
            this.label2.TabIndex = 48;
            this.label2.Text = "USBPcap\r\n 路径:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 29);
            this.label13.TabIndex = 61;
            this.label13.Text = "温升仪\r\n设备型号:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbTempDevice
            // 
            this.cmbTempDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTempDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTempDevice.Location = new System.Drawing.Point(70, 32);
            this.cmbTempDevice.Name = "cmbTempDevice";
            this.cmbTempDevice.Size = new System.Drawing.Size(82, 20);
            this.cmbTempDevice.TabIndex = 62;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(158, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 29);
            this.label14.TabIndex = 63;
            this.label14.Text = "功率仪\r\n设备型号:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPowerDevice
            // 
            this.cmbPowerDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPowerDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPowerDevice.Location = new System.Drawing.Point(225, 32);
            this.cmbPowerDevice.Name = "cmbPowerDevice";
            this.cmbPowerDevice.Size = new System.Drawing.Size(78, 20);
            this.cmbPowerDevice.TabIndex = 64;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 29);
            this.label10.TabIndex = 51;
            this.label10.Text = "显示板\r\n 波特率:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Disp_comboBoxBaudRate
            // 
            this.Disp_comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Disp_comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Disp_comboBoxBaudRate.Location = new System.Drawing.Point(70, 61);
            this.Disp_comboBoxBaudRate.Name = "Disp_comboBoxBaudRate";
            this.Disp_comboBoxBaudRate.Size = new System.Drawing.Size(82, 20);
            this.Disp_comboBoxBaudRate.TabIndex = 52;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(158, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 29);
            this.label11.TabIndex = 53;
            this.label11.Text = "功率板\r\n 波特率:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ctrl_comboBoxBaudRate
            // 
            this.Ctrl_comboBoxBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ctrl_comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ctrl_comboBoxBaudRate.Location = new System.Drawing.Point(225, 61);
            this.Ctrl_comboBoxBaudRate.Name = "Ctrl_comboBoxBaudRate";
            this.Ctrl_comboBoxBaudRate.Size = new System.Drawing.Size(78, 20);
            this.Ctrl_comboBoxBaudRate.TabIndex = 54;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 29);
            this.label12.TabIndex = 57;
            this.label12.Text = "上报模块\r\n 波特率:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbUploadBaudRate
            // 
            this.cmbUploadBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbUploadBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUploadBaudRate.Location = new System.Drawing.Point(70, 90);
            this.cmbUploadBaudRate.Name = "cmbUploadBaudRate";
            this.cmbUploadBaudRate.Size = new System.Drawing.Size(82, 20);
            this.cmbUploadBaudRate.TabIndex = 58;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(158, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 29);
            this.label9.TabIndex = 59;
            this.label9.Text = "定时断开(min):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAutoDisconnect
            // 
            this.txtAutoDisconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAutoDisconnect.Location = new System.Drawing.Point(225, 90);
            this.txtAutoDisconnect.Name = "txtAutoDisconnect";
            this.txtAutoDisconnect.Size = new System.Drawing.Size(78, 21);
            this.txtAutoDisconnect.TabIndex = 60;
            this.txtAutoDisconnect.Text = "120";
            this.txtAutoDisconnect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 29);
            this.label8.TabIndex = 55;
            this.label8.Text = "数据记录间隔(s):";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRecordInterval
            // 
            this.txtRecordInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecordInterval.Location = new System.Drawing.Point(70, 119);
            this.txtRecordInterval.Name = "txtRecordInterval";
            this.txtRecordInterval.Size = new System.Drawing.Size(82, 21);
            this.txtRecordInterval.TabIndex = 56;
            this.txtRecordInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbDebugMode
            // 
            this.cbDebugMode.AutoSize = true;
            this.tableLayoutPanel14.SetColumnSpan(this.cbDebugMode, 2);
            this.cbDebugMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDebugMode.Location = new System.Drawing.Point(158, 119);
            this.cbDebugMode.Name = "cbDebugMode";
            this.cbDebugMode.Size = new System.Drawing.Size(145, 23);
            this.cbDebugMode.TabIndex = 66;
            this.cbDebugMode.Text = "Debug模式";
            this.cbDebugMode.UseVisualStyleBackColor = true;
            // 
            // splitContainer2_temppower_IH
            // 
            this.splitContainer2_temppower_IH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2_temppower_IH.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2_temppower_IH.Name = "splitContainer2_temppower_IH";
            this.splitContainer2_temppower_IH.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2_temppower_IH.Panel1
            // 
            this.splitContainer2_temppower_IH.Panel1.Controls.Add(this.splitContainer11);
            // 
            // splitContainer2_temppower_IH.Panel2
            // 
            this.splitContainer2_temppower_IH.Panel2.Controls.Add(this.groupbox3);
            this.splitContainer2_temppower_IH.Size = new System.Drawing.Size(1190, 694);
            this.splitContainer2_temppower_IH.SplitterDistance = 393;
            this.splitContainer2_temppower_IH.TabIndex = 3;
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer11.IsSplitterFixed = true;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            this.splitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.btUploadName);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.splitContainer5_temp_power);
            this.splitContainer11.Size = new System.Drawing.Size(1190, 393);
            this.splitContainer11.SplitterDistance = 25;
            this.splitContainer11.TabIndex = 1;
            // 
            // btUploadName
            // 
            this.btUploadName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btUploadName.Location = new System.Drawing.Point(1, 0);
            this.btUploadName.Name = "btUploadName";
            this.btUploadName.Size = new System.Drawing.Size(93, 23);
            this.btUploadName.TabIndex = 1;
            this.btUploadName.Text = "上报通道名称";
            this.btUploadName.UseVisualStyleBackColor = true;
            // 
            // splitContainer5_temp_power
            // 
            this.splitContainer5_temp_power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5_temp_power.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5_temp_power.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5_temp_power.Name = "splitContainer5_temp_power";
            // 
            // splitContainer5_temp_power.Panel1
            // 
            this.splitContainer5_temp_power.Panel1.Controls.Add(this.groupBoxTemp);
            // 
            // splitContainer5_temp_power.Panel2
            // 
            this.splitContainer5_temp_power.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer5_temp_power.Size = new System.Drawing.Size(1190, 364);
            this.splitContainer5_temp_power.SplitterDistance = 463;
            this.splitContainer5_temp_power.TabIndex = 0;
            // 
            // groupBoxTemp
            // 
            this.groupBoxTemp.Controls.Add(this.panelTempChannelsContainer);
            this.groupBoxTemp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTemp.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTemp.Name = "groupBoxTemp";
            this.groupBoxTemp.Size = new System.Drawing.Size(463, 364);
            this.groupBoxTemp.TabIndex = 0;
            this.groupBoxTemp.TabStop = false;
            this.groupBoxTemp.Text = "温升仪";
            // 
            // panelTempChannelsContainer
            // 
            this.panelTempChannelsContainer.AutoScroll = true;
            this.panelTempChannelsContainer.Controls.Add(this.tlpTempChannels);
            this.panelTempChannelsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTempChannelsContainer.Location = new System.Drawing.Point(3, 17);
            this.panelTempChannelsContainer.Name = "panelTempChannelsContainer";
            this.panelTempChannelsContainer.Size = new System.Drawing.Size(457, 344);
            this.panelTempChannelsContainer.TabIndex = 0;
            // 
            // tlpTempChannels
            // 
            this.tlpTempChannels.AutoScroll = true;
            this.tlpTempChannels.ColumnCount = 6;
            this.tlpTempChannels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTempChannels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpTempChannels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTempChannels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpTempChannels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTempChannels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlpTempChannels.Controls.Add(this.chkChannel3, 4, 0);
            this.tlpTempChannels.Controls.Add(this.chkChannel2, 2, 0);
            this.tlpTempChannels.Controls.Add(this.chkChannel1, 0, 0);
            this.tlpTempChannels.Controls.Add(this.chkChannel101, 0, 1);
            this.tlpTempChannels.Controls.Add(this.txtChannel101, 1, 1);
            this.tlpTempChannels.Controls.Add(this.chkChannel201, 2, 1);
            this.tlpTempChannels.Controls.Add(this.txtChannel201, 3, 1);
            this.tlpTempChannels.Controls.Add(this.chkChannel301, 4, 1);
            this.tlpTempChannels.Controls.Add(this.txtChannel301, 5, 1);
            this.tlpTempChannels.Controls.Add(this.chkChannel102, 0, 2);
            this.tlpTempChannels.Controls.Add(this.txtChannel102, 1, 2);
            this.tlpTempChannels.Controls.Add(this.chkChannel202, 2, 2);
            this.tlpTempChannels.Controls.Add(this.txtChannel202, 3, 2);
            this.tlpTempChannels.Controls.Add(this.chkChannel302, 4, 2);
            this.tlpTempChannels.Controls.Add(this.txtChannel302, 5, 2);
            this.tlpTempChannels.Controls.Add(this.chkChannel103, 0, 3);
            this.tlpTempChannels.Controls.Add(this.txtChannel103, 1, 3);
            this.tlpTempChannels.Controls.Add(this.chkChannel203, 2, 3);
            this.tlpTempChannels.Controls.Add(this.txtChannel203, 3, 3);
            this.tlpTempChannels.Controls.Add(this.chkChannel303, 4, 3);
            this.tlpTempChannels.Controls.Add(this.txtChannel303, 5, 3);
            this.tlpTempChannels.Controls.Add(this.chkChannel104, 0, 4);
            this.tlpTempChannels.Controls.Add(this.txtChannel104, 1, 4);
            this.tlpTempChannels.Controls.Add(this.chkChannel204, 2, 4);
            this.tlpTempChannels.Controls.Add(this.txtChannel204, 3, 4);
            this.tlpTempChannels.Controls.Add(this.chkChannel304, 4, 4);
            this.tlpTempChannels.Controls.Add(this.txtChannel304, 5, 4);
            this.tlpTempChannels.Controls.Add(this.chkChannel105, 0, 5);
            this.tlpTempChannels.Controls.Add(this.txtChannel105, 1, 5);
            this.tlpTempChannels.Controls.Add(this.chkChannel205, 2, 5);
            this.tlpTempChannels.Controls.Add(this.txtChannel205, 3, 5);
            this.tlpTempChannels.Controls.Add(this.chkChannel305, 4, 5);
            this.tlpTempChannels.Controls.Add(this.txtChannel305, 5, 5);
            this.tlpTempChannels.Controls.Add(this.chkChannel106, 0, 6);
            this.tlpTempChannels.Controls.Add(this.txtChannel106, 1, 6);
            this.tlpTempChannels.Controls.Add(this.chkChannel206, 2, 6);
            this.tlpTempChannels.Controls.Add(this.txtChannel206, 3, 6);
            this.tlpTempChannels.Controls.Add(this.chkChannel306, 4, 6);
            this.tlpTempChannels.Controls.Add(this.txtChannel306, 5, 6);
            this.tlpTempChannels.Controls.Add(this.chkChannel107, 0, 7);
            this.tlpTempChannels.Controls.Add(this.txtChannel107, 1, 7);
            this.tlpTempChannels.Controls.Add(this.chkChannel207, 2, 7);
            this.tlpTempChannels.Controls.Add(this.txtChannel207, 3, 7);
            this.tlpTempChannels.Controls.Add(this.chkChannel307, 4, 7);
            this.tlpTempChannels.Controls.Add(this.txtChannel307, 5, 7);
            this.tlpTempChannels.Controls.Add(this.chkChannel108, 0, 8);
            this.tlpTempChannels.Controls.Add(this.txtChannel108, 1, 8);
            this.tlpTempChannels.Controls.Add(this.chkChannel208, 2, 8);
            this.tlpTempChannels.Controls.Add(this.txtChannel208, 3, 8);
            this.tlpTempChannels.Controls.Add(this.chkChannel308, 4, 8);
            this.tlpTempChannels.Controls.Add(this.txtChannel308, 5, 8);
            this.tlpTempChannels.Controls.Add(this.chkChannel109, 0, 9);
            this.tlpTempChannels.Controls.Add(this.txtChannel109, 1, 9);
            this.tlpTempChannels.Controls.Add(this.chkChannel209, 2, 9);
            this.tlpTempChannels.Controls.Add(this.txtChannel209, 3, 9);
            this.tlpTempChannels.Controls.Add(this.chkChannel309, 4, 9);
            this.tlpTempChannels.Controls.Add(this.txtChannel309, 5, 9);
            this.tlpTempChannels.Controls.Add(this.chkChannel110, 0, 10);
            this.tlpTempChannels.Controls.Add(this.txtChannel110, 1, 10);
            this.tlpTempChannels.Controls.Add(this.chkChannel210, 2, 10);
            this.tlpTempChannels.Controls.Add(this.txtChannel210, 3, 10);
            this.tlpTempChannels.Controls.Add(this.chkChannel310, 4, 10);
            this.tlpTempChannels.Controls.Add(this.txtChannel310, 5, 10);
            this.tlpTempChannels.Controls.Add(this.chkChannel111, 0, 11);
            this.tlpTempChannels.Controls.Add(this.txtChannel111, 1, 11);
            this.tlpTempChannels.Controls.Add(this.chkChannel211, 2, 11);
            this.tlpTempChannels.Controls.Add(this.txtChannel211, 3, 11);
            this.tlpTempChannels.Controls.Add(this.chkChannel311, 4, 11);
            this.tlpTempChannels.Controls.Add(this.txtChannel311, 5, 11);
            this.tlpTempChannels.Controls.Add(this.chkChannel112, 0, 12);
            this.tlpTempChannels.Controls.Add(this.txtChannel112, 1, 12);
            this.tlpTempChannels.Controls.Add(this.chkChannel212, 2, 12);
            this.tlpTempChannels.Controls.Add(this.txtChannel212, 3, 12);
            this.tlpTempChannels.Controls.Add(this.chkChannel312, 4, 12);
            this.tlpTempChannels.Controls.Add(this.txtChannel312, 5, 12);
            this.tlpTempChannels.Controls.Add(this.chkChannel113, 0, 13);
            this.tlpTempChannels.Controls.Add(this.txtChannel113, 1, 13);
            this.tlpTempChannels.Controls.Add(this.chkChannel213, 2, 13);
            this.tlpTempChannels.Controls.Add(this.txtChannel213, 3, 13);
            this.tlpTempChannels.Controls.Add(this.chkChannel313, 4, 13);
            this.tlpTempChannels.Controls.Add(this.txtChannel313, 5, 13);
            this.tlpTempChannels.Controls.Add(this.chkChannel114, 0, 14);
            this.tlpTempChannels.Controls.Add(this.txtChannel114, 1, 14);
            this.tlpTempChannels.Controls.Add(this.chkChannel214, 2, 14);
            this.tlpTempChannels.Controls.Add(this.txtChannel214, 3, 14);
            this.tlpTempChannels.Controls.Add(this.chkChannel314, 4, 14);
            this.tlpTempChannels.Controls.Add(this.txtChannel314, 5, 14);
            this.tlpTempChannels.Controls.Add(this.chkChannel115, 0, 15);
            this.tlpTempChannels.Controls.Add(this.txtChannel115, 1, 15);
            this.tlpTempChannels.Controls.Add(this.chkChannel215, 2, 15);
            this.tlpTempChannels.Controls.Add(this.txtChannel215, 3, 15);
            this.tlpTempChannels.Controls.Add(this.chkChannel315, 4, 15);
            this.tlpTempChannels.Controls.Add(this.txtChannel315, 5, 15);
            this.tlpTempChannels.Controls.Add(this.chkChannel116, 0, 16);
            this.tlpTempChannels.Controls.Add(this.txtChannel116, 1, 16);
            this.tlpTempChannels.Controls.Add(this.chkChannel216, 2, 16);
            this.tlpTempChannels.Controls.Add(this.txtChannel216, 3, 16);
            this.tlpTempChannels.Controls.Add(this.chkChannel316, 4, 16);
            this.tlpTempChannels.Controls.Add(this.txtChannel316, 5, 16);
            this.tlpTempChannels.Controls.Add(this.chkChannel117, 0, 17);
            this.tlpTempChannels.Controls.Add(this.txtChannel117, 1, 17);
            this.tlpTempChannels.Controls.Add(this.chkChannel217, 2, 17);
            this.tlpTempChannels.Controls.Add(this.txtChannel217, 3, 17);
            this.tlpTempChannels.Controls.Add(this.chkChannel317, 4, 17);
            this.tlpTempChannels.Controls.Add(this.txtChannel317, 5, 17);
            this.tlpTempChannels.Controls.Add(this.chkChannel118, 0, 18);
            this.tlpTempChannels.Controls.Add(this.txtChannel118, 1, 18);
            this.tlpTempChannels.Controls.Add(this.chkChannel218, 2, 18);
            this.tlpTempChannels.Controls.Add(this.txtChannel218, 3, 18);
            this.tlpTempChannels.Controls.Add(this.chkChannel318, 4, 18);
            this.tlpTempChannels.Controls.Add(this.txtChannel318, 5, 18);
            this.tlpTempChannels.Controls.Add(this.chkChannel119, 0, 19);
            this.tlpTempChannels.Controls.Add(this.txtChannel119, 1, 19);
            this.tlpTempChannels.Controls.Add(this.chkChannel219, 2, 19);
            this.tlpTempChannels.Controls.Add(this.txtChannel219, 3, 19);
            this.tlpTempChannels.Controls.Add(this.chkChannel319, 4, 19);
            this.tlpTempChannels.Controls.Add(this.txtChannel319, 5, 19);
            this.tlpTempChannels.Controls.Add(this.chkChannel120, 0, 20);
            this.tlpTempChannels.Controls.Add(this.txtChannel120, 1, 20);
            this.tlpTempChannels.Controls.Add(this.chkChannel220, 2, 20);
            this.tlpTempChannels.Controls.Add(this.txtChannel220, 3, 20);
            this.tlpTempChannels.Controls.Add(this.chkChannel320, 4, 20);
            this.tlpTempChannels.Controls.Add(this.txtChannel320, 5, 20);
            this.tlpTempChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTempChannels.Location = new System.Drawing.Point(0, 0);
            this.tlpTempChannels.Name = "tlpTempChannels";
            this.tlpTempChannels.RowCount = 21;
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tlpTempChannels.Size = new System.Drawing.Size(457, 344);
            this.tlpTempChannels.TabIndex = 0;
            // 
            // chkChannel3
            // 
            this.chkChannel3.AutoSize = true;
            this.chkChannel3.Location = new System.Drawing.Point(287, 3);
            this.chkChannel3.Name = "chkChannel3";
            this.chkChannel3.Size = new System.Drawing.Size(48, 16);
            this.chkChannel3.TabIndex = 2;
            this.chkChannel3.Text = "全选";
            // 
            // chkChannel2
            // 
            this.chkChannel2.AutoSize = true;
            this.chkChannel2.Location = new System.Drawing.Point(145, 3);
            this.chkChannel2.Name = "chkChannel2";
            this.chkChannel2.Size = new System.Drawing.Size(48, 16);
            this.chkChannel2.TabIndex = 2;
            this.chkChannel2.Text = "全选";
            // 
            // chkChannel1
            // 
            this.chkChannel1.AutoSize = true;
            this.chkChannel1.Location = new System.Drawing.Point(3, 3);
            this.chkChannel1.Name = "chkChannel1";
            this.chkChannel1.Size = new System.Drawing.Size(48, 16);
            this.chkChannel1.TabIndex = 1;
            this.chkChannel1.Text = "全选";
            // 
            // chkChannel101
            // 
            this.chkChannel101.AutoSize = true;
            this.chkChannel101.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel101.Location = new System.Drawing.Point(3, 27);
            this.chkChannel101.Name = "chkChannel101";
            this.chkChannel101.Size = new System.Drawing.Size(48, 23);
            this.chkChannel101.TabIndex = 0;
            this.chkChannel101.Text = "101";
            this.chkChannel101.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel101
            // 
            this.txtChannel101.Location = new System.Drawing.Point(57, 27);
            this.txtChannel101.Name = "txtChannel101";
            this.txtChannel101.ReadOnly = true;
            this.txtChannel101.Size = new System.Drawing.Size(74, 21);
            this.txtChannel101.TabIndex = 1;
            this.txtChannel101.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel201
            // 
            this.chkChannel201.AutoSize = true;
            this.chkChannel201.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel201.Location = new System.Drawing.Point(145, 27);
            this.chkChannel201.Name = "chkChannel201";
            this.chkChannel201.Size = new System.Drawing.Size(48, 23);
            this.chkChannel201.TabIndex = 2;
            this.chkChannel201.Text = "201";
            this.chkChannel201.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel201
            // 
            this.txtChannel201.Location = new System.Drawing.Point(199, 27);
            this.txtChannel201.Name = "txtChannel201";
            this.txtChannel201.ReadOnly = true;
            this.txtChannel201.Size = new System.Drawing.Size(74, 21);
            this.txtChannel201.TabIndex = 3;
            this.txtChannel201.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel301
            // 
            this.chkChannel301.AutoSize = true;
            this.chkChannel301.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel301.Location = new System.Drawing.Point(287, 27);
            this.chkChannel301.Name = "chkChannel301";
            this.chkChannel301.Size = new System.Drawing.Size(48, 23);
            this.chkChannel301.TabIndex = 4;
            this.chkChannel301.Text = "301";
            this.chkChannel301.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel301
            // 
            this.txtChannel301.Location = new System.Drawing.Point(341, 27);
            this.txtChannel301.Name = "txtChannel301";
            this.txtChannel301.ReadOnly = true;
            this.txtChannel301.Size = new System.Drawing.Size(74, 21);
            this.txtChannel301.TabIndex = 5;
            this.txtChannel301.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel102
            // 
            this.chkChannel102.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel102.Location = new System.Drawing.Point(3, 56);
            this.chkChannel102.Name = "chkChannel102";
            this.chkChannel102.Size = new System.Drawing.Size(48, 23);
            this.chkChannel102.TabIndex = 6;
            this.chkChannel102.Text = "102";
            this.chkChannel102.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel102
            // 
            this.txtChannel102.Location = new System.Drawing.Point(57, 56);
            this.txtChannel102.Name = "txtChannel102";
            this.txtChannel102.ReadOnly = true;
            this.txtChannel102.Size = new System.Drawing.Size(74, 21);
            this.txtChannel102.TabIndex = 7;
            this.txtChannel102.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel202
            // 
            this.chkChannel202.AutoSize = true;
            this.chkChannel202.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel202.Location = new System.Drawing.Point(145, 56);
            this.chkChannel202.Name = "chkChannel202";
            this.chkChannel202.Size = new System.Drawing.Size(48, 23);
            this.chkChannel202.TabIndex = 8;
            this.chkChannel202.Text = "202";
            this.chkChannel202.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel202
            // 
            this.txtChannel202.Location = new System.Drawing.Point(199, 56);
            this.txtChannel202.Name = "txtChannel202";
            this.txtChannel202.ReadOnly = true;
            this.txtChannel202.Size = new System.Drawing.Size(74, 21);
            this.txtChannel202.TabIndex = 9;
            this.txtChannel202.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel302
            // 
            this.chkChannel302.AutoSize = true;
            this.chkChannel302.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel302.Location = new System.Drawing.Point(287, 56);
            this.chkChannel302.Name = "chkChannel302";
            this.chkChannel302.Size = new System.Drawing.Size(48, 23);
            this.chkChannel302.TabIndex = 10;
            this.chkChannel302.Text = "302";
            this.chkChannel302.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel302
            // 
            this.txtChannel302.Location = new System.Drawing.Point(341, 56);
            this.txtChannel302.Name = "txtChannel302";
            this.txtChannel302.ReadOnly = true;
            this.txtChannel302.Size = new System.Drawing.Size(74, 21);
            this.txtChannel302.TabIndex = 11;
            this.txtChannel302.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel103
            // 
            this.chkChannel103.AutoSize = true;
            this.chkChannel103.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel103.Location = new System.Drawing.Point(3, 85);
            this.chkChannel103.Name = "chkChannel103";
            this.chkChannel103.Size = new System.Drawing.Size(48, 23);
            this.chkChannel103.TabIndex = 12;
            this.chkChannel103.Text = "103";
            this.chkChannel103.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel103
            // 
            this.txtChannel103.Location = new System.Drawing.Point(57, 85);
            this.txtChannel103.Name = "txtChannel103";
            this.txtChannel103.ReadOnly = true;
            this.txtChannel103.Size = new System.Drawing.Size(74, 21);
            this.txtChannel103.TabIndex = 13;
            this.txtChannel103.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel203
            // 
            this.chkChannel203.AutoSize = true;
            this.chkChannel203.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel203.Location = new System.Drawing.Point(145, 85);
            this.chkChannel203.Name = "chkChannel203";
            this.chkChannel203.Size = new System.Drawing.Size(48, 23);
            this.chkChannel203.TabIndex = 14;
            this.chkChannel203.Text = "203";
            this.chkChannel203.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel203
            // 
            this.txtChannel203.Location = new System.Drawing.Point(199, 85);
            this.txtChannel203.Name = "txtChannel203";
            this.txtChannel203.ReadOnly = true;
            this.txtChannel203.Size = new System.Drawing.Size(74, 21);
            this.txtChannel203.TabIndex = 15;
            this.txtChannel203.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel303
            // 
            this.chkChannel303.AutoSize = true;
            this.chkChannel303.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel303.Location = new System.Drawing.Point(287, 85);
            this.chkChannel303.Name = "chkChannel303";
            this.chkChannel303.Size = new System.Drawing.Size(48, 23);
            this.chkChannel303.TabIndex = 16;
            this.chkChannel303.Text = "303";
            this.chkChannel303.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel303
            // 
            this.txtChannel303.Location = new System.Drawing.Point(341, 85);
            this.txtChannel303.Name = "txtChannel303";
            this.txtChannel303.ReadOnly = true;
            this.txtChannel303.Size = new System.Drawing.Size(74, 21);
            this.txtChannel303.TabIndex = 17;
            this.txtChannel303.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel104
            // 
            this.chkChannel104.AutoSize = true;
            this.chkChannel104.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel104.Location = new System.Drawing.Point(3, 114);
            this.chkChannel104.Name = "chkChannel104";
            this.chkChannel104.Size = new System.Drawing.Size(48, 23);
            this.chkChannel104.TabIndex = 18;
            this.chkChannel104.Text = "104";
            this.chkChannel104.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel104
            // 
            this.txtChannel104.Location = new System.Drawing.Point(57, 114);
            this.txtChannel104.Name = "txtChannel104";
            this.txtChannel104.ReadOnly = true;
            this.txtChannel104.Size = new System.Drawing.Size(74, 21);
            this.txtChannel104.TabIndex = 19;
            this.txtChannel104.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel204
            // 
            this.chkChannel204.AutoSize = true;
            this.chkChannel204.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel204.Location = new System.Drawing.Point(145, 114);
            this.chkChannel204.Name = "chkChannel204";
            this.chkChannel204.Size = new System.Drawing.Size(48, 23);
            this.chkChannel204.TabIndex = 20;
            this.chkChannel204.Text = "204";
            this.chkChannel204.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel204
            // 
            this.txtChannel204.Location = new System.Drawing.Point(199, 114);
            this.txtChannel204.Name = "txtChannel204";
            this.txtChannel204.ReadOnly = true;
            this.txtChannel204.Size = new System.Drawing.Size(74, 21);
            this.txtChannel204.TabIndex = 21;
            this.txtChannel204.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel304
            // 
            this.chkChannel304.AutoSize = true;
            this.chkChannel304.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel304.Location = new System.Drawing.Point(287, 114);
            this.chkChannel304.Name = "chkChannel304";
            this.chkChannel304.Size = new System.Drawing.Size(48, 23);
            this.chkChannel304.TabIndex = 22;
            this.chkChannel304.Text = "304";
            this.chkChannel304.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel304
            // 
            this.txtChannel304.Location = new System.Drawing.Point(341, 114);
            this.txtChannel304.Name = "txtChannel304";
            this.txtChannel304.ReadOnly = true;
            this.txtChannel304.Size = new System.Drawing.Size(74, 21);
            this.txtChannel304.TabIndex = 23;
            this.txtChannel304.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel105
            // 
            this.chkChannel105.AutoSize = true;
            this.chkChannel105.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel105.Location = new System.Drawing.Point(3, 143);
            this.chkChannel105.Name = "chkChannel105";
            this.chkChannel105.Size = new System.Drawing.Size(48, 23);
            this.chkChannel105.TabIndex = 24;
            this.chkChannel105.Text = "105";
            this.chkChannel105.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel105
            // 
            this.txtChannel105.Location = new System.Drawing.Point(57, 143);
            this.txtChannel105.Name = "txtChannel105";
            this.txtChannel105.ReadOnly = true;
            this.txtChannel105.Size = new System.Drawing.Size(74, 21);
            this.txtChannel105.TabIndex = 25;
            this.txtChannel105.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel205
            // 
            this.chkChannel205.AutoSize = true;
            this.chkChannel205.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel205.Location = new System.Drawing.Point(145, 143);
            this.chkChannel205.Name = "chkChannel205";
            this.chkChannel205.Size = new System.Drawing.Size(48, 23);
            this.chkChannel205.TabIndex = 26;
            this.chkChannel205.Text = "205";
            this.chkChannel205.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel205
            // 
            this.txtChannel205.Location = new System.Drawing.Point(199, 143);
            this.txtChannel205.Name = "txtChannel205";
            this.txtChannel205.ReadOnly = true;
            this.txtChannel205.Size = new System.Drawing.Size(74, 21);
            this.txtChannel205.TabIndex = 27;
            this.txtChannel205.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel305
            // 
            this.chkChannel305.AutoSize = true;
            this.chkChannel305.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel305.Location = new System.Drawing.Point(287, 143);
            this.chkChannel305.Name = "chkChannel305";
            this.chkChannel305.Size = new System.Drawing.Size(48, 23);
            this.chkChannel305.TabIndex = 28;
            this.chkChannel305.Text = "305";
            this.chkChannel305.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel305
            // 
            this.txtChannel305.Location = new System.Drawing.Point(341, 143);
            this.txtChannel305.Name = "txtChannel305";
            this.txtChannel305.ReadOnly = true;
            this.txtChannel305.Size = new System.Drawing.Size(74, 21);
            this.txtChannel305.TabIndex = 29;
            this.txtChannel305.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel106
            // 
            this.chkChannel106.AutoSize = true;
            this.chkChannel106.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel106.Location = new System.Drawing.Point(3, 172);
            this.chkChannel106.Name = "chkChannel106";
            this.chkChannel106.Size = new System.Drawing.Size(48, 23);
            this.chkChannel106.TabIndex = 30;
            this.chkChannel106.Text = "106";
            this.chkChannel106.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel106
            // 
            this.txtChannel106.Location = new System.Drawing.Point(57, 172);
            this.txtChannel106.Name = "txtChannel106";
            this.txtChannel106.ReadOnly = true;
            this.txtChannel106.Size = new System.Drawing.Size(74, 21);
            this.txtChannel106.TabIndex = 31;
            this.txtChannel106.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel206
            // 
            this.chkChannel206.AutoSize = true;
            this.chkChannel206.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel206.Location = new System.Drawing.Point(145, 172);
            this.chkChannel206.Name = "chkChannel206";
            this.chkChannel206.Size = new System.Drawing.Size(48, 23);
            this.chkChannel206.TabIndex = 32;
            this.chkChannel206.Text = "206";
            this.chkChannel206.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel206
            // 
            this.txtChannel206.Location = new System.Drawing.Point(199, 172);
            this.txtChannel206.Name = "txtChannel206";
            this.txtChannel206.ReadOnly = true;
            this.txtChannel206.Size = new System.Drawing.Size(74, 21);
            this.txtChannel206.TabIndex = 33;
            this.txtChannel206.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel306
            // 
            this.chkChannel306.AutoSize = true;
            this.chkChannel306.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel306.Location = new System.Drawing.Point(287, 172);
            this.chkChannel306.Name = "chkChannel306";
            this.chkChannel306.Size = new System.Drawing.Size(48, 23);
            this.chkChannel306.TabIndex = 34;
            this.chkChannel306.Text = "306";
            this.chkChannel306.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel306
            // 
            this.txtChannel306.Location = new System.Drawing.Point(341, 172);
            this.txtChannel306.Name = "txtChannel306";
            this.txtChannel306.ReadOnly = true;
            this.txtChannel306.Size = new System.Drawing.Size(74, 21);
            this.txtChannel306.TabIndex = 35;
            this.txtChannel306.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel107
            // 
            this.chkChannel107.AutoSize = true;
            this.chkChannel107.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel107.Location = new System.Drawing.Point(3, 201);
            this.chkChannel107.Name = "chkChannel107";
            this.chkChannel107.Size = new System.Drawing.Size(48, 23);
            this.chkChannel107.TabIndex = 36;
            this.chkChannel107.Text = "107";
            this.chkChannel107.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel107
            // 
            this.txtChannel107.Location = new System.Drawing.Point(57, 201);
            this.txtChannel107.Name = "txtChannel107";
            this.txtChannel107.ReadOnly = true;
            this.txtChannel107.Size = new System.Drawing.Size(74, 21);
            this.txtChannel107.TabIndex = 37;
            this.txtChannel107.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel207
            // 
            this.chkChannel207.AutoSize = true;
            this.chkChannel207.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel207.Location = new System.Drawing.Point(145, 201);
            this.chkChannel207.Name = "chkChannel207";
            this.chkChannel207.Size = new System.Drawing.Size(48, 23);
            this.chkChannel207.TabIndex = 38;
            this.chkChannel207.Text = "207";
            this.chkChannel207.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel207
            // 
            this.txtChannel207.Location = new System.Drawing.Point(199, 201);
            this.txtChannel207.Name = "txtChannel207";
            this.txtChannel207.ReadOnly = true;
            this.txtChannel207.Size = new System.Drawing.Size(74, 21);
            this.txtChannel207.TabIndex = 39;
            this.txtChannel207.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel307
            // 
            this.chkChannel307.AutoSize = true;
            this.chkChannel307.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel307.Location = new System.Drawing.Point(287, 201);
            this.chkChannel307.Name = "chkChannel307";
            this.chkChannel307.Size = new System.Drawing.Size(48, 23);
            this.chkChannel307.TabIndex = 40;
            this.chkChannel307.Text = "307";
            this.chkChannel307.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel307
            // 
            this.txtChannel307.Location = new System.Drawing.Point(341, 201);
            this.txtChannel307.Name = "txtChannel307";
            this.txtChannel307.ReadOnly = true;
            this.txtChannel307.Size = new System.Drawing.Size(74, 21);
            this.txtChannel307.TabIndex = 41;
            this.txtChannel307.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel108
            // 
            this.chkChannel108.AutoSize = true;
            this.chkChannel108.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel108.Location = new System.Drawing.Point(3, 230);
            this.chkChannel108.Name = "chkChannel108";
            this.chkChannel108.Size = new System.Drawing.Size(48, 23);
            this.chkChannel108.TabIndex = 42;
            this.chkChannel108.Text = "108";
            this.chkChannel108.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel108
            // 
            this.txtChannel108.Location = new System.Drawing.Point(57, 230);
            this.txtChannel108.Name = "txtChannel108";
            this.txtChannel108.ReadOnly = true;
            this.txtChannel108.Size = new System.Drawing.Size(74, 21);
            this.txtChannel108.TabIndex = 43;
            this.txtChannel108.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel208
            // 
            this.chkChannel208.AutoSize = true;
            this.chkChannel208.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel208.Location = new System.Drawing.Point(145, 230);
            this.chkChannel208.Name = "chkChannel208";
            this.chkChannel208.Size = new System.Drawing.Size(48, 23);
            this.chkChannel208.TabIndex = 44;
            this.chkChannel208.Text = "208";
            this.chkChannel208.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel208
            // 
            this.txtChannel208.Location = new System.Drawing.Point(199, 230);
            this.txtChannel208.Name = "txtChannel208";
            this.txtChannel208.ReadOnly = true;
            this.txtChannel208.Size = new System.Drawing.Size(74, 21);
            this.txtChannel208.TabIndex = 45;
            this.txtChannel208.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel308
            // 
            this.chkChannel308.AutoSize = true;
            this.chkChannel308.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel308.Location = new System.Drawing.Point(287, 230);
            this.chkChannel308.Name = "chkChannel308";
            this.chkChannel308.Size = new System.Drawing.Size(48, 23);
            this.chkChannel308.TabIndex = 46;
            this.chkChannel308.Text = "308";
            this.chkChannel308.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel308
            // 
            this.txtChannel308.Location = new System.Drawing.Point(341, 230);
            this.txtChannel308.Name = "txtChannel308";
            this.txtChannel308.ReadOnly = true;
            this.txtChannel308.Size = new System.Drawing.Size(74, 21);
            this.txtChannel308.TabIndex = 47;
            this.txtChannel308.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel109
            // 
            this.chkChannel109.AutoSize = true;
            this.chkChannel109.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel109.Location = new System.Drawing.Point(3, 259);
            this.chkChannel109.Name = "chkChannel109";
            this.chkChannel109.Size = new System.Drawing.Size(48, 23);
            this.chkChannel109.TabIndex = 48;
            this.chkChannel109.Text = "109";
            this.chkChannel109.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel109
            // 
            this.txtChannel109.Location = new System.Drawing.Point(57, 259);
            this.txtChannel109.Name = "txtChannel109";
            this.txtChannel109.ReadOnly = true;
            this.txtChannel109.Size = new System.Drawing.Size(74, 21);
            this.txtChannel109.TabIndex = 49;
            this.txtChannel109.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel209
            // 
            this.chkChannel209.AutoSize = true;
            this.chkChannel209.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel209.Location = new System.Drawing.Point(145, 259);
            this.chkChannel209.Name = "chkChannel209";
            this.chkChannel209.Size = new System.Drawing.Size(48, 23);
            this.chkChannel209.TabIndex = 50;
            this.chkChannel209.Text = "209";
            this.chkChannel209.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel209
            // 
            this.txtChannel209.Location = new System.Drawing.Point(199, 259);
            this.txtChannel209.Name = "txtChannel209";
            this.txtChannel209.ReadOnly = true;
            this.txtChannel209.Size = new System.Drawing.Size(74, 21);
            this.txtChannel209.TabIndex = 51;
            this.txtChannel209.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel309
            // 
            this.chkChannel309.AutoSize = true;
            this.chkChannel309.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel309.Location = new System.Drawing.Point(287, 259);
            this.chkChannel309.Name = "chkChannel309";
            this.chkChannel309.Size = new System.Drawing.Size(48, 23);
            this.chkChannel309.TabIndex = 52;
            this.chkChannel309.Text = "309";
            this.chkChannel309.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel309
            // 
            this.txtChannel309.Location = new System.Drawing.Point(341, 259);
            this.txtChannel309.Name = "txtChannel309";
            this.txtChannel309.ReadOnly = true;
            this.txtChannel309.Size = new System.Drawing.Size(74, 21);
            this.txtChannel309.TabIndex = 53;
            this.txtChannel309.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel110
            // 
            this.chkChannel110.AutoSize = true;
            this.chkChannel110.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel110.Location = new System.Drawing.Point(3, 288);
            this.chkChannel110.Name = "chkChannel110";
            this.chkChannel110.Size = new System.Drawing.Size(48, 23);
            this.chkChannel110.TabIndex = 54;
            this.chkChannel110.Text = "110";
            this.chkChannel110.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel110
            // 
            this.txtChannel110.Location = new System.Drawing.Point(57, 288);
            this.txtChannel110.Name = "txtChannel110";
            this.txtChannel110.ReadOnly = true;
            this.txtChannel110.Size = new System.Drawing.Size(74, 21);
            this.txtChannel110.TabIndex = 55;
            this.txtChannel110.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel210
            // 
            this.chkChannel210.AutoSize = true;
            this.chkChannel210.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel210.Location = new System.Drawing.Point(145, 288);
            this.chkChannel210.Name = "chkChannel210";
            this.chkChannel210.Size = new System.Drawing.Size(48, 23);
            this.chkChannel210.TabIndex = 56;
            this.chkChannel210.Text = "210";
            this.chkChannel210.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel210
            // 
            this.txtChannel210.Location = new System.Drawing.Point(199, 288);
            this.txtChannel210.Name = "txtChannel210";
            this.txtChannel210.ReadOnly = true;
            this.txtChannel210.Size = new System.Drawing.Size(74, 21);
            this.txtChannel210.TabIndex = 57;
            this.txtChannel210.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel310
            // 
            this.chkChannel310.AutoSize = true;
            this.chkChannel310.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel310.Location = new System.Drawing.Point(287, 288);
            this.chkChannel310.Name = "chkChannel310";
            this.chkChannel310.Size = new System.Drawing.Size(48, 23);
            this.chkChannel310.TabIndex = 58;
            this.chkChannel310.Text = "310";
            this.chkChannel310.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel310
            // 
            this.txtChannel310.Location = new System.Drawing.Point(341, 288);
            this.txtChannel310.Name = "txtChannel310";
            this.txtChannel310.ReadOnly = true;
            this.txtChannel310.Size = new System.Drawing.Size(74, 21);
            this.txtChannel310.TabIndex = 59;
            this.txtChannel310.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel111
            // 
            this.chkChannel111.AutoSize = true;
            this.chkChannel111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel111.Location = new System.Drawing.Point(3, 317);
            this.chkChannel111.Name = "chkChannel111";
            this.chkChannel111.Size = new System.Drawing.Size(48, 23);
            this.chkChannel111.TabIndex = 60;
            this.chkChannel111.Text = "111";
            this.chkChannel111.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel111
            // 
            this.txtChannel111.Location = new System.Drawing.Point(57, 317);
            this.txtChannel111.Name = "txtChannel111";
            this.txtChannel111.ReadOnly = true;
            this.txtChannel111.Size = new System.Drawing.Size(74, 21);
            this.txtChannel111.TabIndex = 61;
            this.txtChannel111.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel211
            // 
            this.chkChannel211.AutoSize = true;
            this.chkChannel211.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel211.Location = new System.Drawing.Point(145, 317);
            this.chkChannel211.Name = "chkChannel211";
            this.chkChannel211.Size = new System.Drawing.Size(48, 23);
            this.chkChannel211.TabIndex = 62;
            this.chkChannel211.Text = "211";
            this.chkChannel211.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel211
            // 
            this.txtChannel211.Location = new System.Drawing.Point(199, 317);
            this.txtChannel211.Name = "txtChannel211";
            this.txtChannel211.ReadOnly = true;
            this.txtChannel211.Size = new System.Drawing.Size(74, 21);
            this.txtChannel211.TabIndex = 63;
            this.txtChannel211.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel311
            // 
            this.chkChannel311.AutoSize = true;
            this.chkChannel311.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel311.Location = new System.Drawing.Point(287, 317);
            this.chkChannel311.Name = "chkChannel311";
            this.chkChannel311.Size = new System.Drawing.Size(48, 23);
            this.chkChannel311.TabIndex = 64;
            this.chkChannel311.Text = "311";
            this.chkChannel311.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel311
            // 
            this.txtChannel311.Location = new System.Drawing.Point(341, 317);
            this.txtChannel311.Name = "txtChannel311";
            this.txtChannel311.ReadOnly = true;
            this.txtChannel311.Size = new System.Drawing.Size(74, 21);
            this.txtChannel311.TabIndex = 65;
            this.txtChannel311.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel112
            // 
            this.chkChannel112.AutoSize = true;
            this.chkChannel112.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel112.Location = new System.Drawing.Point(3, 346);
            this.chkChannel112.Name = "chkChannel112";
            this.chkChannel112.Size = new System.Drawing.Size(48, 23);
            this.chkChannel112.TabIndex = 66;
            this.chkChannel112.Text = "112";
            this.chkChannel112.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel112
            // 
            this.txtChannel112.Location = new System.Drawing.Point(57, 346);
            this.txtChannel112.Name = "txtChannel112";
            this.txtChannel112.ReadOnly = true;
            this.txtChannel112.Size = new System.Drawing.Size(74, 21);
            this.txtChannel112.TabIndex = 67;
            this.txtChannel112.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel212
            // 
            this.chkChannel212.AutoSize = true;
            this.chkChannel212.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel212.Location = new System.Drawing.Point(145, 346);
            this.chkChannel212.Name = "chkChannel212";
            this.chkChannel212.Size = new System.Drawing.Size(48, 23);
            this.chkChannel212.TabIndex = 68;
            this.chkChannel212.Text = "212";
            this.chkChannel212.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel212
            // 
            this.txtChannel212.Location = new System.Drawing.Point(199, 346);
            this.txtChannel212.Name = "txtChannel212";
            this.txtChannel212.ReadOnly = true;
            this.txtChannel212.Size = new System.Drawing.Size(74, 21);
            this.txtChannel212.TabIndex = 69;
            this.txtChannel212.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel312
            // 
            this.chkChannel312.AutoSize = true;
            this.chkChannel312.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel312.Location = new System.Drawing.Point(287, 346);
            this.chkChannel312.Name = "chkChannel312";
            this.chkChannel312.Size = new System.Drawing.Size(48, 23);
            this.chkChannel312.TabIndex = 70;
            this.chkChannel312.Text = "312";
            this.chkChannel312.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel312
            // 
            this.txtChannel312.Location = new System.Drawing.Point(341, 346);
            this.txtChannel312.Name = "txtChannel312";
            this.txtChannel312.ReadOnly = true;
            this.txtChannel312.Size = new System.Drawing.Size(74, 21);
            this.txtChannel312.TabIndex = 71;
            this.txtChannel312.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel113
            // 
            this.chkChannel113.AutoSize = true;
            this.chkChannel113.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel113.Location = new System.Drawing.Point(3, 375);
            this.chkChannel113.Name = "chkChannel113";
            this.chkChannel113.Size = new System.Drawing.Size(48, 23);
            this.chkChannel113.TabIndex = 72;
            this.chkChannel113.Text = "113";
            this.chkChannel113.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel113
            // 
            this.txtChannel113.Location = new System.Drawing.Point(57, 375);
            this.txtChannel113.Name = "txtChannel113";
            this.txtChannel113.ReadOnly = true;
            this.txtChannel113.Size = new System.Drawing.Size(74, 21);
            this.txtChannel113.TabIndex = 73;
            this.txtChannel113.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel213
            // 
            this.chkChannel213.AutoSize = true;
            this.chkChannel213.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel213.Location = new System.Drawing.Point(145, 375);
            this.chkChannel213.Name = "chkChannel213";
            this.chkChannel213.Size = new System.Drawing.Size(48, 23);
            this.chkChannel213.TabIndex = 74;
            this.chkChannel213.Text = "213";
            this.chkChannel213.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel213
            // 
            this.txtChannel213.Location = new System.Drawing.Point(199, 375);
            this.txtChannel213.Name = "txtChannel213";
            this.txtChannel213.ReadOnly = true;
            this.txtChannel213.Size = new System.Drawing.Size(74, 21);
            this.txtChannel213.TabIndex = 75;
            this.txtChannel213.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel313
            // 
            this.chkChannel313.AutoSize = true;
            this.chkChannel313.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel313.Location = new System.Drawing.Point(287, 375);
            this.chkChannel313.Name = "chkChannel313";
            this.chkChannel313.Size = new System.Drawing.Size(48, 23);
            this.chkChannel313.TabIndex = 76;
            this.chkChannel313.Text = "313";
            this.chkChannel313.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel313
            // 
            this.txtChannel313.Location = new System.Drawing.Point(341, 375);
            this.txtChannel313.Name = "txtChannel313";
            this.txtChannel313.ReadOnly = true;
            this.txtChannel313.Size = new System.Drawing.Size(74, 21);
            this.txtChannel313.TabIndex = 77;
            this.txtChannel313.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel114
            // 
            this.chkChannel114.AutoSize = true;
            this.chkChannel114.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel114.Location = new System.Drawing.Point(3, 404);
            this.chkChannel114.Name = "chkChannel114";
            this.chkChannel114.Size = new System.Drawing.Size(48, 23);
            this.chkChannel114.TabIndex = 78;
            this.chkChannel114.Text = "114";
            this.chkChannel114.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel114
            // 
            this.txtChannel114.Location = new System.Drawing.Point(57, 404);
            this.txtChannel114.Name = "txtChannel114";
            this.txtChannel114.ReadOnly = true;
            this.txtChannel114.Size = new System.Drawing.Size(74, 21);
            this.txtChannel114.TabIndex = 79;
            this.txtChannel114.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel214
            // 
            this.chkChannel214.AutoSize = true;
            this.chkChannel214.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel214.Location = new System.Drawing.Point(145, 404);
            this.chkChannel214.Name = "chkChannel214";
            this.chkChannel214.Size = new System.Drawing.Size(48, 23);
            this.chkChannel214.TabIndex = 80;
            this.chkChannel214.Text = "214";
            this.chkChannel214.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel214
            // 
            this.txtChannel214.Location = new System.Drawing.Point(199, 404);
            this.txtChannel214.Name = "txtChannel214";
            this.txtChannel214.ReadOnly = true;
            this.txtChannel214.Size = new System.Drawing.Size(74, 21);
            this.txtChannel214.TabIndex = 81;
            this.txtChannel214.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel314
            // 
            this.chkChannel314.AutoSize = true;
            this.chkChannel314.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel314.Location = new System.Drawing.Point(287, 404);
            this.chkChannel314.Name = "chkChannel314";
            this.chkChannel314.Size = new System.Drawing.Size(48, 23);
            this.chkChannel314.TabIndex = 82;
            this.chkChannel314.Text = "314";
            this.chkChannel314.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel314
            // 
            this.txtChannel314.Location = new System.Drawing.Point(341, 404);
            this.txtChannel314.Name = "txtChannel314";
            this.txtChannel314.ReadOnly = true;
            this.txtChannel314.Size = new System.Drawing.Size(74, 21);
            this.txtChannel314.TabIndex = 83;
            this.txtChannel314.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel115
            // 
            this.chkChannel115.AutoSize = true;
            this.chkChannel115.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel115.Location = new System.Drawing.Point(3, 433);
            this.chkChannel115.Name = "chkChannel115";
            this.chkChannel115.Size = new System.Drawing.Size(48, 23);
            this.chkChannel115.TabIndex = 84;
            this.chkChannel115.Text = "115";
            this.chkChannel115.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel115
            // 
            this.txtChannel115.Location = new System.Drawing.Point(57, 433);
            this.txtChannel115.Name = "txtChannel115";
            this.txtChannel115.ReadOnly = true;
            this.txtChannel115.Size = new System.Drawing.Size(74, 21);
            this.txtChannel115.TabIndex = 85;
            this.txtChannel115.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel215
            // 
            this.chkChannel215.AutoSize = true;
            this.chkChannel215.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel215.Location = new System.Drawing.Point(145, 433);
            this.chkChannel215.Name = "chkChannel215";
            this.chkChannel215.Size = new System.Drawing.Size(48, 23);
            this.chkChannel215.TabIndex = 86;
            this.chkChannel215.Text = "215";
            this.chkChannel215.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel215
            // 
            this.txtChannel215.Location = new System.Drawing.Point(199, 433);
            this.txtChannel215.Name = "txtChannel215";
            this.txtChannel215.ReadOnly = true;
            this.txtChannel215.Size = new System.Drawing.Size(74, 21);
            this.txtChannel215.TabIndex = 87;
            this.txtChannel215.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel315
            // 
            this.chkChannel315.AutoSize = true;
            this.chkChannel315.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel315.Location = new System.Drawing.Point(287, 433);
            this.chkChannel315.Name = "chkChannel315";
            this.chkChannel315.Size = new System.Drawing.Size(48, 23);
            this.chkChannel315.TabIndex = 88;
            this.chkChannel315.Text = "315";
            this.chkChannel315.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel315
            // 
            this.txtChannel315.Location = new System.Drawing.Point(341, 433);
            this.txtChannel315.Name = "txtChannel315";
            this.txtChannel315.ReadOnly = true;
            this.txtChannel315.Size = new System.Drawing.Size(74, 21);
            this.txtChannel315.TabIndex = 89;
            this.txtChannel315.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel116
            // 
            this.chkChannel116.AutoSize = true;
            this.chkChannel116.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel116.Location = new System.Drawing.Point(3, 462);
            this.chkChannel116.Name = "chkChannel116";
            this.chkChannel116.Size = new System.Drawing.Size(48, 23);
            this.chkChannel116.TabIndex = 90;
            this.chkChannel116.Text = "116";
            this.chkChannel116.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel116
            // 
            this.txtChannel116.Location = new System.Drawing.Point(57, 462);
            this.txtChannel116.Name = "txtChannel116";
            this.txtChannel116.ReadOnly = true;
            this.txtChannel116.Size = new System.Drawing.Size(74, 21);
            this.txtChannel116.TabIndex = 91;
            this.txtChannel116.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel216
            // 
            this.chkChannel216.AutoSize = true;
            this.chkChannel216.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel216.Location = new System.Drawing.Point(145, 462);
            this.chkChannel216.Name = "chkChannel216";
            this.chkChannel216.Size = new System.Drawing.Size(48, 23);
            this.chkChannel216.TabIndex = 92;
            this.chkChannel216.Text = "216";
            this.chkChannel216.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel216
            // 
            this.txtChannel216.Location = new System.Drawing.Point(199, 462);
            this.txtChannel216.Name = "txtChannel216";
            this.txtChannel216.ReadOnly = true;
            this.txtChannel216.Size = new System.Drawing.Size(74, 21);
            this.txtChannel216.TabIndex = 93;
            this.txtChannel216.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel316
            // 
            this.chkChannel316.AutoSize = true;
            this.chkChannel316.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel316.Location = new System.Drawing.Point(287, 462);
            this.chkChannel316.Name = "chkChannel316";
            this.chkChannel316.Size = new System.Drawing.Size(48, 23);
            this.chkChannel316.TabIndex = 94;
            this.chkChannel316.Text = "316";
            this.chkChannel316.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel316
            // 
            this.txtChannel316.Location = new System.Drawing.Point(341, 462);
            this.txtChannel316.Name = "txtChannel316";
            this.txtChannel316.ReadOnly = true;
            this.txtChannel316.Size = new System.Drawing.Size(74, 21);
            this.txtChannel316.TabIndex = 95;
            this.txtChannel316.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel117
            // 
            this.chkChannel117.AutoSize = true;
            this.chkChannel117.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel117.Location = new System.Drawing.Point(3, 491);
            this.chkChannel117.Name = "chkChannel117";
            this.chkChannel117.Size = new System.Drawing.Size(48, 23);
            this.chkChannel117.TabIndex = 96;
            this.chkChannel117.Text = "117";
            this.chkChannel117.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel117
            // 
            this.txtChannel117.Location = new System.Drawing.Point(57, 491);
            this.txtChannel117.Name = "txtChannel117";
            this.txtChannel117.ReadOnly = true;
            this.txtChannel117.Size = new System.Drawing.Size(74, 21);
            this.txtChannel117.TabIndex = 97;
            this.txtChannel117.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel217
            // 
            this.chkChannel217.AutoSize = true;
            this.chkChannel217.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel217.Location = new System.Drawing.Point(145, 491);
            this.chkChannel217.Name = "chkChannel217";
            this.chkChannel217.Size = new System.Drawing.Size(48, 23);
            this.chkChannel217.TabIndex = 98;
            this.chkChannel217.Text = "217";
            this.chkChannel217.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel217
            // 
            this.txtChannel217.Location = new System.Drawing.Point(199, 491);
            this.txtChannel217.Name = "txtChannel217";
            this.txtChannel217.ReadOnly = true;
            this.txtChannel217.Size = new System.Drawing.Size(74, 21);
            this.txtChannel217.TabIndex = 99;
            this.txtChannel217.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel317
            // 
            this.chkChannel317.AutoSize = true;
            this.chkChannel317.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel317.Location = new System.Drawing.Point(287, 491);
            this.chkChannel317.Name = "chkChannel317";
            this.chkChannel317.Size = new System.Drawing.Size(48, 23);
            this.chkChannel317.TabIndex = 100;
            this.chkChannel317.Text = "317";
            this.chkChannel317.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel317
            // 
            this.txtChannel317.Location = new System.Drawing.Point(341, 491);
            this.txtChannel317.Name = "txtChannel317";
            this.txtChannel317.ReadOnly = true;
            this.txtChannel317.Size = new System.Drawing.Size(74, 21);
            this.txtChannel317.TabIndex = 101;
            this.txtChannel317.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel118
            // 
            this.chkChannel118.AutoSize = true;
            this.chkChannel118.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel118.Location = new System.Drawing.Point(3, 520);
            this.chkChannel118.Name = "chkChannel118";
            this.chkChannel118.Size = new System.Drawing.Size(48, 23);
            this.chkChannel118.TabIndex = 102;
            this.chkChannel118.Text = "118";
            this.chkChannel118.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel118
            // 
            this.txtChannel118.Location = new System.Drawing.Point(57, 520);
            this.txtChannel118.Name = "txtChannel118";
            this.txtChannel118.ReadOnly = true;
            this.txtChannel118.Size = new System.Drawing.Size(74, 21);
            this.txtChannel118.TabIndex = 103;
            this.txtChannel118.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel218
            // 
            this.chkChannel218.AutoSize = true;
            this.chkChannel218.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel218.Location = new System.Drawing.Point(145, 520);
            this.chkChannel218.Name = "chkChannel218";
            this.chkChannel218.Size = new System.Drawing.Size(48, 23);
            this.chkChannel218.TabIndex = 104;
            this.chkChannel218.Text = "218";
            this.chkChannel218.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel218
            // 
            this.txtChannel218.Location = new System.Drawing.Point(199, 520);
            this.txtChannel218.Name = "txtChannel218";
            this.txtChannel218.ReadOnly = true;
            this.txtChannel218.Size = new System.Drawing.Size(74, 21);
            this.txtChannel218.TabIndex = 105;
            this.txtChannel218.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel318
            // 
            this.chkChannel318.AutoSize = true;
            this.chkChannel318.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel318.Location = new System.Drawing.Point(287, 520);
            this.chkChannel318.Name = "chkChannel318";
            this.chkChannel318.Size = new System.Drawing.Size(48, 23);
            this.chkChannel318.TabIndex = 106;
            this.chkChannel318.Text = "318";
            this.chkChannel318.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel318
            // 
            this.txtChannel318.Location = new System.Drawing.Point(341, 520);
            this.txtChannel318.Name = "txtChannel318";
            this.txtChannel318.ReadOnly = true;
            this.txtChannel318.Size = new System.Drawing.Size(74, 21);
            this.txtChannel318.TabIndex = 107;
            this.txtChannel318.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel119
            // 
            this.chkChannel119.AutoSize = true;
            this.chkChannel119.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel119.Location = new System.Drawing.Point(3, 549);
            this.chkChannel119.Name = "chkChannel119";
            this.chkChannel119.Size = new System.Drawing.Size(48, 23);
            this.chkChannel119.TabIndex = 108;
            this.chkChannel119.Text = "119";
            this.chkChannel119.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel119
            // 
            this.txtChannel119.Location = new System.Drawing.Point(57, 549);
            this.txtChannel119.Name = "txtChannel119";
            this.txtChannel119.ReadOnly = true;
            this.txtChannel119.Size = new System.Drawing.Size(74, 21);
            this.txtChannel119.TabIndex = 109;
            this.txtChannel119.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel219
            // 
            this.chkChannel219.AutoSize = true;
            this.chkChannel219.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel219.Location = new System.Drawing.Point(145, 549);
            this.chkChannel219.Name = "chkChannel219";
            this.chkChannel219.Size = new System.Drawing.Size(48, 23);
            this.chkChannel219.TabIndex = 110;
            this.chkChannel219.Text = "219";
            this.chkChannel219.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel219
            // 
            this.txtChannel219.Location = new System.Drawing.Point(199, 549);
            this.txtChannel219.Name = "txtChannel219";
            this.txtChannel219.ReadOnly = true;
            this.txtChannel219.Size = new System.Drawing.Size(74, 21);
            this.txtChannel219.TabIndex = 111;
            this.txtChannel219.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel319
            // 
            this.chkChannel319.AutoSize = true;
            this.chkChannel319.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel319.Location = new System.Drawing.Point(287, 549);
            this.chkChannel319.Name = "chkChannel319";
            this.chkChannel319.Size = new System.Drawing.Size(48, 23);
            this.chkChannel319.TabIndex = 112;
            this.chkChannel319.Text = "319";
            this.chkChannel319.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel319
            // 
            this.txtChannel319.Location = new System.Drawing.Point(341, 549);
            this.txtChannel319.Name = "txtChannel319";
            this.txtChannel319.ReadOnly = true;
            this.txtChannel319.Size = new System.Drawing.Size(74, 21);
            this.txtChannel319.TabIndex = 113;
            this.txtChannel319.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel120
            // 
            this.chkChannel120.AutoSize = true;
            this.chkChannel120.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel120.Location = new System.Drawing.Point(3, 578);
            this.chkChannel120.Name = "chkChannel120";
            this.chkChannel120.Size = new System.Drawing.Size(48, 23);
            this.chkChannel120.TabIndex = 114;
            this.chkChannel120.Text = "120";
            this.chkChannel120.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel120
            // 
            this.txtChannel120.Location = new System.Drawing.Point(57, 578);
            this.txtChannel120.Name = "txtChannel120";
            this.txtChannel120.ReadOnly = true;
            this.txtChannel120.Size = new System.Drawing.Size(74, 21);
            this.txtChannel120.TabIndex = 115;
            this.txtChannel120.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel220
            // 
            this.chkChannel220.AutoSize = true;
            this.chkChannel220.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel220.Location = new System.Drawing.Point(145, 578);
            this.chkChannel220.Name = "chkChannel220";
            this.chkChannel220.Size = new System.Drawing.Size(48, 23);
            this.chkChannel220.TabIndex = 116;
            this.chkChannel220.Text = "220";
            this.chkChannel220.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel220
            // 
            this.txtChannel220.Location = new System.Drawing.Point(199, 578);
            this.txtChannel220.Name = "txtChannel220";
            this.txtChannel220.ReadOnly = true;
            this.txtChannel220.Size = new System.Drawing.Size(74, 21);
            this.txtChannel220.TabIndex = 117;
            this.txtChannel220.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkChannel320
            // 
            this.chkChannel320.AutoSize = true;
            this.chkChannel320.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChannel320.Location = new System.Drawing.Point(287, 578);
            this.chkChannel320.Name = "chkChannel320";
            this.chkChannel320.Size = new System.Drawing.Size(48, 23);
            this.chkChannel320.TabIndex = 118;
            this.chkChannel320.Text = "320";
            this.chkChannel320.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel320
            // 
            this.txtChannel320.Location = new System.Drawing.Point(341, 578);
            this.txtChannel320.Name = "txtChannel320";
            this.txtChannel320.ReadOnly = true;
            this.txtChannel320.Size = new System.Drawing.Size(74, 21);
            this.txtChannel320.TabIndex = 119;
            this.txtChannel320.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 393);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "功率仪";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(717, 373);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.lblLF_FanLevel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(717, 373);
            this.panel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new System.Drawing.Size(680, 0);
            this.panel1.Controls.Add(this.dgvPower);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 373);
            this.panel1.TabIndex = 70;
            // 
            // dgvPower
            // 
            this.dgvPower.AllowUserToAddRows = false;
            this.dgvPower.AllowUserToDeleteRows = false;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPower.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPower.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvPower.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPower.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvPower.ColumnHeadersHeight = 20;
            this.dgvPower.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Time,
            this.Column_Ua,
            this.Column_Ub,
            this.Column_Uc,
            this.Column_Ia,
            this.Column_Ib,
            this.Column_Ic,
            this.Column_P,
            this.Column_Freq,
            this.Column_En});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPower.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvPower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPower.Location = new System.Drawing.Point(0, 0);
            this.dgvPower.MultiSelect = false;
            this.dgvPower.Name = "dgvPower";
            this.dgvPower.Size = new System.Drawing.Size(717, 373);
            this.dgvPower.TabIndex = 2;
            // 
            // Column_Time
            // 
            this.Column_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Time.DefaultCellStyle = dataGridViewCellStyle16;
            this.Column_Time.FillWeight = 20F;
            this.Column_Time.Frozen = true;
            this.Column_Time.HeaderText = "时间";
            this.Column_Time.MinimumWidth = 90;
            this.Column_Time.Name = "Column_Time";
            this.Column_Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Time.Width = 90;
            // 
            // Column_Ua
            // 
            this.Column_Ua.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Ua.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column_Ua.Frozen = true;
            this.Column_Ua.HeaderText = "Ua";
            this.Column_Ua.Name = "Column_Ua";
            this.Column_Ua.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Ua.Width = 60;
            // 
            // Column_Ub
            // 
            this.Column_Ub.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Ub.DefaultCellStyle = dataGridViewCellStyle18;
            this.Column_Ub.Frozen = true;
            this.Column_Ub.HeaderText = "Ub";
            this.Column_Ub.Name = "Column_Ub";
            this.Column_Ub.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Ub.Width = 60;
            // 
            // Column_Uc
            // 
            this.Column_Uc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Uc.DefaultCellStyle = dataGridViewCellStyle19;
            this.Column_Uc.Frozen = true;
            this.Column_Uc.HeaderText = "Uc";
            this.Column_Uc.Name = "Column_Uc";
            this.Column_Uc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Uc.Width = 60;
            // 
            // Column_Ia
            // 
            this.Column_Ia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Ia.DefaultCellStyle = dataGridViewCellStyle20;
            this.Column_Ia.Frozen = true;
            this.Column_Ia.HeaderText = "Ia";
            this.Column_Ia.Name = "Column_Ia";
            this.Column_Ia.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Ia.Width = 60;
            // 
            // Column_Ib
            // 
            this.Column_Ib.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Ib.DefaultCellStyle = dataGridViewCellStyle21;
            this.Column_Ib.Frozen = true;
            this.Column_Ib.HeaderText = "Ib";
            this.Column_Ib.Name = "Column_Ib";
            this.Column_Ib.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Ib.Width = 60;
            // 
            // Column_Ic
            // 
            this.Column_Ic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Ic.DefaultCellStyle = dataGridViewCellStyle22;
            this.Column_Ic.Frozen = true;
            this.Column_Ic.HeaderText = "Ic";
            this.Column_Ic.Name = "Column_Ic";
            this.Column_Ic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Ic.Width = 60;
            // 
            // Column_P
            // 
            this.Column_P.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_P.DefaultCellStyle = dataGridViewCellStyle23;
            this.Column_P.Frozen = true;
            this.Column_P.HeaderText = "P";
            this.Column_P.Name = "Column_P";
            this.Column_P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_P.Width = 60;
            // 
            // Column_Freq
            // 
            this.Column_Freq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Freq.DefaultCellStyle = dataGridViewCellStyle24;
            this.Column_Freq.Frozen = true;
            this.Column_Freq.HeaderText = "Freq";
            this.Column_Freq.Name = "Column_Freq";
            this.Column_Freq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Freq.Width = 60;
            // 
            // Column_En
            // 
            this.Column_En.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_En.DefaultCellStyle = dataGridViewCellStyle25;
            this.Column_En.HeaderText = "En";
            this.Column_En.Name = "Column_En";
            this.Column_En.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(326, 27);
            this.statusStrip.TabIndex = 11;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(32, 22);
            this.statusLabel.Text = "就绪";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3_set_log);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1534, 726);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer3_set_log
            // 
            this.splitContainer3_set_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3_set_log.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3_set_log.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3_set_log.Name = "splitContainer3_set_log";
            this.splitContainer3_set_log.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3_set_log.Panel1
            // 
            this.splitContainer3_set_log.Panel1.Controls.Add(this.portGroup);
            // 
            // splitContainer3_set_log.Panel2
            // 
            this.splitContainer3_set_log.Panel2.Controls.Add(this.splitContainer4_log_status);
            this.splitContainer3_set_log.Size = new System.Drawing.Size(326, 726);
            this.splitContainer3_set_log.SplitterDistance = 230;
            this.splitContainer3_set_log.TabIndex = 0;
            // 
            // splitContainer4_log_status
            // 
            this.splitContainer4_log_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4_log_status.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4_log_status.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4_log_status.Name = "splitContainer4_log_status";
            this.splitContainer4_log_status.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4_log_status.Panel1
            // 
            this.splitContainer4_log_status.Panel1.Controls.Add(this.LOG);
            // 
            // splitContainer4_log_status.Panel2
            // 
            this.splitContainer4_log_status.Panel2.Controls.Add(this.statusStrip);
            this.splitContainer4_log_status.Size = new System.Drawing.Size(326, 492);
            this.splitContainer4_log_status.SplitterDistance = 461;
            this.splitContainer4_log_status.TabIndex = 0;
            // 
            // LOG
            // 
            this.LOG.Controls.Add(this.tabPage1);
            this.LOG.Controls.Add(this.tabPage2);
            this.LOG.Controls.Add(this.tabPage3);
            this.LOG.Controls.Add(this.tabPage4);
            this.LOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LOG.Location = new System.Drawing.Point(0, 0);
            this.LOG.Name = "LOG";
            this.LOG.SelectedIndex = 0;
            this.LOG.Size = new System.Drawing.Size(326, 461);
            this.LOG.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LogBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(318, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "日志";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.Location = new System.Drawing.Point(3, 3);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(312, 429);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LogBox_Temp);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(318, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "温升仪原始数据";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LogBox_Temp
            // 
            this.LogBox_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox_Temp.Location = new System.Drawing.Point(3, 3);
            this.LogBox_Temp.Name = "LogBox_Temp";
            this.LogBox_Temp.Size = new System.Drawing.Size(312, 429);
            this.LogBox_Temp.TabIndex = 1;
            this.LogBox_Temp.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.LogBox_Power);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(318, 435);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "功率仪原始数据";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // LogBox_Power
            // 
            this.LogBox_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox_Power.Location = new System.Drawing.Point(3, 3);
            this.LogBox_Power.Name = "LogBox_Power";
            this.LogBox_Power.Size = new System.Drawing.Size(312, 429);
            this.LogBox_Power.TabIndex = 1;
            this.LogBox_Power.Text = "";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.LogBox_IH);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(318, 435);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "IH数据";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // LogBox_IH
            // 
            this.LogBox_IH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox_IH.Location = new System.Drawing.Point(3, 3);
            this.LogBox_IH.Name = "LogBox_IH";
            this.LogBox_IH.Size = new System.Drawing.Size(312, 429);
            this.LogBox_IH.TabIndex = 2;
            this.LogBox_IH.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1204, 726);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.splitContainer2_temppower_IH);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1196, 700);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "数据";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.splitContainer10);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1196, 700);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "图表";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer10.IsSplitterFixed = true;
            this.splitContainer10.Location = new System.Drawing.Point(3, 3);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.btnToggleSettings);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.splitContainer9);
            this.splitContainer10.Size = new System.Drawing.Size(1190, 694);
            this.splitContainer10.SplitterDistance = 25;
            this.splitContainer10.TabIndex = 2;
            // 
            // btnToggleSettings
            // 
            this.btnToggleSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToggleSettings.Location = new System.Drawing.Point(3, 0);
            this.btnToggleSettings.Name = "btnToggleSettings";
            this.btnToggleSettings.Size = new System.Drawing.Size(75, 23);
            this.btnToggleSettings.TabIndex = 0;
            this.btnToggleSettings.Text = "展开/折叠";
            this.btnToggleSettings.UseVisualStyleBackColor = true;
            this.btnToggleSettings.Click += new System.EventHandler(this.btnToggleSettings_Click);
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.chart);
            this.splitContainer9.Size = new System.Drawing.Size(1190, 665);
            this.splitContainer9.SplitterDistance = 247;
            this.splitContainer9.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(247, 665);
            this.treeView1.TabIndex = 0;
            // 
            // chart
            // 
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(939, 665);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // DAForm
            // 
            this.ClientSize = new System.Drawing.Size(1534, 726);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(858, 500);
            this.Name = "DAForm";
            this.Text = "多设备数据采集上位机";
            this.groupbox3.ResumeLayout(false);
            this.mainIHPanel.ResumeLayout(false);
            this.panelLF.ResumeLayout(false);
            this.panelLF.PerformLayout();
            this.splitContainer6_LFDisp.Panel1.ResumeLayout(false);
            this.splitContainer6_LFDisp.Panel1.PerformLayout();
            this.splitContainer6_LFDisp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6_LFDisp)).EndInit();
            this.splitContainer6_LFDisp.ResumeLayout(false);
            this.groupBoxLF_Display.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer3_LFControl.Panel1.ResumeLayout(false);
            this.splitContainer3_LFControl.Panel1.PerformLayout();
            this.splitContainer3_LFControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3_LFControl)).EndInit();
            this.splitContainer3_LFControl.ResumeLayout(false);
            this.groupBoxLF_Power.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxLR_Display.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxLR_Power.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel1.PerformLayout();
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.splitContainer13.Panel1.ResumeLayout(false);
            this.splitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).EndInit();
            this.splitContainer13.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.splitContainer8.Panel1.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            this.splitContainer8.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.portGroup.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.splitContainer2_temppower_IH.Panel1.ResumeLayout(false);
            this.splitContainer2_temppower_IH.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2_temppower_IH)).EndInit();
            this.splitContainer2_temppower_IH.ResumeLayout(false);
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            this.splitContainer5_temp_power.Panel1.ResumeLayout(false);
            this.splitContainer5_temp_power.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5_temp_power)).EndInit();
            this.splitContainer5_temp_power.ResumeLayout(false);
            this.groupBoxTemp.ResumeLayout(false);
            this.panelTempChannelsContainer.ResumeLayout(false);
            this.tlpTempChannels.ResumeLayout(false);
            this.tlpTempChannels.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPower)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3_set_log.Panel1.ResumeLayout(false);
            this.splitContainer3_set_log.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3_set_log)).EndInit();
            this.splitContainer3_set_log.ResumeLayout(false);
            this.splitContainer4_log_status.Panel1.ResumeLayout(false);
            this.splitContainer4_log_status.Panel2.ResumeLayout(false);
            this.splitContainer4_log_status.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4_log_status)).EndInit();
            this.splitContainer4_log_status.ResumeLayout(false);
            this.LOG.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel mainIHPanel;
        private Panel panelLF;
        private Panel panelLR;
        private Panel panelCLF;
        private Panel panelCLR;
        private Panel panelRF;
        private Panel panelRR;
        private GroupBox groupBoxLF_Power;
        private GroupBox groupBoxLF_Display;
        private CheckBox chkLF_HeatNTC1;
        private TextBox LF_HeatNTC1_TextBox;
        private CheckBox chkLF_HeatNTC2;
        private TextBox LF_HeatNTC2_TextBox;
        private CheckBox chkLF_IGBTNTC1;
        private TextBox LF_IGBTNTC1_TextBox;
        private CheckBox chkLF_IGBTNTC2;
        private TextBox LF_IGBTNTC2_TextBox;
        private CheckBox chkLF_PanTemp;
        private TextBox LF_PanTemp_TextBox;
        private CheckBox chkLF_Freq;
        private TextBox LF_Freq_TextBox;
        private CheckBox chkLF_Voltage;
        private TextBox LF_Voltage_TextBox;
        private CheckBox chkLF_Power;
        private TextBox LF_Power_TextBox;
        private CheckBox chkLF_MCUTemp;
        private TextBox LF_MCUTemp_TextBox;
        private CheckBox chkLF_ErrorCode;
        private Label lblLF_ErrorCode;
        private TextBox LF_ErrorCode;
        private CheckBox chkLF_PollingState;
        private Label lblLF_PollingState;
        private TextBox LF_PollingState;
        private CheckBox chkLF_FreqControlFlag;
        private Label lblLF_FreqControlFlag;
        private TextBox LF_FreqControlFlag;
        private CheckBox chkLF_HeatFlag;
        private TextBox LF_HeatFlag;
        private GroupBox groupbox3;
        private GroupBox portGroup;
        private Label lblDA;
        private ComboBox cmbDAList;
        private TextBox TbDeviceAddress_DA;
        private Label label1;
        private Button btnStart;
        private Button btnClear;
        private Button btnStop;
        private Button btnData;
        private Button btnRefreshPorts;
        private SplitContainer splitContainer2_temppower_IH;
        private Label label4;
        private ComboBox cmbUploadPort;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer3_set_log;
        private SplitContainer splitContainer4_log_status;
        private SplitContainer splitContainer5_temp_power;
        private GroupBox groupBox2;
        private DataGridView dgvPower;
        private Label label6;
        private ComboBox cmbRealPort;
        private TabControl LOG;
        private TabPage tabPage1;
        private RichTextBox LogBox;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private RichTextBox LogBox_Temp;
        private RichTextBox LogBox_Power;
        private Label label3;
        private ComboBox cmbVirtualPort1;
        private Label label5;
        private ComboBox Ctrl_comboBoxPortName;
        private Label label7;
        private ComboBox Disp_comboBoxPortName;
        private SplitContainer splitContainer6_LFDisp;
        private CheckBox chkLF_HeatingFreqFollow;
        private TextBox LF_DebugSubChannel_TextBox;
        private TextBox LF_HeatingFreqFollow_TextBox;
        private CheckBox chkLF_DebugSubChannel;
        private CheckBox chkLF_PanControlActive;
        private TextBox LF_BridgeControl_TextBox;
        private TextBox LF_PanControlActive_TextBox;
        private CheckBox chkLF_BridgeControl;
        private CheckBox chkLF_InnerOuterRing;
        private TextBox LF_FanLevel_TextBox;
        private Label lblLF_FanLevel;
        private CheckBox chkLF_FanLevel;
        private CheckBox chkLF_allZone_BridgeHeatFlag;
        private TextBox LF_NoiseControl_TextBox;
        private TextBox LF_allZone_BridgeHeatFlag_TextBox;
        private CheckBox chkLF_NoiseControl;
        private CheckBox chkLF_PPGMode;
        private TextBox LF_HeatFreqJitterFlag_TextBox;
        private TextBox LF_PPGMode_TextBox;
        private CheckBox chkLF_HeatFreqJitterFlag;
        private CheckBox chkLF_AllowPanDetection;
        private TextBox LF_StoveSwitch_TextBox;
        private CheckBox chkLF_StoveSwitch;
        private TextBox LF_AllowPanDetection_TextBox;
        private TextBox LF_PauseFlag_TextBox;
        private CheckBox chkLF_PauseFlag;
        private TextBox LF_RequestPower_TextBox;
        private CheckBox chkLF_RequestPower;
        private TextBox LF_DebugChannel_TextBox;
        private CheckBox chkLF_DebugChannel;
        private TabPage tabPage4;
        private RichTextBox LogBox_IH;

        private GroupBox groupBoxTemp;
        private System.Windows.Forms.Panel panelTempChannelsContainer;
        private System.Windows.Forms.CheckBox chkChannel101;
        private System.Windows.Forms.TextBox txtChannel101;
        private System.Windows.Forms.CheckBox chkChannel201;
        private System.Windows.Forms.TextBox txtChannel201;
        private System.Windows.Forms.CheckBox chkChannel301;
        private System.Windows.Forms.TextBox txtChannel301;
        private System.Windows.Forms.CheckBox chkChannel102;
        private System.Windows.Forms.TextBox txtChannel102;
        private System.Windows.Forms.CheckBox chkChannel202;
        private System.Windows.Forms.TextBox txtChannel202;
        private System.Windows.Forms.CheckBox chkChannel302;
        private System.Windows.Forms.TextBox txtChannel302;
        private System.Windows.Forms.CheckBox chkChannel103;
        private System.Windows.Forms.TextBox txtChannel103;
        private System.Windows.Forms.CheckBox chkChannel203;
        private System.Windows.Forms.TextBox txtChannel203;
        private System.Windows.Forms.CheckBox chkChannel303;
        private System.Windows.Forms.TextBox txtChannel303;
        private System.Windows.Forms.CheckBox chkChannel104;
        private System.Windows.Forms.TextBox txtChannel104;
        private System.Windows.Forms.CheckBox chkChannel204;
        private System.Windows.Forms.TextBox txtChannel204;
        private System.Windows.Forms.CheckBox chkChannel304;
        private System.Windows.Forms.TextBox txtChannel304;
        private System.Windows.Forms.CheckBox chkChannel105;
        private System.Windows.Forms.TextBox txtChannel105;
        private System.Windows.Forms.CheckBox chkChannel205;
        private System.Windows.Forms.TextBox txtChannel205;
        private System.Windows.Forms.CheckBox chkChannel305;
        private System.Windows.Forms.TextBox txtChannel305;
        private System.Windows.Forms.CheckBox chkChannel106;
        private System.Windows.Forms.TextBox txtChannel106;
        private System.Windows.Forms.CheckBox chkChannel206;
        private System.Windows.Forms.TextBox txtChannel206;
        private System.Windows.Forms.CheckBox chkChannel306;
        private System.Windows.Forms.TextBox txtChannel306;
        private System.Windows.Forms.CheckBox chkChannel107;
        private System.Windows.Forms.TextBox txtChannel107;
        private System.Windows.Forms.CheckBox chkChannel207;
        private System.Windows.Forms.TextBox txtChannel207;
        private System.Windows.Forms.CheckBox chkChannel307;
        private System.Windows.Forms.TextBox txtChannel307;
        private System.Windows.Forms.CheckBox chkChannel108;
        private System.Windows.Forms.TextBox txtChannel108;
        private System.Windows.Forms.CheckBox chkChannel208;
        private System.Windows.Forms.TextBox txtChannel208;
        private System.Windows.Forms.CheckBox chkChannel308;
        private System.Windows.Forms.TextBox txtChannel308;
        private System.Windows.Forms.CheckBox chkChannel109;
        private System.Windows.Forms.TextBox txtChannel109;
        private System.Windows.Forms.CheckBox chkChannel209;
        private System.Windows.Forms.TextBox txtChannel209;
        private System.Windows.Forms.CheckBox chkChannel309;
        private System.Windows.Forms.TextBox txtChannel309;
        private System.Windows.Forms.CheckBox chkChannel110;
        private System.Windows.Forms.TextBox txtChannel110;
        private System.Windows.Forms.CheckBox chkChannel210;
        private System.Windows.Forms.TextBox txtChannel210;
        private System.Windows.Forms.CheckBox chkChannel310;
        private System.Windows.Forms.TextBox txtChannel310;
        private System.Windows.Forms.CheckBox chkChannel111;
        private System.Windows.Forms.TextBox txtChannel111;
        private System.Windows.Forms.CheckBox chkChannel211;
        private System.Windows.Forms.TextBox txtChannel211;
        private System.Windows.Forms.CheckBox chkChannel311;
        private System.Windows.Forms.TextBox txtChannel311;
        private System.Windows.Forms.CheckBox chkChannel112;
        private System.Windows.Forms.TextBox txtChannel112;
        private System.Windows.Forms.CheckBox chkChannel212;
        private System.Windows.Forms.TextBox txtChannel212;
        private System.Windows.Forms.CheckBox chkChannel312;
        private System.Windows.Forms.TextBox txtChannel312;
        private System.Windows.Forms.CheckBox chkChannel113;
        private System.Windows.Forms.TextBox txtChannel113;
        private System.Windows.Forms.CheckBox chkChannel213;
        private System.Windows.Forms.TextBox txtChannel213;
        private System.Windows.Forms.CheckBox chkChannel313;
        private System.Windows.Forms.TextBox txtChannel313;
        private System.Windows.Forms.CheckBox chkChannel114;
        private System.Windows.Forms.TextBox txtChannel114;
        private System.Windows.Forms.CheckBox chkChannel214;
        private System.Windows.Forms.TextBox txtChannel214;
        private System.Windows.Forms.CheckBox chkChannel314;
        private System.Windows.Forms.TextBox txtChannel314;
        private System.Windows.Forms.CheckBox chkChannel115;
        private System.Windows.Forms.TextBox txtChannel115;
        private System.Windows.Forms.CheckBox chkChannel215;
        private System.Windows.Forms.TextBox txtChannel215;
        private System.Windows.Forms.CheckBox chkChannel315;
        private System.Windows.Forms.TextBox txtChannel315;
        private System.Windows.Forms.CheckBox chkChannel116;
        private System.Windows.Forms.TextBox txtChannel116;
        private System.Windows.Forms.CheckBox chkChannel216;
        private System.Windows.Forms.TextBox txtChannel216;
        private System.Windows.Forms.CheckBox chkChannel316;
        private System.Windows.Forms.TextBox txtChannel316;
        private System.Windows.Forms.CheckBox chkChannel117;
        private System.Windows.Forms.TextBox txtChannel117;
        private System.Windows.Forms.CheckBox chkChannel217;
        private System.Windows.Forms.TextBox txtChannel217;
        private System.Windows.Forms.CheckBox chkChannel317;
        private System.Windows.Forms.TextBox txtChannel317;
        private System.Windows.Forms.CheckBox chkChannel118;
        private System.Windows.Forms.TextBox txtChannel118;
        private System.Windows.Forms.CheckBox chkChannel218;
        private System.Windows.Forms.TextBox txtChannel218;
        private System.Windows.Forms.CheckBox chkChannel318;
        private System.Windows.Forms.TextBox txtChannel318;
        private System.Windows.Forms.CheckBox chkChannel119;
        private System.Windows.Forms.TextBox txtChannel119;
        private System.Windows.Forms.CheckBox chkChannel219;
        private System.Windows.Forms.TextBox txtChannel219;
        private System.Windows.Forms.CheckBox chkChannel319;
        private System.Windows.Forms.TextBox txtChannel319;
        private System.Windows.Forms.CheckBox chkChannel120;
        private System.Windows.Forms.TextBox txtChannel120;
        private System.Windows.Forms.CheckBox chkChannel220;
        private System.Windows.Forms.TextBox txtChannel220;
        private System.Windows.Forms.CheckBox chkChannel320;
        private System.Windows.Forms.TextBox txtChannel320;
        private Panel panel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox LF_InnerOuterRing_TextBox;
        private TableLayoutPanel tableLayoutPanel2;
        private SplitContainer splitContainer3_LFControl;
        private SplitContainer splitContainer3;
        private GroupBox groupBoxLR_Power;
        private TableLayoutPanel tableLayoutPanel4;
        private CheckBox chkLR_PollingState;
        private TextBox LR_PollingState;
        private CheckBox chkLR_FreqControlFlag;
        private CheckBox chkLR_HeatFlag;
        private TextBox LR_FreqControlFlag;
        private TextBox LR_HeatFlag;
        private TextBox LR_HeatNTC2_TextBox;
        private CheckBox chkLR_HeatNTC2;
        private CheckBox chkLR_HeatNTC1;
        private TextBox LR_HeatNTC1_TextBox;
        private CheckBox chkLR_IGBTNTC1;
        private TextBox LR_IGBTNTC1_TextBox;
        private CheckBox chkLR_IGBTNTC2;
        private TextBox LR_ErrorCode;
        private TextBox LR_IGBTNTC2_TextBox;
        private CheckBox chkLR_PanTemp;
        private TextBox LR_PanTemp_TextBox;
        private CheckBox chkLR_Freq;
        private TextBox LR_Freq_TextBox;
        private CheckBox chkLR_ErrorCode;
        private CheckBox chkLR_Voltage;
        private TextBox LR_MCUTemp_TextBox;
        private TextBox LR_Voltage_TextBox;
        private CheckBox chkLR_Power;
        private CheckBox chkLR_MCUTemp;
        private TextBox LR_Power_TextBox;
        private SplitContainer splitContainer4;
        private SplitContainer splitContainer2;
        private GroupBox groupBoxLR_Display;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox LR_RequestPower_TextBox;
        private CheckBox chkLR_HeatingFreqFollow;
        private CheckBox chkLR_PanControlActive;
        private TextBox LR_HeatingFreqFollow_TextBox;
        private CheckBox chkLR_RequestPower;
        private TextBox LR_PanControlActive_TextBox;
        private TextBox LR_DebugChannel_TextBox;
        private CheckBox chkLR_InnerOuterRing;
        private TextBox LR_InnerOuterRing_TextBox;
        private CheckBox chkLR_DebugChannel;
        private CheckBox chkLR_PauseFlag;
        private TextBox LR_DebugSubChannel_TextBox;
        private TextBox LR_PauseFlag_TextBox;
        private CheckBox chkLR_allZone_BridgeHeatFlag;
        private CheckBox chkLR_DebugSubChannel;
        private TextBox LR_allZone_BridgeHeatFlag_TextBox;
        private TextBox LR_BridgeControl_TextBox;
        private CheckBox chkLR_PPGMode;
        private CheckBox chkLR_StoveSwitch;
        private CheckBox chkLR_BridgeControl;
        private TextBox LR_PPGMode_TextBox;
        private TextBox LR_FanLevel_TextBox;
        private TextBox LR_StoveSwitch_TextBox;
        private TextBox LR_AllowPanDetection_TextBox;
        private CheckBox chkLR_FanLevel;
        private CheckBox chkLR_AllowPanDetection;
        private TextBox LR_NoiseControl_TextBox;
        private CheckBox chkLR_HeatFreqJitterFlag;
        private TextBox LR_HeatFreqJitterFlag_TextBox;
        private CheckBox chkLR_NoiseControl;
        private Splitter splitter1;
        private SplitContainer splitContainer6;
        private GroupBox groupBox14;
        private TableLayoutPanel tableLayoutPanel7;
        private TextBox RR_RequestPower_TextBox;
        private CheckBox chkRR_HeatingFreqFollow;
        private CheckBox chkRR_PanControlActive;
        private TextBox RR_HeatingFreqFollow_TextBox;
        private CheckBox chkRR_RequestPower;
        private TextBox RR_PanControlActive_TextBox;
        private TextBox RR_DebugChannel_TextBox;
        private CheckBox chkRR_InnerOuterRing;
        private TextBox RR_InnerOuterRing_TextBox;
        private CheckBox chkRR_DebugChannel;
        private CheckBox chkRR_PauseFlag;
        private TextBox RR_DebugSubChannel_TextBox;
        private TextBox RR_PauseFlag_TextBox;
        private CheckBox chkRR_allZone_BridgeHeatFlag;
        private CheckBox chkRR_DebugSubChannel;
        private TextBox RR_allZone_BridgeHeatFlag_TextBox;
        private TextBox RR_BridgeControl_TextBox;
        private CheckBox chkRR_PPGMode;
        private CheckBox chkRR_StoveSwitch;
        private CheckBox chkRR_BridgeControl;
        private TextBox RR_PPGMode_TextBox;
        private TextBox RR_FanLevel_TextBox;
        private TextBox RR_StoveSwitch_TextBox;
        private TextBox RR_AllowPanDetection_TextBox;
        private CheckBox chkRR_FanLevel;
        private CheckBox chkRR_AllowPanDetection;
        private TextBox RR_NoiseControl_TextBox;
        private CheckBox chkRR_HeatFreqJitterFlag;
        private TextBox RR_HeatFreqJitterFlag_TextBox;
        private CheckBox chkRR_NoiseControl;
        private GroupBox groupBox6;
        private TableLayoutPanel tableLayoutPanel5;
        private TextBox RF_RequestPower_TextBox;
        private CheckBox chkRF_HeatingFreqFollow;
        private CheckBox chkRF_PanControlActive;
        private TextBox RF_HeatingFreqFollow_TextBox;
        private CheckBox chkRF_RequestPower;
        private TextBox RF_PanControlActive_TextBox;
        private TextBox RF_DebugChannel_TextBox;
        private CheckBox chkRF_InnerOuterRing;
        private TextBox RF_InnerOuterRing_TextBox;
        private CheckBox chkRF_DebugChannel;
        private CheckBox chkRF_PauseFlag;
        private TextBox RF_DebugSubChannel_TextBox;
        private TextBox RF_PauseFlag_TextBox;
        private CheckBox chkRF_allZone_BridgeHeatFlag;
        private CheckBox chkRF_DebugSubChannel;
        private TextBox RF_allZone_BridgeHeatFlag_TextBox;
        private TextBox RF_BridgeControl_TextBox;
        private CheckBox chkRF_PPGMode;
        private CheckBox chkRF_StoveSwitch;
        private CheckBox chkRF_BridgeControl;
        private TextBox RF_PPGMode_TextBox;
        private TextBox RF_FanLevel_TextBox;
        private TextBox RF_StoveSwitch_TextBox;
        private TextBox RF_AllowPanDetection_TextBox;
        private CheckBox chkRF_FanLevel;
        private CheckBox chkRF_AllowPanDetection;
        private TextBox RF_NoiseControl_TextBox;
        private CheckBox chkRF_HeatFreqJitterFlag;
        private TextBox RF_HeatFreqJitterFlag_TextBox;
        private CheckBox chkRF_NoiseControl;
        private SplitContainer splitContainer5;
        private GroupBox groupBox13;
        private TableLayoutPanel tableLayoutPanel6;
        private CheckBox chkRF_PollingState;
        private TextBox RF_PollingState;
        private CheckBox chkRF_FreqControlFlag;
        private CheckBox chkRF_HeatFlag;
        private TextBox RF_FreqControlFlag;
        private TextBox RF_HeatFlag;
        private TextBox RF_HeatNTC2_TextBox;
        private CheckBox chkRF_HeatNTC2;
        private CheckBox chkRF_HeatNTC1;
        private TextBox RF_HeatNTC1_TextBox;
        private CheckBox chkRF_IGBTNTC1;
        private TextBox RF_IGBTNTC1_TextBox;
        private CheckBox chkRF_IGBTNTC2;
        private TextBox RF_ErrorCode;
        private TextBox RF_IGBTNTC2_TextBox;
        private CheckBox chkRF_PanTemp;
        private TextBox RF_PanTemp_TextBox;
        private CheckBox chkRF_Freq;
        private TextBox RF_Freq_TextBox;
        private CheckBox chkRF_ErrorCode;
        private CheckBox chkRF_Voltage;
        private TextBox RF_MCUTemp_TextBox;
        private TextBox RF_Voltage_TextBox;
        private CheckBox chkRF_Power;
        private CheckBox chkRF_MCUTemp;
        private TextBox RF_Power_TextBox;
        private SplitContainer splitContainer12;
        private GroupBox groupBox15;
        private TableLayoutPanel tableLayoutPanel8;
        private CheckBox chkRR_PollingState;
        private TextBox RR_PollingState;
        private CheckBox chkRR_FreqControlFlag;
        private CheckBox chkRR_HeatFlag;
        private TextBox RR_FreqControlFlag;
        private TextBox RR_HeatFlag;
        private TextBox RR_HeatNTC2_TextBox;
        private CheckBox chkRR_HeatNTC2;
        private CheckBox chkRR_HeatNTC1;
        private TextBox RR_HeatNTC1_TextBox;
        private CheckBox chkRR_IGBTNTC1;
        private TextBox RR_IGBTNTC1_TextBox;
        private CheckBox chkRR_IGBTNTC2;
        private TextBox RR_ErrorCode;
        private TextBox RR_IGBTNTC2_TextBox;
        private CheckBox chkRR_PanTemp;
        private TextBox RR_PanTemp_TextBox;
        private CheckBox chkRR_Freq;
        private TextBox RR_Freq_TextBox;
        private CheckBox chkRR_ErrorCode;
        private CheckBox chkRR_Voltage;
        private TextBox RR_MCUTemp_TextBox;
        private TextBox RR_Voltage_TextBox;
        private CheckBox chkRR_Power;
        private CheckBox chkRR_MCUTemp;
        private TextBox RR_Power_TextBox;
        private SplitContainer splitContainer13;
        private GroupBox groupBox5;
        private TableLayoutPanel tableLayoutPanel9;
        private TextBox CLF_RequestPower_TextBox;
        private CheckBox chkCLF_HeatingFreqFollow;
        private CheckBox chkCLF_PanControlActive;
        private TextBox CLF_HeatingFreqFollow_TextBox;
        private CheckBox chkCLF_RequestPower;
        private TextBox CLF_PanControlActive_TextBox;
        private TextBox CLF_DebugChannel_TextBox;
        private CheckBox chkCLF_InnerOuterRing;
        private TextBox CLF_InnerOuterRing_TextBox;
        private CheckBox chkCLF_DebugChannel;
        private CheckBox chkCLF_PauseFlag;
        private TextBox CLF_DebugSubChannel_TextBox;
        private TextBox CLF_PauseFlag_TextBox;
        private CheckBox chkCLF_allZone_BridgeHeatFlag;
        private CheckBox chkCLF_DebugSubChannel;
        private TextBox CLF_allZone_BridgeHeatFlag_TextBox;
        private TextBox CLF_BridgeControl_TextBox;
        private CheckBox chkCLF_PPGMode;
        private CheckBox chkCLF_StoveSwitch;
        private CheckBox chkCLF_BridgeControl;
        private TextBox CLF_PPGMode_TextBox;
        private TextBox CLF_FanLevel_TextBox;
        private TextBox CLF_StoveSwitch_TextBox;
        private TextBox CLF_AllowPanDetection_TextBox;
        private CheckBox chkCLF_FanLevel;
        private CheckBox chkCLF_AllowPanDetection;
        private TextBox CLF_NoiseControl_TextBox;
        private CheckBox chkCLF_HeatFreqJitterFlag;
        private TextBox CLF_HeatFreqJitterFlag_TextBox;
        private CheckBox chkCLF_NoiseControl;
        private SplitContainer splitContainer7;
        private GroupBox groupBox7;
        private TableLayoutPanel tableLayoutPanel10;
        private CheckBox chkCLF_PollingState;
        private TextBox CLF_PollingState;
        private CheckBox chkCLF_FreqControlFlag;
        private CheckBox chkCLF_HeatFlag;
        private TextBox CLF_FreqControlFlag;
        private TextBox CLF_HeatFlag;
        private TextBox CLF_HeatNTC2_TextBox;
        private CheckBox chkCLF_HeatNTC2;
        private CheckBox chkCLF_HeatNTC1;
        private TextBox CLF_HeatNTC1_TextBox;
        private CheckBox chkCLF_IGBTNTC1;
        private TextBox CLF_IGBTNTC1_TextBox;
        private CheckBox chkCLF_IGBTNTC2;
        private TextBox CLF_ErrorCode;
        private TextBox CLF_IGBTNTC2_TextBox;
        private CheckBox chkCLF_PanTemp;
        private TextBox CLF_PanTemp_TextBox;
        private CheckBox chkCLF_Freq;
        private TextBox CLF_Freq_TextBox;
        private CheckBox chkCLF_ErrorCode;
        private CheckBox chkCLF_Voltage;
        private TextBox CLF_MCUTemp_TextBox;
        private TextBox CLF_Voltage_TextBox;
        private CheckBox chkCLF_Power;
        private CheckBox chkCLF_MCUTemp;
        private TextBox CLF_Power_TextBox;
        private SplitContainer splitContainer8;
        private GroupBox groupBox8;
        private TableLayoutPanel tableLayoutPanel11;
        private TextBox CLR_RequestPower_TextBox;
        private CheckBox chkCLR_HeatingFreqFollow;
        private CheckBox chkCLR_PanControlActive;
        private TextBox CLR_HeatingFreqFollow_TextBox;
        private CheckBox chkCLR_RequestPower;
        private TextBox CLR_PanControlActive_TextBox;
        private TextBox CLR_DebugChannel_TextBox;
        private CheckBox chkCLR_InnerOuterRing;
        private TextBox CLR_InnerOuterRing_TextBox;
        private CheckBox chkCLR_DebugChannel;
        private CheckBox chkCLR_PauseFlag;
        private TextBox CLR_DebugSubChannel_TextBox;
        private TextBox CLR_PauseFlag_TextBox;
        private CheckBox chkCLR_allZone_BridgeHeatFlag;
        private CheckBox chkCLR_DebugSubChannel;
        private TextBox CLR_allZone_BridgeHeatFlag_TextBox;
        private TextBox CLR_BridgeControl_TextBox;
        private CheckBox chkCLR_PPGMode;
        private CheckBox chkCLR_StoveSwitch;
        private CheckBox chkCLR_BridgeControl;
        private TextBox CLR_PPGMode_TextBox;
        private TextBox CLR_FanLevel_TextBox;
        private TextBox CLR_StoveSwitch_TextBox;
        private TextBox CLR_AllowPanDetection_TextBox;
        private CheckBox chkCLR_FanLevel;
        private CheckBox chkCLR_AllowPanDetection;
        private TextBox CLR_NoiseControl_TextBox;
        private CheckBox chkCLR_HeatFreqJitterFlag;
        private TextBox CLR_HeatFreqJitterFlag_TextBox;
        private CheckBox chkCLR_NoiseControl;
        private GroupBox groupBox9;
        private TableLayoutPanel tableLayoutPanel12;
        private CheckBox chkCLR_PollingState;
        private TextBox CLR_PollingState;
        private CheckBox chkCLR_FreqControlFlag;
        private CheckBox chkCLR_HeatFlag;
        private TextBox CLR_FreqControlFlag;
        private TextBox CLR_HeatFlag;
        private TextBox CLR_HeatNTC2_TextBox;
        private CheckBox chkCLR_HeatNTC2;
        private CheckBox chkCLR_HeatNTC1;
        private TextBox CLR_HeatNTC1_TextBox;
        private CheckBox chkCLR_IGBTNTC1;
        private TextBox CLR_IGBTNTC1_TextBox;
        private CheckBox chkCLR_IGBTNTC2;
        private TextBox CLR_ErrorCode;
        private TextBox CLR_IGBTNTC2_TextBox;
        private CheckBox chkCLR_PanTemp;
        private TextBox CLR_PanTemp_TextBox;
        private CheckBox chkCLR_Freq;
        private TextBox CLR_Freq_TextBox;
        private CheckBox chkCLR_ErrorCode;
        private CheckBox chkCLR_Voltage;
        private TextBox CLR_MCUTemp_TextBox;
        private TextBox CLR_Voltage_TextBox;
        private CheckBox chkCLR_Power;
        private CheckBox chkCLR_MCUTemp;
        private TextBox CLR_Power_TextBox;
        private TextBox LF_ReserveD8_TextBox;
        private TextBox LF_ReserveD7_TextBox;
        private TextBox LF_Disp_ReserveD1B7_TextBox;
        private TextBox LF_Disp_ReserveD1B6_TextBox;
        private CheckBox chkLF_ReserveD8;
        private CheckBox chkLF_ReserveD7;
        private CheckBox chkLF_Disp_ReserveD1B7;
        private CheckBox chkLF_Disp_ReserveD1B6;
        private TextBox LF_ReserveD16_TextBox;
        private TextBox LF_ReserveD15_TextBox;
        private TextBox LF_ReserveD14_TextBox;
        private TextBox LF_Power_ReserveD1B7_TextBox;
        private TextBox LF_Power_ReserveD1B6_TextBox;
        private CheckBox chkLF_Power_ReserveD1B6;
        private CheckBox chkLF_Power_ReserveD1B7;
        private CheckBox chkLF_ReserveD14;
        private CheckBox chkLF_ReserveD15;
        private CheckBox chkLF_ReserveD16;
        private CheckBox chkLR_ReserveD8;
        private CheckBox chkLR_ReserveD7;
        private CheckBox chkLR_Disp_ReserveD1B7;
        private CheckBox chkLR_Disp_ReserveD1B6;
        private TextBox LR_ReserveD8_TextBox;
        private TextBox LR_ReserveD7_TextBox;
        private TextBox LR_Disp_ReserveD1B7_TextBox;
        private TextBox LR_Disp_ReserveD1B6_TextBox;
        private CheckBox chkLR_ReserveD15;
        private CheckBox chkLR_Power_ReserveD1B6;
        private CheckBox chkLR_Power_ReserveD1B7;
        private CheckBox chkLR_ReserveD14;
        private TextBox LR_ReserveD16_TextBox;
        private TextBox LR_ReserveD15_TextBox;
        private TextBox LR_ReserveD14_TextBox;
        private CheckBox chkLR_ReserveD16;
        private TextBox LR_Power_ReserveD1B6_TextBox;
        private TextBox LR_Power_ReserveD1B7_TextBox;
        private TextBox RF_ReserveD8_TextBox;
        private TextBox RF_ReserveD7_TextBox;
        private TextBox RF_Disp_ReserveD1B7_TextBox;
        private TextBox RF_Disp_ReserveD1B6_TextBox;
        private CheckBox chkRF_ReserveD8;
        private CheckBox chkRF_ReserveD7;
        private CheckBox chkRF_Disp_ReserveD1B7;
        private CheckBox chkRF_Disp_ReserveD1B6;
        private CheckBox chkRF_ReserveD16;
        private CheckBox chkRF_ReserveD15;
        private CheckBox chkRF_ReserveD14;
        private CheckBox chkRF_Power_ReserveD1B7;
        private CheckBox chkRF_Power_ReserveD1B6;
        private TextBox RF_ReserveD16_TextBox;
        private TextBox RF_ReserveD15_TextBox;
        private TextBox RF_ReserveD14_TextBox;
        private TextBox RF_Power_ReserveD1B7_TextBox;
        private TextBox RF_Power_ReserveD1B6_TextBox;
        private TextBox RR_ReserveD8_TextBox;
        private TextBox RR_ReserveD7_TextBox;
        private TextBox RR_Disp_ReserveD1B7_TextBox;
        private TextBox RR_Disp_ReserveD1B6_TextBox;
        private CheckBox chkRR_ReserveD8;
        private CheckBox chkRR_ReserveD7;
        private CheckBox chkRR_Disp_ReserveD1B7;
        private CheckBox chkRR_Disp_ReserveD1B6;
        private TextBox RR_ReserveD16_TextBox;
        private TextBox RR_ReserveD15_TextBox;
        private TextBox RR_ReserveD14_TextBox;
        private TextBox RR_Power_ReserveD1B7_TextBox;
        private TextBox RR_Power_ReserveD1B6_TextBox;
        private CheckBox chkRR_ReserveD16;
        private CheckBox chkRR_ReserveD15;
        private CheckBox chkRR_ReserveD14;
        private CheckBox chkRR_Power_ReserveD1B7;
        private CheckBox chkRR_Power_ReserveD1B6;
        private TextBox CLF_ReserveD8_TextBox;
        private TextBox CLF_ReserveD7_TextBox;
        private TextBox CLF_Disp_ReserveD1B7_TextBox;
        private TextBox CLF_Disp_ReserveD1B6_TextBox;
        private CheckBox chkCLF_ReserveD8;
        private CheckBox chkCLF_ReserveD7;
        private CheckBox chkCLF_Disp_ReserveD1B7;
        private CheckBox chkCLF_Disp_ReserveD1B6;
        private TextBox CLF_ReserveD16_TextBox;
        private TextBox CLF_ReserveD15_TextBox;
        private TextBox CLF_ReserveD14_TextBox;
        private TextBox CLF_Power_ReserveD1B7_TextBox;
        private TextBox CLF_Power_ReserveD1B6_TextBox;
        private CheckBox chkCLF_ReserveD16;
        private CheckBox chkCLF_ReserveD15;
        private CheckBox chkCLF_ReserveD14;
        private CheckBox chkCLF_Power_ReserveD1B7;
        private CheckBox chkCLF_Power_ReserveD1B6;
        private TextBox CLR_ReserveD8_TextBox;
        private TextBox CLR_ReserveD7_TextBox;
        private TextBox CLR_Disp_ReserveD1B7_TextBox;
        private TextBox CLR_Disp_ReserveD1B6_TextBox;
        private CheckBox chkCLR_ReserveD8;
        private CheckBox chkCLR_ReserveD7;
        private CheckBox chkCLR_Disp_ReserveD1B7;
        private CheckBox chkCLR_Disp_ReserveD1B6;
        private TextBox CLR_ReserveD16_TextBox;
        private TextBox CLR_ReserveD15_TextBox;
        private TextBox CLR_ReserveD14_TextBox;
        private TextBox CLR_Power_ReserveD1B7_TextBox;
        private TextBox CLR_Power_ReserveD1B6_TextBox;
        private CheckBox chkCLR_ReserveD16;
        private CheckBox chkCLR_ReserveD15;
        private CheckBox chkCLR_ReserveD14;
        private CheckBox chkCLR_Power_ReserveD1B7;
        private CheckBox chkCLR_Power_ReserveD1B6;
        private Panel panel1;
        private DataGridViewTextBoxColumn Column_Time;
        private DataGridViewTextBoxColumn Column_Ua;
        private DataGridViewTextBoxColumn Column_Ub;
        private DataGridViewTextBoxColumn Column_Uc;
        private DataGridViewTextBoxColumn Column_Ia;
        private DataGridViewTextBoxColumn Column_Ib;
        private DataGridViewTextBoxColumn Column_Ic;
        private DataGridViewTextBoxColumn Column_P;
        private DataGridViewTextBoxColumn Column_Freq;
        private DataGridViewTextBoxColumn Column_En;
        private CheckBox chkChannel1;
        private CheckBox chkChannel3;
        private CheckBox chkChannel2;
        private TableLayoutPanel tlpTempChannels;
        private TableLayoutPanel tableLayoutPanel13;
        private TabControl tabControl1;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private Button btnCapture;
        private Button btnSaveConfigure;
        private Button btnLoadConfigure;
        private SplitContainer splitContainer10;
        private SplitContainer splitContainer9;
        private TreeView treeView1;
        private Button btnToggleSettings;
        private TabControl tabControl2;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private TableLayoutPanel tableLayoutPanel14;
        private TextBox tbUSBPcapPath;
        private Button btnaddress;
        private Label label2;
        private Label label10;
        private ComboBox Disp_comboBoxBaudRate;
        private Label label8;
        private TextBox txtRecordInterval;
        private Label label11;
        private ComboBox Ctrl_comboBoxBaudRate;
        private Label label12;
        private ComboBox cmbUploadBaudRate;
        private Label label9;
        private TextBox txtAutoDisconnect;
        private Label label13;
        private ComboBox cmbTempDevice;
        private Label label14;
        private ComboBox cmbPowerDevice;
        private CheckBox cbDebugMode;
        private SplitContainer splitContainer11;
        private Button btUploadName;
    }
}