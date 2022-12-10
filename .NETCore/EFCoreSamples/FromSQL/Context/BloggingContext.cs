using System.ComponentModel.DataAnnotations.Schema;
using FromSQLDbQuery.Models;
using Microsoft.EntityFrameworkCore;

namespace FromSQLDbQuery.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        //[NotMapped]
        public DbSet<ShortBlog> ShortBlogs { get; set; }

        [NotMapped]
        public DbSet<ShortBlogQuery> ShortBlogsQuery { get; set; }

        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=.\dev2019;Database=Demo.FromSQL;Integrated Security=true;Encrypt=false;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortBlog>().HasKey(x => x.BlogId);
            modelBuilder.Entity<ShortBlogQuery>().ToView("ViewName").HasNoKey();
        }
    }
}