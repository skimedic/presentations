namespace AutoLot.Models.Entities;

[Table("Makes", Schema = "dbo")]
[EntityTypeConfiguration(typeof(MakeConfiguration))]
public class Make : BaseEntity
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [InverseProperty(nameof(Car.MakeNavigation))]
    public virtual IEnumerable<Car> Cars { get; set; } = new List<Car>();
}
