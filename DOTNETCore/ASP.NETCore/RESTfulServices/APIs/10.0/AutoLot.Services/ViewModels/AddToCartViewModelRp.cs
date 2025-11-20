// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - AddToCartViewModelRp.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.ViewModels;

public class AddToCartViewModelRp : AddToCartViewModelBase
{
    [Required]
    [MustBeGreaterThanZero]
    [MustNotBeGreaterThan(nameof(StockQuantity), prefix: "Entity")]
    public int Quantity { get; set; }
}