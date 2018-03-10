using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Migrations.Models;

namespace Migrations.Context
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<BloggingContext>
    {
        public BloggingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Demo.Migrations;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
            return new BloggingContext(optionsBuilder.Options);
        }
    }
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}