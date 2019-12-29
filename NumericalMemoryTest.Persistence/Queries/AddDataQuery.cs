using MySql.Data.MySqlClient;
using NumericalMemoryTest.Infrastructure.Models;
using NumericalMemoryTest.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Persistence.Queries
{
    class AddDataQuery : ISaveDataQuery
    {
        private readonly NumericalMemoryContext _context;
        public AddDataQuery(NumericalMemoryContext context)
        {
            _context = context;
        }

        public bool SaveData(Result result)
        {
            try
            {
                using (var conn = _context.GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand($"select * from Result where id = {UserId}", conn);//TODO: Sql command
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
