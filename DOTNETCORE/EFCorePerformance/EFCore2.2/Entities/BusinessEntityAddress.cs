using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore2.Entities
{
    [Table("BusinessEntityAddress", Schema = "Person")]
    public partial class BusinessEntityAddress
    {
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("AddressID")]
        public int AddressId { get; set; }
        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("AddressId")]
        [InverseProperty("BusinessEntityAddress")]
        public virtual Address Address { get; set; }
        [ForeignKey("AddressTypeId")]
        [InverseProperty("BusinessEntityAddress")]
        public virtual AddressType AddressType { get; set; }
        [ForeignKey("BusinessEntityId")]
        [InverseProperty("BusinessEntityAddress")]
        public virtual BusinessEntity BusinessEntity { get; set; }
    }
}
