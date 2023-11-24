using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Migrations.Models;
using Migrations.ViewModels;

namespace Migrations.EFStructures;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<CreditRisk> CreditRisks { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Make> Makes { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Order> Orders { get; set; }

    public DbSet<CustomOrderViewModel> CustomOrderViewModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomOrderViewModel>(entity =>
        {
            entity.HasNoKey().ToView("CustomerOrderView","dbo");
        });
        modelBuilder.Entity<CreditRisk>(entity =>
        {
            entity.HasOne(d => d.CustomerNavigation)
                .WithMany(p => p.CreditRisks)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CreditRisks_Customers");
            entity.HasIndex(cr => new { cr.FirstName, cr.LastName }).IsUnique(true);
        });

        modelBuilder.Entity<Make>(entity =>
        {
            entity.HasMany(e => e.Cars)
                .WithOne(c => c.MakeNavigation)
                .HasForeignKey(k => k.MakeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Make_Inventory");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasOne(d => d.CarNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Inventory");

            entity.HasOne(d => d.CustomerNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Orders_Customers");
        });
        base.OnModelCreating(modelBuilder);
    }
}