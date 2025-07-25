using System;
using System.Collections.Generic;
using System.Linq;

namespace DA
{
    // 性能监控类 - 用于监控温升仪数据更新性能
    public class PerformanceMonitor
    {
        private DateTime startTime = DateTime.Now;
        private readonly object lockObj = new object();

        // 事件计数器
        public long TemperatureEventsReceived { get; private set; } = 0;
        public long UIUpdatesProcessed { get; private set; } = 0;
        public long DataGridOperations { get; private set; } = 0;

        // 队列监控
        public int MaxUIQueueSize { get; private set; } = 0;
        public int CurrentUIQueueSize { get; set; } = 0;
        public long UIQueueCleanups { get; private set; } = 0;

        // 性能计时器
        private readonly List<long> uiUpdateTimes = new List<long>();
        private readonly List<long> dataGridUpdateTimes = new List<long>();

        // 内存监控
        private long initialMemory = GC.GetTotalMemory(false);

        /// <summary>
        /// 记录温升仪事件
        /// </summary>
        public void RecordTemperatureEvent()
        {
            lock (lockObj)
            {
                TemperatureEventsReceived++;
            }
        }

        /// <summary>
        /// 记录UI更新
        /// </summary>
        public void RecordUIUpdate()
        {
            lock (lockObj)
            {
                UIUpdatesProcessed++;
            }
        }

        /// <summary>
        /// 记录DataGrid操作
        /// </summary>
        public void RecordDataGridOperation()
        {
            lock (lockObj)
            {
                DataGridOperations++;
            }
        }

        /// <summary>
        /// 更新UI队列大小
        /// </summary>
        /// <param name="size">当前队列大小</param>
        public void UpdateUIQueueSize(int size)
        {
            lock (lockObj)
            {
                CurrentUIQueueSize = size;
                if (size > MaxUIQueueSize)
                {
                    MaxUIQueueSize = size;
                }
            }
        }

        /// <summary>
        /// 记录UI队列清理
        /// </summary>
        public void RecordUIQueueCleanup()
        {
            lock (lockObj)
            {
                UIQueueCleanups++;
            }
        }

        /// <summary>
        /// 记录UI更新耗时
        /// </summary>
        /// <param name="milliseconds">耗时（毫秒）</param>
        public void RecordUIUpdateTime(long milliseconds)
        {
            lock (lockObj)
            {
                uiUpdateTimes.Add(milliseconds);
                // 只保留最近100次记录
                if (uiUpdateTimes.Count > 100)
                {
                    uiUpdateTimes.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// 记录DataGrid更新耗时
        /// </summary>
        /// <param name="milliseconds">耗时（毫秒）</param>
        public void RecordDataGridUpdateTime(long milliseconds)
        {
            lock (lockObj)
            {
                dataGridUpdateTimes.Add(milliseconds);
                // 只保留最近100次记录
                if (dataGridUpdateTimes.Count > 100)
                {
                    dataGridUpdateTimes.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// 获取性能报告
        /// </summary>
        /// <returns>格式化的性能报告字符串</returns>
        public string GetPerformanceReport()
        {
            lock (lockObj)
            {
                var runTime = DateTime.Now - startTime;
                var currentMemory = GC.GetTotalMemory(false);
                var memoryDelta = (currentMemory - initialMemory) / 1024.0 / 1024.0; // MB

                var avgUITime = uiUpdateTimes.Count > 0 ? uiUpdateTimes.Average() : 0;
                var maxUITime = uiUpdateTimes.Count > 0 ? uiUpdateTimes.Max() : 0;
                var avgDataGridTime = dataGridUpdateTimes.Count > 0 ? dataGridUpdateTimes.Average() : 0;
                var maxDataGridTime = dataGridUpdateTimes.Count > 0 ? dataGridUpdateTimes.Max() : 0;

                var eventsPerMinute = runTime.TotalMinutes > 0 ? TemperatureEventsReceived / runTime.TotalMinutes : 0;

                return $"=== 性能监控报告 ===\n" +
                       $"运行时间: {runTime:hh\\:mm\\:ss}\n" +
                       $"温升仪事件总数: {TemperatureEventsReceived} (平均 {eventsPerMinute:F1}/分钟)\n" +
                       $"UI更新总数: {UIUpdatesProcessed}\n" +
                       $"表格操作总数: {DataGridOperations}\n" +
                       $"当前UI队列长度: {CurrentUIQueueSize}\n" +
                       $"最大UI队列长度: {MaxUIQueueSize}\n" +
                       $"队列清理次数: {UIQueueCleanups}\n" +
                       $"UI更新耗时: 平均 {avgUITime:F1}ms, 最大 {maxUITime}ms\n" +
                       $"表格更新耗时: 平均 {avgDataGridTime:F1}ms, 最大 {maxDataGridTime}ms\n" +
                       $"内存变化: {memoryDelta:F1} MB\n" +
                       $"===================";
            }
        }

        /// <summary>
        /// 检查性能问题并返回警告信息
        /// </summary>
        /// <returns>警告信息列表</returns>
        public List<string> CheckPerformanceIssues()
        {
            var warnings = new List<string>();

            lock (lockObj)
            {
                // 检查UI队列是否积压严重
                if (CurrentUIQueueSize > 80)
                {
                    warnings.Add($"警告：UI队列积压严重 ({CurrentUIQueueSize}/100)");
                }

                // 检查是否频繁清理队列
                if (UIQueueCleanups > 10)
                {
                    warnings.Add($"警告：UI队列频繁清理 ({UIQueueCleanups}次)");
                }

                // 检查事件频率是否过高（超过每分钟1000次）
                var runTime = DateTime.Now - startTime;
                if (runTime.TotalMinutes > 0)
                {
                    var eventsPerMinute = TemperatureEventsReceived / runTime.TotalMinutes;
                    if (eventsPerMinute > 1000)
                    {
                        warnings.Add($"警告：温升仪事件频率过高 ({eventsPerMinute:F0}/分钟)");
                    }
                }

                // 检查UI更新耗时是否过长
                if (uiUpdateTimes.Count > 0)
                {
                    var avgUITime = uiUpdateTimes.Average();
                    if (avgUITime > 50) // 超过50ms
                    {
                        warnings.Add($"警告：UI更新耗时过长 (平均 {avgUITime:F1}ms)");
                    }
                }
            }

            return warnings;
        }

        /// <summary>
        /// 重置所有监控数据
        /// </summary>
        public void Reset()
        {
            lock (lockObj)
            {
                startTime = DateTime.Now;
                TemperatureEventsReceived = 0;
                UIUpdatesProcessed = 0;
                DataGridOperations = 0;
                MaxUIQueueSize = 0;
                CurrentUIQueueSize = 0;
                UIQueueCleanups = 0;
                uiUpdateTimes.Clear();
                dataGridUpdateTimes.Clear();
                initialMemory = GC.GetTotalMemory(false);
            }
        }
    }
}
