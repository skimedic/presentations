using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("SalesOrderDetail", Schema = "Sales")]
    public partial class SalesOrderDetail
    {
        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        [Column("SalesOrderDetailID")]
        public int SalesOrderDetailId { get; set; }
        [StringLength(25)]
        public string CarrierTrackingNumber { get; set; }
        public short OrderQty { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("SpecialOfferID")]
        public int SpecialOfferId { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPriceDiscount { get; set; }
        [Column(TypeName = "numeric(38, 6)")]
        public decimal LineTotal { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("SalesOrderId")]
        [InverseProperty("SalesOrderDetail")]
        public SalesOrderHeader SalesOrder { get; set; }
        [ForeignKey("SpecialOfferId,ProductId")]
        [InverseProperty("SalesOrderDetail")]
        public SpecialOfferProduct SpecialOfferProduct { get; set; }
    }
}
