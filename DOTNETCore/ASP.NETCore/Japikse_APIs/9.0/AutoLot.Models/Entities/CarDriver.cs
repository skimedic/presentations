// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - CarDriver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Models.Entities;

[Serializable]
[Table("InventoryToDrivers", Schema = "dbo")]
[EntityTypeConfiguration(typeof(CarDriverConfiguration))]
public class CarDriver : BaseEntity
{
    public int DriverId { get; set; }

    [ForeignKey(nameof(DriverId))]
    [XmlIgnore]
    public Driver DriverNavigation { get; set; }

    [Column("InventoryId")]
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    [XmlIgnore]
    public Car CarNavigation { get; set; }
}