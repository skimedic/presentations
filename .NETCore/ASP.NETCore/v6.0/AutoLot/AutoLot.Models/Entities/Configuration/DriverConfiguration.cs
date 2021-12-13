namespace AutoLot.Models.Entities.Configuration;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
       // builder.ToTable(b => b.IsTemporal(t =>
       //{
       //    t.HasPeriodEnd("ValidTo");
       //    t.HasPeriodStart("ValidFrom");
       //    t.UseHistoryTable("DriverAudit");
       //}));

        builder.OwnsOne(o => o.PersonInformation,
            pd =>
            {
                pd.Property<string>(nameof(Person.FirstName))
                    .HasColumnName(nameof(Person.FirstName))
                    .HasColumnType("nvarchar(50)");
                pd.Property<string>(nameof(Person.LastName))
                    .HasColumnName(nameof(Person.LastName))
                    .HasColumnType("nvarchar(50)");
                pd.Property(p => p.FullName)
                     .HasColumnName(nameof(Person.FullName))
                     .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
            });
        builder.Navigation(d => d.PersonInformation).IsRequired(true);

    }
}
