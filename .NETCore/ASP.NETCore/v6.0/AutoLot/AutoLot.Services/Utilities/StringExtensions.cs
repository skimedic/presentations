// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - StringExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.Utilities;

public static class StringExtensions
{
    public static string RemoveControllerSuffix(this string original)
        => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
    public static string RemoveAsyncSuffix(this string original)
        => original.Replace("Async", "", StringComparison.OrdinalIgnoreCase);
    public static string RemoveModelSuffix(this string original)
        => original.Replace("Model", "", StringComparison.OrdinalIgnoreCase);
}
