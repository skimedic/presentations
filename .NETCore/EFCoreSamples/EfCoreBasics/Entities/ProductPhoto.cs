// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ProductPhoto.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("ProductPhoto", Schema = "Production")]
public partial class ProductPhoto
{
    public ProductPhoto()
    {
        ProductProductPhoto = new HashSet<ProductProductPhoto>();
    }

    [Key] [Column("ProductPhotoID")] public int ProductPhotoId { get; set; }

    public byte[] ThumbNailPhoto { get; set; }

    [StringLength(50)] public string ThumbnailPhotoFileName { get; set; }

    public byte[] LargePhoto { get; set; }

    [StringLength(50)] public string LargePhotoFileName { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("ProductPhoto")]
    public virtual ICollection<ProductProductPhoto> ProductProductPhoto { get; set; }
}