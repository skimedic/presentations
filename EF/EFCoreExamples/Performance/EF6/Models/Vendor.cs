using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Performance.EF6.Models
{
    [Table("Purchasing.Vendor")]
    public partial class Vendor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendor()
        {
            ProductVendors = new HashSet<ProductVendor>();
            PurchaseOrderHeaders = new HashSet<PurchaseOrderHeader>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(15)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte CreditRating { get; set; }

        public bool PreferredVendorStatus { get; set; }

        public bool ActiveFlag { get; set; }

        [StringLength(1024)]
        public string PurchasingWebServiceURL { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntity BusinessEntity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
    }
}
