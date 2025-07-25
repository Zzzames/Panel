using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA
{
    // 功率仪表格管理类 - 功率仪表格的交互逻辑   
    public class PowerGridManager
    {
        private DataGridView dgvPower;
        private ChartManager chartManager;

        // 功率仪列复选框自定义文字存储字典
        private Dictionary<string, bool> powerColumnsChecked = new Dictionary<string, bool>();

        // 绘制复选框所需的尺寸
        private const int CHECKBOX_SIZE = 15;
        private const int CHECKBOX_MARGIN = 2;

        // 表格行数限制配置
        private const int MAX_GRID_ROWS = 500;
        private int gridKeepRowsOnReset = 200;  // 保留行数

        // 事件定义
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;
        public event EventHandler<string> ColumnHeaderChanged;
        public event Action NotifyTreeViewRefresh;

        public PowerGridManager(DataGridView dgvPower, ChartManager chartManager)
        {
            this.dgvPower = dgvPower ?? throw new ArgumentNullException(nameof(dgvPower));
            this.chartManager = chartManager;

            InitializeGrid();
        }

        // 初始化表格     
        private void InitializeGrid()
        {
            try
            {
                // 设置DataGridView列标题可编辑
                dgvPower.EnableHeadersVisualStyles = false;
                dgvPower.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dgvPower.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;

                // 配置表格
                SetupGridForHeaderCheckboxes();
            }
            catch (Exception ex)
            {
                OnLogMessage($"初始化功率仪表格时出错: {ex.Message}", true);
            }
        }

        // 配置功率仪表格中的复选框操作逻辑      
        private void SetupGridForHeaderCheckboxes()
        {
            try
            {
                // 为每个列添加字典条目
                foreach (DataGridViewColumn col in dgvPower.Columns)
                {
                    powerColumnsChecked[col.Name] = false;
                }

                // 添加列标题点击事件处理程序
                dgvPower.CellMouseClick += Dgv_CellMouseClick;
                dgvPower.CellDoubleClick += Dgv_CellDoubleClick;

                // 自定义绘制列标题
                dgvPower.CellPainting += Dgv_CellPainting;
            }
            catch (Exception ex)
            {
                OnLogMessage($"配置表格复选框时出错: {ex.Message}", true);
            }
        }

        // 在列标题绘制复选框
        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                // 如果是列标题单元格，排除时间列
                if (e.RowIndex == -1 && e.ColumnIndex > 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    // 获取当前列的选中状态
                    bool isChecked = false;
                    if (dgvPower.Columns[e.ColumnIndex] != null &&
                        powerColumnsChecked.ContainsKey(dgvPower.Columns[e.ColumnIndex].Name))
                    {
                        isChecked = powerColumnsChecked[dgvPower.Columns[e.ColumnIndex].Name];
                    }

                    // 计算复选框位置
                    Rectangle checkBoxRect = new Rectangle(
                        e.CellBounds.X + CHECKBOX_MARGIN,
                        e.CellBounds.Y + (e.CellBounds.Height - CHECKBOX_SIZE) / 2,
                        CHECKBOX_SIZE,
                        CHECKBOX_SIZE);

                    // 绘制复选框
                    ControlPaint.DrawCheckBox(e.Graphics, checkBoxRect,
                        isChecked ? ButtonState.Checked : ButtonState.Normal);

                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"绘制复选框时出错: {ex.Message}", true);
            }
        }

        // 处理单元格点击事件
        private void Dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                // 处理列标题单元格点击，排除时间列
                if (e.RowIndex == -1 && e.ColumnIndex > 0 && e.ColumnIndex < dgvPower.Columns.Count)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        // 左键：切换单个复选框状态
                        string columnName = dgvPower.Columns[e.ColumnIndex].Name;

                        if (powerColumnsChecked.ContainsKey(columnName))
                        {
                            powerColumnsChecked[columnName] = !powerColumnsChecked[columnName];

                            // 重绘标题
                            dgvPower.InvalidateCell(e.ColumnIndex, -1);
                            // 重绘左上角单元格
                            dgvPower.InvalidateCell(-1, -1);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"处理复选框点击时出错: {ex.Message}", true);
            }
        }
        // 处理单元格双击事件
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 处理列标题单元格双击，排除时间列
                if (e.RowIndex == -1 && e.ColumnIndex > 0 && e.ColumnIndex < dgvPower.Columns.Count)
                {
                    // 双击左键：编辑列标题
                    EditColumnHeader(e.ColumnIndex);
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"处理列标题双击时出错: {ex.Message}", true);
            }
        }

        // 编辑列标题的方法
        private void EditColumnHeader(int columnIndex)
        {
            try
            {
                if (columnIndex < 0 || columnIndex >= dgvPower.Columns.Count)
                    return;

                // 获取当前列
                DataGridViewColumn column = dgvPower.Columns[columnIndex];

                // 新建一个输入框，输入新的列标题
                using (Form inputForm = new Form())
                {
                    inputForm.Text = "编辑列标题";
                    inputForm.Size = new Size(300, 150);
                    inputForm.StartPosition = FormStartPosition.CenterParent;
                    inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    inputForm.MaximizeBox = false;
                    inputForm.MinimizeBox = false;

                    Label label = new Label();
                    label.Text = "请输入新的列标题:";
                    label.Location = new Point(10, 10);
                    label.AutoSize = true;

                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(10, 40);
                    textBox.Size = new Size(265, 23);
                    textBox.Text = column.HeaderText; // 默认显示当前标题

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
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        string newTitle = textBox.Text.Trim();
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            string oldTitle = column.HeaderText;
                            column.HeaderText = newTitle;

                            // 更新图表中的曲线名称
                            if (chartManager != null && powerColumnsChecked.ContainsKey(column.Name) &&
                                powerColumnsChecked[column.Name])
                            {
                                chartManager.RenameSeries(oldTitle, newTitle);
                            }

                            // 通知TreeView刷新
                            NotifyTreeViewRefresh?.Invoke();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"编辑列标题时出错: {ex.Message}", true);
            }
        }

        // 添加功率仪数据到表格
        public void AddPowerDataToGrid(DateTime timestamp, Dictionary<string, double> powerData)
        {
            try
            {
                // 检查是否需要清理旧行数据
                if (dgvPower.Rows.Count >= MAX_GRID_ROWS)
                {
                    int rowsToRemove = dgvPower.Rows.Count - gridKeepRowsOnReset;
                    for (int i = 0; i < rowsToRemove && dgvPower.Rows.Count > 0; i++)
                    {
                        dgvPower.Rows.RemoveAt(0);
                    }
                }

                // 添加新行
                int rowIndex = dgvPower.Rows.Add();
                DataGridViewRow row = dgvPower.Rows[rowIndex];

                // 设置时间列
                string displayTime = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
                row.Cells["Column_Time"].Value = displayTime;

                // 设置各个参数列
                foreach (var item in powerData)
                {
                    if (item.Value != 0)
                    {
                        string valueStr = item.Value.ToString("F2");

                        // 根据参数名称找到对应的列
                        string columnName = GetColumnNameForParameter(item.Key);
                        if (!string.IsNullOrEmpty(columnName) && dgvPower.Columns.Contains(columnName))
                        {
                            row.Cells[columnName].Value = valueStr;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"在表格中添加功率仪数据时出错: {ex.Message}", true);
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

        // 更新功率仪数据的图表
        public void UpdateChartForPowerData(DateTime timestamp, Dictionary<string, double> powerData)
        {
            try
            {
                if (chartManager == null) return;

                foreach (var item in powerData)
                {
                    if (item.Value != 0)
                    {
                        string columnName = GetColumnNameForParameter(item.Key);
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            // 检查对应列是否被勾选
                            if (powerColumnsChecked.ContainsKey(columnName) &&
                                powerColumnsChecked[columnName])
                            {
                                // 使用列的HeaderText作为曲线名称
                                var column = dgvPower.Columns[columnName];
                                if (column != null)
                                {
                                    string seriesName = column.HeaderText;
                                    // 只有勾选时才添加数据到图表
                                    chartManager.AddOrUpdateData(seriesName, timestamp, item.Value, ChartAxisType.Secondary);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"更新功率仪图表数据时出错: {ex.Message}", true);
            }
        }

        // 获取所有选中的功率仪列
        public Dictionary<string, bool> GetSelectedColumns()
        {
            return new Dictionary<string, bool>(powerColumnsChecked);
        }

        // 获取选中列的显示名称列表
        public List<string> GetSelectedColumnDisplayNames()
        {
            var selectedColumns = new List<string>();

            foreach (var colPair in powerColumnsChecked)
            {
                if (colPair.Value)
                {
                    // 查找对应的列并获取其HeaderText
                    var column = dgvPower.Columns[colPair.Key];
                    if (column != null)
                    {
                        selectedColumns.Add(column.HeaderText);
                    }
                }
            }

            return selectedColumns;
        }

        // 设置指定列的复选框状态
        public void SetColumnCheckState(string columnName, bool isChecked)
        {
            try
            {
                if (powerColumnsChecked.ContainsKey(columnName))
                {
                    powerColumnsChecked[columnName] = isChecked;

                    // 重绘表格标题以更新复选框显示
                    dgvPower.Invalidate();
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"设置列 {columnName} 复选框状态时出错: {ex.Message}", true);
            }
        }

        // 清除表格数据
        public void ClearGridData()
        {
            try
            {
                dgvPower.Rows.Clear();
            }
            catch (Exception ex)
            {
                OnLogMessage($"清除表格数据时出错: {ex.Message}", true);
            }
        }

        // 设置表格行数限制
        public void SetRowLimits(int maxRows, int keepRows)
        {
            if (maxRows > 0 && keepRows > 0 && keepRows < maxRows)
            {
                gridKeepRowsOnReset = keepRows;
            }
        }

        // 滚动到表格底部
        public void ScrollToBottom()
        {
            try
            {
                if (dgvPower.Rows.Count > 0)
                {
                    dgvPower.FirstDisplayedScrollingRowIndex = dgvPower.Rows.Count - 1;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"滚动到表格底部时出错: {ex.Message}", true);
            }
        }

        // 暂停和恢复表格布局
        public void SuspendLayout()
        {
            dgvPower.SuspendLayout();
        }

        public void ResumeLayout()
        {
            dgvPower.ResumeLayout();
        }

        #region 事件触发方法

        private void OnLogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        private void OnColumnHeaderChanged(string message)
        {
            ColumnHeaderChanged?.Invoke(this, message);
        }

        #endregion

        #region 配置保存和加载

        // 获取功率仪表格配置
        public List<DAForm.PowerGridColumnConfig> GetPowerGridConfiguration()
        {
            var config = new List<DAForm.PowerGridColumnConfig>();

            try
            {
                foreach (DataGridViewColumn column in dgvPower.Columns)
                {
                    if (column.Name != "Column_Time") // 排除时间列
                    {
                        bool isSelected = powerColumnsChecked.ContainsKey(column.Name) && powerColumnsChecked[column.Name];

                        config.Add(new DAForm.PowerGridColumnConfig
                        {
                            ColumnName = column.Name,
                            IsVisible = column.Visible,
                            IsSelected = isSelected,
                            HeaderText = column.HeaderText
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"获取功率仪表格配置时出错: {ex.Message}", true);
            }

            return config;
        }

        // 应用功率仪表格配置
        public void ApplyPowerGridConfiguration(List<DAForm.PowerGridColumnConfig> config)
        {
            if (config == null) return;

            try
            {
                int appliedCount = 0;

                foreach (var columnConfig in config)
                {
                    DataGridViewColumn column = dgvPower.Columns[columnConfig.ColumnName];
                    if (column != null)
                    {
                        // 应用列可见性
                        column.Visible = columnConfig.IsVisible;

                        // 应用列标题（自定义文字）
                        if (!string.IsNullOrEmpty(columnConfig.HeaderText))
                        {
                            column.HeaderText = columnConfig.HeaderText;
                        }

                        // 应用复选框状态
                        if (powerColumnsChecked.ContainsKey(columnConfig.ColumnName))
                        {
                            powerColumnsChecked[columnConfig.ColumnName] = columnConfig.IsSelected;
                        }

                        appliedCount++;
                    }
                }

                // 重绘表格标题以更新复选框状态
                dgvPower.Invalidate();
            }
            catch (Exception ex)
            {
                OnLogMessage($"应用功率仪表格配置时出错: {ex.Message}", true);
            }
        }

        // 恢复功率仪默认配置
        public void RestoreDefaultConfiguration()
        {
            try
            {
                int restoredCount = 0;

                // 定义默认列标题
                var defaultHeaders = new Dictionary<string, string>
                {
                    ["Column_Ua"] = "Ua",
                    ["Column_Ub"] = "Ub",
                    ["Column_Uc"] = "Uc",
                    ["Column_Ia"] = "Ia",
                    ["Column_Ib"] = "Ib",
                    ["Column_Ic"] = "Ic",
                    ["Column_P"] = "P",
                    ["Column_Freq"] = "Freq",
                    ["Column_En"] = "En"
                };

                // 恢复所有列的默认状态
                foreach (DataGridViewColumn column in dgvPower.Columns)
                {
                    if (column.Name != "Column_Time")
                    {
                        column.Visible = true; // 默认所有列可见

                        // 恢复默认列标题
                        if (defaultHeaders.ContainsKey(column.Name))
                        {
                            column.HeaderText = defaultHeaders[column.Name];
                        }

                        if (powerColumnsChecked.ContainsKey(column.Name))
                        {
                            powerColumnsChecked[column.Name] = false; // 默认不选中
                        }
                        restoredCount++;
                    }
                }

                // 重绘表格标题以更新复选框状态
                dgvPower.Invalidate();
            }
            catch (Exception ex)
            {
                OnLogMessage($"恢复功率仪默认配置时出错: {ex.Message}", true);
            }
        }

        // 获取所有可用的图表系列信息
        public List<DAForm.ChartSeriesInfo> GetAvailableSeries()
        {
            var seriesList = new List<DAForm.ChartSeriesInfo>();
            foreach (DataGridViewColumn column in dgvPower.Columns)
            {
                if (column.Name != "Column_Time")
                {
                    seriesList.Add(new DAForm.ChartSeriesInfo
                    {
                        SeriesName = column.HeaderText,
                        DisplayName = column.HeaderText,
                        UniqueID = column.Name,
                        AxisType = DA.ChartAxisType.Secondary
                    });
                }
            }
            return seriesList;
        }

        #endregion

        #region 资源清理

        // 释放资源       
        public void Dispose()
        {
            try
            {
                if (dgvPower != null)
                {
                    dgvPower.CellMouseClick -= Dgv_CellMouseClick;
                    dgvPower.CellDoubleClick -= Dgv_CellDoubleClick;
                    dgvPower.CellPainting -= Dgv_CellPainting;
                }

                powerColumnsChecked?.Clear();
            }
            catch (Exception ex)
            {
                OnLogMessage($"释放PowerGridManager资源时出错: {ex.Message}", true);
            }
        }

        #endregion
    }
}