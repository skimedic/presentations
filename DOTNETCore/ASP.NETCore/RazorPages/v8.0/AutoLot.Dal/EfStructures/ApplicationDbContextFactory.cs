﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var cs = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot;Integrated Security=true";
        //var cs = @"Server=(localdb)\ProjectModels;Database=AutoLot;Trusted_Connection=True;";
        //var cs = @"server=.,5433;Database=AutoLot;User Id=sa;Password=P@ssw0rd;Encrypt=false;";
        optionsBuilder.UseSqlServer(cs);
        //optionsBuilder.UseSqlServer(cs, options => options.EnableRetryOnFailure());
        optionsBuilder.ConfigureWarnings(cw => cw.Ignore(RelationalEventId.BoolWithDefaultWarning));
        Console.WriteLine(cs);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
