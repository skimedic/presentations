using System;
using Microsoft.EntityFrameworkCore;
using Migrations.Models;

namespace Migrations.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Blog>()
                .Property(e => e.BlogType)
                .HasConversion(
                    v => v.ToString(),
                    v => (BlogTypeEnum)Enum.Parse(typeof(BlogTypeEnum), v));
        }
    }
}