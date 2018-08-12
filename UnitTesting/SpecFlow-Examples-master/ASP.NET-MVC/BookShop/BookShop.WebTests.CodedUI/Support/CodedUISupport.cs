using System.Configuration;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting;


namespace BookShop.WebTests.CodedUI.Support
{
    [Binding]
    public static class CodedUISupport
    {
        private static bool ReuseWebSession
        {
            //get { return ConfigurationManager.AppSettings["ReuseWebSession"] == "true"; }
            get { return false; }
        }

        [BeforeScenario("webCodedUI")]
        public static void BeforeWebScenario()
        {
            CodedUIController.Instance.Start();
        }

        [AfterScenario("webCodedUI")]
        public static void AfterWebScenario()
        {
            if (!ReuseWebSession)
                CodedUIController.Instance.Stop();
        }

        //[AfterFeature]
        [AfterTestRun]
        public static void AfterWebFeature()
        {
            CodedUIController.Instance.Stop();
        }
    }
}