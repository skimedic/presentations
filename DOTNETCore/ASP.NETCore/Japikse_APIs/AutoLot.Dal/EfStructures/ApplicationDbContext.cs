// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - ApplicationDbContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/2/4
// ==================================

namespace AutoLot.Dal.EfStructures;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    [DbFunction("udf_CountOfMakes", Schema = "dbo")]
    public static int InventoryCountFor(int makeId)
        => throw new NotSupportedException();

    //The FromExpression call in the CLR function body allows
    //for the function to be used instead of a regular DbSet
    [DbFunction("udtf_GetCarsForMake", Schema = "dbo")]
    public IQueryable<CarViewModel> GetCarsFor(int makeId)
        => FromExpression(() => GetCarsFor(makeId));

    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<CarDriver> CarsToDrivers { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Radio> Radios { get; set; }
    public DbSet<SeriLogEntry> SeriLogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CarConfiguration().Configure(modelBuilder.Entity<Car>());
        new DriverConfiguration().Configure(modelBuilder.Entity<Driver>());
        new CarDriverConfiguration().Configure(modelBuilder.Entity<CarDriver>());
        new RadioConfiguration().Configure(modelBuilder.Entity<Radio>());
        new MakeConfiguration().Configure(modelBuilder.Entity<Make>());
        new SeriLogEntryConfiguration().Configure(modelBuilder.Entity<SeriLogEntry>());
        new CarViewModelConfiguration().Configure(modelBuilder.Entity<CarViewModel>());
    }

    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            //A concurrency error occurred
            //Should log and handle intelligently
            Console.WriteLine(ex.Message);
            EntityEntry entryEntity = ex.Entries[0];
            //Kept in DbChangeTracker
            PropertyValues originalValues = entryEntity.OriginalValues;
            PropertyValues currentValues = entryEntity.CurrentValues;
            IEnumerable<PropertyEntry> modifiedEntries = 
                entryEntity.Properties.Where(e => e.IsModified);
            foreach (var itm in modifiedEntries)
            {
                //Console.WriteLine($"{itm.Metadata.Name},");
            }
            //Needs to call to database to get values
            PropertyValues databaseValues = entryEntity.GetDatabaseValues();
            //Discards local changes, gets database values, resets change tracker
            //entryEntity.Reload();
            throw new CustomConcurrencyException("A concurrency error happened.", ex);
        }
        catch (RetryLimitExceededException ex)
        {
            //DbResiliency retry limit exceeded
            //Should log and handle intelligently
            throw new CustomRetryLimitExceededException("There is a problem with SQL Server.", ex);
        }
        catch (DbUpdateException ex)
        {
            //Should log and handle intelligently
            throw new CustomDbUpdateException("An error occurred updating the database", ex);
        }
        catch (Exception ex)
        {
            //Should log and handle intelligently
            throw new CustomException("An error occurred updating the database", ex);
        }
    }
}