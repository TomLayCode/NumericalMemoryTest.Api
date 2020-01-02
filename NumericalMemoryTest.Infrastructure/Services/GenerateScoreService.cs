using NumericalMemoryTest.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Infrastructure.Services
{
    public class GenerateScoreService : IGenerateScoreService
    {
        public int GenerateScore(int numberCorrect, int score)
        {
            return (score*numberCorrect);
        }
    }
}
