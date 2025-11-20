// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - AddToCartViewModelBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.ViewModels.Base;

public class AddToCartViewModelBase
{
    public int Id { get; set; }

    [Display(Name = "Stock Quantity")]
    public int StockQuantity { get; set; }

    public int ItemId { get; set; }
}