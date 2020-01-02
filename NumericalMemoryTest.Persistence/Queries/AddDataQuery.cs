using MySql.Data.MySqlClient;
using NumericalMemoryTest.Infrastructure.Models;
using NumericalMemoryTest.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Persistence.Queries
{
    public class AddDataQuery : ISaveDataQuery
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
                    MySqlCommand cmd = new MySqlCommand(
                        $"INSERT INTO Result " +
                        $"(UserId, Score, NumberCorrect, NumberIncorrect) " +
                        $"VALUES({result.UserId}, {result.Score}, {result.NumberCorrect}, {result.NumberIncorrect})", conn);
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
