using Find.Context;
using Find.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Find
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            using (var db = new BloggingContext())
            {
                var b = db.Blogs.First();
                var b2 = db.Find<Blog>(b.BlogId);
                var b2a = db.Blogs.Find(b.BlogId);
                var b3 = db.Blogs.First(x => x.BlogId == b.BlogId);
                if (b.BlogId == b2.BlogId && b.BlogId == b2a.BlogId && b.BlogId == b3.BlogId)
                {
                    Console.WriteLine("Found all of the blogs.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Didn't find all of the blogs.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
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
                    new Blog {Name = "Skimedic's Blog", Url = "http://skimedic.com"},
                    new Blog {Name = "Lee's Blog", Url = "http://leebrandt.me"}
                };
                db.AddRange(blogs);
                db.SaveChanges();
            }
        }
    }
}