using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("PurchaseOrderHeader", Schema = "Purchasing")]
    public partial class PurchaseOrderHeader
    {
        public PurchaseOrderHeader()
        {
            PurchaseOrderDetail = new HashSet<PurchaseOrderDetail>();
        }

        [Key]
        [Column("PurchaseOrderID")]
        public int PurchaseOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        public byte Status { get; set; }
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("VendorID")]
        public int VendorId { get; set; }
        [Column("ShipMethodID")]
        public int ShipMethodId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("EmployeeId")]
        [InverseProperty("PurchaseOrderHeader")]
        public Employee Employee { get; set; }
        [ForeignKey("ShipMethodId")]
        [InverseProperty("PurchaseOrderHeader")]
        public ShipMethod ShipMethod { get; set; }
        [ForeignKey("VendorId")]
        [InverseProperty("PurchaseOrderHeader")]
        public Vendor Vendor { get; set; }
        [InverseProperty("PurchaseOrder")]
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
    }
}
