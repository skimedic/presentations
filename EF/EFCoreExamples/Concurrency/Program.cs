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
                //change values outside of current context
                db.Database.ExecuteSqlCommand($"Update dbo.blogs set name='Foo' where {nameof(Blog.BlogId)} = {blog.BlogId}");
                blog.Name = "Bar";
                try
                {
                    db.SaveChanges();
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
                    PrintProperties(entryEntity, null);
                }
            }
            //PrintTimeStamp(blog1,1);
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
            Console.Write(reloadedValues != null 
                ? "Current | Original | Database:" 
                : "Current | Original:");
            Console.Write($"{ entryEntity.CurrentValues[fieldName]}");
            Console.Write($" | {entryEntity.OriginalValues[fieldName]}");
            if (reloadedValues != null)
            {
                Console.WriteLine($" | {reloadedValues[fieldName]}");
            }
            else
            {
                Console.WriteLine("");
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