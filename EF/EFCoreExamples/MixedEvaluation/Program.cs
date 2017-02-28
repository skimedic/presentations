using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MixedEvaluation.Context;
using MixedEvaluation.Models;

namespace MixedEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            //Demo allowing mixed mode
            //var dbAllow = CreateDb(false);
            //RunTest(dbAllow, "Allowing");

            //Demo prevent mix mode
            var dbPrevent = CreateDb(true);
            RunTest(dbPrevent, "Preventing");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static BloggingContext CreateDb(bool preventMixedMode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Demo.MixedEvaluation;Trusted_Connection=True;";

            if (preventMixedMode)
            {
                optionsBuilder.UseSqlServer(connectionString)
                    .ConfigureWarnings(warnings
                        => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            return new BloggingContext(optionsBuilder.Options);
        }

        private static void RunTest(BloggingContext db, string message)
        {
                try
                {
                    Console.WriteLine($"{message} mixed mode evaluation");
                    var blogs = db.Blogs.Where(x => HasWord(x.Name, "Blog")).ToList();
                    Console.WriteLine($"{blogs.Count} blog names contain the word 'Blog'");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                db.Dispose();
        }
        private static bool HasWord(string word, string wordToFind)
        {
            return word.IndexOf(wordToFind,StringComparison.OrdinalIgnoreCase) >=0;
        }
        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                // Insert some new blogs
                db.Blogs.Add(new Blog { Name = "The Horse Blog", Url = "http://sample.com/blogs/horses" });
                db.Blogs.Add(new Blog { Name = "The Snake Blog", Url = "http://sample.com/blogs/snakes" });
                db.Blogs.Add(new Blog { Name = "The Fish Blog", Url = "http://sample.com/blogs/fish" });
                db.Blogs.Add(new Blog { Name = "The Koala Blog", Url = "http://sample.com/blogs/koalas" });
                db.Blogs.Add(new Blog { Name = "The Parrot Blog", Url = "http://sample.com/blogs/parrots" });
                db.Blogs.Add(new Blog { Name = "The Kangaroo Blog", Url = "http://sample.com/blogs/kangaroos" });
                db.SaveChanges();

            }
        }
    }
}