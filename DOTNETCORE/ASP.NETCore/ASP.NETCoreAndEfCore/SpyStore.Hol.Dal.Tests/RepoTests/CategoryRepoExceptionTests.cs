using System;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Models.Entities;
using System.Linq;
using SpyStore.Hol.Dal.Exceptions;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Dal.Tests.RepoTests.Base;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class CategoryRepoExceptionTests : RepoTestsBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryRepoExceptionTests()
        {
            _repo = new CategoryRepo(Db);
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldNotDeleteOnConcurrencyIssue()
        {
            var category = new Category {CategoryName = "Foo"};
            _repo.Add(category);
            _repo.Context.Database.ExecuteSqlCommand("Update Store.Categories set CategoryName = 'Bar'");
            var ex = Assert.Throws<SpyStoreConcurrencyException>(() => _repo.Delete(category));
        }

        //[Fact]
        //public void ShouldThrowRetryExeptionWhenCantConnect()
        //{
        //    var contextOptionsBuilder = new DbContextOptionsBuilder<StoreContext>();
        //    var connectionString =
        //        @"Server=(localdb)\mssqllocaldb;Database=SpyStore;user id=foo;password=bar;MultipleActiveResultSets=true;";
        //    //contextOptionsBuilder.UseSqlServer(connectionString, 
        //    //    o => o.EnableRetryOnFailure(2,new TimeSpan(0,0,0,0,100),new Collection<int>{ -2146232060 }));
        //    contextOptionsBuilder.UseSqlServer(connectionString,
        //        options => options.ExecutionStrategy(c => new MyExecutionStrategy(c, 5, new TimeSpan(0, 0, 0, 0, 30))));

        //    var repo = new CategoryRepo(contextOptionsBuilder.Options);
        //    var category = new Category {CategoryName = "Foo"};
        //    var ex = Assert.Throws<RetryLimitExceededException>(()=> repo.Add(category));
        //}

    }
}