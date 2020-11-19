using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AutoLot.Dal.test.Models;

namespace AutoLot.Dal.test.EfStructures
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CreditRisks> CreditRisks { get; set; }
        public virtual DbSet<CustomerOrderView> CustomerOrderView { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Makes> Makes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.,5433;Database=AutoLot;User Id=sa;Password=P@ssw0rd;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditRisks>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditRisks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CreditRisks_Customers");
            });

            modelBuilder.Entity<CustomerOrderView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CustomerOrderView");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasIndex(e => e.MakeId);

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Make_Inventory");
            });

            modelBuilder.Entity<Makes>(entity =>
            {
                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.CarId);

                entity.HasIndex(e => new { e.CustomerId, e.CarId })
                    .IsUnique();

                entity.Property(e => e.TimeStamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Inventory");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Orders_Customers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
