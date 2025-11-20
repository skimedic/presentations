// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot;Integrated Security=true;";
        //var connectionString = @"Server=(localdb)\ProjectModels;Database=AutoLot;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.ConfigureWarnings(cw => cw.Ignore(RelationalEventId.BoolWithDefaultWarning));
        Console.WriteLine(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
