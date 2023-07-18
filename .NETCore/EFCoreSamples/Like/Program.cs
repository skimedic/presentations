using System;
using System.Collections.Generic;
using System.Linq;
using HelperFunctions.Context;
using HelperFunctions.Models;
using Microsoft.EntityFrameworkCore;

namespace HelperFunctions;

class Program
{
    static void Main(string[] args)
    {
        SetupDatabase();
        using (var db = new BloggingContext())
        {
            var b = db.Blogs.First(x => EF.Functions.Like(x.Name,"%medic%"));
            Console.WriteLine(b.Name);
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
                new Blog {Name = "Skimedic's Blog", Url = "http://skimedic.com"},
                new Blog {Name = "Lee's Blog", Url = "http://leebrandt.me"}
            };
            db.AddRange(blogs);
            db.SaveChanges();
        }
    }
}