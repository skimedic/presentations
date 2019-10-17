using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Calculator
    {
        public int FirstNumber { private get; set; }
        public int SecondNumber { private get; set; }

        public int Result { get; private set; }

        public void Add()
        {
            Result = FirstNumber + SecondNumber;
        }

        public void Subtract()
        {
            Result = FirstNumber - SecondNumber;
        }

        public void Multiply()
        {
            Result = FirstNumber * SecondNumber;
        }

        public void Divide()
        {
            Result = FirstNumber / SecondNumber;
        }
    }
}
