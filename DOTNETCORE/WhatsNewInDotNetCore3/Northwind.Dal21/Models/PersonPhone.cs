using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("PersonPhone", Schema = "Person")]
    public partial class PersonPhone
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column(TypeName = "Phone")]
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [Column("PhoneNumberTypeID")]
        public int PhoneNumberTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("PersonPhone")]
        public Person BusinessEntity { get; set; }
        [ForeignKey("PhoneNumberTypeId")]
        [InverseProperty("PersonPhone")]
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
