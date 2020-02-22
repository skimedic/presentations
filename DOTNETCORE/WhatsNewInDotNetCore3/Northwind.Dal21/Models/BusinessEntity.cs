using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("BusinessEntity", Schema = "Person")]
    public partial class BusinessEntity
    {
        public BusinessEntity()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
            BusinessEntityContact = new HashSet<BusinessEntityContact>();
        }

        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("BusinessEntity")]
        public Person Person { get; set; }
        [InverseProperty("BusinessEntity")]
        public Store Store { get; set; }
        [InverseProperty("BusinessEntity")]
        public Vendor Vendor { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<BusinessEntityContact> BusinessEntityContact { get; set; }
    }
}
