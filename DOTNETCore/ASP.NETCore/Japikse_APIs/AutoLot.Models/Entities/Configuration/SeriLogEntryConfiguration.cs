// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - SeriLogEntryConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class SeriLogEntryConfiguration : IEntityTypeConfiguration<SeriLogEntry>
{
    public void Configure(EntityTypeBuilder<SeriLogEntry> builder)
    {
        builder.Property(e => e.Properties).HasColumnType("Xml");
        builder.Property(e => e.TimeStamp).HasDefaultValueSql("GetDate()");
        builder.Property(p => p.LineNumber).HasDefaultValue(0).HasSentinel(-1);
    }
}