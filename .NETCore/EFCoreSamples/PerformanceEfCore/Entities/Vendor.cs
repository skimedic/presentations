using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities;

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
    [StringLength(15)]
    public string AccountNumber { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    public byte CreditRating { get; set; }
    [Required]
    public bool? PreferredVendorStatus { get; set; }
    [Required]
    public bool? ActiveFlag { get; set; }
    [Column("PurchasingWebServiceURL")]
    [StringLength(1024)]
    public string PurchasingWebServiceUrl { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(BusinessEntityId))]
    [InverseProperty("Vendor")]
    public virtual BusinessEntity BusinessEntity { get; set; }
    [InverseProperty("BusinessEntity")]
    public virtual ICollection<ProductVendor> ProductVendor { get; set; }
    [InverseProperty("Vendor")]
    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
}