// Copyright Information
// ==================================
// Channel9 - EfCore - AwDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCore.EfStructures
{
    public class AwDbContextFactory : IDesignTimeDbContextFactory<AwDbContext>
    {
        //This is only used by the design time tooling CLI
        public AwDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AwDbContext>();
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=Adventureworks2016;Trusted_Connection=true;";
            optionsBuilder
                .UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            //Console.WriteLine(connectionString);
            return new AwDbContext(optionsBuilder.Options);
        }
    }
}