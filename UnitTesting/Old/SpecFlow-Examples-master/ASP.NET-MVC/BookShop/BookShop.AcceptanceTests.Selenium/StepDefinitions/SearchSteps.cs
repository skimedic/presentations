using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Selenium.Support;
using BookShop.AcceptanceTests.Support;
using Bookshop.Controllers;
using Bookshop.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Selenium.StepDefinitions
{
    [Binding]
    public class SearchSteps : SeleniumStepsBase
    {
        [When(@"I perform a simple search on '(.*)'")]
        public void PerformSimpleSearch(string title)
        {
            selenium.GoToThePage("Home");
            selenium.Type("searchTerm", title);
            selenium.Click("searchButton");
            selenium.WaitForPageToLoad("30000");
        }

        [Then(@"the book list should exactly contain book '(.*)'")]
        public void ThenTheBookListShouldExactlyContainBook(string title)
        {
            ThenTheBookListShouldExactlyContainBooks(title);
        }

        [Then(@"the book list should exactly contain books (.*)")]
        public void ThenTheBookListShouldExactlyContainBooks(string titleList)
        {
            var titles = titleList.Split(',').Select(t => t.Trim().Trim('\''));


            var itemCount = selenium.GetXpathCount("//table/tbody/tr");
            var books = new List<Book>();
            const int headerCount = 1;
            for (int i = headerCount + 1; i <= itemCount; i++)
            {
                string title = selenium.GetText("//table/tbody/tr[" + i + "]/td[@class='title']");
                string author = selenium.GetText("//table/tbody/tr[" + i + "]/td[@class='author']");
                books.Add(new Book { Title = title, Author = author });
            }

            foreach (var title in titles)
                CustomAssert.Any(books, b => b.Title == title);
            Assert.AreEqual(titles.Count(), books.Count, "The list contains other books too");
        }
    }
}