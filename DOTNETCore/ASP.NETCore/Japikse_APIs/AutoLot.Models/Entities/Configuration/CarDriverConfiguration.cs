﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - CarDriverConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CarDriverConfiguration : IEntityTypeConfiguration<CarDriver>
{
    public void Configure(EntityTypeBuilder<CarDriver> builder)
    {
        builder
            .Property(e => e.TimeStamp)
            .HasConversion<byte[]>();

        builder.HasQueryFilter(cd => cd.CarNavigation.IsDrivable);
    }
}