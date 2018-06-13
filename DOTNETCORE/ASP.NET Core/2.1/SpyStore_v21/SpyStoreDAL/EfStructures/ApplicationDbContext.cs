using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpyStoreModels.Models;

namespace SpyStoreDAL.EfStructures
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartRecord> ShoppingCartRecords { get; set; }

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

                //This doesn't work in EF Core 1.0. It's fixed in 1.1
                //entity.Property(e => e.OrderTotal)
                //    .HasColumnType("money")
                //    .HasComputedColumnSql("Store.GetOrderTotal([Id])");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.LineItemTotal)
                    .HasColumnType("money")
                    .HasComputedColumnSql("[Quantity]*[UnitCost]");

                entity.Property(e => e.UnitCost).HasColumnType("money");
            });


            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.UnitCost).HasColumnType("money");
                entity.Property(e => e.CurrentPrice).HasColumnType("money");
            });

            modelBuilder.Entity<ShoppingCartRecord>(entity =>
            {
                entity.HasIndex(e => new { ShoppingCartRecordId = e.Id, e.ProductId, e.ApplicationUserId })
                    .HasName("IX_ShoppingCart").IsUnique();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Quantity)
                    .ValueGeneratedNever()
                    .HasDefaultValue(1);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
