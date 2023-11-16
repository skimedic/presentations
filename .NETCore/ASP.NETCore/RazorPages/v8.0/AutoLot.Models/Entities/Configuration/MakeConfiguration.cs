// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - MakeConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class MakeConfiguration : IEntityTypeConfiguration<Make>
{
    public void Configure(EntityTypeBuilder<Make> builder)
    {
        builder.ToTable( b => b.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("MakesAudit");
        }));
    }
}