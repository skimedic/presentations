// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - Culture.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("Culture", Schema = "Production")]
public partial class Culture
{
    public Culture()
    {
        ProductModelProductDescriptionCulture = new HashSet<ProductModelProductDescriptionCulture>();
    }

    [Key]
    [Column("CultureID")]
    [StringLength(6)]
    public string CultureId { get; set; }

    [Required] [StringLength(50)] public string Name { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("Culture")]
    public virtual ICollection<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture
    {
        get;
        set;
    }
}