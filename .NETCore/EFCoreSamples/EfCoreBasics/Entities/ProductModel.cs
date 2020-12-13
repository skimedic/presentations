// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ProductModel.cs
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
    [Table("ProductModel", Schema = "Production")]
    public partial class ProductModel
    {
        public ProductModel()
        {
            Product = new HashSet<Product>();
            ProductModelIllustration = new HashSet<ProductModelIllustration>();
            ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
        }

        [Key] [Column("ProductModelID")] public int ProductModelId { get; set; }

        [Required] [StringLength(50)] public string Name { get; set; }

        [Column(TypeName = "xml")] public string CatalogDescription { get; set; }

        [Column(TypeName = "xml")] public string Instructions { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductModel")] public virtual ICollection<Product> Product { get; set; }

        [InverseProperty("ProductModel")]
        public virtual ICollection<ProductModelIllustration> ProductModelIllustration { get; set; }

        [InverseProperty("ProductModel")]
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture
        {
            get;
            set;
        }
    }
}