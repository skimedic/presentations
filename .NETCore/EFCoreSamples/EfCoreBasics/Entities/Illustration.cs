// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - Illustration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("Illustration", Schema = "Production")]
public partial class Illustration
{
    public Illustration()
    {
        ProductModelIllustration = new HashSet<ProductModelIllustration>();
    }

    [Key] [Column("IllustrationID")] public int IllustrationId { get; set; }

    [Column(TypeName = "xml")] public string Diagram { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("Illustration")]
    public virtual ICollection<ProductModelIllustration> ProductModelIllustration { get; set; }
}