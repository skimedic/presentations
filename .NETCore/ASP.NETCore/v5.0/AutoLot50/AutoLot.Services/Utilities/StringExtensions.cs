// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - StringExtensions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;

namespace AutoLot.Services.Utilities
{
    public static class StringExtensions
    {
        public static string RemoveController(this string original)
            => original.Replace("Controller", "", StringComparison.OrdinalIgnoreCase);
    }
}
