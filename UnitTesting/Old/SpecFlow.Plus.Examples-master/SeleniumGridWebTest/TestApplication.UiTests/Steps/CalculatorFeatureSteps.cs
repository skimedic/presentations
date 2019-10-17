using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Steps
{
    [Binding]
    public class CalculatorFeatureSteps
    {
        private readonly WebDriver _webDriver;

        public CalculatorFeatureSteps(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }
       
        [Given(@"I have entered (.*) into (.*) calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0, string id)
        {
            _webDriver.Wait.Until(d => d.FindElement(By.Id(id))).SendKeys(p0.ToString());
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            var addButton = _webDriver.Wait.Until(d => d.FindElement(By.Id("AddButton")));
            addButton.Submit();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            var result = _webDriver.Wait.Until(d => d.FindElement(By.Id("result")));

            result.Text.Should().Be(p0.ToString());
        }
    }
}
