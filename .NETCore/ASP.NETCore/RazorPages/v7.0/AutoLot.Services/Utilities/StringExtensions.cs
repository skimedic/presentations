// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Services - StringExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Services.Utilities;

public static class StringExtensions
{
    public static string RemoveController(this string original)
        => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
}
