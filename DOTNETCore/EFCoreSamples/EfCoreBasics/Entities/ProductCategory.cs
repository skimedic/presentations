// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ProductCategory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("ProductCategory", Schema = "Production")]
public partial class ProductCategory
{
    public ProductCategory()
    {
        ProductSubcategory = new HashSet<ProductSubcategory>();
    }

    [Key] [Column("ProductCategoryID")] public int ProductCategoryId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Column("rowguid")] public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("ProductCategory")]
    public virtual ICollection<ProductSubcategory> ProductSubcategory { get; set; }
}