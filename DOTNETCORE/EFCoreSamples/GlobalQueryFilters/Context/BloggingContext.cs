using GlobalQueryFilters.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters.Context
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
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString =
                    @"Server=(localdb)\mssqllocaldb;Database=Demo.GlobalQueryFilters;Integrated Security=true;";
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}