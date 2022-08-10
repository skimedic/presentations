// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - CreditRiskConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CreditRiskConfiguration : IEntityTypeConfiguration<CreditRisk>
{
    public void Configure(EntityTypeBuilder<CreditRisk> builder)
    {
       // builder.ToTable(b => b.IsTemporal(t =>
       //{
       //    t.HasPeriodEnd("ValidTo");
       //    t.HasPeriodStart("ValidFrom");
       //    t.UseHistoryTable("CreditRiskAudit");
       //}));

        builder.HasOne(d => d.CustomerNavigation)
            .WithMany(p => p.CreditRisks)
            .HasForeignKey(d => d.CustomerId)
            .HasConstraintName("FK_CreditRisks_Customers");

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
                     .HasComputedColumnSql("[LastName] + ', ' + [FirstName]",true);
            });
        builder.Navigation(d => d.PersonInformation).IsRequired(true);
    }
}
