using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities
{
    [Table("PersonPhone", Schema = "Person")]
    public partial class PersonPhone
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        [Key]
        [Column("PhoneNumberTypeID")]
        public int PhoneNumberTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.PersonPhone))]
        public virtual Person BusinessEntity { get; set; }
        [ForeignKey(nameof(PhoneNumberTypeId))]
        [InverseProperty("PersonPhone")]
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
