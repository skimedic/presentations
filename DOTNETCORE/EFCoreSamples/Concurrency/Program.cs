using System;
using System.Collections.Generic;
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
                    EntityEntry entryEntity = ex.Entries[0];
                    //Kept in DbChangeTracker
                    PropertyValues originalValues = entryEntity.OriginalValues;
                    PropertyValues currentValues = entryEntity.CurrentValues;
                    IEnumerable<PropertyEntry> modifiedEntries = entryEntity.Properties.Where(e => e.IsModified);
                    foreach (var itm in modifiedEntries)
                    {
                        //Console.WriteLine($"{itm.Metadata.Name},");
                    }
                    //Needs to call to database to get values
                    PropertyValues databaseValues = entryEntity.GetDatabaseValues();
                    //Discards local changes, gets database values, resets change tracker
                    entryEntity.Reload();
                }
            }
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