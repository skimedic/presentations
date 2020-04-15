// Copyright Information
// ==================================
// Channel9 - EfCore - ProductDescription.cs
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
    [Table("ProductDescription", Schema = "Production")]
    public partial class ProductDescription
    {
        public ProductDescription()
        {
            ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
        }

        [Key] [Column("ProductDescriptionID")] public int ProductDescriptionId { get; set; }

        [Required] [StringLength(400)] public string Description { get; set; }

        [Column("rowguid")] public Guid Rowguid { get; set; }

        [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

        [InverseProperty("ProductDescription")]
        public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture
        {
            get;
            set;
        }
    }
}