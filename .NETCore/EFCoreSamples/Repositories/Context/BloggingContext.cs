using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using Repositories.Models;

using System;

namespace Repositories.Context;

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
        var connectionString = @"Server=.\dev2019;Database=Demo.Repos;Integrated Security=true;Encrypt=false;";
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            //A concurrency error occurred
            //Should log and handle intelligently
            throw;// new SpyStoreConcurrencyException("A concurrency error happened.", ex);
        }
        catch (RetryLimitExceededException ex)
        {
            //DbResiliency retry limit exceeded
            //Should log and handle intelligently
            throw;// new SpyStoreRetryLimitExceededException("There is a problem with you connection.", ex);
        }
        catch (DbUpdateException ex)
        {
            //Should log and handle intelligently
            if (ex.InnerException is SqlException sqlException)
            {
                if (sqlException.Message.Contains("FOREIGN KEY constraint", StringComparison.OrdinalIgnoreCase))
                {
                    if (sqlException.Message.Contains("table \"Store.Products\", column 'Id'",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        throw;// new SpyStoreInvalidProductException($"Invalid Product Id\r\n{ex.Message}", ex);
                    }

                    if (sqlException.Message.Contains("table \"Store.Customers\", column 'Id'",
                            StringComparison.OrdinalIgnoreCase))
                    {
                        throw;// new SpyStoreInvalidCustomerException($"Invalid Customer Id\r\n{ex.Message}", ex);
                    }
                }
            }

            throw;// new SpyStoreException("An error occurred updating the database", ex);
        }
        catch (Exception ex)
        {
            //Should log and handle intelligently
            throw; //new SpyStoreException("An error occurred updating the database", ex);
        }
    }
}