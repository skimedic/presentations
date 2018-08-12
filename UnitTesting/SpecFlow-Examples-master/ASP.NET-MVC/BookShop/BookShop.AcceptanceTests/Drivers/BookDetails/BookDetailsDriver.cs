using System;
using System.Linq;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Support;
using BookShop.Mvc.Controllers;
using BookShop.Mvc.Models;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.Drivers.BookDetails
{
    public class BookDetailsDriver
    {
        private const decimal BookDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public BookDetailsDriver(CatalogContext context)
        {
            _context = context;
        }

        public void AddToDatabase(Table books)
        {
            using (var db = new DatabaseContext())
            {
                foreach (var row in books.Rows)
                {
                    var book = new Book
                    {
                        Author = row["Author"],
                        Title = row["Title"],
                        Price = books.Header.Contains("Price")
                            ? Convert.ToDecimal(row["Price"])
                            : BookDefaultPrice
                    };

                    _context.ReferenceBooks.Add(
                        books.Header.Contains("Id") ? row["Id"] : book.Title,
                        book);

                    db.Books.Add(book);
                }

                db.SaveChanges();
            }
        }

        public void OpenBookDetails(string bookId)
        {
            var book = _context.ReferenceBooks.GetById(bookId);
            using (var controller = new CatalogController())
            {
                _result = controller.Details(book.Id);
            }
        }

        public void ShowsBookDetails(Table expectedBookDetails)
        {
            var shownBookDetails = _result.Model<Book>();
            var row = expectedBookDetails.Rows.Single();
            
            shownBookDetails.Should().Match<Book>(
                b => b.Title == row["Title"]
                && b.Author == row["Author"]
                && b.Price == decimal.Parse(row["Price"]));
        }
    }
}
