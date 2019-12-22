using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalMemoryTest.Infrastructure.Models
{
    public class Result
    {
        public int UserId { get; set; }
        public int Score { get; set; }
        public int NumberCorrect { get; set; }
        public int NumberIncorrect { get; set; }
    }
}
