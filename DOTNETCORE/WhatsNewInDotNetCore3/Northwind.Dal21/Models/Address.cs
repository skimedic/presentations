using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Address", Schema = "Person")]
    public partial class Address
    {
        public Address()
        {
            BusinessEntityAddress = new HashSet<BusinessEntityAddress>();
            SalesOrderHeaderBillToAddress = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddress = new HashSet<SalesOrderHeader>();
        }

        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [StringLength(60)]
        public string AddressLine1 { get; set; }
        [StringLength(60)]
        public string AddressLine2 { get; set; }
        [Required]
        [StringLength(30)]
        public string City { get; set; }
        [Column("StateProvinceID")]
        public int StateProvinceId { get; set; }
        [Required]
        [StringLength(15)]
        public string PostalCode { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("StateProvinceId")]
        [InverseProperty("Address")]
        public StateProvince StateProvince { get; set; }
        [InverseProperty("Address")]
        public ICollection<BusinessEntityAddress> BusinessEntityAddress { get; set; }
        [InverseProperty("BillToAddress")]
        public ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddress { get; set; }
        [InverseProperty("ShipToAddress")]
        public ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddress { get; set; }
    }
}
