#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - PositivePriceValidationRule.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Globalization;
using System.Windows.Controls;

namespace WPFDemo.E_DataBinding.Helpers
{
    public class PositivePriceValidationRule : ValidationRule
    {
        public decimal MinPrice { get; set; }
	    public decimal MaxPrice { get; set; } = decimal.MaxValue;

	    #region Overrides of ValidationRule

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(true, null);
            }
            decimal price;
            if (!Decimal.TryParse(value.ToString(), NumberStyles.Any, cultureInfo, out price))
            {
                return new ValidationResult(false, "Invalid Characters Entered");
            }
            if (price < MinPrice || price > MaxPrice)
            {
                return new ValidationResult(false, "Not in the correct range of " + MinPrice.ToString("C") + " to " + MaxPrice.ToString("C"));
            }
            return new ValidationResult(true, null);
        }

        #endregion
    }
}
