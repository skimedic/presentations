using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Dal.test.Models
{
    public partial class CreditRisks
    {
        [Key]
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.CreditRisks))]
        public virtual Customers Customer { get; set; }
    }
}
