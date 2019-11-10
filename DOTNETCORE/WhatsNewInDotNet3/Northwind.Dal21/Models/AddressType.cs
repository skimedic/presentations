using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("AddressType", Schema = "Person")]
    public partial class AddressType
    {
        public AddressType()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
        }

        [Column("AddressTypeID")]
        public int AddressTypeId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("AddressType")]
        public ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }
    }
}
