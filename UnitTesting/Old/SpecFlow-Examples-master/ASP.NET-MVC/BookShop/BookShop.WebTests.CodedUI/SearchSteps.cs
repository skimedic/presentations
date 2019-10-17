using System.Collections.Generic;
using System.Linq;
using BookShop.Mvc.Models;
using TechTalk.SpecFlow;
using BookShop.WebTests.CodedUI.Support;
using BookShop.AcceptanceTests.Common;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace BookShop.WebTests.CodedUI
{
    [Binding, Scope(Tag = "webCodedUI")]
    public class SearchSteps : CodedUIStepsBase
    {

        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string searchTerm)
        {
            map.Home();
            map.Search(searchTerm);
        }


        [Then(@"the list of found books should contain only: '(.*)'")]
        public void ThenTheListOfFoundBooksShouldContainOnly(string expectedTitleList)
        {
            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));

            var foundBooks = _collectListedBooks();

            BookAssertions.FoundBooksShouldMatchTitles(foundBooks, expectedTitles);
        }

        private List<Book> _collectListedBooks()
        {
            var foundBooks = map.ShopHome.DocumentResult.ResultTable.Rows.OfType<HtmlRow>()
                .Select(row => new Book()
                {
                    Title = row.Cells[0].GetProperty("InnerText").ToString().Trim(),
                    Author = row.Cells[1].GetProperty("InnerText").ToString().Trim()
                }).ToList();
            return foundBooks;
        }

        [Then(@"the list of found books should be:")]
        public void ThenTheListOfFoundBooksShouldBe(Table expectedBooks)
        {
            var foundBooks = _collectListedBooks();

            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);

            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }

    }
}