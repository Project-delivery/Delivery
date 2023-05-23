using Npgsql;
using System.Xml;
using Newtonsoft.Json;

namespace Delivery.Models
{
    public class DatabaseBackup
    {
        private string connectionString;

        public DatabaseBackup(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void BackupDatabase(string backupFilePath)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'public'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tableName = reader.GetString(0);
                            var tableData = GetTableData(connection, tableName);
                            var tableBackup = new TableBackup { TableName = tableName, TableData = tableData };
                            var json = JsonConvert.SerializeObject(tableBackup, Newtonsoft.Json.Formatting.Indented);
                            var tableBackupFilePath = Path.Combine(backupFilePath, $"{tableName}.json");
                            File.WriteAllText(tableBackupFilePath, json);
                        }
                    }
                }
            }

            Console.WriteLine("Database backup created successfully.");
        }

        private List<Dictionary<string, object>> GetTableData(NpgsqlConnection connection, string tableName)
        {
            var tableData = new List<Dictionary<string, object>>();
            using (var command = new NpgsqlCommand())
            {
                command.Connection = connection;
                command.CommandText = $"SELECT * FROM {tableName}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var rowData = new Dictionary<string, object>();
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var columnName = reader.GetName(i);
                            var columnValue = reader.GetValue(i);
                            rowData.Add(columnName, columnValue);
                        }
                        tableData.Add(rowData);
                    }
                }
            }
            return tableData;
        }
    }
    public class TableBackup
    {
        public string TableName { get; set; }
        public List<Dictionary<string, object>> TableData { get; set; }
    }
}
