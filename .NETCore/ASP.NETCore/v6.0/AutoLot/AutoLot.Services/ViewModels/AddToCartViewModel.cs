// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - AddToCartViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.ViewModels;

public class AddToCartViewModel
{
    public int Id { get; set; }
    [DisplayName("Stock Quantity")]
    public int StockQuantity { get; set; }
    public int ItemId { get; set; }
    [MustBeGreaterThanZero]
    [MustNotBeGreaterThan(nameof(StockQuantity))]
    public int Quantity { get; set; }
}