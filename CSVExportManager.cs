using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    // 保存数据类 - 封装所有与数据导出相关的逻辑
    public class CSVExportManager
    {
        private SQLiteManager sqliteManager;
        private int recordIntervalSeconds;

        // 映射委托，用于从DAForm获取映射逻辑
        public Func<string, int[], string> GetDbColumnNameForDisplay { get; set; }
        public Func<string, string> GetIHDbColumnNameForDisplay { get; set; }

        // StringBuilder对象重用池
        private readonly StringBuilder csvStringBuilder = new StringBuilder(4096);
        private readonly object stringBuilderLock = new object();

        // 事件定义
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event EventHandler<string> StatusChanged;

        public CSVExportManager(SQLiteManager sqliteManager, int recordIntervalSeconds = 1)
        {
            this.sqliteManager = sqliteManager ?? throw new ArgumentNullException(nameof(sqliteManager));
            this.recordIntervalSeconds = recordIntervalSeconds;
        }

        // 更新数据记录间隔
        public void UpdateRecordInterval(int intervalSeconds)
        {
            if (intervalSeconds > 0)
            {
                recordIntervalSeconds = intervalSeconds;
            }
        }

        // 导出选中列的数据到CSV文件
        public async Task<bool> ExportSelectedColumnsAsync(string filePath, List<string> selectedColumns, bool isAutoSave = false)
        {
            try
            {
                if (selectedColumns == null || selectedColumns.Count == 0)
                {
                    if (!isAutoSave)
                    {
                        OnLogMessage("请至少选择一列数据进行导出", true);
                    }
                    return false;
                }

                OnStatusChanged("正在导出数据，请稍候...");

                // 在后台线程执行导出
                bool result = await Task.Run(() => SaveSelectedColumnsToCSV(filePath, selectedColumns, isAutoSave));

                if (result)
                {
                    OnStatusChanged("数据导出完成");
                }
                else
                {
                    OnStatusChanged("数据导出失败");
                }

                return result;
            }
            catch (Exception ex)
            {
                OnLogMessage($"导出数据时出错: {ex.Message}", true);
                OnStatusChanged("数据导出失败");
                return false;
            }
        }

        // 自动保存数据
        public async Task<bool> AutoSaveDataAsync(List<string> selectedColumns)
        {
            try
            {
                if (selectedColumns == null || selectedColumns.Count == 0)
                {
                    OnLogMessage("没有选择任何数据。");
                    return false;
                }

                // 生成自动保存文件路径
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = $"数据_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                string filePath = Path.Combine(documentsPath, fileName);

                OnLogMessage($"正在自动保存数据到: {filePath}");

                bool result = await ExportSelectedColumnsAsync(filePath, selectedColumns, true);

                if (result)
                {
                    OnLogMessage("数据自动保存完成。");
                }

                return result;
            }
            catch (Exception ex)
            {
                OnLogMessage($"自动保存数据失败: {ex.Message}", true);
                return false;
            }
        }

        // 显示保存对话框并导出数据
        public async Task<bool> ExportAsync(List<string> selectedColumns)
        {
            try
            {
                if (selectedColumns == null || selectedColumns.Count == 0)
                {
                    MessageBox.Show("请至少选择一项数据进行导出", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV文件|*.csv",
                    Title = "保存数据",
                    DefaultExt = "csv"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    bool result = await ExportSelectedColumnsAsync(filePath, selectedColumns);

                    if (result)
                    {
                        ShowAutoClosingMessageBox($"数据已保存到:\n{filePath}", "保存成功", 3000);
                    }

                    return result;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存数据失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OnLogMessage($"保存数据失败: {ex.Message}", true);
                return false;
            }
        }

        // 核心CSV保存方法
        private bool SaveSelectedColumnsToCSV(string filePath, List<string> selectedColumns, bool isAutoSave = false)
        {
            try
            {
                // 从SQLite数据库查询数据
                var records = sqliteManager?.QueryDeviceData();
                if (records == null || records.Count == 0)
                {
                    if (!isAutoSave)
                    {
                        OnLogMessage("没有数据可以导出", false);
                    }
                    return false;
                }

                // 将查询结果按时间戳分组
                var queryResult = sqliteManager.GroupDataByTimestamp(records);

                // 处理数据
                var mergedData = new Dictionary<string, Dictionary<string, string>>();

                if (queryResult.Count > 0)
                {
                    // 按秒分组所有数据
                    var groupedBySecond = queryResult.GroupBy(r =>
                        new DateTime(r.Timestamp.Year, r.Timestamp.Month, r.Timestamp.Day,
                                   r.Timestamp.Hour, r.Timestamp.Minute, r.Timestamp.Second))
                        .ToDictionary(g => g.Key, g => g.ToList());

                    // 根据设置的采样间隔，生成固定采样点并收集最近数据
                    if (recordIntervalSeconds > 0 && groupedBySecond.Count > 0)
                    {
                        mergedData = ProcessDataWithInterval(groupedBySecond, selectedColumns);
                    }
                    else
                    {
                        mergedData = ProcessDataWithoutInterval(groupedBySecond, selectedColumns);
                    }
                }

                // 生成CSV内容并保存
                return GenerateAndSaveCSV(filePath, selectedColumns, mergedData);
            }
            catch (Exception ex)
            {
                if (!isAutoSave)
                {
                    OnLogMessage($"保存数据失败: {ex.Message}", true);
                }
                return false;
            }
        }

        // 按间隔处理数据
        private Dictionary<string, Dictionary<string, string>> ProcessDataWithInterval(
            Dictionary<DateTime, List<(DateTime Timestamp, Dictionary<string, string> Data)>> groupedBySecond,
            List<string> selectedColumns)
        {
            var mergedData = new Dictionary<string, Dictionary<string, string>>();
            var firstSecond = groupedBySecond.Keys.Min();
            var lastSecond = groupedBySecond.Keys.Max();

            // 查询数据库中所有数据的真实时间范围
            var allRecords = sqliteManager?.QueryDeviceData();
            if (allRecords != null && allRecords.Count > 0)
            {
                var realLastSecond = allRecords.Max(r => new DateTime(r.Timestamp.Year, r.Timestamp.Month, r.Timestamp.Day,
                                                                    r.Timestamp.Hour, r.Timestamp.Minute, r.Timestamp.Second));
                if (realLastSecond > lastSecond)
                {
                    lastSecond = realLastSecond;
                }
            }

            // 从第一个数据时间开始，按间隔生成采样点
            var currentSampleTime = firstSecond;
            var lastKnownValues = new Dictionary<string, string>();

            while (currentSampleTime <= lastSecond)
            {
                string timeKey = currentSampleTime.ToString("yyyy-MM-dd HH:mm:ss");
                mergedData[timeKey] = new Dictionary<string, string>();

                // 定义搜索窗口（前后各半个间隔时间）
                var windowStart = currentSampleTime.AddSeconds(-recordIntervalSeconds / 2.0);
                var windowEnd = currentSampleTime.AddSeconds(recordIntervalSeconds / 2.0);

                // 为每个选中的列找到最接近采样时间的数据
                foreach (string displayColumnName in selectedColumns)
                {
                    DateTime? closestTime = null;
                    double minTimeDiff = double.MaxValue;
                    string bestValue = "";

                    // 获取可能的数据库列名
                    List<string> possibleDbColumns = GetPossibleDbColumnNames(displayColumnName);

                    // 在窗口内搜索该列的最近数据
                    foreach (var kvp in groupedBySecond)
                    {
                        foreach (var timeData in kvp.Value)
                        {
                            if (timeData.Timestamp >= windowStart && timeData.Timestamp <= windowEnd)
                            {
                                // 检查所有可能的列名
                                foreach (string columnName in possibleDbColumns)
                                {
                                    if (timeData.Data.ContainsKey(columnName))
                                    {
                                        double timeDiff = Math.Abs((timeData.Timestamp - currentSampleTime).TotalSeconds);
                                        if (timeDiff < minTimeDiff)
                                        {
                                            minTimeDiff = timeDiff;
                                            closestTime = timeData.Timestamp;
                                            bestValue = timeData.Data[columnName];
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // 如果找到了数据，添加到输出并更新缓存
                    if (closestTime.HasValue && !string.IsNullOrEmpty(bestValue))
                    {
                        mergedData[timeKey][displayColumnName] = bestValue;
                        lastKnownValues[displayColumnName] = bestValue;
                    }
                    else if (lastKnownValues.ContainsKey(displayColumnName))
                    {
                        // 如果没找到，用上一个值填充
                        mergedData[timeKey][displayColumnName] = lastKnownValues[displayColumnName];
                    }
                }

                // 按设定间隔移动到下一个采样时间点
                currentSampleTime = currentSampleTime.AddSeconds(recordIntervalSeconds);
            }

            return mergedData;
        }

        // 不按间隔处理数据（保留所有数据）
        private Dictionary<string, Dictionary<string, string>> ProcessDataWithoutInterval(
            Dictionary<DateTime, List<(DateTime Timestamp, Dictionary<string, string> Data)>> groupedBySecond,
            List<string> selectedColumns)
        {
            var mergedData = new Dictionary<string, Dictionary<string, string>>();

            foreach (var kvp in groupedBySecond)
            {
                string timeKey = kvp.Key.ToString("yyyy-MM-dd HH:mm:ss");
                mergedData[timeKey] = new Dictionary<string, string>();

                // 合并同一秒内的所有数据
                foreach (var timeData in kvp.Value)
                {
                    foreach (var dataItem in timeData.Data)
                    {
                        // 检查数据库列名是否对应选中的显示列名
                        foreach (string selectedDisplayName in selectedColumns)
                        {
                            // 直接匹配或通过映射匹配
                            if (dataItem.Key == selectedDisplayName)
                            {
                                mergedData[timeKey][selectedDisplayName] = dataItem.Value;
                                break;
                            }

                            // 检查映射关系
                            List<string> possibleDbColumns = GetPossibleDbColumnNames(selectedDisplayName);
                            if (possibleDbColumns.Contains(dataItem.Key))
                            {
                                mergedData[timeKey][selectedDisplayName] = dataItem.Value;
                                break;
                            }
                        }
                    }
                }
            }

            return mergedData;
        }

        // 获取显示列名对应的可能数据库列名
        private List<string> GetPossibleDbColumnNames(string displayColumnName)
        {
            List<string> possibleDbColumns = new List<string> { displayColumnName };

            // 温升仪通道映射
            int[] channels = { 101, 102, 103, 104, 105, 106, 107, 108, 109, 110,
                              111, 112, 113, 114, 115, 116, 117, 118, 119, 120,
                              201, 202, 203, 204, 205, 206, 207, 208, 209, 210,
                              211, 212, 213, 214, 215, 216, 217, 218, 219, 220,
                              301, 302, 303, 304, 305, 306, 307, 308, 309, 310,
                              311, 312, 313, 314, 315, 316, 317, 318, 319, 320 };

            string tempDbColumnName = GetDbColumnNameForDisplayInternal(displayColumnName, channels);
            if (tempDbColumnName != displayColumnName)
            {
                possibleDbColumns.Add(tempDbColumnName);
            }

            // IH设备映射
            string ihDbColumnName = GetIHDbColumnNameForDisplayInternal(displayColumnName);
            if (ihDbColumnName != displayColumnName)
            {
                possibleDbColumns.Add(ihDbColumnName);
            }

            return possibleDbColumns;
        }

        // 根据显示名称获取对应的数据库列名（温升仪）
        private string GetDbColumnNameForDisplayInternal(string displayName, int[] channels)
        {
            // 如果设置了委托，使用委托
            if (GetDbColumnNameForDisplay != null)
            {
                return GetDbColumnNameForDisplay(displayName, channels);
            }

            foreach (int channel in channels)
            {
                if (displayName == channel.ToString())
                {
                    if (channel >= 1 && channel <= 3)
                    {
                        return displayName;
                    }
                    return $"Channel{channel}";
                }
            }
            return displayName;
        }

        // 根据IH设备显示名称获取对应的数据库列名
        private string GetIHDbColumnNameForDisplayInternal(string displayName)
        {
            // 如果设置了委托，使用委托
            if (GetIHDbColumnNameForDisplay != null)
            {
                return GetIHDbColumnNameForDisplay(displayName);
            }

            string[] ihPositions = { "LR", "LF", "RR", "RF", "CLF", "CLR" };

            foreach (string position in ihPositions)
            {
                if (displayName.StartsWith($"{position}_"))
                {
                    // 提取参数名部分
                    string paramName = displayName.Substring(position.Length + 1);

                    // 构建数据库列名格式
                    return $"{position}_{paramName}";
                }
            }

            return displayName;
        }

        // 生成CSV内容并保存到文件
        private bool GenerateAndSaveCSV(string filePath, List<string> selectedColumns,
            Dictionary<string, Dictionary<string, string>> mergedData)
        {
            try
            {
                // 添加列标题（时间戳 + 经过时间 + 选中的列）
                List<string> headers = new List<string> { "时间", "经过" };
                headers.AddRange(selectedColumns);

                // 按时间排序并输出数据
                var sortedTimes = mergedData.Keys.OrderBy(t => t).ToList();

                // 获取第一个时间作为起始时间
                DateTime? firstTime = null;
                if (sortedTimes.Count > 0)
                {
                    DateTime.TryParse(sortedTimes[0], out DateTime parsedTime);
                    firstTime = parsedTime;
                }

                // 构建CSV内容
                string csvContent = BuildCSVContent(headers, sortedTimes, mergedData, selectedColumns, firstTime);

                // 保存到文件
                File.WriteAllText(filePath, csvContent, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                OnLogMessage($"生成CSV文件失败: {ex.Message}", true);
                return false;
            }
        }

        // 构建CSV内容
        private string BuildCSVContent(List<string> headers, List<string> sortedTimes,
            Dictionary<string, Dictionary<string, string>> mergedData, List<string> selectedColumns, DateTime? firstTime)
        {
            lock (stringBuilderLock)
            {
                csvStringBuilder.Clear();

                // 添加列标题
                csvStringBuilder.AppendLine(string.Join(",", headers));

                // 添加数据行
                foreach (string timeKey in sortedTimes)
                {
                    List<string> rowData = new List<string>();

                    // 添加时间戳
                    rowData.Add($"=\"{timeKey}\"");

                    // 计算并添加经过时间
                    string elapsedTime = "00:00:00";
                    if (firstTime.HasValue && DateTime.TryParse(timeKey, out DateTime currentTime))
                    {
                        TimeSpan elapsed = currentTime - firstTime.Value;
                        elapsedTime = elapsed.ToString(@"hh\:mm\:ss");
                    }
                    rowData.Add(elapsedTime);

                    // 添加每列的数据
                    foreach (string columnName in selectedColumns)
                    {
                        string value = "";
                        if (mergedData[timeKey].ContainsKey(columnName))
                        {
                            value = mergedData[timeKey][columnName];
                        }

                        // 如果数据包含逗号，用引号包裹
                        if (value.Contains(","))
                        {
                            value = $"\"{value}\"";
                        }

                        rowData.Add(value);
                    }

                    // 添加行数据到CSV
                    csvStringBuilder.AppendLine(string.Join(",", rowData));
                }

                return csvStringBuilder.ToString();
            }
        }

        // 显示可自动关闭的消息框
        private void ShowAutoClosingMessageBox(string message, string caption, int timeout)
        {
            var form = new Form();
            var label = new Label();
            var buttonOk = new Button();
            var timer = new System.Windows.Forms.Timer();

            form.Text = caption;
            label.Text = message;
            buttonOk.Text = "确定";
            buttonOk.DialogResult = DialogResult.OK;
            form.AcceptButton = buttonOk;

            label.AutoSize = true;
            label.Location = new System.Drawing.Point(20, 20);

            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ControlBox = false;
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Width + 40), 120);

            buttonOk.Location = new System.Drawing.Point(form.ClientSize.Width - buttonOk.Width - 20,
                form.ClientSize.Height - buttonOk.Height - 20);
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.Controls.Add(label);
            form.Controls.Add(buttonOk);

            timer.Interval = timeout;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                form.Close();
            };

            buttonOk.Click += (s, e) =>
            {
                timer.Stop();
            };

            timer.Start();
            form.ShowDialog();
            timer.Dispose();
            form.Dispose();
        }

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

        #region 资源清理

        // 释放资源
        public void Dispose()
        {
            try
            {
                lock (stringBuilderLock)
                {
                    csvStringBuilder?.Clear();
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"释放CSVExportManager资源时出错: {ex.Message}", true);
            }
        }

        #endregion
    }
}