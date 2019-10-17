using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace simpleCalc.Test.Web.Support
{
    public class BrowserContext
    {
        private static Lazy<IWebDriver> webDriver = CreateLazyWebDriver();

        private static Lazy<IWebDriver> CreateLazyWebDriver()
        {
            return new Lazy<IWebDriver>(() => new FirefoxDriver());
        }

        public IWebDriver WebDriver
        {
            get { return webDriver.Value; }
        }

        public Uri BaseUrl { get; private set; }

        public BrowserContext()
        {
            BaseUrl = new Uri("http://localhost:12578"); 
        }

        public void NavigateTo(string path)
        {
            WebDriver.Navigate().GoToUrl(GetUrl(path));
        }

        private Uri GetUrl(string path)
        {
            return new Uri(BaseUrl, path);
        }

        public static void Quit()
        {
            if (GetIsInitialized())
            {
                webDriver.Value.Quit();
                webDriver = CreateLazyWebDriver();
            }
        }

        private static bool GetIsInitialized()
        {
            return webDriver.IsValueCreated;
        }

        public bool IsInitialized
        {
            get { return GetIsInitialized(); }
        }

        public void AssertOnPath(string path)
        {
            var url = GetUrl(path);
            url.Should().Be(new Uri(WebDriver.Url));
        }
    }
}
