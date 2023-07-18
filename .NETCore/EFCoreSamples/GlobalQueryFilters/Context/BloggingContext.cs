using GlobalQueryFilters.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters.Context;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public int TenantId { get;set; }
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
                @"Server=.\dev2019;Database=Demo.GlobalQueryFilters;Integrated Security=true;Encrypt=false;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasQueryFilter(p => !p.IsDeleted && p.BlogId == TenantId);
    }
}