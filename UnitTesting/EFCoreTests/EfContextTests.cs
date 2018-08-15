using System;
using EFCoreSamples.Context;
using EFCoreSamples.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Xunit;

namespace EFCoreTests
{
    public class EfContextTests : IDisposable
    {
        public EfContextTests()
        {
            SetupDatabase();
        }

        public void Dispose()
        {
        }

        [Fact]
        public void Should_Throw_Retry_Limit_Exceeded_Exception()
        {
            BloggingContext db = SetUpContext(true);
            using (db)
            {
                var blog = new Blog { Name = "Skimedic's Blog", Url = "http://skimedic.com" };
                db.Add(blog);
                Assert.Throws<RetryLimitExceededException>(() => db.SaveChanges());
            }

        }

        [Fact]
        public void Should_Test_Concurrency_Errors()
        {
            BloggingContext db = SetUpContext(false);
            var strategy = db.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    var blog = new Blog { Name = "Skimedic's Blog", Url = "http://skimedic.com" };
                    db.Add(blog);
                    db.SaveChanges();
                    db.Database.ExecuteSqlCommand($"Update Blogs set Name='Test' where id = {blog.Id}");
                    blog.Url = "NewUrl";
                    db.Update(blog);
                    var ex = Assert.Throws<DbUpdateConcurrencyException>(() => db.SaveChanges());
                    Assert.Single(ex.Entries);
                    Assert.Equal("NewUrl", ex.Entries[0].CurrentValues[nameof(Blog.Url)]);
                    Assert.Equal("http://skimedic.com", ex.Entries[0].GetDatabaseValues()[nameof(Blog.Url)]);
                    transaction.Rollback();
                }
            });

        }
        private static BloggingContext SetUpContext(bool useCustomStrategy)
        {
            var builder = new DbContextOptionsBuilder<BloggingContext>();
            var baseConnectionString =
                @"Server=(localdb)\mssqllocaldb;Database=UnitTestingEF;MultipleActiveResultSets=true;";
            if (useCustomStrategy)
            {
                builder = builder.UseSqlServer($"{baseConnectionString}user id=foo;password=bar",
                o => o.ExecutionStrategy(c => new CustomExecutionStrategy(c, 5, new TimeSpan(0, 0, 0, 0, 30))));
            }
            else
            {
                builder = builder.UseSqlServer($"{baseConnectionString}Integrated Security=true;", o => o.EnableRetryOnFailure());
            }

            builder = builder.ConfigureWarnings(
                warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            return new BloggingContext(builder.Options);
        }

        private static void SetupDatabase()
        {
            using (var db = SetUpContext(false))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

    }
}
