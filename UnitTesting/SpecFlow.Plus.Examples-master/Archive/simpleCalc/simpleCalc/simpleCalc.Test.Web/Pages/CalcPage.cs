using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using simpleCalc.Test.Web.Support;

namespace simpleCalc.Test.Web.Pages
{
    class CalcPage : BasePage
    {
        public CalcPage(BrowserContext browserContext) : base(browserContext, "Home/Index")
        {
           
        }

        public override void GoTo()
        {
            base.GoTo();

            var radioButtons = this.browserContext.WebDriver.FindElements(By.Id("Function"));

            foreach (var radioButton in radioButtons)
            {
                switch (radioButton.GetAttribute("value"))
                {
                    case "plus":
                        PlusElement = radioButton;
                        break;
                    case "minus":
                        MinusElement = radioButton;
                        break;
                    case "multiply":
                        MultiplyElement = radioButton;
                        break;
                    case "divide":
                        DivideElement = radioButton;
                        break;
                }
            }
        }

        [FindsBy(How = How.Id)]
        public IWebElement Operand1 { get; set; }

        [FindsBy(How = How.Id)]
        public IWebElement Operand2 { get; set; }

        [FindsBy(How = How.Id)]
        public IWebElement calcButton { get; set; }

        [FindsBy(How= How.Id)]
        public IWebElement result { get; set; }

        public IWebElement PlusElement { get; set; }
        public IWebElement MinusElement { get; set; }
        public IWebElement MultiplyElement { get; set; }
        public IWebElement DivideElement { get; set; }
    }
}
