using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using simpleCalc.PCL;

namespace simpleCalc.Test.Drivers
{
    class MainViewModelDriver
    {
        private readonly MainViewModel _mainViewModel;
        public MainViewModelDriver()
        {
            _mainViewModel = new MainViewModel();
        }

        public void SetOperand1(string value)
        {
            var doubleValue = Convert.ToDouble(value);
            _mainViewModel.Operand1 = doubleValue;
        }

        public void SetOperand2(string value)
        {
            var doubleValue = Convert.ToDouble(value);
            _mainViewModel.Operand2 = doubleValue;
        }

        public void AssertResult(string value)
        {
            _mainViewModel.Result.Should().Be(value);
        }

        public void Calc()
        {
            _mainViewModel.CalcCommand.Execute(null);
        }

        public void SetFunction(string functionName)
        {
            switch (functionName.ToUpper())
            {
                case "PLUS":
                    _mainViewModel.PlusOperator = true;
                    break;
                case "MINUS":
                    _mainViewModel.MinusOperator = true;
                    break;
                case "MULTIPLY":
                    _mainViewModel.MultiplyOperator = true;
                    break;
                case "DIVIDE":
                    _mainViewModel.DivideOperator = true;
                    break;
            }
        }
    }
}
