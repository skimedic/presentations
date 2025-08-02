﻿// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - Driver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Models.Entities;

[Table("Drivers", Schema = "dbo")]
[EntityTypeConfiguration(typeof(DriverConfiguration))]
public class Driver : BaseEntity
{
    public Person PersonInformation { get; set; } = new Person();

    [InverseProperty(nameof(Car.Drivers))]
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();

    [InverseProperty(nameof(CarDriver.DriverNavigation))]
    public IEnumerable<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();
}