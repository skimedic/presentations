using OpenQA.Selenium.Support.PageObjects;
using simpleCalc.Test.Web.Support;

namespace simpleCalc.Test.Web.Pages
{
    public abstract class BasePage
    {
        protected readonly BrowserContext browserContext;
        protected readonly string path;

        protected BasePage(BrowserContext browserContext, string path)
        {
            this.browserContext = browserContext;
            this.path = path;
            PageFactory.InitElements(browserContext.WebDriver, this);
        }

        public virtual void GoTo()
        {
            browserContext.NavigateTo(path);
        }

        public virtual void AssertOnPage()
        {
            browserContext.AssertOnPath(path);
        }
    }
}
