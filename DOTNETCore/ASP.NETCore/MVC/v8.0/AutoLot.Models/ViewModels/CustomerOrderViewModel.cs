// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - CustomerOrderViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Models.ViewModels;

[Keyless]
[EntityTypeConfiguration(typeof(CustomerOrderViewModelConfiguration))]
public partial class CustomerOrderViewModel 
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(50)]
    public string LastName { get; set; }
    [Required]
    [StringLength(50)]
    public string Color { get; set; }
    [Required]
    [StringLength(50)]
    public string PetName { get; set; }
    [Required]
    [StringLength(50)]
    public string Make { get; set; }
    public bool? IsDrivable { get; set; }
    public string Display { get; set; }
    public string Price { get; set; }
    public DateTime? DateBuilt { get; set; }
    [NotMapped]
    public string FullDetail => $"{FirstName} {LastName} ordered a {Color} {Make} named {PetName}";
    public override string ToString() => FullDetail;
}
