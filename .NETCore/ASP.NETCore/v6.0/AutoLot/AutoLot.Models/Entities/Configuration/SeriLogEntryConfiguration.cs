namespace AutoLot.Models.Entities.Configuration;

public class SeriLogEntryConfiguration : IEntityTypeConfiguration<SeriLogEntry>
{
    public void Configure(EntityTypeBuilder<SeriLogEntry> builder)
    {
        builder.Property(e => e.Properties).HasColumnType("Xml");
        builder.Property(e => e.TimeStamp).HasDefaultValueSql("GetDate()");
    }
}
