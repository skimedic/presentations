using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
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
        public virtual Person BusinessEntity { get; set; }
        [ForeignKey("CreditCardId")]
        [InverseProperty("PersonCreditCard")]
        public virtual CreditCard CreditCard { get; set; }
    }
}
