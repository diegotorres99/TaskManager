using Microsoft.Data.Sqlite;
using System;

namespace TaskManager.Model.DataContext
{
    public class DataContext : IDisposable
    {
        private readonly string _connectionString;
        private SqliteConnection? _connection;

        public DataContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));

            _connectionString = connectionString;
        }

        // This method opens the connection to the SQLite database
        public SqliteConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqliteConnection(_connectionString);
                _connection.Open(); // Open the connection when it's first accessed
            }
            return _connection;
        }

        // Dispose pattern for cleanup
        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
