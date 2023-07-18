using System.ComponentModel.DataAnnotations.Schema;
using ChangeTrackingEvents.Models.Base;

namespace ChangeTrackingEvents.Models;

[Table("Orders",Schema = "Dbo")]
public partial class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public int CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    [InverseProperty(nameof(Car.Orders))]
    public Car CarNavigation { get; set; }

    [ForeignKey(nameof(CustomerId))]
    [InverseProperty(nameof(Customer.Orders))]
    public Customer CustomerNavigation { get; set; }
}