using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SpyStore.Hol.Dal.EfStructures
{
  public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
  {
    public StoreContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
#if SQL2017
            //use sqllocaldb to update/create localdb instances
            var path = Environment.GetEnvironmentVariable("APPDATA");
            var connectionString =
                $@"Data Source=(localdb)\mssqllocaldb2017;Initial Catalog=SpyStore2.2_2017;Trusted_Connection=True;MultipleActiveResultSets=true;AttachDbFileName={path}\SpyStore2.2_2017.mdf;";
#elif LOCALDB
            var connectionString =
                @"Server=(localdb)\mssqllocaldb;Database=SpyStoreHol;Trusted_Connection=True;MultipleActiveResultSets=true;";
#else
      var connectionString =
        @"Server=.,6433;Database=SpyStoreHol;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;";
#endif
      optionsBuilder
        .UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
      Console.WriteLine(connectionString);
      return new StoreContext(optionsBuilder.Options);
    }
  }
}