using System;
using System.Linq;
using Batching.Models;
using Batching.Context;
using Microsoft.EntityFrameworkCore;

namespace Batching
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();

            using (var db = new BloggingContext())
            {
                // Modify some existing blogs
                var existing = db.Blogs.ToArray();
                existing[0].Url = "http://sample.com/blogs/dogs";
                existing[1].Url = "http://sample.com/blogs/cats";

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

        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureCreated();

                if (db.Blogs.Any())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM dbo.Blogs");
                }

                db.Blogs.Add(new Blog {Name = "The Dog Blog", Url = "http://sample.com/dogs"});
                db.Blogs.Add(new Blog {Name = "The Cat Blog", Url = "http://sample.com/cats"});
                db.SaveChanges();
            }
        }
    }
}