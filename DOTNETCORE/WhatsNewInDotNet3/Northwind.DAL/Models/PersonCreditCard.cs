using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal.Models
{
    [Table("PersonCreditCard", Schema = "Sales")]
    public partial class PersonCreditCard
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("CreditCardID")]
        public int CreditCardId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.PersonCreditCard))]
        public virtual Person BusinessEntity { get; set; }
        [ForeignKey(nameof(CreditCardId))]
        [InverseProperty("PersonCreditCard")]
        public virtual CreditCard CreditCard { get; set; }
    }
}
