// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Services - StringExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Services.Utilities;
public static class StringExtensions
{
    public static string RemoveController(this string original)
        => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
    public static string RemoveAsyncSuffix(this string original)
        => original.Replace("Async", "", StringComparison.OrdinalIgnoreCase);
}
