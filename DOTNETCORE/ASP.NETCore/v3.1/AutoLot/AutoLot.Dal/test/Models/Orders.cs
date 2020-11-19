using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Dal.test.Models
{
    public partial class Orders
    {
        [Key]
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }

        [ForeignKey(nameof(CarId))]
        [InverseProperty(nameof(Inventory.Orders))]
        public virtual Inventory Car { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Orders))]
        public virtual Customers Customer { get; set; }
    }
}
