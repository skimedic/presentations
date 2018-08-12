using System.Linq;
using BookShop.Mvc.Models;
using BookShop.WebTests.Selenium.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using BookShop.AcceptanceTests.Common;

namespace BookShop.WebTests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class SearchSteps : SeleniumStepsBase
    {

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            selenium.NavigateTo("Home");

            selenium.SetTextBoxValue("searchTerm", searchTerm);
            selenium.SubmitForm("searchForm");
        }


        [Then(@"the list of found books should contain only: '(.*)'")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {
            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));
            var foundBooks = from row in selenium.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.FoundBooksShouldMatchTitles(foundBooks, expectedTitles);
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);
            var foundBooks = from row in selenium.FindElements(By.XPath("//table/tbody/tr"))
                             let title = row.FindElement(By.ClassName("title")).Text
                             let author = row.FindElement(By.ClassName("author")).Text
                             select new Book { Title = title, Author = author };

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

    }
}