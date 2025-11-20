// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Models - Make.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Models.Entities;

[Serializable]
[Table("Makes", Schema = "dbo")]
[EntityTypeConfiguration(typeof(MakeConfiguration))]
public class Make : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; }

    [InverseProperty(nameof(Car.MakeNavigation))]
    [XmlIgnore]
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();
}
