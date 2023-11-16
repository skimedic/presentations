// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var cs = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot_MVC;Integrated Security=true";
        //var cs = @"Server=(localdb)\ProjectModels;Database=AutoLot_Hol;Trusted_Connection=True;";
        optionsBuilder.UseSqlServer(cs);
        //optionsBuilder.UseSqlServer(cs, options => options.EnableRetryOnFailure());
        optionsBuilder.ConfigureWarnings(cw => cw.Ignore(RelationalEventId.BoolWithDefaultWarning));
        Console.WriteLine(cs);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
