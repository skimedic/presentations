using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EntityConfiguration.EfStructures
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=SpyStoreHol;Trusted_Connection=True;MultipleActiveResultSets=true;";
            optionsBuilder
                .UseSqlServer(connectionString,
                    options => options.EnableRetryOnFailure().CommandTimeout(60))
                .EnableSensitiveDataLogging(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            Console.WriteLine(connectionString);
            return new StoreDbContext(optionsBuilder.Options);
        }
    }
}