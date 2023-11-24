// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - SpecialOffer.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("SpecialOffer", Schema = "Sales")]
public partial class SpecialOffer
{
    public SpecialOffer()
    {
        SpecialOfferProduct = new HashSet<SpecialOfferProduct>();
    }

    [Key] [Column("SpecialOfferID")] public int SpecialOfferId { get; set; }

    [Required] [StringLength(255)] public string Description { get; set; }

    [Column(TypeName = "smallmoney")] public decimal DiscountPct { get; set; }

    [Required] [StringLength(50)] public string Type { get; set; }

    [Required] [StringLength(50)] public string Category { get; set; }

    [Column(TypeName = "datetime")] public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")] public DateTime EndDate { get; set; }

    public int MinQty { get; set; }
    public int? MaxQty { get; set; }

    [Column("rowguid")] public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [InverseProperty("SpecialOffer")]
    public virtual ICollection<SpecialOfferProduct> SpecialOfferProduct { get; set; }
}