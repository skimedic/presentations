// Copyright Information
// ==================================
// EntityFrameworkCore - EfCoreBasics - ShoppingCartItem.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/04/08
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreBasics.Entities;

[Table("ShoppingCartItem", Schema = "Sales")]
public partial class ShoppingCartItem
{
    [Key] [Column("ShoppingCartItemID")] public int ShoppingCartItemId { get; set; }

    [Required]
    [Column("ShoppingCartID")]
    [StringLength(50)]
    public string ShoppingCartId { get; set; }

    public int Quantity { get; set; }

    [Column("ProductID")] public int ProductId { get; set; }

    [Column(TypeName = "datetime")] public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")] public DateTime ModifiedDate { get; set; }

    [ForeignKey(nameof(ProductId))]
    [InverseProperty("ShoppingCartItem")]
    public virtual Product Product { get; set; }
}