using System;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BookShop.WebTests.Selenium.Support
{
    public static class WebDriverExtensions
    {
        public static string GetTextBoxValue(this IWebDriver browser, string field)
        {
            var control = GetFieldControl(browser, field);

            return control.GetAttribute("value");
        }

        public static void SetTextBoxValue(this IWebDriver browser, string field, string value)
        {
            var control = GetFieldControl(browser, field);
            var wait = new WebDriverWait(browser, SeleniumController.DefaultTimeout);
            if (!string.IsNullOrEmpty(control.GetAttribute("value")))
            {
                control.Clear();
                wait.Until(_ => string.IsNullOrEmpty(control.GetAttribute("value")));
            }
            
            control.SendKeys(value);
//            wait.Until( _ => control.Value == value);
            System.Threading.Thread.Sleep(100);
        }

        public static void SubmitForm(this IWebDriver browser, string formId = null)
        {
            var form = formId == null ? GetForm(browser) : browser.FindElements(By.Id(formId)).First();
            form.Submit();
            System.Threading.Thread.Sleep(100);
        }

        public static void ClickButton(this IWebDriver browser, string buttonId)
        {
            browser.FindElements(By.Id(buttonId)).First().Click();
        }

        private static IWebElement GetFieldControl(IWebDriver browser, string field)
        {
            var form = GetForm(browser);
            return form.FindElement(By.Id(field));
        }

        private static IWebElement GetForm(IWebDriver browser)
        {
            return browser.FindElements(By.TagName("form")).First();
        }

        public static void NavigateTo(this IWebDriver browser, string relativeUrl)
        {
            browser.Navigate().GoToUrl(new Uri(new Uri(ConfigurationManager.AppSettings["AppUrl"]), relativeUrl));
        }

        public static DropDown GetDropDown(this IWebDriver browser, string id)
        {
            return browser.FindElement(By.Id(id)).AsDropDown();
        }

        public static DropDown AsDropDown(this IWebElement e)
        {
            return new DropDown(e);
        }

        public class DropDown
        {
            private readonly IWebElement _dropDown;

            public DropDown(IWebElement dropDown)
            {
                this._dropDown = dropDown;

                if (dropDown.TagName != "select")
                    throw new ArgumentException("Invalid web element type");
            }

            public string SelectedValue
            {
                get
                {
                    var selectedOption = _dropDown.FindElements(By.TagName("option")).FirstOrDefault(e => e.Selected);

                    return selectedOption?.GetAttribute("value");

                }
                set
                {
                    new SelectElement(_dropDown).SelectByValue(value);
                }
            }
        }
    }
}
