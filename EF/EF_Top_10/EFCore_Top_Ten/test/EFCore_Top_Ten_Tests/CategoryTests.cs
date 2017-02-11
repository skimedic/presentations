#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten_Tests - CategoryTests.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using EFCore_Top_Ten.EF;
using EFCore_Top_Ten.Exceptions;
using EFCore_Top_Ten.Models;
using EFCore_Top_Ten.Repos;
using EFCore_Top_Ten_Tests.Utilities;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using EFCore_Top_Ten.BulkCopy;

namespace EFCore_Top_Ten_Tests
{
    [Collection("Database Testing")]
    public class CategoryTests : IDisposable
    {
        private readonly StoreContext _db;

        public CategoryTests()
        {
            _db = new StoreContext();
            DatabaseUtilities.CleanDataBase(_db, "Store.Category");
            DatabaseUtilities.CleanDataBase(_db, "Store.AccountTransactions");
            DatabaseUtilities.CleanDataBase(_db, "Store.Accounts");
        }
        public void Dispose()
        {
            DatabaseUtilities.CleanDataBase(_db, "Store.Category");
            DatabaseUtilities.CleanDataBase(_db, "Store.AccountTransactions");
            DatabaseUtilities.CleanDataBase(_db, "Store.Accounts");
            _db.Dispose();
        }

        //private Category CreateCategoryInstance(string categoryName)
        //{
        //    return new Category { CategoryName = categoryName };
        //}
        private void AddCategory(string categoryName)
        {
            AddCategory(new Category { CategoryName = categoryName });
        }
        private void AddCategory(Category category)
        {
            new CategoryRepo().Add(category);
        }

        [Fact]
        public void ShouldAddACategory()
        {
            AddCategory("TestCategory");
        }
        [Fact]
        public void ShouldFailOnConcurrencyError()
        {
            AddCategory("TestCategory");
            var repo1 = new CategoryRepo();
            var cat1 = repo1.GetFirst();

            var repo2 = new CategoryRepo();
            var cat2 = repo2.GetFirst();

            var catName = cat1.CategoryName;

            var otherCatName = "foo";
            cat1.CategoryName = otherCatName;
            repo1.Save(cat1);

            var newCategoryName = "bar";
            cat2.CategoryName = newCategoryName;

            var ex =
                Assert.Throws<DbUpdateConcurrencyException>(() => repo2.Save(cat2));
        }
        public static IList<Account> GetAccounts() => new List<Account>
        {
            new Account {AccountNumber = "1234", Balance = 100.00},
            new Account {AccountNumber = "5678", Balance = 200.00}
        };

        private void AddAccountTransactions()
        {
            var repo = new AccountRepo();
            GetAccounts().ToList().ForEach(x => repo.Add(x));
        }

        [Fact]
        public void ShouldSucceedEntireTransaction()
        {
            AddAccountTransactions();
            var acctRepo = new AccountRepo();
            var acctXferRepo = new AccountTransactionRepo();
            var accounts = acctRepo.GetAll();
            var xferCount = acctXferRepo.GetAll().Count;
            var xfers = new List<AccountTransaction>()
            {
                new AccountTransaction {AccountID = accounts[0].Id, Amount = 100, TransactionDate = DateTime.Now},
                new AccountTransaction {AccountID = accounts[1].Id, Amount = -100, TransactionDate = DateTime.Now},
            };
            acctXferRepo.AddRange(xfers);
            acctXferRepo.GetAll().Count.Equals(xferCount + 2);

        }

        [Fact]
        public void ShouldFailEntireTransaction()
        {
            AddAccountTransactions();
            var acctRepo = new AccountRepo();
            var acctXferRepo = new AccountTransactionRepo();
            var accounts = acctRepo.GetAll();
            var xferCount = acctXferRepo.GetAll().Count;
            var xfers = new List<AccountTransaction>()
            {
                new AccountTransaction {Account = accounts[0], Amount = 100, TransactionDate = DateTime.Now},
                new AccountTransaction {Account = accounts[1], Amount = -100},
            };
            Assert.Throws<DbUpdateException>(() => acctXferRepo.AddRange(xfers));
            acctXferRepo.GetAll().Count.Equals(xferCount);
        }
        [Fact]
        public void ShouldDoBulkCopy()
        {
            AddAccountTransactions();
            var accountId = new AccountRepo().GetFirst().Id;
            var xfers = new List<AccountTransaction>();
            for (int x = 0; x < 100; x++)
            {
                xfers.Add(new AccountTransaction { AccountID = accountId, Amount = 100, TransactionDate = DateTime.Now });
            }
            ExecuteBulkCopy.ImportRecordsToSQL(xfers);
            new AccountTransactionRepo().GetAll().Count.Equals(100);
        }


        //[Fact]
        //public void ShouldGetAllCategories()
        //{
        //    _db.Categories.Add(CreateCategoryInstance("Foo"));
        //    _db.Categories.Add(CreateCategoryInstance("Bar"));
        //    _db.SaveChanges();
        //    var categories = _db.Categories.ToList();
        //    Assert.Equal(2, _db.Categories.Count());
        //    Assert.Equal("Foo", categories[0].CategoryName);
        //    Assert.Equal("Bar", categories[1].CategoryName);
        //}

        //[Fact]
        //public void ShouldGetFirstCategory()
        //{
        //    _db.Categories.Add(CreateCategoryInstance("Foo"));
        //    _db.Categories.Add(CreateCategoryInstance("Bar"));
        //    _db.SaveChanges();
        //    var cat = _db.Categories.First();
        //    Assert.Equal("Foo", cat.CategoryName);
        //    Assert.Equal(2, cat.Id);
        //}

        //[Fact]
        //public void ShouldUpdateACategory()
        //{
        //    _db.Categories.Add(CreateCategoryInstance("Foo"));
        //    _db.SaveChanges();
        //    var category = _db.Categories.First();
        //    category.CategoryName = "Bar";
        //    _db.Categories.Update(category);
        //    Assert.Equal(EntityState.Modified, _db.Entry(category).State);
        //    _db.SaveChanges();
        //    Assert.Equal(EntityState.Unchanged, _db.Entry(category).State);
        //    Assert.Equal("Bar", _db.Categories.First().CategoryName);
        //}

        //[Fact]
        //public void ShouldNotUpdateANonAttachedCategory()
        //{
        //    var category = CreateCategoryInstance("Foo");
        //    _db.Categories.Add(category);
        //    category.CategoryName = "Bar";
        //    Assert.Throws<InvalidOperationException>(() => _db.Categories.Update(category));
        //}

        //[Fact]
        //public void ShouldDeleteACategory()
        //{
        //    _db.Categories.Add(CreateCategoryInstance("Foo"));
        //    _db.Categories.Add(CreateCategoryInstance("Bar"));
        //    _db.SaveChanges();
        //    Assert.Equal(2, _db.Categories.Count());
        //    var category = _db.Categories.First();
        //    _db.Categories.Remove(category);
        //    Assert.Equal(EntityState.Deleted, _db.Entry(category).State);
        //    _db.SaveChanges();
        //    Assert.Equal(EntityState.Detached, _db.Entry(category).State);
        //    Assert.Equal(1, _db.Categories.Count());
        //}
        //[Fact]
        //public void ShouldNotDeleteACategoryWithoutTimestampData()
        //{
        //    var category = CreateCategoryInstance("Foo");
        //    _db.Categories.Add(category);
        //    _db.SaveChanges();
        //    var db2 = new StoreContext();
        //    var catToDelete = new Category { Id = category.Id};
        //    db2.Categories.Remove(catToDelete);
        //    var ex = Assert.Throws<DbUpdateConcurrencyException>(() =>db2.SaveChanges());
        //    Assert.Equal(1,ex.Entries.Count);
        //    Assert.Equal(2,((Category)ex.Entries[0].Entity).Id);
        //}
        //[Fact]
        //public void ShouldDeleteACategoryWithTimestampData()
        //{
        //    var category = CreateCategoryInstance("Foo");
        //    _db.Categories.Add(category);
        //    _db.SaveChanges();
        //    var db2 = new StoreContext();
        //    var catToDelete = new Category { Id = category.Id, TimeStamp = category.TimeStamp};
        //    db2.Entry(catToDelete).State = EntityState.Deleted;
        //    var affected = db2.SaveChanges();
        //    Assert.Equal(1,affected);
        //}

    }
}
