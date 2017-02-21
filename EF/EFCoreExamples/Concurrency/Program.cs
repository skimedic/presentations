using System;
using System.Linq;
using Concurrency.Context;
using Concurrency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            using (var db = new BloggingContext())
            {
                var blog = new Blog {Name = "Skimedic's Blog", Url = "http://skimedic.com"};
                db.Add(blog);
                db.SaveChanges();
            }
            var context1 = new BloggingContext();
            var blog1 = context1.Blogs.First();
            //Create a new context to simulate different user - could also use SQL Command
            var context2 = new BloggingContext();
            var blog2 = context2.Blogs.First();
            PrintTimeStamp(blog1, 1);
            PrintTimeStamp(blog2, 2);
            blog1.Name = ".NET Musings";
            context1.SaveChanges();
            Console.WriteLine("After save:");
            PrintTimeStamp(blog1,1);
            blog2.Url = "foo";
            try
            {
                context2.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine(ex.Message);
                var entryEntity = ex.Entries[0];
                var databaseValues = entryEntity.GetDatabaseValues();
                Console.WriteLine("------------------------------------------");
                PrintProperties(entryEntity, databaseValues);
                Console.WriteLine("------------------------------------------");
                var modifiedEntries = entryEntity.Properties.Where(e => e.IsModified);
                Console.WriteLine("Modified Properties");
                foreach (var itm in modifiedEntries)
                {
                    Console.WriteLine($"{itm.Metadata.Name},");
                }
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Reloaded Properties");
                entryEntity.Reload();
                PrintProperties(entryEntity,null);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void PrintProperties(
            EntityEntry entryEntity, 
            PropertyValues databaseValues)
        {
            Console.WriteLine($"Property Values:");
            PrintFieldValues(entryEntity, databaseValues, nameof(Blog.Name));
            PrintFieldValues(entryEntity, databaseValues, nameof(Blog.Url));

        }
        private static void PrintFieldValues(
            EntityEntry entryEntity, 
            PropertyValues reloadedValues,
            string fieldName)
        {
            Console.WriteLine($"Field Name:{fieldName}");
            Console.WriteLine($"Current:  {entryEntity.CurrentValues[fieldName]}");
            Console.WriteLine($"Original: {entryEntity.OriginalValues[fieldName]}");
            if (reloadedValues != null)
            {
                Console.WriteLine($"Database: {reloadedValues[fieldName]}");
            }

        }
        private static void PrintTimeStamp(Blog blog, int counter)
        {
            Console.Write($"Timestamp for item {counter}:");
            for (int x = 0; x < blog.Timestamp.Length; x++)
            {
                if (x < blog.Timestamp.Length - 1)
                {
                    Console.Write(blog.Timestamp[x]);
                }
                else
                {
                    Console.WriteLine(blog.Timestamp[x]);
                }
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