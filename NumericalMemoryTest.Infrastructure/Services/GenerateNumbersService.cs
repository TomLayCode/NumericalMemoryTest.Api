using NumericalMemoryTest.Domain.Abstractions;
using NumericalMemoryTest.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Infrastructure.Services
{
    public class GenerateNumbersService : IGenerateNumbersService
    {
        private readonly Settings _settings;
        public GenerateNumbersService(Settings settings)
        {
            _settings = settings;
        }
        public IList<int> GenerateNumbers()
        {
            var numbers = new List<int>();
            for (var i = 0; i < (_settings.TestLength/3); i++)
            {
                numbers.Add(GenerateNumber(i));
            }

            return numbers;
        }

        #region Helpers
        public int GenerateNumber(int iterantion)
        {
            Random rnd = new Random();
            int month = rnd.Next(1, 13);
        }
        #endregion
    }
}
