// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - ApplicationDbContext.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using System.Collections;
using System.Collections.Generic;
using AutoLot.Models.Entities;
using AutoLot.Models.Entities.Owned;
using AutoLot.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using AutoLot.Dal.Exceptions;

namespace AutoLot.Dal.EfStructures
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            ChangeTracker.Tracked += ChangeTracker_Tracked;
            SavingChanges += (sender, args) =>
            {
                Console.WriteLine($"Saving changes for {((DbContext)sender).Database.GetConnectionString()}");
            };

            SavedChanges += (sender, args) =>
            {
                Console.WriteLine($"Saved {args.EntitiesSavedCount} changes for {((DbContext)sender).Database.GetConnectionString()}");
            };  
            SaveChangesFailed += (sender, args) =>
            {
                Console.WriteLine($"An exception occurred! {args.Exception.Message} entities");
            };
               
        }

        private void ChangeTracker_StateChanged(object? sender, EntityStateChangedEventArgs e)
        {
            if (!(e.Entry.Entity is Car c))
            {
                return;
            }

            var action = string.Empty;
            Console.WriteLine($"Car {c.PetName} was {e.OldState} before the state changed to {e.NewState}");
            switch (e.NewState)
            {
                case EntityState.Added:
                case EntityState.Deleted:
                case EntityState.Modified:
                case EntityState.Unchanged:
                    switch (e.OldState)
                    {
                        case EntityState.Added:
                            action = "Added";
                            break;
                        case EntityState.Deleted:
                            action = "Deleted";
                            break;
                        case EntityState.Modified:
                            action = "Edited";
                            break;
                        case EntityState.Detached:
                        case EntityState.Unchanged:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    Console.WriteLine($"The object was {action}");
                    break;
                case EntityState.Detached:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ChangeTracker_Tracked(object? sender, EntityTrackedEventArgs e)
        {
            var source = (e.FromQuery) ? "Database" : "Code";
            if (e.Entry.Entity is Car c)
            {
                Console.WriteLine($"Car entry {c.PetName} was added from {source}");
            }
        }

        public DbSet<SeriLogEntry>? LogEntries { get; set; }
        public DbSet<CreditRisk>? CreditRisks { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Make>? Makes { get; set; }
        public DbSet<Car>? Cars { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<CustomerOrderViewModel>? CustomerOrderViewModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>()
            //    .ToTable("Inventory")
            //    .ToView("InventoryWithMakesView");
            modelBuilder.Entity<SeriLogEntry>(entity =>
            {
                entity.Property(e => e.Properties).HasColumnType("Xml");
                entity.Property(e => e.TimeStamp).HasDefaultValueSql("GetDate()");
            });
            //modelBuilder.Entity<SeriLogEntry>(entity =>
            //{
            //    entity.ToTable("Serilog", "Logging", t => t.ExcludeFromMigrations());
            //});

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasQueryFilter(c => c.IsDriveable);
                entity.Property(p => p.IsDriveable).HasField("_isDriveable").HasDefaultValue(true);
            });
            //New in EF Core 5 - bi-directional query filters
            modelBuilder.Entity<Order>().HasQueryFilter(e => e.CarNavigation!.IsDriveable);

            modelBuilder.Entity<CustomerOrderViewModel>().HasNoKey().ToView("CustomerOrderView", "dbo");

            //modelBuilder.Entity<CustomerOrderViewModel>().HasNoKey().ToSqlQuery(
            //    @"SELECT c.FirstName, c.LastName, i.Color, i.PetName, m.Name AS Make
            //      FROM   dbo.Orders o
            //      INNER JOIN dbo.Customers c ON o.CustomerId = c.Id 
            //      INNER JOIN dbo.Inventory  i ON o.CarId = i.Id
            //      INNER JOIN dbo.Makes m ON m.Id = i.MakeId");

            modelBuilder.Entity<CreditRisk>(entity =>
            {
                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p!.CreditRisks)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_CreditRisks_Customers");

                //entity
                //    .Property<string>(nameof(Person.FirstName))
                //    .HasColumnName(nameof(Person.FirstName))
                //    .HasMaxLength(50)
                //    .IsRequired(true);

                //entity
                //    .Property<string>(nameof(Person.LastName))
                //    .HasColumnName(nameof(Person.LastName))
                //    .HasMaxLength(50)
                //    .IsRequired(true);

                entity.OwnsOne(o => o.PersonalInformation,
                    pd =>
                    {
                        pd.Property<string>(nameof(Person.FirstName))
                            .HasColumnName(nameof(Person.FirstName))
                            .HasColumnType("nvarchar(50)");
                        pd.Property<string>(nameof(Person.LastName))
                            .HasColumnName(nameof(Person.LastName))
                            .HasColumnType("nvarchar(50)");
                    });
                //entity.HasIndex(nameof(Person.FirstName), nameof(Person.LastName)).IsUnique(true);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.OwnsOne(o => o.PersonalInformation,
                    pd =>
                    {
                        pd.Property(p => p.FirstName).HasColumnName(nameof(Person.FirstName));
                        pd.Property(p => p.LastName).HasColumnName(nameof(Person.LastName));
                        pd.Property(p => p.FullName)
                            .HasColumnName(nameof(Person.FullName))
                            .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
                    });
                entity.Navigation(c => c.PersonalInformation).IsRequired(true);
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.HasMany(e => e.Cars)
                    .WithOne(c => c.MakeNavigation!)
                    .HasForeignKey(k => k.MakeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Make_Inventory");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.CarNavigation)
                    .WithMany(p => p!.Orders)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Inventory");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p!.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Customers");
                entity.HasIndex(cr => new {cr.CustomerId, cr.CarId}).IsUnique(true);
            });
            base.OnModelCreating(modelBuilder);
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
                throw new CustomRetryLimitExceededException("There is a problem with SQl Server.", ex);
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
}
