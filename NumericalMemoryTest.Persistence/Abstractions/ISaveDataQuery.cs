using NumericalMemoryTest.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Persistence.Abstractions
{
    public interface ISaveDataQuery
    {
        bool SaveData(Result result);
    }
}
