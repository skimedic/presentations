using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLot.Dal.test.Models
{
    public partial class Customers
    {
        public Customers()
        {
            CreditRisks = new HashSet<CreditRisks>();
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int Id { get; set; }
        public byte[] TimeStamp { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<CreditRisks> CreditRisks { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
