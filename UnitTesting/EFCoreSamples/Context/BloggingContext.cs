using System;
using EFCoreSamples.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSamples.Context
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public BloggingContext()
        {
        }

        public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
        {
        }
    }
}