// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - RadioConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class RadioConfiguration : IEntityTypeConfiguration<Radio>
{
    public void Configure(EntityTypeBuilder<Radio> builder)
    {
        builder.ToTable( b => b.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("RadiosAudit");
        }));

        builder.HasIndex(e => e.CarId, "IX_Radios_CarId").IsUnique();
        builder.HasQueryFilter(e => e.CarNavigation.IsDrivable);
        builder.HasOne(d => d.CarNavigation)
           .WithOne(p => p.RadioNavigation)
           .HasForeignKey<Radio>(d => d.CarId);
    }
}