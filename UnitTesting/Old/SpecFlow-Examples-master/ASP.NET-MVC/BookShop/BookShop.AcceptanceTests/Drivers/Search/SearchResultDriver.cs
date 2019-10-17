using System.Collections.Generic;
using System.Linq;
using BookShop.AcceptanceTests.Common;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Search
{
    public class SearchResultDriver
    {
        private readonly SearchResultState _state;

        public SearchResultDriver(SearchResultState state)
        {
            _state = state;
        }

        public void ShowsBooks(string expectedTitlesString)
        {
            var shownBooks = _state.ActionResult.Model<IEnumerable<Book>>();
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                 select t.Trim().Trim('\'');

            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }

        public void ShowsBooks(Table expectedBooks)
        {
            var foundBooks = _state.ActionResult.Model<IEnumerable<Book>>();
            var expectedTitles = expectedBooks.Rows.Select(r => r["Title"]);
            BookAssertions.FoundBooksShouldMatchTitlesInOrder(foundBooks, expectedTitles);
        }
    }
}
