using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestCalculator;

namespace ExcelExample.Steps
{
    [Binding]
    class CalculatorCommonFeatureSteps
    {
        private readonly Calculator _calculator;

        public CalculatorCommonFeatureSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int firstNumber)
        {
            _calculator.FirstNumber = firstNumber;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int secondNumber)
        {
            _calculator.SecondNumber = secondNumber;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _calculator.Add();
        }

        [When(@"I press substract")]
        public void WhenIPressSubstract()
        {
            _calculator.Subtract();
        }

        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            _calculator.Multiply();
        }

        [When(@"I press divide")]
        public void WhenIPressDivide()
        {
            _calculator.Divide();
        }

        [Then(@"The result should be (.*) on the screen")]
        public void ThenTheResltShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expected: expectedResult, actual: _calculator.Result);
        }
    }
}
