﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - ApplicationDbContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Dal.EfStructures;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        SavingChanges += (sender, args) =>
        {
            string cs = ((ApplicationDbContext)sender)!.Database!.GetConnectionString();
            Console.WriteLine($"Saving changes for {cs}");
        };
        SavedChanges += (sender, args) =>
        {
            string cs = ((ApplicationDbContext)sender)!.Database!.GetConnectionString();
            Console.WriteLine($"Saved {args!.EntitiesSavedCount} changes for {cs}");
        };
        SaveChangesFailed += (sender, args) =>
        {
            Console.WriteLine($"An exception occurred! {args.Exception.Message} entities");
        };
        ChangeTracker.Tracked += ChangeTracker_Tracked;
        ChangeTracker.StateChanged += ChangeTracker_StateChanged;
    }

    private void ChangeTracker_Tracked(object sender, EntityTrackedEventArgs e)
    {
        var source = (e.FromQuery) ? "Database" : "Code";
        if (e.Entry.Entity is Car c)
        {
            Console.WriteLine($"Car entry {c.PetName} was added from {source}");
        }
    }

    private void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
    {
        if (e.Entry.Entity is not Car c)
        {
            return;
        }

        var action = string.Empty;
        Console.WriteLine($"Car {c.PetName} was {e.OldState} before the state changed to {e.NewState}");
        switch (e.NewState)
        {
            case EntityState.Unchanged:
                action = e.OldState switch
                {
                    EntityState.Added => "Added",
                    EntityState.Modified => "Edited",
                    _ => action
                };
                Console.WriteLine($"The object was {action}");
                break;
        }
    }

    [DbFunction("udf_CountOfMakes", Schema = "dbo")]
    public static int InventoryCountFor(int makeId)
        => throw new NotSupportedException();

    //The FromExpression call in the CLR function body allows
    //for the function to be used instead of a regular DbSet
    [DbFunction("udtf_GetCarsForMake", Schema = "dbo")]
    public IQueryable<Car> GetCarsFor(int makeId)
        => FromExpression(() => GetCarsFor(makeId));

    public DbSet<CreditRisk> CreditRisks { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerOrderViewModel> CustomerOrderViewModels { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<CarDriver> CarsToDrivers { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Radio> Radios { get; set; }
    public DbSet<SeriLogEntry> SeriLogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CarConfiguration().Configure(modelBuilder.Entity<Car>());
        new DriverConfiguration().Configure(modelBuilder.Entity<Driver>());
        new CarDriverConfiguration().Configure(modelBuilder.Entity<CarDriver>());
        new RadioConfiguration().Configure(modelBuilder.Entity<Radio>());
        new CustomerConfiguration().Configure(modelBuilder.Entity<Customer>());
        new MakeConfiguration().Configure(modelBuilder.Entity<Make>());
        new CreditRiskConfiguration().Configure(modelBuilder.Entity<CreditRisk>());
        new OrderConfiguration().Configure(modelBuilder.Entity<Order>());
        new SeriLogEntryConfiguration().Configure(modelBuilder.Entity<SeriLogEntry>());
        new CustomerOrderViewModelConfiguration().Configure(modelBuilder.Entity<CustomerOrderViewModel>());
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