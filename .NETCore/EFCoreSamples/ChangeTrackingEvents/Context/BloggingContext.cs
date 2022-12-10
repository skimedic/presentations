using System;
using System.Collections.Generic;
using ChangeTrackingEvents.Interceptors;
using ChangeTrackingEvents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ChangeTrackingEvents.Context
{
    public sealed class BloggingContext : DbContext
    {
        public BloggingContext()
        {
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            ChangeTracker.Tracked += ChangeTracker_Tracked;
        }

        private void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            var source = (e.FromQuery) ? "Database" : "Code";
            if (e.Entry.Entity is Blog b)
            {
                Console.WriteLine($"Blog entry {b.Name} was added from {source}");
            }
        }

        private void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            if (e.Entry.Entity is Blog b)
            {
                var action = string.Empty;
                Console.WriteLine($"Blog {b.Name} was {e.OldState} before the state changed to {e.NewState}");
                switch (e.NewState)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
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
                        }
                        break;
                }
            }
        }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=.\dev2019;Database=Demo.ChangeTracking;Integrated Security=true;Encrypt=false;";
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString)
                    .AddInterceptors(new List<IInterceptor>
                    {
                        new CommandInterceptor(),
                        new ConnectionInterceptor(), 
                        new TransactionInterceptor()
                    });
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}