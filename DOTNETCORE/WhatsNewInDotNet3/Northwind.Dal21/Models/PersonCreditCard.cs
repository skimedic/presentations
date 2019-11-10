using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("PersonCreditCard", Schema = "Sales")]
    public partial class PersonCreditCard
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("CreditCardID")]
        public int CreditCardId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("PersonCreditCard")]
        public Person BusinessEntity { get; set; }
        [ForeignKey("CreditCardId")]
        [InverseProperty("PersonCreditCard")]
        public CreditCard CreditCard { get; set; }
    }
}
