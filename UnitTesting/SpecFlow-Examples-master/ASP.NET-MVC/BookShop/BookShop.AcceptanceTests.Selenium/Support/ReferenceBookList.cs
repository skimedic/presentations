using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookshop.Models;
using NUnit.Framework;

namespace BookShop.AcceptanceTests.Support
{
    public class ReferenceBookList : Dictionary<string, Book>
    {
        public Book GetById(string bookId)
        {
            var result = this[bookId.Trim()];
            Assert.IsNotNull(result, "no reference book with id: " + bookId);
            return result;
        }
    }
}
