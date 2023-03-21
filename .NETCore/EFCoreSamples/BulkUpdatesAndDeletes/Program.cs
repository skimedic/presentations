using BulkUpdatesAndDeletes.Context;
using BulkUpdatesAndDeletes.Models;
using Microsoft.EntityFrameworkCore;

SetupDatabase();

using (var db = new BloggingContext())
{
    Console.WriteLine("Adding SOme Records");

    db.Blogs.Add(new Blog
    {
        Name = ".NET Musings",
        Url = "http://www.skimedic.com"
    });
    db.Blogs.Add(new Blog
    {
        Name = "Some Other Blog",
        Url = "http://www.someotherblog.com"
    });
    db.SaveChanges();
    Console.WriteLine("Using Execute Update");

    //These don't work
    //db.Blogs.ExecuteUpdate(b => b.SetProperty(p => p.Name, p => $"""{p.Name} Updated"""));
    //db.Blogs.ExecuteUpdate(b => b.SetProperty(p => p.Name, p => $"{p.Name} Updated"));
    //This one does
    db.Blogs.Where(b=>b.Name==".NET Musings")
        .ExecuteUpdate(b => b.SetProperty(p => p.Name, p => p.Name + " Updated"));
    
    Console.WriteLine("Change Tracker still has the old value");
    foreach (var b in db.Blogs)
    {
        Console.WriteLine($"{b.Name} ({b.Url})");
    }

    db.ChangeTracker.Clear();
    Console.WriteLine("Must query the database again to get the update");

    foreach (var b in db.Blogs)
    {
        Console.WriteLine($"{b.Name} ({b.Url})");
    }

    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
}


static void SetupDatabase()
{
    using (var db = new BloggingContext())
    {
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();
    }
}