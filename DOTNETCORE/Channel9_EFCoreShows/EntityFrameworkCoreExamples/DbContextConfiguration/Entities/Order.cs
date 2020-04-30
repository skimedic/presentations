using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using EntityConfiguration.Entities.Base;

namespace EntityConfiguration.Entities
{
  [Table("Orders", Schema = "Store")]
  public class Order : OrderBase
  {
    [ForeignKey(nameof(CustomerId))]
    public Customer CustomerNavigation { get; set; }

    [InverseProperty(nameof(OrderDetail.OrderNavigation))]
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
  }
}