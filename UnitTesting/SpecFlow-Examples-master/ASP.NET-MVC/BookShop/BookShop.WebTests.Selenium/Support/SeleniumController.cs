using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
////using OpenQA.Selenium.IE;

namespace BookShop.WebTests.Selenium.Support
{
    public class SeleniumController
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
        public static SeleniumController Instance = new SeleniumController();

        public IWebDriver Selenium { get; private set; }

        public void Start()
        {
            if (!(Selenium is null))
            {
                return;
            }

            string appUrl = ConfigurationManager.AppSettings["AppUrl"];

            Selenium = new FirefoxDriver();
            ////this.Selenium = new InternetExplorerDriver();
            Selenium.Manage().Timeouts().ImplicitWait = DefaultTimeout;

            ////Selenium = new DefaultSelenium("localhost", 4444, "*chrome", appUrl);
            ////Selenium.Start();
            Trace("Selenium started");
        }

        public void Stop()
        {
            if (Selenium is null)
            {
                return;
            }

            try
            {
                Selenium.Quit();
                Selenium.Dispose();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc, "Selenium stop error");
            }

            Selenium = null;
            Trace("Selenium stopped");
        }

        private static void Trace(string message) => Console.WriteLine($"-> {message}");
    }
}