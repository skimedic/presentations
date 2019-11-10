using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("EmailAddress", Schema = "Person")]
    public partial class EmailAddress
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("EmailAddressID")]
        public int EmailAddressId { get; set; }
        [Column("EmailAddress")]
        [StringLength(50)]
        public string EmailAddress1 { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("EmailAddress")]
        public Person BusinessEntity { get; set; }
    }
}
