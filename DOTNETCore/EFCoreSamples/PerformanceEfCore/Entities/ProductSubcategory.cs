using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities;

[Table("ProductSubcategory", Schema = "Production")]
public partial class ProductSubcategory
{
    public ProductSubcategory()
    {
        Product = new HashSet<Product>();
    }

    [Key]
    [Column("ProductSubcategoryID")]
    public int ProductSubcategoryId { get; set; }
    [Column("ProductCategoryID")]
    public int ProductCategoryId { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Column("rowguid")]
    public Guid Rowguid { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(ProductCategoryId))]
    [InverseProperty("ProductSubcategory")]
    public virtual ProductCategory ProductCategory { get; set; }
    [InverseProperty("ProductSubcategory")]
    public virtual ICollection<Product> Product { get; set; }
}