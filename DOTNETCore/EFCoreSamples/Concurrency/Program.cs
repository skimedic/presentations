﻿using System;
using System.Collections.Generic;
using System.Linq;
using Concurrency.Context;
using Concurrency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;

namespace Concurrency;

class Program
{
    static void Main(string[] args)
    {
        SetupDatabase();
        using (var db = new BloggingContext())
        {
            var blog = new Blog {Name = "Skimedic's Blog", Url = "http://skimedic.com"};
            var blog2 = new Blog {Name = "Brandon's Blog", Url = "http://thirtywaystodropdatabases.com"};
            db.Blogs.Add(blog);
            db.Blogs.Add(blog2);
            var foo = db.Blogs;
            db.SaveChanges();
            //change values outside of current context
            db.Database.ExecuteSqlInterpolated($"Update dbo.blogs set name='Foo' where BlogId = {blog.BlogId}");
            blog.Name = "Bar";
            blog2.Name = "Brandon's retired and digging ditches now";
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
                IEnumerable<PropertyEntry> modifiedEntries = 
                    entryEntity.Properties.Where(e => e.IsModified);
                foreach (var itm in modifiedEntries)
                {
                    //Console.WriteLine($"{itm.Metadata.Name},");
                }
                //Needs to call to database to get values
                PropertyValues databaseValues = entryEntity.GetDatabaseValues();
                //Discards local changes, gets database values, resets change tracker
                entryEntity.Reload();
                //logging stuff here
                //throw new AppDbUpdateException(ex,IList<Customer>)
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