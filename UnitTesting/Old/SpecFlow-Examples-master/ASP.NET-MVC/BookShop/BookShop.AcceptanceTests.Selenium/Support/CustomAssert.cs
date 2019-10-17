using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BookShop.AcceptanceTests.Support
{
    public static class CustomAssert
    {
        public static void Any<T>(IEnumerable<T> items, Func<T, bool> predicate)
        {
            Assert.IsTrue(items.Any(predicate), "The collection does not contain the expected item");
        }
    }
}
