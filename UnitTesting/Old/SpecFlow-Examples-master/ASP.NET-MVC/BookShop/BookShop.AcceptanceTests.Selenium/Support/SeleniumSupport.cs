using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Selenium.Support
{
    [Binding]
    public static class SeleniumSupport
    {
        private static bool ReuseWebSession
        {
            get { return ConfigurationManager.AppSettings["ReuseWebSession"] != "true"; }
        }

        [BeforeScenario("web")]
        public static void BeforeWebScenario()
        {
            StartSelenium();
        }

        [AfterScenario("web")]
        public static void AfterWebScenario()
        {
            if (ReuseWebSession)
                StopSelenium();

            Assert.AreEqual("", ScenarioContext.Current.SeleniumErrors().ToString(), "Selenium verification errors");
        }

        [AfterFeature]
        public static void AfterWebFeature()
        {
            StopSelenium();
        }

        private static ISelenium seleniumCache = null;

        private static void StartSelenium()
        {
            if (seleniumCache == null)
            {
//                var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
//                var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
                var appUrl = ConfigurationManager.AppSettings["AppUrl"];

                //AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory);
                seleniumCache = new DefaultSelenium("localhost", 4444, "*chrome", appUrl);
                //seleniumCache = new DefaultSelenium("localhost", 4444, "*firefoxproxy", appUrl);
                seleniumCache.Start();
                Console.WriteLine("-> Selenium started");
            }
            ScenarioContext.Current.SetSelenium(seleniumCache);
        }

        private static void StopSelenium()
        {
            if (seleniumCache == null)
                return;

            try
            {
                seleniumCache.Stop();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex, "Selenium stop error");
            }
            seleniumCache = null;
            Console.WriteLine("-> Selenium stopped");
        }
    }

    public static class ScenarioContextWebExtensions
    {
        public static ISelenium Selenium(this ScenarioContext scenarioContext)
        {
            var result = (ISelenium)ScenarioContext.Current["selenium"];
            Assert.IsNotNull(result, "selenium is not started");
            return result;
        }

        public static bool IsSeleniumRunning(this ScenarioContext scenarioContext)
        {
            return ScenarioContext.Current["selenium"] != null;
        }

        public static void SetSelenium(this ScenarioContext scenarioContext, ISelenium selenium)
        {
            ScenarioContext.Current["selenium"] = selenium;
            ScenarioContext.Current["selenium-errors"] = new StringBuilder();
        }

        public static StringBuilder SeleniumErrors(this ScenarioContext scenarioContext)
        {
            var result = (StringBuilder)ScenarioContext.Current["selenium-errors"];
            Assert.IsNotNull(result, "selenium is not started");
            return result;
        }
    }

    public abstract class SeleniumStepsBase
    {
        protected ISelenium selenium
        {
            get { return ScenarioContext.Current.Selenium(); }
        }
    }
}