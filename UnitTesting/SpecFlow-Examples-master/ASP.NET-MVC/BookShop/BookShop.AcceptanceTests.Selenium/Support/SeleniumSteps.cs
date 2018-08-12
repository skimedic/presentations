using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Selenium.Support
{
    static public class SeleniumStepsExtensions
    {
        public static void GoToThePage(this ISelenium selenium, string page)
        {
            selenium.Open("/" + page);
        }

        [When(@"I click the link '(.*)'")]
        public static void ClickTheLink(this ISelenium selenium, string link)
        {
            selenium.Click("link=" + link);
            selenium.WaitForPageToLoad("30000");
        }

        [When(@"I click the button '(.*)'")]
        public static void ClickTheButton(this ISelenium selenium, string button)
        {
            selenium.Click("//input[@value='" + button + "']");
            selenium.WaitForPageToLoad("30000");
        }
    }

    [Binding]
    public class SeleniumSteps : SeleniumStepsBase
    {
        [When(@"I go to the '(.*)' page")]
        public void GoToThePage(string page)
        {
            selenium.GoToThePage(page);
        }

        [When(@"I click the link '(.*)'")]
        public void ClickTheLink(string link)
        {
            selenium.ClickTheLink(link);
        }

        [When(@"I click the button '(.*)'")]
        public void ClickTheButton(string button)
        {
            selenium.ClickTheButton(button);
        }
    }
}
