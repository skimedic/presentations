using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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
}