using MySql.Data.MySqlClient;
using NumericalMemoryTest.Infrastructure.Models;
using NumericalMemoryTest.Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Persistence.Queries
{
    public class GetDataQuery : IGetDataQuery
    {
        private readonly NumericalMemoryContext _context;
        public GetDataQuery(NumericalMemoryContext context)
        {
            _context = context;
        }

        public Result GetData(int UserId)
        {
            var result = new Result();

            using (var conn = _context.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand($"select * from Result where id = {UserId}", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.UserId = UserId;
                        result.NumberCorrect = Convert.ToInt32(reader["NumberCorrect"]);
                        result.NumberIncorrect = Convert.ToInt32(reader["NumberIncorrect"]);
                        result.Score = Convert.ToInt32(reader["Score"]);
                    }
                }
            }
            return result;
        }
    }
}
