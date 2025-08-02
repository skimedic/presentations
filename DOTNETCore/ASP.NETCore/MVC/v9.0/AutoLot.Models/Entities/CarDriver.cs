// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - CarDriver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Models.Entities;

[Table("InventoryToDrivers", Schema = "dbo")]
[EntityTypeConfiguration(typeof(CarDriverConfiguration))]
public class CarDriver : BaseEntity
{
    public int DriverId { get; set; }

    [ForeignKey(nameof(DriverId))]
    public Driver DriverNavigation { get; set; }

    [Column("InventoryId")]
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    public Car CarNavigation { get; set; }
}