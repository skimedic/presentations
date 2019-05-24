using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options): base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=Demo.Repos;Integrated Security=true;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}