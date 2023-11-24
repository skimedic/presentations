// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ProductInventory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("ProductInventory", Schema = "Production")]
public partial class ProductInventory
{
    [Key] [Column("ProductID")] public int ProductId { get; set; }

    [Key] [Column("LocationID")] public short LocationId { get; set; }

    [Required] [StringLength(10)] public string Shelf { get; set; }

    public byte Bin { get; set; }
    public short Quantity { get; set; }

    [Column("rowguid")] public Guid Rowguid { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(LocationId))]
    [InverseProperty("ProductInventory")]
    public virtual Location Location { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("ProductInventory")]
    public virtual Product Product { get; set; }
}