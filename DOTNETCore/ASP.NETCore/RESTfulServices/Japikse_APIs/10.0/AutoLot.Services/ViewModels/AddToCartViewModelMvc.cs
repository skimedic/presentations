// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - AddToCartViewModelMvc.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.ViewModels;

public class AddToCartViewModelMvc : AddToCartViewModelBase
{
    [Required]
    [MustBeGreaterThanZero]
    [MustNotBeGreaterThan(nameof(StockQuantity))]
    public int Quantity { get; set; }
}