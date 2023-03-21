// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - AddToCartViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2021/11/13
// ==================================

using System.ComponentModel;

namespace AutoLot.Mvc.Models;

public class AddToCartViewModel
{
    public int Id { get; set; }
    [DisplayName("Stock Quantity")]
    public int StockQuantity { get; set; }
    public int ItemId { get; set; }
    [Required, MustBeGreaterThanZero, MustNotBeGreaterThan(nameof(StockQuantity))]
    public int Quantity { get; set; }

}