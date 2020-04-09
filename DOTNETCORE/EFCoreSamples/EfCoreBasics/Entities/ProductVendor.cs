// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ProductVendor.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities
{
    [Table("ProductVendor", Schema = "Purchasing")]
    public partial class ProductVendor
    {
        [Key] [Column("ProductID")] public int ProductId { get; set; }

        [Key] [Column("BusinessEntityID")] public int BusinessEntityId { get; set; }

        public int AverageLeadTime { get; set; }

        [Column(TypeName = "money")] public decimal StandardPrice { get; set; }

        [Column(TypeName = "money")] public decimal? LastReceiptCost { get; set; }

        [Column(TypeName = "datetime")] public DateTime? LastReceiptDate { get; set; }

        public int MinOrderQty { get; set; }
        public int MaxOrderQty { get; set; }
        public int? OnOrderQty { get; set; }

        [Required] [StringLength(3)] public string UnitMeasureCode { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(BusinessEntityId))]
        [InverseProperty(nameof(Vendor.ProductVendor))]
        public virtual Vendor BusinessEntity { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductVendor")]
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(UnitMeasureCode))]
        [InverseProperty(nameof(UnitMeasure.ProductVendor))]
        public virtual UnitMeasure UnitMeasureCodeNavigation { get; set; }
    }
}