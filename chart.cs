using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DA
{
    public enum ChartAxisType { Primary, Secondary }

    public class ChartManager
    {
        // 图表核心组件
        private Chart chart;
        private readonly Dictionary<string, Series> seriesDict = new Dictionary<string, Series>();

        // 颜色和样式相关
        private readonly List<Color> ColorList = new List<Color>(); //颜色列表
        private int nextColorIndex = 0; //颜色索引
        private readonly Dictionary<string, Color> originalColors = new Dictionary<string, Color>();
        private readonly Dictionary<string, int> originalLineWidths = new Dictionary<string, int>();
        private string highlightedSeries = null;

        // 配置常量
        private const int MAX_DATA_POINTS = 3600; // 每条曲线最多保留的数据点数
        private const int DEFAULT_LINE_WIDTH = 1; // 默认线宽
        private const int HIGHLIGHT_LINE_WIDTH = 3; // 高亮时的线宽
        private const int FADE_ALPHA = 20; // 淡化时的透明度 (0-255),越低越淡
        private const double AUTO_SCROLL_WINDOW_MINUTES = 10; // 自动滚动窗口大小（分钟）

        // 缩放相关常量
        private const double ZOOM_FACTOR = 1.2; // 缩放X轴，例子：1.2表示放大1.2倍，0.8表示缩小0.8倍
        private const double Y_ZOOM_FACTOR = 2; // 缩放Y轴
        private const double MIN_ZOOM_RANGE_SECONDS = 10; // 最小缩放范围（秒），例子：10表示最小缩放范围为10秒
        private const double MAX_ZOOM_RANGE_HOURS = 2; // 最大缩放范围（小时）

        // 鼠标交互相关
        private bool isLeftMouseDragging = false;
        private Point lastMousePosition;

        // 数据采样相关
        private readonly Dictionary<string, DateTime> lastSampleTime = new Dictionary<string, DateTime>();
        private readonly Dictionary<string, double> lastSampleValue = new Dictionary<string, double>();
        private readonly TimeSpan sampleInterval = TimeSpan.FromSeconds(1); // 1秒采样间隔

        public ChartManager(Chart chartControl)
        {
            chart = chartControl;
            InitializeColor();
            SetupChart();
            AttachEvents();
        }

        // 初始化颜色列表
        private void InitializeColor()
        {
            ColorList.AddRange(new Color[]
            {
                Color.FromArgb(0, 255, 255),
                Color.FromArgb(255, 80, 80),
                Color.FromArgb(80, 255, 80),
                Color.FromArgb(255, 255, 80),
                Color.FromArgb(255, 128, 255),
                Color.FromArgb(128, 128, 255),
                Color.FromArgb(255, 165, 0),
                Color.FromArgb(200, 100, 255),
                Color.FromArgb(100, 255, 200),
                Color.FromArgb(255, 100, 150),
                Color.FromArgb(150, 255, 100),
                Color.FromArgb(100, 150, 255),
                Color.FromArgb(255, 200, 100),
                Color.FromArgb(200, 255, 100),
                Color.FromArgb(100, 200, 255),
                Color.FromArgb(255, 100, 200),
                Color.FromArgb(200, 100, 200),
                Color.FromArgb(100, 255, 150),
                Color.FromArgb(150, 100, 255),
                Color.FromArgb(255, 150, 100),
            });
        }

        // 设置图表的基本样式和外观
        private void SetupChart()
        {
            // 清空默认设置
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

            // 创建主图表区域
            ChartArea mainArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(mainArea);

            // 设置深色主题背景
            chart.BackColor = Color.Black;
            mainArea.BackColor = Color.Black;

            // 设置区域位置和大小
            mainArea.Position.X = 0;
            mainArea.Position.Y = 0;
            mainArea.Position.Width = 100;
            mainArea.Position.Height = 100;

            // 设置主区域的坐标轴样式
            SetupAxis(mainArea.AxisX, "", ChartAxisType.Primary);
            SetupAxis(mainArea.AxisY, "温度/电流/频率", ChartAxisType.Primary);
            SetupAxis(mainArea.AxisY2, "电压/AD/功率", ChartAxisType.Secondary);

            // 设置网格线样式
            mainArea.AxisX.MajorGrid.LineColor = Color.FromArgb(40, 40, 40);
            mainArea.AxisY.MajorGrid.LineColor = Color.FromArgb(40, 40, 40);

            // 设置图例
            Legend legend = new Legend("MainLegend")
            {
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Microsoft YaHei", 8),
                Docking = Docking.Top,
                Alignment = StringAlignment.Far
            };
            chart.Legends.Add(legend);

            // 设置默认坐标轴范围
            SetDefaultAxisRanges();
        }

        // 设置坐标轴为默认范围
        private void SetDefaultAxisRanges()
        {
            DateTime now = DateTime.Now;
            // DateTime startTime = now.AddMinutes(-AUTO_SCROLL_WINDOW_MINUTES);
            DateTime endTime = now.AddMinutes(+AUTO_SCROLL_WINDOW_MINUTES);
            double minX = now.ToOADate();
            double maxX = endTime.ToOADate();

            // 设置默认X轴范围
            ChartArea mainArea = chart.ChartAreas["MainArea"];
            mainArea.AxisX.Minimum = minX;
            mainArea.AxisX.Maximum = maxX;

            // 启用Y轴自动缩放
            mainArea.AxisY.IsStartedFromZero = false;
            mainArea.AxisY2.IsStartedFromZero = false;

            // 设置初始Y轴范围，但允许自动调整
            mainArea.AxisY.Minimum = Double.NaN; // 自动计算最小值
            mainArea.AxisY.Maximum = Double.NaN; // 自动计算最大值

            mainArea.AxisY2.Minimum = Double.NaN;
            mainArea.AxisY2.Maximum = Double.NaN;
        }

        // 设置坐标轴样式
        private void SetupAxis(Axis axis, string title, ChartAxisType axisType)
        {
            axis.Title = title;
            axis.TitleForeColor = Color.Gainsboro;
            axis.TitleFont = new Font("Microsoft YaHei", 9, FontStyle.Bold);

            axis.LabelStyle.ForeColor = Color.Gainsboro;
            axis.LabelStyle.Font = new Font("Microsoft YaHei", 8);

            axis.LineColor = Color.FromArgb(80, 80, 80);
            axis.MajorTickMark.LineColor = Color.FromArgb(80, 80, 80);

            if (axis.AxisName == AxisName.X)
            {
                axis.LabelStyle.Format = "HH:mm:ss";
                axis.IntervalType = DateTimeIntervalType.Auto;
            }

            if (axisType == ChartAxisType.Secondary)
            {
                axis.Enabled = AxisEnabled.True;
                axis.MajorGrid.Enabled = false;
            }
        }

        // 绑定鼠标事件        
        private void AttachEvents()
        {
            chart.MouseMove += Chart_MouseMove;
            chart.MouseLeave += Chart_MouseLeave;
            chart.MouseDown += Chart_MouseDown;
            chart.MouseUp += Chart_MouseUp;
            chart.MouseWheel += Chart_MouseWheel;
            chart.MouseDoubleClick += Chart_MouseDoubleClick;
        }

        private Color GetNextColor()
        {
            Color color = ColorList[nextColorIndex % ColorList.Count];
            nextColorIndex++;
            return color;
        }

        // 显示指定曲线        
        public void ShowSeries(string seriesName, ChartAxisType axisType)
        {
            if (!seriesDict.ContainsKey(seriesName))
            {
                CreateSeries(seriesName, axisType);
            }

            seriesDict[seriesName].Enabled = true;
        }

        // 隐藏指定曲线        
        public void HideSeries(string seriesName)
        {
            if (seriesDict.ContainsKey(seriesName))
            {
                seriesDict[seriesName].Enabled = false;
            }
        }

        // 重命名曲线
        public void RenameSeries(string oldSeriesName, string newSeriesName)
        {
            // 如果旧曲线不存在或新曲线名称已存在，则不执行任何操作
            if (!seriesDict.ContainsKey(oldSeriesName) || seriesDict.ContainsKey(newSeriesName))
            {
                return;
            }

            // 获取旧曲线对象
            Series series = seriesDict[oldSeriesName];

            // 更新图表和字典中的名称
            series.Name = newSeriesName;
            seriesDict.Remove(oldSeriesName);
            seriesDict[newSeriesName] = series;

            // 更新颜色和线宽字典的键
            if (originalColors.ContainsKey(oldSeriesName))
            {
                originalColors[newSeriesName] = originalColors[oldSeriesName];
                originalColors.Remove(oldSeriesName);
            }
            if (originalLineWidths.ContainsKey(oldSeriesName))
            {
                originalLineWidths[newSeriesName] = originalLineWidths[oldSeriesName];
                originalLineWidths.Remove(oldSeriesName);
            }
            if (lastSampleTime.ContainsKey(oldSeriesName))
            {
                lastSampleTime[newSeriesName] = lastSampleTime[oldSeriesName];
                lastSampleTime.Remove(oldSeriesName);
            }
            if (lastSampleValue.ContainsKey(oldSeriesName))
            {
                lastSampleValue[newSeriesName] = lastSampleValue[oldSeriesName];
                lastSampleValue.Remove(oldSeriesName);
            }
        }

        // 创建新的数据曲线        
        private void CreateSeries(string seriesName, ChartAxisType axisType)
        {
            string chartAreaName = "MainArea";
            AxisType yAxisType;

            // 根据轴类型选择Y轴类型
            switch (axisType)
            {
                case ChartAxisType.Primary:
                    yAxisType = AxisType.Primary;
                    break;
                case ChartAxisType.Secondary:
                default:
                    yAxisType = AxisType.Secondary;
                    break;
            }

            Series series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Line,
                ChartArea = chartAreaName,
                Legend = "MainLegend",
                YAxisType = yAxisType,// 根据数据类型选择主次Y轴
                XValueType = ChartValueType.DateTime, //X轴类型为日期时间
                Enabled = false // 新创建的曲线默认隐藏，通过复选框控制数据添加和显示
            };

            // 设置线条样式
            Color color = GetNextColor();
            series.Color = color;
            series.BorderWidth = DEFAULT_LINE_WIDTH;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 5;

            // 保存原始样式
            originalColors[seriesName] = color;
            originalLineWidths[seriesName] = DEFAULT_LINE_WIDTH;

            chart.Series.Add(series);
            seriesDict[seriesName] = series;
        }

        // 添加或更新数据点        
        public void AddOrUpdateData(string seriesName, DateTime timestamp, double value, ChartAxisType axisType)
        {
            if (!seriesDict.ContainsKey(seriesName))
            {
                // TreeView控制显示
                CreateSeries(seriesName, axisType);
            }

            Series series = seriesDict[seriesName];

            // 1秒间隔采样控制
            bool shouldAddPoint = false;

            if (!lastSampleTime.ContainsKey(seriesName))
            {
                // 添加第一个数据点
                shouldAddPoint = true;
            }
            else
            {
                // 检查数据时间戳是否超过采样间隔
                if ((timestamp - lastSampleTime[seriesName]) >= sampleInterval)
                {
                    shouldAddPoint = true;
                }
                else
                {
                    lastSampleValue[seriesName] = value;
                    return;
                }
            }

            if (shouldAddPoint)
            {
                try
                {
                    // 使用最新的数据值
                    double valueToAdd = lastSampleValue.ContainsKey(seriesName) ? lastSampleValue[seriesName] : value;

                    // 添加数据点
                    series.Points.AddXY(timestamp, valueToAdd);

                    if (series.Points.Count > MAX_DATA_POINTS)
                    {
                        series.Points.RemoveAt(0);
                    }

                    // 更新采样时间和值
                    lastSampleTime[seriesName] = timestamp;
                    lastSampleValue[seriesName] = value;

                    // 只有启用的系列才影响Y轴范围调整
                    if (series.Enabled)
                    {
                        AutoAdjustAxisRanges();
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"添加图表数据时出错: {ex.Message}");
                }
            }
        }

        // 自动调整坐标轴范围
        private void AutoAdjustAxisRanges()
        {
            try
            {
                if (chart.Series.Count == 0) return;

                ChartArea mainArea = chart.ChartAreas["MainArea"];

                // 自动调整Y轴范围
                AutoAdjustYAxisRanges(mainArea);
            }
            catch { }
        }

        // 自动调整Y轴范围
        private void AutoAdjustYAxisRanges(ChartArea area)
        {
            double primaryMin = double.MaxValue;
            double primaryMax = double.MinValue;
            double secondaryMin = double.MaxValue;
            double secondaryMax = double.MinValue;

            bool hasPrimaryData = false;
            bool hasSecondaryData = false;

            // 获取当前时间窗口内的数据范围
            double xMin = area.AxisX.Minimum;
            double xMax = area.AxisX.Maximum;

            foreach (Series series in chart.Series)
            {
                if (!series.Enabled || series.Points.Count == 0) continue;

                // 只考虑当前时间窗口内的数据点
                var windowPoints = series.Points.Where(p => p.XValue >= xMin && p.XValue <= xMax);

                if (!windowPoints.Any()) continue;

                double seriesMin = windowPoints.Min(p => p.YValues[0]);
                double seriesMax = windowPoints.Max(p => p.YValues[0]);

                if (series.YAxisType == AxisType.Primary)
                {
                    primaryMin = Math.Min(primaryMin, seriesMin);
                    primaryMax = Math.Max(primaryMax, seriesMax);
                    hasPrimaryData = true;
                }
                else if (series.YAxisType == AxisType.Secondary)
                {
                    secondaryMin = Math.Min(secondaryMin, seriesMin);
                    secondaryMax = Math.Max(secondaryMax, seriesMax);
                    hasSecondaryData = true;
                }
            }

            // 设置主Y轴范围
            if (hasPrimaryData)
            {
                double range = primaryMax - primaryMin;
                double margin = Math.Max(range * 0.1, 1); // 10%边距，最小1个单位

                area.AxisY.Minimum = primaryMin - margin;
                area.AxisY.Maximum = primaryMax + margin;
            }

            // 设置次Y轴范围
            if (hasSecondaryData)
            {
                double range = secondaryMax - secondaryMin;
                double margin = Math.Max(range * 0.1, 1); // 10%边距，最小1个单位

                area.AxisY2.Minimum = secondaryMin - margin;
                area.AxisY2.Maximum = secondaryMax + margin;
            }
        }

        // 清空所有数据      
        public void Clear()
        {
            foreach (Series series in chart.Series)
            {
                series.Points.Clear();
            }

            // 重置高亮状态
            ClearHighlight();

            // 清空数据后，重置坐标轴到默认视图
            SetDefaultAxisRanges();
        }

        // 鼠标移动事件处理
        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                // 处理左键拖拽
                if (isLeftMouseDragging)
                {
                    int deltaX = e.X - lastMousePosition.X;
                    int deltaY = e.Y - lastMousePosition.Y;
                    PanChart(deltaX, deltaY, e.X);
                    lastMousePosition = e.Location;
                    return;
                }

                // 只有在没有拖拽时才处理数据点高亮
                HitTestResult result = chart.HitTest(e.X, e.Y);

                if (result.ChartElementType == ChartElementType.DataPoint &&
                    result.Series != null && result.Series.Enabled)
                {
                    string seriesName = result.Series.Name;

                    // 不需要重复处理
                    if (highlightedSeries == seriesName) return;

                    HighlightSeries(seriesName, result.PointIndex);
                }
                else
                {
                    // 鼠标不在任何数据点上，清除高亮
                    if (highlightedSeries != null)
                    {
                        ClearHighlight();
                    }
                }
            }
            catch
            {
            }
        }

        // 鼠标离开事件处理       
        private void Chart_MouseLeave(object sender, EventArgs e)
        {
            ClearHighlight();
            isLeftMouseDragging = false; // 鼠标离开时停止拖拽
        }

        // 鼠标按下事件处理
        private void Chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftMouseDragging = true;
                lastMousePosition = e.Location;
                chart.Cursor = Cursors.Hand;

                // 开始拖拽时清除高亮效果
                ClearHighlight();
            }
        }

        // 鼠标释放事件处理
        private void Chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftMouseDragging = false;
                chart.Cursor = Cursors.Default;
            }
        }

        // 鼠标滚轮事件处理 - 缩放功能
        private void Chart_MouseWheel(object sender, MouseEventArgs e)
        {
            ChartArea area = chart.ChartAreas["MainArea"];
            // 检查是否按住Ctrl键来决定缩放Y轴还是X轴
            bool isCtrlPressed = Control.ModifierKeys == Keys.Control;
            bool zoomIn = e.Delta > 0;

            if (isCtrlPressed)
            {
                // Ctrl + 滚轮：缩放Y轴
                ZoomYAxis(e.X, e.Y, zoomIn);
            }
            else
            {
                // 滚轮：缩放X轴（时间）
                double mouseXValue = area.AxisX.PixelPositionToValue(e.X);
                ZoomXAxis(mouseXValue, zoomIn);
            }
        }

        // 鼠标双击事件处理 - 重置缩放
        private void Chart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ResetZoom();
        }

        // 高亮指定曲线       
        private void HighlightSeries(string seriesName, int pointIndex)
        {
            // 清除之前的高亮
            ClearHighlight();

            highlightedSeries = seriesName;

            foreach (var kvp in seriesDict)
            {
                Series series = kvp.Value;
                if (!series.Enabled) continue;

                if (kvp.Key == seriesName)
                {
                    // 高亮当前曲线
                    series.BorderWidth = HIGHLIGHT_LINE_WIDTH;
                    series.Color = originalColors[kvp.Key];

                    // 显示数据点标签
                    if (pointIndex >= 0 && pointIndex < series.Points.Count)
                    {
                        series.Points[pointIndex].Label = series.Points[pointIndex].YValues[0].ToString("F2");
                        series.Points[pointIndex].LabelForeColor = Color.White;
                        series.Points[pointIndex].LabelBackColor = Color.FromArgb(150, 0, 0, 0);
                    }
                }
                else
                {
                    // 淡化其他曲线
                    Color fadeColor = Color.FromArgb(FADE_ALPHA, originalColors[kvp.Key]);
                    series.Color = fadeColor;
                    series.BorderWidth = originalLineWidths[kvp.Key];
                }
            }
        }

        // 清除高亮效果       
        private void ClearHighlight()
        {
            highlightedSeries = null;

            foreach (var kvp in seriesDict)
            {
                Series series = kvp.Value;
                if (!series.Enabled) continue;

                // 恢复原始样式
                series.Color = originalColors[kvp.Key];
                series.BorderWidth = originalLineWidths[kvp.Key];

                // 清除所有标签
                foreach (DataPoint point in series.Points)
                {
                    point.Label = "";
                }
            }
        }

        // 移除指定曲线       
        public void RemoveSeries(string seriesName)
        {
            if (seriesDict.ContainsKey(seriesName))
            {
                chart.Series.Remove(seriesDict[seriesName]);
                seriesDict.Remove(seriesName);
                originalColors.Remove(seriesName);
                originalLineWidths.Remove(seriesName);
                lastSampleTime.Remove(seriesName);
                lastSampleValue.Remove(seriesName);

                if (highlightedSeries == seriesName)
                {
                    ClearHighlight();
                }
            }
        }

        // 获取所有曲线名称
        public List<string> GetAllSeriesNames()
        {
            return seriesDict.Keys.ToList();
        }

        // 检查曲线是否存在且启用
        public bool IsSeriesEnabled(string seriesName)
        {
            return seriesDict.ContainsKey(seriesName) && seriesDict[seriesName].Enabled;
        }

        // 平移图表
        private void PanChart(int deltaX, int deltaY, int mouseX)
        {
            ChartArea area = chart.ChartAreas["MainArea"];

            // 平移X轴
            if (deltaX != 0)
            {
                double panRatioX = deltaX / (double)chart.Width;
                var xAxis = area.AxisX;

                double axisMin = xAxis.Minimum;
                double axisMax = xAxis.Maximum;
                double axisRange = axisMax - axisMin;

                double panAmount = axisRange * panRatioX;

                xAxis.Minimum = axisMin - panAmount;
                xAxis.Maximum = axisMax - panAmount;
            }

            // 平移Y轴
            if (deltaY != 0)
            {
                double panRatioY = deltaY / (double)chart.Height;

                // 平移主Y轴
                PanSingleYAxis(area.AxisY, panRatioY);

                // 平移次Y轴
                if (area.AxisY2.Enabled == AxisEnabled.True)
                {
                    PanSingleYAxis(area.AxisY2, panRatioY);
                }
            }
        }

        // 平移单个Y轴
        private void PanSingleYAxis(Axis yAxis, double panRatio)
        {
            // 获取当前轴范围
            if (double.IsNaN(yAxis.Minimum) || double.IsNaN(yAxis.Maximum))
            {
                yAxis.Minimum = yAxis.Minimum;
                yAxis.Maximum = yAxis.Maximum;
            }

            double axisMin = yAxis.Minimum;
            double axisMax = yAxis.Maximum;
            double axisRange = axisMax - axisMin;

            if (axisRange <= 0) return;

            double panAmount = axisRange * panRatio;

            // 应用平移
            yAxis.Minimum = axisMin + panAmount;
            yAxis.Maximum = axisMax + panAmount;
        }

        // 缩放X轴（时间轴）
        private void ZoomXAxis(double centerXValue, bool zoomIn)
        {
            ChartArea area = chart.ChartAreas["MainArea"];
            var xAxis = area.AxisX;

            // 获取当前轴范围
            double currentMin = xAxis.Minimum;
            double currentMax = xAxis.Maximum;
            double currentRange = currentMax - currentMin;

            // 计算缩放后的范围
            double newRange;
            if (zoomIn)
            {
                newRange = currentRange / ZOOM_FACTOR;
            }
            else
            {
                newRange = currentRange * ZOOM_FACTOR;
            }

            // 检查缩放范围限制
            double minRangeOADate = TimeSpan.FromSeconds(MIN_ZOOM_RANGE_SECONDS).TotalDays;
            double maxRangeOADate = TimeSpan.FromHours(MAX_ZOOM_RANGE_HOURS).TotalDays;

            if (newRange < minRangeOADate)
            {
                newRange = minRangeOADate;
            }
            else if (newRange > maxRangeOADate)
            {
                newRange = maxRangeOADate;
            }

            // 以鼠标位置为中心计算新的最小值和最大值
            double centerRatio = (centerXValue - currentMin) / currentRange;

            double newMin = centerXValue - newRange * centerRatio;
            double newMax = centerXValue + newRange * (1 - centerRatio);

            // 应用新的范围
            xAxis.Minimum = newMin;
            xAxis.Maximum = newMax;

            // 重新计算Y轴范围以适应新的时间窗口
            AutoAdjustYAxisRanges(area);
        }

        // 缩放Y轴
        private void ZoomYAxis(int mouseX, int mouseY, bool zoomIn)
        {
            ChartArea area = chart.ChartAreas["MainArea"];

            // 判断鼠标位置更靠近哪个Y轴
            bool isNearSecondaryAxis = mouseX >= area.Position.Width / 2;

            if (isNearSecondaryAxis && area.AxisY2.Enabled == AxisEnabled.True)
            {
                // 缩放次Y轴（右侧）
                ZoomAxis(area.AxisY2, mouseY, zoomIn);
            }
            else
            {
                // 缩放主Y轴（左侧）
                ZoomAxis(area.AxisY, mouseY, zoomIn);
            }
        }

        // 缩放指定轴
        private void ZoomAxis(Axis axis, int mousePixel, bool zoomIn)
        {
            // 获取当前的自动计算范围
            if (double.IsNaN(axis.Minimum) || double.IsNaN(axis.Maximum))
            {
                axis.Minimum = axis.Minimum;
                axis.Maximum = axis.Maximum;
            }

            double currentMin = axis.Minimum;
            double currentMax = axis.Maximum;
            double currentRange = currentMax - currentMin;

            if (currentRange <= 0) return;

            // 计算鼠标位置对应的轴值作为缩放中心
            double centerValue;
            try
            {
                centerValue = axis.PixelPositionToValue(mousePixel);
            }
            catch
            {
                // 如果转换失败，使用轴中心作为缩放中心
                centerValue = (currentMin + currentMax) / 2;
            }

            // 计算缩放后的范围
            double newRange;
            if (zoomIn)
            {
                newRange = currentRange / Y_ZOOM_FACTOR;
            }
            else
            {
                newRange = currentRange * Y_ZOOM_FACTOR;
            }

            // 防止范围过小
            if (newRange < 0.01)
            {
                newRange = 0.01;
            }

            // 以鼠标位置为中心计算新的最小值和最大值
            double centerRatio = (centerValue - currentMin) / currentRange;

            double newMin = centerValue - newRange * centerRatio;
            double newMax = centerValue + newRange * (1 - centerRatio);

            // 应用新的范围
            axis.Minimum = newMin;
            axis.Maximum = newMax;
        }

        // 重置缩放到默认视图
        private void ResetZoom()
        {
            // 重置X轴到默认时间窗口
            SetDefaultAxisRanges();

            // 重置Y轴为自动范围
            ChartArea area = chart.ChartAreas["MainArea"];
            area.AxisY.Minimum = Double.NaN;
            area.AxisY.Maximum = Double.NaN;
            area.AxisY2.Minimum = Double.NaN;
            area.AxisY2.Maximum = Double.NaN;

            // 重新计算Y轴范围
            AutoAdjustYAxisRanges(area);
        }

        public static ChartAxisType GetAxisTypeForParameter(string parameterName)
        {
            string upperParam = parameterName.ToUpper();

            // 将温度、电流相关的参数分配给主轴
            if (parameterName.Contains("温度") || upperParam.Contains("TEMP") || upperParam.Contains("NTC") ||
                upperParam.Contains("IA") || upperParam.Contains("IB") || upperParam.Contains("IC") || upperParam.Contains("Freq"))
            {
                return ChartAxisType.Primary;
            }

            // 电压、AD、功率相关参数分配给次轴
            return ChartAxisType.Secondary;
        }
    }
}
