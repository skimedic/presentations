﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - CustomerConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // builder.ToTable(b => b.IsTemporal(t =>
        //{
        //    t.HasPeriodEnd("ValidTo");
        //    t.HasPeriodStart("ValidFrom");
        //    t.UseHistoryTable("CustomerAudit");
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