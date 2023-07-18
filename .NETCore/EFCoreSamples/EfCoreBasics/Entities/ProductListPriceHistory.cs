// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ProductListPriceHistory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("ProductListPriceHistory", Schema = "Production")]
public partial class ProductListPriceHistory
{
    [Key] [Column("ProductID")] public int ProductId { get; set; }

    [Key] [Column(TypeName = "datetime")] public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")] public DateTime? EndDate { get; set; }

    [Column(TypeName = "money")] public decimal ListPrice { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("ProductListPriceHistory")]
    public virtual Product Product { get; set; }
}