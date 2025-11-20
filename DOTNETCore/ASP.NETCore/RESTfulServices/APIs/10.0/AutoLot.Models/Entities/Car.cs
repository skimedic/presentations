// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Models.Entities;

[Serializable]
[Table("Inventory", Schema = "dbo")]
[Index(nameof(MakeId), Name = "IX_Inventory_MakeId")]
[EntityTypeConfiguration(typeof(CarConfiguration))]
public class Car : BaseEntity
{
    [Required,StringLength(50)]
    public string Color { get; set; }
    public string Price { get; set; }

    //EF  <=7
    //private bool? _isDrivable;
    //[DisplayName("Is Drivable")]
    //public bool IsDrivable
    //{
    //    get => _isDrivable ?? true;
    //    set => _isDrivable = value;
    //}
    //EF 8+
    [DisplayName("Is Drivable")]
    public bool IsDrivable { get; set; } = true;

    public DateTime? DateBuilt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string Display { get; set; }

    [Required, StringLength(50), DisplayName("Pet Name")]
    public string PetName { get; set; }

    [Required, DisplayName("Make")]
    public int MakeId { get; set; }

    [ForeignKey(nameof(MakeId))]
    [InverseProperty(nameof(Make.Cars))]
    [XmlIgnore]
    public Make MakeNavigation { get; set; }

    [InverseProperty(nameof(Radio.CarNavigation))]
    [XmlIgnore]
    public Radio RadioNavigation { get; set; }

    [InverseProperty(nameof(Driver.Cars))]
    [XmlIgnore]
    public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();

    [InverseProperty(nameof(CarDriver.CarNavigation))]
    [XmlIgnore]
    public IEnumerable<CarDriver> CarDrivers { get; set; } = new List<CarDriver>();

    [NotMapped]
    public string MakeName => MakeNavigation?.Name ?? "Unknown";
    
	public override string ToString()
    {
        // Since the PetName column could be empty, supply
        // the default name of **No Name**.
        return $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
    }
}
