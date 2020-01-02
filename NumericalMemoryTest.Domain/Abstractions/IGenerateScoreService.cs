using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Domain.Abstractions
{
    public interface IGenerateScoreService
    {
        int GenerateScore(int numberCorrect, int score);
    }
}
