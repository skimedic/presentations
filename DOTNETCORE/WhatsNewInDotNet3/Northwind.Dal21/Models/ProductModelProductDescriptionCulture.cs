using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Dal21.Models
{
    [Table("ProductModelProductDescriptionCulture", Schema = "Production")]
    public partial class ProductModelProductDescriptionCulture
    {
        [Column("ProductModelID")]
        public int ProductModelId { get; set; }
        [Column("ProductDescriptionID")]
        public int ProductDescriptionId { get; set; }
        [Column("CultureID")]
        [StringLength(6)]
        public string CultureId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey("CultureId")]
        [InverseProperty("ProductModelProductDescriptionCulture")]
        public Culture Culture { get; set; }
        [ForeignKey("ProductDescriptionId")]
        [InverseProperty("ProductModelProductDescriptionCulture")]
        public ProductDescription ProductDescription { get; set; }
        [ForeignKey("ProductModelId")]
        [InverseProperty("ProductModelProductDescriptionCulture")]
        public ProductModel ProductModel { get; set; }
    }
}
