// Copyright Information
// ==================================
// Channel9 - EfCore - SalesOrderDetail.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/10
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore.Entities
{
    [Table("SalesOrderDetail", Schema = "Sales")]
    public partial class SalesOrderDetail
    {
        [Key] [Column("SalesOrderID")] public int SalesOrderId { get; set; }

        [Key] [Column("SalesOrderDetailID")] public int SalesOrderDetailId { get; set; }

        [StringLength(25)] public string CarrierTrackingNumber { get; set; }

        public short OrderQty { get; set; }

        [Column("ProductID")] public int ProductId { get; set; }

        [Column("SpecialOfferID")] public int SpecialOfferId { get; set; }

        [Column(TypeName = "money")] public decimal UnitPrice { get; set; }

        [Column(TypeName = "money")] public decimal UnitPriceDiscount { get; set; }

        [Column(TypeName = "numeric(38, 6)")] public decimal LineTotal { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(SalesOrderId))]
        [InverseProperty(nameof(SalesOrderHeader.SalesOrderDetail))]
        public virtual SalesOrderHeader SalesOrder { get; set; }

        [ForeignKey("SpecialOfferId,ProductId")]
        [InverseProperty("SalesOrderDetail")]
        public virtual SpecialOfferProduct SpecialOfferProduct { get; set; }
    }
}