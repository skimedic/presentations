using System.Collections.Generic;
using BookShop.Mvc.Models;
using FluentAssertions;

namespace BookShop.AcceptanceTests.Support
{
    public class ReferenceBookList : Dictionary<string, Book>
    {
        public Book GetById(string bookId)
        {
            return this[bookId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<Book>().Which;
        }
    }
}
