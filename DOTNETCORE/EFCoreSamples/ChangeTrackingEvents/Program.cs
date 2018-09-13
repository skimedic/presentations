using System;
using System.Collections.Generic;
using System.Linq;
using ChangeTrackingEvents.Context;
using ChangeTrackingEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ChangeTrackingEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Name = "Skimedic's Blog", Url = "http://skimedic.com" };
                Console.WriteLine("Going to add to DbSet<T>");
                db.Add(blog);
                Console.WriteLine("Going to save added record");
                db.SaveChanges();
                Console.WriteLine("Saved the added record");
            }
            //using (var db = new BloggingContext())
            //{
            //    var blog = db.Blogs.First();
            //}
            //using (var db = new BloggingContext())
            //{
            //    var blog = db.Blogs.AsNoTracking().First();
            //}
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
