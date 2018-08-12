using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using CalculatorUnitTests.Driver;
using CalculatorUnitTests.Helper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace CalculatorUnitTests.Steps
{
    [Binding]
    public class CalculatorFeatureSteps
    {
        private readonly Calculator _calculator;
        private static Process _driver;

        public CalculatorFeatureSteps(Calculator calculator)
        {
            _calculator = calculator;
        }

        [BeforeTestRun]
        public static void StartWinAppDriver()
        {
            try
            {
                _driver = Process.Start(ConfigurationManager.AppSettings["winAppPath"]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not locate WinAppDriver.exe, get it from https://github.com/Microsoft/WinAppDriver/releases and change the winAppPath in app.settings accordingly");
                throw new FileNotFoundException("Could not locate File WinAppDriver.exe", e);
            }
        }

        [AfterTestRun]
        public static void KillWinAppDriver()
        {
            _driver.Kill();
        }

        [Given(@"I navigated to Standard Calculator")]
        public void GivenINavigatedToStandard()
        {
            _calculator.NavigateToStandard();
        }
        
        [Given(@"I have entered (.*) into calculator")]
        public void GivenIHaveEnteredIntoCalculator(string p0)
        {
            _calculator.EnterNumber(p0);
        }
        
        [Given(@"I press (.*)")]
        public void GivenIPress(string p0)
        {
            _calculator.EnterSign(p0);
        }
        
        [When(@"I press (.*)")]
        public void WhenIPressEquals(string p0)
        {
            _calculator.EnterSign(p0);
        }

        [Then(@"Calculator title is (.*)")]
        public void ThenBrowserTitleIs(string p0)
        {
            _calculator.GetTitle().Should().Be(p0);
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {
            _calculator.GetResult().Should().Be(p0);
        }
    }
}
