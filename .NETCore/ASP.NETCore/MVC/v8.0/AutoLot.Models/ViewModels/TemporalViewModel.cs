// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Models - TemporalViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Models.ViewModels;

public class TemporalViewModel<T> where T : BaseEntity, new()
{
    public T Entity { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
}