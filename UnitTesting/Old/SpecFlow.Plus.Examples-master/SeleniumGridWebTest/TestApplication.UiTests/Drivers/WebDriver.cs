using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace TestApplication.UiTests.Drivers
{
    public class WebDriver
    {
        private IWebDriver _currentWebDriver;

        public IWebDriver Current
        {
            get
            {
                if (_currentWebDriver != null)
                    return _currentWebDriver;
                DriverOptions desiredCapabilities;

                switch (BrowserConfig)
                {
                    case "IE":
                        desiredCapabilities = new InternetExplorerOptions();
                        break;
                    case "Chrome":
                        desiredCapabilities = new ChromeOptions();
                        break;
                    case "Firefox":
                        desiredCapabilities = new FirefoxOptions();
                        break;
                    default:
                        throw new NotSupportedException($"{BrowserConfig} is not a supported browser");
                }

                _currentWebDriver = new RemoteWebDriver(new Uri(ConfigurationManager.AppSettings["seleniumHub"]), desiredCapabilities);

                return _currentWebDriver;
            }
        }

        private WebDriverWait _wait;
        public WebDriverWait Wait => _wait ?? (_wait = new WebDriverWait(Current, TimeSpan.FromSeconds(10)));

        protected string BrowserConfig => ConfigurationManager.AppSettings["browser"];
        protected string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        public void Quit()
        {
            if (_currentWebDriver != null)
            {
                _currentWebDriver.Quit();
                _currentWebDriver.Dispose();
                _currentWebDriver = null;
            }
        }
    }
}
