using NumericalMemoryTest.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Persistence.Abstractions
{
    public interface IGetDataQuery
    {
        public Result GetData(int UserId);
    }
}
