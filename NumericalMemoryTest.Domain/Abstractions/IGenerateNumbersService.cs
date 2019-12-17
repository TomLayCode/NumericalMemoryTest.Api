using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Domain.Abstractions
{
    public interface IGenerateNumbersService
    {
        IList<int> GenerateNumbers();
    }
}
