// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Models - CarViewModelConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/03
// ==================================

namespace AutoLot.Models.ViewModels.Configuration;

public class CarViewModelConfiguration : IEntityTypeConfiguration<CarViewModel>
{
    public void Configure(EntityTypeBuilder<CarViewModel> builder)
    {
        builder.HasNoKey();
        builder.ToTable(t => t.ExcludeFromMigrations());
        CultureInfo provider = new("en-us");
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        builder.Property(p => p.Price)
            .HasConversion(
                v => decimal.Parse(v, style, provider),
                v => v.ToString("C2"));
    }
}