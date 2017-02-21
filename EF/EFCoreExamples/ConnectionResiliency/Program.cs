using System;
using ConnectionResiliency.Context;
using ConnectionResiliency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConnectionResiliency
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            var contextOptionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=SpyStore;user id=foo;password=bar;MultipleActiveResultSets=true;";
            contextOptionsBuilder.UseSqlServer(connectionString,
                o => o.ExecutionStrategy(c => new CustomExecutionStrategy(c, 5, new TimeSpan(0, 0, 0, 0, 30))));
            using (var db = new BloggingContext(contextOptionsBuilder.Options))
            {
                var blog = new Blog { Name = "Skimedic's Blog", Url = "http://skimedic.com" };
                db.Add(blog);
                try
                {
                    db.SaveChanges();
                }
                catch (RetryLimitExceededException ex)
                {
                    //A retry limit error occurred
                    //Should handle intelligently
                    Console.WriteLine($"Retry limit exceeded! {ex.Message}");
                }
                catch (Exception ex)
                {
                    //Should handle intelligently
                    Console.WriteLine(ex);
                    throw;
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}