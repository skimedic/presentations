using System;
using ConnectionResiliency.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectionResiliency.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=Demo.ConnectionResiliency;Trusted_Connection=True;";
            // EnablesRetryOnFailure adds default SqlServerRetryingExecutionStrategy
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(connectionString);
                //optionsBuilder.UseSqlServer(connectionString, options
                //    => options.EnableRetryOnFailure());
                optionsBuilder.UseSqlServer(connectionString,
                    options => options.ExecutionStrategy(
                        c => new CustomExecutionStrategy(
                            c, 5, new TimeSpan(0, 0, 0, 0, 30))));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}