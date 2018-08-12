using OpenQA.Selenium;

namespace BookShop.WebTests.Selenium.Support
{
    public abstract class SeleniumStepsBase
    {
// ReSharper disable InconsistentNaming
        protected IWebDriver selenium
// ReSharper restore InconsistentNaming
        {
            get { return SeleniumController.Instance.Selenium; }
        }
    }
}