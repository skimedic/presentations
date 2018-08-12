using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using simpleCalc.Test.Drivers;
using TechTalk.SpecFlow;

namespace simpleCalc.Test.Bindings
{
    [Binding]
    class CalcViewModelBinding
    {
        private readonly MainViewModelDriver _mainViewModelDriver;

        public CalcViewModelBinding(MainViewModelDriver mainViewModelDriver)
        {
            _mainViewModelDriver = mainViewModelDriver;
        }

        [Given(@"the first operand is '(.*)'")]
        public void GivenTheFirstOperandIs(string value)
        {
            _mainViewModelDriver.SetOperand1(value);
        }

        [Given(@"the function is '(.*)'")]
        public void GivenTheFunctionIs(string functionName)
        {
            _mainViewModelDriver.SetFunction(functionName);
        }

        [Given(@"the second operand is '(.*)'")]
        public void GivenTheSecondOperandIs(string value)
        {
            _mainViewModelDriver.SetOperand2(value);
        }

        [When(@"the calcuation is executed")]
        public void WhenTheCalcuationIsExecuted()
        {
            _mainViewModelDriver.Calc();
        }

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(string value)
        {
            _mainViewModelDriver.AssertResult(value);
        }

    }
}
