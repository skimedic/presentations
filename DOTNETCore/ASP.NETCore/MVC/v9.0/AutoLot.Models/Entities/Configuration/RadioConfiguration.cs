// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Models - RadioConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class RadioConfiguration : IEntityTypeConfiguration<Radio>
{
    public void Configure(EntityTypeBuilder<Radio> builder)
    {
        builder
            .Property(e => e.TimeStamp)
            .HasConversion<byte[]>();

        builder.HasIndex(e => e.CarId, "IX_Radios_CarId")
            .IsUnique();
        builder.HasQueryFilter(e => e.CarNavigation.IsDrivable);
        builder
            .HasOne(d => d.CarNavigation)
            .WithOne(p => p.RadioNavigation)
            .HasForeignKey<Radio>(d => d.CarId);
    }
}