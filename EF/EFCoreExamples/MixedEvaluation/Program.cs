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
            //CreateAndRunTest(true);
            //Demo prevent mix mode
            CreateAndRunTest(false);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private static void CreateAndRunTest(bool allowMixedMode)
        {
            var db = CreateDb(allowMixedMode);
            RunTest(db, allowMixedMode);
        }
        private static BloggingContext CreateDb(bool allowMixedMode)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Demo.MixedEvaluation;Trusted_Connection=True;";

            if (allowMixedMode)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString)
                    .ConfigureWarnings(warnings
                        => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
            return new BloggingContext(optionsBuilder.Options);
        }

        private static void RunTest(BloggingContext db, bool allowMixedMode)
        {
            string message = allowMixedMode ? "Allowing" : "Preventing";
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
            return word.IndexOf(wordToFind, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.Blogs.Add(new Blog { Name = "The Horse Blog", Url = "http://sample.com/blogs/horses" });
                db.SaveChanges();

            }
        }
    }
}