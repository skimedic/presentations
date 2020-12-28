// Copyright Information
// ==================================
// AutoLot - AutoLot.Models - Order.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Models.Entities
{
    [Table("Orders", Schema = "Dbo")]
    [Index(nameof(CustomerId),IsUnique = true)]
    [Index(nameof(CarId),IsUnique = true)]
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
