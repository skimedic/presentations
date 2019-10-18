using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore3.Entities
{
    [Table("EmailAddress", Schema = "Person")]
    public partial class EmailAddress
    {
        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Key]
        [Column("EmailAddressID")]
        public int EmailAddressId { get; set; }
        [Column("EmailAddress")]
        [StringLength(50)]
        public string EmailAddress1 { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Person.EmailAddress))]
        public virtual Person BusinessEntity { get; set; }
    }
}
