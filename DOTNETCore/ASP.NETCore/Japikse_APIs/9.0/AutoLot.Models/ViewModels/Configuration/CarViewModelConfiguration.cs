// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - CarViewModelConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
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