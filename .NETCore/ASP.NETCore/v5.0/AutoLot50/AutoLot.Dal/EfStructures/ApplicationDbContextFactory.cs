// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoLot.Dal.EfStructures
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = @"server=.,5433;Database=AutoLotPresentation;User Id=sa;Password=P@ssw0rd;";
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            Console.WriteLine(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}