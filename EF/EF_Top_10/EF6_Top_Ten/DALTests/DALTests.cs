#region copyright
// // Copyright Information
// // ==============================
// // DALTests - DALTests.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.BulkCopy;
using DAL.EF;
using DAL.EF.Initialization;
using DAL.Exceptions;
using DAL.Models;
using DAL.Repos;
using log4net.Config;
using NUnit.Framework;

namespace DALTests
{
    [TestFixture]
    public class DALTests
    {
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            XmlConfigurator.Configure();
            DbInterception.Add(new DatabaseLogger("LogOutput.txt", true));
            DbInterception.Add(new LoggingInterceptor());

        }

        [SetUp]
        public void TestSetUp()
        {
            Database.SetInitializer(new StoreDataInitializer());
        }

        [Test, Ignore]
        public void ShouldRunMigration()
        {
            //Need to add Internals Visible to do this since Configuration is internal 
            var config = new DAL.EF.Migrations.Store.Configuration
            {
                TargetDatabase = new DbConnectionInfo(
                    @"data source=(LocalDb)\MSSQLLocalDB;initial catalog=EF_Top_10;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;",
                    "System.Data.SqlClient")
            };
            var migrator = new DbMigrator(config);
            migrator.Update();
        }
        [Test]
        public void ShouldFailOnConcurrencyError()
        {
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
            var entity = ex.Entries.First();

            entity.CurrentValues["CategoryName"].ShouldEqual(newCategoryName);
            entity.OriginalValues["CategoryName"].ShouldEqual(catName);
            entity.GetDatabaseValues()["CategoryName"].ShouldEqual(otherCatName);
        }

        [Test]
        public void ShouldSucceedEntireTransaction()
        {
            var acctRepo = new AccountRepo();
            var acctXferRepo = new AccountTransactionRepo();
            var accounts = acctRepo.GetAll();
            var xferCount = acctXferRepo.GetAll().Count;
            var xfers = new List<AccountTransaction>()
            {
                new AccountTransaction {Account = accounts[0], Amount = 100, TransactionDate = DateTime.Now},
                new AccountTransaction {Account = accounts[1], Amount = -100, TransactionDate = DateTime.Now},
            };
            acctXferRepo.AddRange(xfers);
            acctXferRepo.GetAll().Count.ShouldEqual(xferCount+2);

        }

        [Test]
        public void ShouldFailEntireTransaction()
        {
            var acctRepo = new AccountRepo();
            var acctXferRepo = new AccountTransactionRepo();
            var accounts = acctRepo.GetAll();
            var xferCount = acctXferRepo.GetAll().Count;
            var xfers = new List<AccountTransaction>()
            {
                new AccountTransaction {Account = accounts[0], Amount = 100, TransactionDate = DateTime.Now},
                new AccountTransaction {Account = accounts[1], Amount = -100},
            };
            Assert.Throws<RetryLimitExceededException>(() => acctXferRepo.AddRange(xfers));
            acctXferRepo.GetAll().Count.ShouldEqual(xferCount);
        }

        [Test]
        public void ShouldGetTableName()
        {
            new AccountTransactionRepo().GetTableName().ShouldEqual("[dbo].[AccountTransactions]");
        }
        [Test]
        public void ShouldDoBulkCopy()
        {
            var accountId = new AccountRepo().GetFirst().Id;
            var xfers = new List<AccountTransaction>();
            for (int x = 0; x < 100; x++)
            {
                xfers.Add(new AccountTransaction { AccountID = accountId, Amount = 100, TransactionDate = DateTime.Now });
            }
            ExecuteBulkCopy.ImportRecordsToSQL(xfers);
            new AccountTransactionRepo().GetAll().Count.ShouldEqual(100);
        }

        [Test]
        public void ShouldLazyLoad()
        {
            var db = new StoreContext();
            var catsSql = db.Categories.ToString();
            catsSql.Contains("Products").ShouldBeFalse();
            var desc = db.Categories.First().Products.ToList()[0]?.Description;
            desc.ShouldNotEqual(null);
        }

        [Test]
        public void ShouldLazyLoadFor()
        {
            var db = new StoreContext();
            var catsSql = db.Categories.ToString();
            catsSql.Contains("Products").ShouldBeFalse();
            var desc = db.Categories.First().Products.ToList()[0]?.Description;
            desc.ShouldNotEqual(null);
        }

        [Test]
        public void ShouldNotLazyLoad()
        {
            //var db = new StoreContext();
            //db.Configuration.LazyLoadingEnabled = false;
            var repo = new CategoryRepo(false);
            var cat = repo.GetFirst();
            var desc = cat.Products?.ToList()[0]?.Description;
            desc.ShouldEqual(null);
        }
        [Test]
        public void ShouldEagerLoad()
        {
            var db = new StoreContext();
            var catsSql = db.Categories.Include(x => x.Products).ToString();
            catsSql.Contains("Products").ShouldBeTrue();
        }

        [Test]
        public void ShouldExplicitlyLoad()
        {
            //var db = new StoreContext();
            //db.Configuration.LazyLoadingEnabled = false;
            var repo = new CategoryRepo(false);
            var cat = repo.GetFirst();
            
            var desc = cat.Products?.ToList()[0]?.Description;
            desc.ShouldEqual(null);
            repo.Context.Entry(cat).Collection(x => x.Products).Load();
            desc = cat.Products?.ToList()[0]?.Description;
            desc.ShouldNotEqual(null);
            //db.Entry(cat).Reference(x => x.ParentCategory).Load();
        }

        [Test]
        public void ShouldExplicitlyLoadWithFilter()
        {
            var repo = new CategoryRepo(false);
            var cat = repo.GetFirst();
            var desc = cat.Products?.ToList()[0]?.Description;
            desc.ShouldEqual(null);
            repo.Context.Entry(cat).Collection(x => x.Products).Query().Where(x=>x.ModelName.Contains("Cigar")).Load();
            desc = cat.Products?.ToList()[0]?.Description;
            desc.ShouldNotEqual(null);
            cat.Products?.Count.ShouldEqual(1);
        }

        [Test]
        public void ShouldUseRetryLogic()
        {
            var acctRepo = new AccountRepo();
            var acctXferRepo = new AccountTransactionRepo();
            var accounts = acctRepo.GetAll();
            var xferCount = acctXferRepo.GetAll().Count;
            var xfer = new AccountTransaction {Account = accounts[1], Amount = -100};
            var ex = Assert.Throws<RetryLimitExceededException>(() => acctXferRepo.Add(xfer));
            acctXferRepo.GetAll().Count.ShouldEqual(xferCount);
        }
    }
}
