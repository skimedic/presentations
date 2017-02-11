#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - PriceValidator.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Globalization;
using System.Windows.Controls;

namespace WPFSamples.E_DataBinding.Validators
{
    public class PriceValidator : ValidationRule
    {
	    public decimal MinimumPrice { get; set; }

        public decimal MaximumPrice { get; set; } = decimal.MaxValue;

	    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal price = 0;
            try
            {
                if (((string)value)?.Length > 0)
                {
                    price = Decimal.Parse((string)value, NumberStyles.Any, cultureInfo);
                }
            }
            catch
            {
                return new ValidationResult(false, "Illegal characters.");
            }
            if ((price < MinimumPrice) || (price > MaximumPrice))
            {
                return new ValidationResult(false,$"Not in the range {MinimumPrice} to {MaximumPrice}.");
            }
            return new ValidationResult(true, null);
        }
    }
}