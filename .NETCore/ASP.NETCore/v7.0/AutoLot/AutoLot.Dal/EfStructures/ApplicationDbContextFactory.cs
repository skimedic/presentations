// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/10
// ==================================

using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //var connectionString = @"server=.,5433;Database=AutoLot_Hol;User Id=sa;Password=P@ssw0rd;";
        var connectionString = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot_Hol;Integrated Security=true;Encrypt=false;";
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
        optionsBuilder.ConfigureWarnings(cw => cw.Ignore(RelationalEventId.BoolWithDefaultWarning));
        Console.WriteLine(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}