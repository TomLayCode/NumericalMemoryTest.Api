using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Persistence
{
    public class NumericalMemoryContext
    {
        public string ConnectionString { get; set; }
        public NumericalMemoryContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
