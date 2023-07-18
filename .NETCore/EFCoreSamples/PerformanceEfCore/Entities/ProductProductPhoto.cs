using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceEfCore.Entities;

[Table("ProductProductPhoto", Schema = "Production")]
public partial class ProductProductPhoto
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }
    [Key]
    [Column("ProductPhotoID")]
    public int ProductPhotoId { get; set; }
    public bool Primary { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("ProductProductPhoto")]
    public virtual Product Product { get; set; }
    [ForeignKey(nameof(ProductPhotoId))]
    [InverseProperty("ProductProductPhoto")]
    public virtual ProductPhoto ProductPhoto { get; set; }
}