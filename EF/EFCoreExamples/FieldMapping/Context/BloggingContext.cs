using FieldMapping.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldMapping.Context
{
    //https://docs.microsoft.com/en-us/ef/core/modeling/backing-field
    /*
      Automatically included:
      _<camelCase property name>
      _propertyName
      m__<camelCase property name>
      m_propertyName
     */
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Demo.FieldMapping;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property<string>("Url")
                .HasField("_url");
            //.Property(x => x.Url)
        }
    }
}