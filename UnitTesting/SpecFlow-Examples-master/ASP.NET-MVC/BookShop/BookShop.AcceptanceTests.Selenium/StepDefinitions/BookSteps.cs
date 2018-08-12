using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BookShop.AcceptanceTests.Support;
using Bookshop.Controllers;
using Bookshop.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class BookSteps
    {
        public static readonly ReferenceBookList ReferenceBooks = new ReferenceBookList();

        [BeforeScenario]
        public void CleanReferenceBooks()
        {
            ReferenceBooks.Clear();
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table table)
        {
            var db = new BookShopEntities();
            foreach (var row in table.Rows)
            {
                Book book = new Book { Author = row["Author"], Title = row["Title"], Price = Convert.ToDecimal(row["Price"]) };
                if (table.Header.Contains("Id"))
                    ReferenceBooks.Add(row["Id"], book);
                db.AddToBooks(book);
            }
            db.SaveChanges();
        }
    }
}
