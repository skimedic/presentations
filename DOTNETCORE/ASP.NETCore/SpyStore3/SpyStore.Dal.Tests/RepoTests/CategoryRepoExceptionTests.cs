using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.Exceptions;
using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Dal.Tests.RepoTests.Base;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests
{
    [Collection("SpyStore.Dal")]
    public class CategoryRepoExceptionTests : RepoTestsBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryRepoExceptionTests()
        {
            _repo = new CategoryRepo(Context);
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
            _repo.Context.Database.ExecuteSqlRaw("Update Store.Categories set CategoryName = 'Bar'");
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