using System.IO;
using AutoLot.Dal.EfStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace AutoLot.Dal.Tests
{
    public static class TestHelpers
    {
        public static IConfiguration GetConfiguration() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

        public static ApplicationDbContext GetContext(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("AutoLot");
            optionsBuilder.UseSqlServer(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure());
            return new ApplicationDbContext(optionsBuilder.Options);
        }

        public static ApplicationDbContext GetSecondContext(ApplicationDbContext oldContext,
            IDbContextTransaction trans)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(
                oldContext.Database.GetDbConnection(),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.UseTransaction(trans.GetDbTransaction());
            return context;
        }
    }
}