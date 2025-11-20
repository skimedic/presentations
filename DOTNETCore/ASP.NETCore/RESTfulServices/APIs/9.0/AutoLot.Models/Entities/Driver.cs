// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Models - Driver.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Models.Entities;

[Serializable]
[Table("Drivers", Schema = "dbo")]
[EntityTypeConfiguration(typeof(DriverConfiguration))]
public class Driver : BaseEntity
{
    public Person PersonInformation { get; set; } = new Person();

    [InverseProperty(nameof(Car.Drivers))]
    [XmlIgnore]
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();

    [InverseProperty(nameof(CarDriver.DriverNavigation))]
    [XmlIgnore]
    public IEnumerable<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();
}