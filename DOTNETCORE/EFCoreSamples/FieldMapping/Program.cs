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
                Console.WriteLine("Setting properties through C#");
                var blog = new Blog {Name = ".NET Musings"};
                blog.SetUrl("http://www.skimedic.com");

                db.Blogs.Add(blog);
                db.SaveChanges();
                Console.WriteLine("Setting properties through EF materialization");
                var blogs = db.Blogs.OrderBy(b => EF.Property<string>(b, "Url")).ToList();
                foreach (var b in blogs)
                {
                    Console.WriteLine($"{b.Name} ({b.GetUrl()})");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
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
