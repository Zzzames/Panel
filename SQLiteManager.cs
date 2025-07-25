using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace DA
{
    /// <summary>
    /// SQLite数据库管理器
    /// 负责所有与SQLite数据库相关的操作
    /// </summary>
    public class SQLiteManager : IDisposable
    {
        private readonly string databasePath;
        private SQLiteConnection dbConnection;
        private readonly object databaseLock = new object();
        private bool disposed = false;

        #region 构造函数和析构函数
        public SQLiteManager(string dbPath = "DeviceData.db")
        {
            databasePath = dbPath;
            Initialize();
        }
        // 析构函数
        ~SQLiteManager()
        {
            Dispose(false);
        }

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
                    lock (databaseLock)
                    {
                        if (dbConnection != null)
                        {
                            if (dbConnection.State == ConnectionState.Open)
                            {
                                dbConnection.Close();
                            }
                            dbConnection.Dispose();
                            dbConnection = null;
                        }
                    }
                }
                disposed = true;
            }
        }

        #endregion

        #region 公共事件
        // 日志消息事件
        public event EventHandler<LogMessageEventArgs> LogMessageAdded;

        protected virtual void OnLogMessage(string message, bool isError = false)
        {
            LogMessageAdded?.Invoke(this, new LogMessageEventArgs(message, isError));
        }

        #endregion

        #region 数据库初始化
        // 初始化数据库
        private void Initialize()
        {
            try
            {
                if (!File.Exists(databasePath))
                {
                    SQLiteConnection.CreateFile(databasePath);
                    OnLogMessage("SQLite数据库文件已创建");
                }

                // 创建连接
                string connectionString = $"Data Source={databasePath};Version=3;";
                dbConnection = new SQLiteConnection(connectionString);
                dbConnection.Open();

                // 创建数据表
                CreateDataTables();

                OnLogMessage("SQLite数据库初始化成功");
            }
            catch (Exception ex)
            {
                OnLogMessage($"初始化SQLite数据库失败: {ex.Message}", true);
                throw;
            }
        }

        // 创建数据表
        private void CreateDataTables()
        {
            try
            {
                string createTableSQL = @"
                    CREATE TABLE IF NOT EXISTS DeviceData (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Timestamp DATETIME NOT NULL,
                        ColumnName TEXT NOT NULL,
                        Value TEXT NOT NULL,
                        DeviceType TEXT NOT NULL,
                        CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                    );
                    
                    CREATE TABLE IF NOT EXISTS ProgramSettings (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        SettingKey TEXT NOT NULL UNIQUE,
                        SettingValue TEXT NOT NULL,
                        UpdatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                    );
                    
                    CREATE INDEX IF NOT EXISTS idx_timestamp ON DeviceData(Timestamp);
                    CREATE INDEX IF NOT EXISTS idx_column_time ON DeviceData(ColumnName, Timestamp);
                    CREATE INDEX IF NOT EXISTS idx_device_time ON DeviceData(DeviceType, Timestamp);
                    CREATE INDEX IF NOT EXISTS idx_setting_key ON ProgramSettings(SettingKey);
                ";

                lock (databaseLock)
                {
                    using (SQLiteCommand command = new SQLiteCommand(createTableSQL, dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                OnLogMessage("数据表创建成功");
            }
            catch (Exception ex)
            {
                OnLogMessage($"创建数据表失败: {ex.Message}", true);
                throw;
            }
        }

        #endregion

        #region 设备数据操作

        // 保存设备数据到数据库
        public bool SaveDeviceData(DateTime timestamp, Dictionary<string, string> data)
        {
            try
            {
                if (data == null || data.Count == 0)
                {
                    return false;
                }

                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        OnLogMessage("数据库连接不可用", true);
                        return false;
                    }

                    using (SQLiteTransaction transaction = dbConnection.BeginTransaction())
                    {
                        try
                        {
                            string insertSQL = @"
                                INSERT INTO DeviceData (Timestamp, ColumnName, Value, DeviceType) 
                                VALUES (@timestamp, @columnName, @value, @deviceType)";

                            using (SQLiteCommand command = new SQLiteCommand(insertSQL, dbConnection, transaction))
                            {
                                foreach (var dataEntry in data)
                                {
                                    string columnName = dataEntry.Key;
                                    string value = dataEntry.Value;
                                    string deviceType = GetDeviceTypeFromColumnName(columnName);

                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@timestamp", timestamp);
                                    command.Parameters.AddWithValue("@columnName", columnName);
                                    command.Parameters.AddWithValue("@value", value);
                                    command.Parameters.AddWithValue("@deviceType", deviceType);

                                    command.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"保存设备数据失败: {ex.Message}", true);
                return false;
            }
        }

        /// <summary>
        /// 根据条件查询设备数据
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="selectedColumns">选中的列名</param>
        /// <param name="deviceTypes">设备类型过滤</param>
        /// <returns>查询结果</returns>
        public List<DeviceDataRecord> QueryDeviceData(DateTime? startTime = null, DateTime? endTime = null,
            List<string> selectedColumns = null, List<string> deviceTypes = null)
        {
            List<DeviceDataRecord> result = new List<DeviceDataRecord>();

            try
            {
                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        OnLogMessage("数据库连接不可用", true);
                        return result;
                    }

                    StringBuilder sqlBuilder = new StringBuilder("SELECT Timestamp, ColumnName, Value, DeviceType FROM DeviceData WHERE 1=1");

                    if (startTime.HasValue)
                    {
                        sqlBuilder.Append(" AND Timestamp >= @startTime");
                    }

                    if (endTime.HasValue)
                    {
                        sqlBuilder.Append(" AND Timestamp <= @endTime");
                    }

                    if (selectedColumns != null && selectedColumns.Count > 0)
                    {
                        sqlBuilder.Append(" AND ColumnName IN (");
                        for (int i = 0; i < selectedColumns.Count; i++)
                        {
                            if (i > 0) sqlBuilder.Append(",");
                            sqlBuilder.Append($"@col{i}");
                        }
                        sqlBuilder.Append(")");
                    }

                    if (deviceTypes != null && deviceTypes.Count > 0)
                    {
                        sqlBuilder.Append(" AND DeviceType IN (");
                        for (int i = 0; i < deviceTypes.Count; i++)
                        {
                            if (i > 0) sqlBuilder.Append(",");
                            sqlBuilder.Append($"@dev{i}");
                        }
                        sqlBuilder.Append(")");
                    }

                    sqlBuilder.Append(" ORDER BY Timestamp, ColumnName");

                    using (SQLiteCommand command = new SQLiteCommand(sqlBuilder.ToString(), dbConnection))
                    {
                        if (startTime.HasValue)
                        {
                            command.Parameters.AddWithValue("@startTime", startTime.Value);
                        }

                        if (endTime.HasValue)
                        {
                            command.Parameters.AddWithValue("@endTime", endTime.Value);
                        }

                        if (selectedColumns != null)
                        {
                            for (int i = 0; i < selectedColumns.Count; i++)
                            {
                                command.Parameters.AddWithValue($"@col{i}", selectedColumns[i]);
                            }
                        }

                        if (deviceTypes != null)
                        {
                            for (int i = 0; i < deviceTypes.Count; i++)
                            {
                                command.Parameters.AddWithValue($"@dev{i}", deviceTypes[i]);
                            }
                        }

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new DeviceDataRecord
                                {
                                    Timestamp = Convert.ToDateTime(reader["Timestamp"]),
                                    ColumnName = reader["ColumnName"].ToString(),
                                    Value = reader["Value"].ToString(),
                                    DeviceType = reader["DeviceType"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"查询设备数据失败: {ex.Message}", true);
            }

            return result;
        }

        // 将查询结果按时间戳分组
        public List<(DateTime Timestamp, Dictionary<string, string> Data)> GroupDataByTimestamp(List<DeviceDataRecord> records)
        {
            try
            {
                Dictionary<DateTime, Dictionary<string, string>> groupedData = new Dictionary<DateTime, Dictionary<string, string>>();

                foreach (var record in records)
                {
                    if (!groupedData.ContainsKey(record.Timestamp))
                    {
                        groupedData[record.Timestamp] = new Dictionary<string, string>();
                    }

                    groupedData[record.Timestamp][record.ColumnName] = record.Value;
                }

                return groupedData.Select(kvp => (kvp.Key, kvp.Value)).OrderBy(item => item.Key).ToList();
            }
            catch (Exception ex)
            {
                OnLogMessage($"数据分组失败: {ex.Message}", true);
                return new List<(DateTime, Dictionary<string, string>)>();
            }
        }

        // 清除所有设备数据
        public bool ClearDeviceData()
        {
            try
            {
                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        OnLogMessage("数据库连接不可用", true);
                        return false;
                    }

                    string deleteSQL = "DELETE FROM DeviceData";

                    using (SQLiteCommand command = new SQLiteCommand(deleteSQL, dbConnection))
                    {
                        int deletedRows = command.ExecuteNonQuery();

                        // 执行VACUUM优化数据库文件大小
                        using (SQLiteCommand vacuumCommand = new SQLiteCommand("VACUUM", dbConnection))
                        {
                            vacuumCommand.ExecuteNonQuery();
                        }

                        // OnLogMessage($"已清除 {deletedRows} 条设备数据记录");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"清除设备数据失败: {ex.Message}", true);
                return false;
            }
        }

        #endregion

        #region 程序设置操作

        // 保存程序设置
        public bool SaveSetting(string key, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }

                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        OnLogMessage("数据库连接不可用，无法保存设置", true);
                        return false;
                    }

                    string upsertSQL = @"
                        INSERT OR REPLACE INTO ProgramSettings (SettingKey, SettingValue, UpdatedAt) 
                        VALUES (@key, @value, @updatedAt)";

                    using (SQLiteCommand command = new SQLiteCommand(upsertSQL, dbConnection))
                    {
                        command.Parameters.AddWithValue("@key", key);
                        command.Parameters.AddWithValue("@value", value ?? string.Empty);
                        command.Parameters.AddWithValue("@updatedAt", DateTime.Now);

                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"保存设置 '{key}' 失败: {ex.Message}", true);
                return false;
            }
        }

        // 加载程序设置
        public string LoadSetting(string key, string defaultValue = null)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return defaultValue;
                }

                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        return defaultValue;
                    }

                    string selectSQL = "SELECT SettingValue FROM ProgramSettings WHERE SettingKey = @key";

                    using (SQLiteCommand command = new SQLiteCommand(selectSQL, dbConnection))
                    {
                        command.Parameters.AddWithValue("@key", key);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            string value = result.ToString();
                            // OnLogMessage($"从数据库加载设置 '{key}': {value}");
                            return value;
                        }
                    }
                    return defaultValue;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"加载设置 '{key}' 失败: {ex.Message}", true);
                return defaultValue;
            }
        }

        // 批量加载程序设置
        public Dictionary<string, string> LoadSettingsBatch(string[] keys)
        {
            var result = new Dictionary<string, string>();

            try
            {
                if (keys == null || keys.Length == 0)
                {
                    return result;
                }

                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        return result;
                    }

                    // 构建批量查询SQL
                    var placeholders = string.Join(",", keys.Select((_, i) => $"@key{i}"));
                    string selectSQL = $"SELECT SettingKey, SettingValue FROM ProgramSettings WHERE SettingKey IN ({placeholders})";

                    using (SQLiteCommand command = new SQLiteCommand(selectSQL, dbConnection))
                    {
                        // 添加参数
                        for (int i = 0; i < keys.Length; i++)
                        {
                            command.Parameters.AddWithValue($"@key{i}", keys[i]);
                        }

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string key = reader["SettingKey"].ToString();
                                string value = reader["SettingValue"]?.ToString() ?? "";
                                result[key] = value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"批量加载设置失败: {ex.Message}", true);
            }

            return result;
        }

        // 删除程序设置
        public bool DeleteSetting(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }

                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        OnLogMessage("数据库连接不可用", true);
                        return false;
                    }

                    string deleteSQL = "DELETE FROM ProgramSettings WHERE SettingKey = @key";

                    using (SQLiteCommand command = new SQLiteCommand(deleteSQL, dbConnection))
                    {
                        command.Parameters.AddWithValue("@key", key);

                        int deletedRows = command.ExecuteNonQuery();
                        if (deletedRows > 0)
                        {
                            OnLogMessage($"设置 '{key}' 已从数据库删除");
                            return true;
                        }
                        else
                        {
                            OnLogMessage($"设置 '{key}' 不存在，无需删除");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"删除设置 '{key}' 失败: {ex.Message}", true);
                return false;
            }
        }

        #endregion

        #region 数据库统计和维护

        // 获取数据库统计信息
        public DatabaseStats GetDatabaseStats()
        {
            try
            {
                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        return new DatabaseStats();
                    }

                    int totalRecords = 0;
                    DateTime? earliestTime = null;
                    DateTime? latestTime = null;

                    string statsSQL = @"
                        SELECT 
                            COUNT(*) as TotalRecords,
                            MIN(Timestamp) as EarliestTime,
                            MAX(Timestamp) as LatestTime
                        FROM DeviceData";

                    using (SQLiteCommand command = new SQLiteCommand(statsSQL, dbConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalRecords = Convert.ToInt32(reader["TotalRecords"]);
                                if (reader["EarliestTime"] != DBNull.Value)
                                    earliestTime = Convert.ToDateTime(reader["EarliestTime"]);
                                if (reader["LatestTime"] != DBNull.Value)
                                    latestTime = Convert.ToDateTime(reader["LatestTime"]);
                            }
                        }
                    }

                    long fileSize = 0;
                    if (File.Exists(databasePath))
                    {
                        fileSize = new FileInfo(databasePath).Length;
                    }

                    return new DatabaseStats
                    {
                        TotalRecords = totalRecords,
                        EarliestTime = earliestTime,
                        LatestTime = latestTime,
                        FileSizeBytes = fileSize,
                        DatabasePath = databasePath
                    };
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"获取数据库统计信息失败: {ex.Message}", true);
                return new DatabaseStats();
            }
        }

        // 优化数据库
        public bool OptimizeDatabase()
        {
            try
            {
                lock (databaseLock)
                {
                    if (dbConnection == null || dbConnection.State != ConnectionState.Open)
                    {
                        OnLogMessage("数据库连接不可用", true);
                        return false;
                    }

                    using (SQLiteCommand command = new SQLiteCommand("VACUUM", dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }

                    OnLogMessage("数据库优化完成");
                    return true;
                }
            }
            catch (Exception ex)
            {
                OnLogMessage($"数据库优化失败: {ex.Message}", true);
                return false;
            }
        }

        // 检查数据库连接状态
        public bool IsConnected()
        {
            try
            {
                lock (databaseLock)
                {
                    return dbConnection != null && dbConnection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region 辅助方法        
        // 根据列名判断设备类型
        private string GetDeviceTypeFromColumnName(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
            {
                return "Unknown";
            }

            // IH设备检测
            if (columnName.StartsWith("LR_") || columnName.StartsWith("LF_") ||
                columnName.StartsWith("RR_") || columnName.StartsWith("RF_") ||
                columnName.StartsWith("CLF_") || columnName.StartsWith("CLR_"))
            {
                return "IH";
            }

            // 功率仪设备检测
            if (columnName.Contains("电压") || columnName.Contains("电流") || columnName.Contains("功率") ||
                columnName.Contains("频率") || columnName.Contains("电能") ||
                columnName.Contains("Voltage") || columnName.Contains("Current") || columnName.Contains("Power") ||
                columnName.Contains("Freq") || columnName.Contains("Energy") ||
                columnName.Contains("Ua") || columnName.Contains("Ub") || columnName.Contains("Uc") ||
                columnName.Contains("Ia") || columnName.Contains("Ib") || columnName.Contains("Ic") ||
                columnName.Contains("En"))
            {
                return "Power";
            }

            // 默认为温升仪设备
            return "Temperature";
        }

        #endregion
    }

    #region 数据结构定义

    // 设备数据记录
    public class DeviceDataRecord
    {
        public DateTime Timestamp { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
        public string DeviceType { get; set; }
    }

    // 数据库统计信息
    public class DatabaseStats
    {
        public int TotalRecords { get; set; } = 0;
        public DateTime? EarliestTime { get; set; } = null;
        public DateTime? LatestTime { get; set; } = null;
        public long FileSizeBytes { get; set; } = 0;
        public string DatabasePath { get; set; } = string.Empty;

        // 获取文件大小的
        public string FileSizeDisplay
        {
            get
            {
                if (FileSizeBytes < 1024)
                    return $"{FileSizeBytes} B";
                else if (FileSizeBytes < 1024 * 1024)
                    return $"{FileSizeBytes / 1024.0:F1} KB";
                else if (FileSizeBytes < 1024 * 1024 * 1024)
                    return $"{FileSizeBytes / (1024.0 * 1024.0):F1} MB";
                else
                    return $"{FileSizeBytes / (1024.0 * 1024.0 * 1024.0):F1} GB";
            }
        }
    }

    #endregion
}