// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Models - Radio.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Models.Entities;

[Serializable]
[Table("Radios", Schema = "dbo")]
[EntityTypeConfiguration(typeof(RadioConfiguration))]
public class Radio : BaseEntity
{
    public bool HasTweeters { get; set; }
    public bool HasSubWoofers { get; set; }

    [Required, StringLength(50)]
    public string RadioId { get; set; }

    [Column("InventoryId")]
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    [XmlIgnore]
    public Car CarNavigation { get; set; }
}