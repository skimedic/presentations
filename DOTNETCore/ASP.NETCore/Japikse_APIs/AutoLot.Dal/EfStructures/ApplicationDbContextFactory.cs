// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - ApplicationDbContextFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/2/4
// ==================================

namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var cs = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot_Hol_SV;Integrated Security=true";
        //var cs = @"Server=(localdb)\ProjectModels;Database=AutoLot_Hol;Trusted_Connection=True;";
        //var cs = @"server=.,5433;Database=AutoLot_Hol;User Id=sa;Password=P@ssw0rd;Encrypt=false;";
        optionsBuilder.UseSqlServer(cs);
        optionsBuilder.ConfigureWarnings(cw => cw.Ignore(RelationalEventId.BoolWithDefaultWarning));
        Console.WriteLine(cs);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
