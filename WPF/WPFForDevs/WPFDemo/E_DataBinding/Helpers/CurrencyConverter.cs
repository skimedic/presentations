#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - CurrencyConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows.Data;
using System.Globalization;

namespace WPFDemo.E_DataBinding.Helpers
{
	[ValueConversion(typeof(decimal),typeof(string))]
	public class CurrencyConverter:IValueConverter
	{
		public object Convert(object value, 
			Type targetType, 
			object parameter, 
			CultureInfo culture)
		{
			if (value == null)
			{
				return Binding.DoNothing;
			}
			var amount = (decimal) value;
			return amount.ToString("C", culture);
		}
		public object ConvertBack(object value, 
			Type targetType, 
			object parameter, 
			CultureInfo culture)
		{
			string price = value.ToString();
			decimal result;
			return Decimal.TryParse(price,NumberStyles.Any,culture,out result) ? result : value;
		}
	}
}