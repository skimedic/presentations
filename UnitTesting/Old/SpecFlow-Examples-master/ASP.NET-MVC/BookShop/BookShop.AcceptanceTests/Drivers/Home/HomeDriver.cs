using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Common;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.Home
{
    public class HomeDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Index();
            }
        }

        public void ShowsBook(string expectedTitle)
        {
            var shownBooks = _result.Model<IEnumerable<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitle);
        }

        public void ShowsBooks(string expectedTitles)
            => ShowsBooks(from t in expectedTitles.Split(',')
                          select t.Trim().Trim('\''));

        public void ShowsBooks(Table expectedBooks)
            => ShowsBooks(expectedBooks.Rows.Select(r => r["Title"]));

        public void ShowsBooks(IEnumerable<string> expectedTitles)
        {
            var shownBooks = _result.Model<IEnumerable<Book>>();
            BookAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }
    }
}
