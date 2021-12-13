namespace AutoLot.Dal.EfStructures;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = @"server=.,5433;Database=AutoLot;User Id=sa;Password=P@ssw0rd;";
        //var connectionString = @"server=(localdb)\MsSqlLocalDb;Database=AutoLot;Integrated Security=true";
        optionsBuilder.UseSqlServer(connectionString);
        //optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
        Console.WriteLine(connectionString);
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
