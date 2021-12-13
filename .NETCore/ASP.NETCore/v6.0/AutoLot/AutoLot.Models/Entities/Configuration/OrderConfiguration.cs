namespace AutoLot.Models.Entities.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable( b => b.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("OrdersAudit");
        }));

        builder.HasIndex(cr => new { cr.CustomerId, cr.CarId }).IsUnique(true);

        builder.HasQueryFilter(e => e.CarNavigation!.IsDrivable);

        builder.HasOne(d => d.CarNavigation)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.CarId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Orders_Inventory");

        builder.HasOne(d => d.CustomerNavigation)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK_Orders_Customers");
    }
}
