using System;
using System.Collections.Generic;
using System.Linq;
using FromSQL.Context;
using FromSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace FromSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Get data from function:");
                var blogs = db.Blogs
                    .FromSql("SELECT * FROM dbo.SearchBlogs(@p0)", "Snake")
                    .OrderBy(b => b.Url);
                foreach (var itm in blogs)
                {
                    Console.WriteLine($"{itm.Name}:{itm.Url}");
                }
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Get data for non table model");
                IEnumerable<ShortBlog> shortBlogs = db.ShortBlogs
                    .FromSql("SELECT * FROM dbo.Blogs")
                    .OrderBy(b => b.Url).ToList();
                foreach (var itm in shortBlogs)
                {
                    Console.WriteLine($"{itm.Url}");
                }
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void SetupDatabase()
        {
            using (var db = new BloggingContext())
            {
                db.Database.EnsureDeleted();
                if (db.Database.EnsureCreated())
                {
                    db.Database.ExecuteSqlCommand(
                        "CREATE FUNCTION [dbo].[SearchBlogs] (@term nvarchar(200)) RETURNS TABLE AS RETURN (SELECT * FROM dbo.Blogs WHERE Url LIKE '%' + @term + '%')");

                    db.Blogs.Add(new Blog {Name = "The Horse Blog", Url = "http://sample.com/blogs/horses"});
                    db.Blogs.Add(new Blog {Name = "The Snake Blog", Url = "http://sample.com/blogs/snakes"});
                    db.Blogs.Add(new Blog {Name = "The Fish Blog", Url = "http://sample.com/blogs/fish"});
                    db.Blogs.Add(new Blog {Name = "The Koala Blog", Url = "http://sample.com/blogs/koalas"});
                    db.Blogs.Add(new Blog {Name = "The Parrot Blog", Url = "http://sample.com/blogs/parrots"});
                    db.Blogs.Add(new Blog {Name = "The Kangaroo Blog", Url = "http://sample.com/blogs/kangaroos"});
                    db.SaveChanges();
                }
            }
        }
    }
}

