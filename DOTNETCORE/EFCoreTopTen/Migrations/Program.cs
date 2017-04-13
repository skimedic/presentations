using System;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new BloggingContext();
            Console.WriteLine("Deleting database...");
            db.Database.EnsureDeleted();

            //doesn't run the migration to build the UDF
            //Console.WriteLine("Creating database");
            //db.Database.EnsureCreated();

            //creates the database and runs all migrations
            Console.WriteLine("Creating database and running migrations");
            db.Database.Migrate(); 
        }
    }
}