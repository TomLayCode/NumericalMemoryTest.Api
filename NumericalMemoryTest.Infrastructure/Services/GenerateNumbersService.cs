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
            int number = 0;
            if (iterantion % 2 != 0) { iterantion = iterantion + 1; }
            for (var i = 0; i < iterantion; i++)
            {
                if (number == 0) 
                {
                    number = GenerateDigit();
                }
                else
                {
                    number = int.Parse(number.ToString() + GenerateDigit().ToString());
                }  
            }

            return number;
        }

        public int GenerateDigit()
        {
            Random rnd = new Random();
            return rnd.Next(1, 9);
        }
        #endregion
    }
}
