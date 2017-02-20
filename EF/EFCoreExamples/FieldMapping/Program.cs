using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FieldMapping.Context;
using FieldMapping.Models;

namespace FieldMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();

            using (var db = new BloggingContext())
            {
                var blog = new Blog {Name = "Rowan's Blog"};
                blog.SetUrl("http://romiller.com");

                db.Blogs.Add(blog);
                db.SaveChanges();

                var blogs = db.Blogs.OrderBy(b => EF.Property<string>(b, "Url")).ToList();
                foreach (var b in blogs)
                {
                    Console.WriteLine($"{b.Name} ({b.GetUrl()})");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
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
