using System;
using System.Linq;
using Batching.Models;
using Batching.Context;
using Microsoft.EntityFrameworkCore;

namespace Batching;

class Program
{
    static void Main(string[] args)
    {
        //Run with default batching
        var options = CreateOptions(false);
        SetupDatabase(options);
        RunQueries(options);

        //Run with custom batching
        //optionsBuilder.UseSqlServer(connectionString,options => options.MaxBatchSize(1));
        var optionsWithCustomBatching = CreateOptions(true);
        SetupDatabase(optionsWithCustomBatching);
        RunQueries(optionsWithCustomBatching);
    }

    private static void RunQueries(DbContextOptions<BloggingContext> options)
    {
        using (var db = new BloggingContext(options))
        {
            // Modify some existing blogs
            var existing = db.Blogs.ToArray();
            existing[0].Url = "http://sample.com/blogs/dogs";
            existing[1].Url = "http://sample.com/blogs/cats";

            // Insert some new blogs
            db.Blogs.Add(new Blog {Name = "The Horse Blog", Url = "http://sample.com/blogs/horses"});
            db.Blogs.Add(new Blog {Name = "The Snake Blog", Url = "http://sample.com/blogs/snakes"});
            db.Blogs.Add(new Blog {Name = "The Fish Blog", Url = "http://sample.com/blogs/fish"});
            db.Blogs.Add(new Blog {Name = "The Koala Blog", Url = "http://sample.com/blogs/koalas"});
            db.Blogs.Add(new Blog {Name = "The Parrot Blog", Url = "http://sample.com/blogs/parrots"});
            db.Blogs.Add(new Blog {Name = "The Kangaroo Blog", Url = "http://sample.com/blogs/kangaroos"});

            try
            {
                db.SaveChanges();
                /*
exec sp_executesql N'SET NOCOUNT ON;
UPDATE [Blogs] SET [Url] = @p0
WHERE [BlogId] = @p1;
SELECT @@ROWCOUNT;

UPDATE [Blogs] SET [Url] = @p2
WHERE [BlogId] = @p3;
SELECT @@ROWCOUNT;

DECLARE @inserted2 TABLE ([BlogId] int, [_Position] [int]);
MERGE [Blogs] USING (
VALUES (@p4, @p5, 0),
(@p6, @p7, 1),
(@p8, @p9, 2),
(@p10, @p11, 3),
(@p12, @p13, 4),
(@p14, @p15, 5)) AS i ([Name], [Url], _Position) ON 1=0
WHEN NOT MATCHED THEN
INSERT ([Name], [Url])
VALUES (i.[Name], i.[Url])
OUTPUT INSERTED.[BlogId], i._Position
INTO @inserted2;

SELECT [t].[BlogId] FROM [Blogs] t
INNER JOIN @inserted2 i ON ([t].[BlogId] = [i].[BlogId])
ORDER BY [i].[_Position];

',N'@p1 int,@p0 nvarchar(4000),@p3 int,@p2 nvarchar(4000),@p4 nvarchar(4000),@p5 nvarchar(4000),@p6 nvarchar(4000),@p7 nvarchar(4000),@p8 nvarchar(4000),@p9 nvarchar(4000),@p10 nvarchar(4000),@p11 nvarchar(4000),@p12 nvarchar(4000),@p13 nvarchar(4000),@p14 nvarchar(4000),@p15 nvarchar(4000)',@p1=33,@p0=N'http://sample.com/blogs/dogs',@p3=34,@p2=N'http://sample.com/blogs/cats',@p4=N'The Horse Blog',@p5=N'http://sample.com/blogs/horses',@p6=N'The Snake Blog',@p7=N'http://sample.com/blogs/snakes',@p8=N'The Fish Blog',@p9=N'http://sample.com/blogs/fish',@p10=N'The Koala Blog',@p11=N'http://sample.com/blogs/koalas',@p12=N'The Parrot Blog',@p13=N'http://sample.com/blogs/parrots',@p14=N'The Kangaroo Blog',@p15=N'http://sample.com/blogs/kangaroos'

                 */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
    private static DbContextOptions<BloggingContext> CreateOptions(bool useCustomBatching)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
        var connectionString = @"Server=.\dev2019;Database=Demo.Batching;Integrated Security=true;Encrypt=false;";

        if (useCustomBatching)
        {
            optionsBuilder.UseSqlServer(connectionString, options => options.MaxBatchSize(1));
        }
        else
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        return optionsBuilder.Options;
    }

    private static void SetupDatabase(DbContextOptions<BloggingContext> options)
    {
        using (var db = new BloggingContext(options))
        {
            db.Database.EnsureCreated();

            if (db.Blogs.Any())
            {
                db.Database.ExecuteSqlRaw("DELETE FROM dbo.Blogs");
            }

            db.Blogs.Add(new Blog {Name = "The Dog Blog", Url = "http://sample.com/dogs"});
            db.Blogs.Add(new Blog {Name = "The Cat Blog", Url = "http://sample.com/cats"});
            db.SaveChanges();
        }
    }
}