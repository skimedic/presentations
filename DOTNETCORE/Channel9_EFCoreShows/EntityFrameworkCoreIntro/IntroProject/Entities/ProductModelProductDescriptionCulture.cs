// Copyright Information
// ==================================
// Channel9 - EfCore - ProductModelProductDescriptionCulture.cs
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
    [Table("ProductModelProductDescriptionCulture", Schema = "Production")]
    public partial class ProductModelProductDescriptionCulture
    {
        [Key] [Column("ProductModelID")] public int ProductModelId { get; set; }

        [Key] [Column("ProductDescriptionID")] public int ProductDescriptionId { get; set; }

        [Key]
        [Column("CultureID")]
        [StringLength(6)]
        public string CultureId { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(CultureId))]
        [InverseProperty("ProductModelProductDescriptionCulture")]
        public virtual Culture Culture { get; set; }

        [ForeignKey(nameof(ProductDescriptionId))]
        [InverseProperty("ProductModelProductDescriptionCulture")]
        public virtual ProductDescription ProductDescription { get; set; }

        [ForeignKey(nameof(ProductModelId))]
        [InverseProperty("ProductModelProductDescriptionCulture")]
        public virtual ProductModel ProductModel { get; set; }
    }
}