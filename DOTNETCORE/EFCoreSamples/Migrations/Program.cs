using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Migrations.Models;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var blog = new Blog {Url = "my link"};
            var posts = new List<Post>
            {
                new Post {Content = "content 1", Title = "Title1"},
                new Post {Content = "content 2", Title = "Title2"},
                new Post {Content = "content 3", Title = "Title3"},
                new Post {Content = "content 4", Title = "Title4"},
                new Post {Content = "content 5", Title = "Title5"},
            };

            blog.Posts.AddRange(posts);


            var db = new BloggingContextFactory().CreateDbContext(new string[0]);
            Console.WriteLine("Deleting database...");
            db.Database.EnsureDeleted();

            //doesn't run the migration to build the UDF
            //Console.WriteLine("Creating database");
            //db.Database.EnsureCreated();

            //creates the database and runs all migrations
            Console.WriteLine("Creating database and running migrations");
            db.Database.Migrate();


            db.Blogs.Add(blog);
            db.SaveChanges();
            var foo = "foo";
        }
    }
}