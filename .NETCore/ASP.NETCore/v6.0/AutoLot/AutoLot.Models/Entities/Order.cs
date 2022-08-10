// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Order.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Models.Entities;

[Table("Orders", Schema = "dbo")]
[Index(nameof(CarId), Name = "IX_Orders_CarId")]
[Index(nameof(CustomerId), nameof(CarId), Name = "IX_Orders_CustomerId_CarId", IsUnique = true)]
[EntityTypeConfiguration(typeof(OrderConfiguration))]
public partial class Order : BaseEntity
{
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    [InverseProperty(nameof(Car.Orders))]
    public virtual Car CarNavigation { get; set; }

    public int CustomerId { get; set; }
    [ForeignKey(nameof(CustomerId))]
    [InverseProperty(nameof(Customer.Orders))]
    public virtual Customer CustomerNavigation { get; set; }
}
