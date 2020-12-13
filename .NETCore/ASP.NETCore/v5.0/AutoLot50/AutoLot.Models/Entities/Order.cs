// Copyright Information
// ==================================
// AutoLot50 - AutoLot.Models - Order.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Models.Entities.Base;

namespace AutoLot.Models.Entities
{
    [Table("Orders", Schema = "Dbo")]
    public partial class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.Orders))]
        public virtual Car? CarNavigation { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.Orders))]
        public virtual Customer? CustomerNavigation { get; set; }
    }
}
