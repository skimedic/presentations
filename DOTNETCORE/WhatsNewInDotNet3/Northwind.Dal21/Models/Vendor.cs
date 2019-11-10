using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("Vendor", Schema = "Purchasing")]
    public partial class Vendor
    {
        public Vendor()
        {
            ProductVendor = new HashSet<ProductVendor>();
            PurchaseOrderHeader = new HashSet<PurchaseOrderHeader>();
        }

        [Key]
        [Column("BusinessEntityID")]
        public int BusinessEntityId { get; set; }
        [Required]
        [Column(TypeName = "AccountNumber")]
        [StringLength(15)]
        public string AccountNumber { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }
        public byte CreditRating { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? PreferredVendorStatus { get; set; }
        [Required]
        [Column(TypeName = "Flag")]
        public bool? ActiveFlag { get; set; }
        [Column("PurchasingWebServiceURL")]
        [StringLength(1024)]
        public string PurchasingWebServiceUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("BusinessEntityId")]
        [InverseProperty("Vendor")]
        public BusinessEntity BusinessEntity { get; set; }
        [InverseProperty("BusinessEntity")]
        public ICollection<ProductVendor> ProductVendor { get; set; }
        [InverseProperty("Vendor")]
        public ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
    }
}
