using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PerformanceEfCore.EfStructures;

namespace SpyStore.Hol.Dal.EfStructures
{
    public class Aw12016DbContextFactory : IDesignTimeDbContextFactory<Aw12016Context>
    {
        public Aw12016Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Aw12016Context>();
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=Adventureworks2016;Trusted_Connection=True;MultipleActiveResultSets=true;";
            optionsBuilder
                .UseSqlServer(connectionString, options =>
                    options.EnableRetryOnFailure().CommandTimeout(60))
                .EnableSensitiveDataLogging(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            Console.WriteLine(connectionString);
            return new Aw12016Context(optionsBuilder.Options);
        }
    }
}