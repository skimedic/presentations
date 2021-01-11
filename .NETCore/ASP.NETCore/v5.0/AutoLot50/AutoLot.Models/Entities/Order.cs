using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoLot.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Models.Entities
{
    [Table("Orders", Schema = "Dbo")]
    [Index(nameof(CarId), Name = "IX_Orders_CarId")]
    [Index(nameof(CustomerId), nameof(CarId), Name = "IX_Orders_CustomerId_CarId", IsUnique = true)]
    public partial class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Car.Orders))]
        public Car? CarNavigation { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.Orders))]
        public Customer? CustomerNavigation { get; set; }
    }
}
