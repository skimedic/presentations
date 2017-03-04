using System.ComponentModel.DataAnnotations.Schema;
using FromSQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FromSQL.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        [NotMapped]
        public DbSet<ShortBlog> ShortBlogs { get; set; }
        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Demo.FromSQL;Trusted_Connection=True;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortBlog>().HasKey(x => x.BlogId);
        }
    }
}