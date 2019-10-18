using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("PersonPhone", Schema = "Person")]
    public partial class PersonPhone
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [Column("PhoneNumberTypeID")]
        public int PhoneNumberTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("PersonPhone")]
        public virtual Person BusinessEntity { get; set; }
        [ForeignKey("PhoneNumberTypeId")]
        [InverseProperty("PersonPhone")]
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
