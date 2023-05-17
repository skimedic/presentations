using System;
using System.Collections.Generic;
using System.Linq;
using GlobalQueryFilters.Context;
using GlobalQueryFilters.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            using (var db = new BloggingContext())
            {
                Console.WriteLine($"{db.Blogs.Count()} active blogs (LINQ).");
                Console.WriteLine($"{db.Blogs.FromSqlRaw("select * from blogs;").Count()} active blogs (FromSql).");
                Console.WriteLine($"{db.Blogs.IgnoreQueryFilters().Count()} total blogs.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                var blogs = new List<Blog>
                {
                    new Blog {Name = "Skimedic's Blog", Url = "http://skimedic.com", IsDeleted = false},
                    new Blog {Name = "Lee's Blog", Url = "http://leebrandt.me", IsDeleted = true}
                };
                db.AddRange(blogs);
                db.SaveChanges();
            }
        }
    }
}
