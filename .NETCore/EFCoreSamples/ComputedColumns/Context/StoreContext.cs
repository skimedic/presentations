using ComputedColumns.Models;
using Microsoft.EntityFrameworkCore;

namespace Migrations.Context;

public class StoreContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public StoreContext()
    {
    }

    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {

    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = @"Server=.\dev2019;Database=Demo.ComputedColumns;Integrated Security=true;Encrypt=false;";
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            //TODO: Comment out for first migration.  Add in after creating UDF
            entity.Property(e => e.OrderTotal)
                .HasColumnType("money")
                .HasComputedColumnSql("Store.GetOrderTotal([Id])");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.LineItemTotal)
                .HasColumnType("money")
                .HasComputedColumnSql("[Quantity]*[UnitCost]");

            entity.Property(e => e.UnitCost).HasColumnType("money");
        });

    }
}