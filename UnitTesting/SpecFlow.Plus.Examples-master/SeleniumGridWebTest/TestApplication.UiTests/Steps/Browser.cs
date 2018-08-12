using System.Configuration;
using FluentAssertions;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;

namespace TestApplication.UiTests.Steps
{
    [Binding]
    public class Browser
    {
        private readonly WebDriver _webDriver;

        public Browser(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedTo(string url)
        {
            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();
            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];
            driver.Navigate().GoToUrl($"{baseUrl}{url}");
        }

        [Then(@"browser title is (.*)")]
        public void ThenBrowserTitleIs(string title)
        {
            var result = _webDriver.Wait.Until(d => d.Title);

            result.Should().Be(title);
        }


        [AfterScenario()]
        public void CloseBrowserAfterTest()
        {
            _webDriver.Quit();
        }
    }
}
