using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PerformanceEfCore.EfStructures;

namespace SpyStore.Hol.Dal.EfStructures
{
    public class Aw2016DbContextFactory : IDesignTimeDbContextFactory<Aw2016Context>
    {
        public Aw2016Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Aw2016Context>();
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=Adventureworks2016;Trusted_Connection=True;MultipleActiveResultSets=true;";
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseSqlServer(connectionString,options => options.EnableRetryOnFailure().CommandTimeout(100));

            //optionsBuilder
            //    .UseSqlServer(connectionString, options =>
            //        options.EnableRetryOnFailure().CommandTimeout(60))
            //    .EnableSensitiveDataLogging(true)
            //    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            Console.WriteLine(connectionString);
            return new Aw2016Context(optionsBuilder.Options);
        }
    }
}