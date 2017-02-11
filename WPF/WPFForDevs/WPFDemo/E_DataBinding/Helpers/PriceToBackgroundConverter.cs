#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - PriceToBackgroundConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WPFDemo.E_DataBinding.Helpers
{
    public class PriceToBackgroundConverter : IValueConverter
    {
        public decimal MinimumPriceToHighLight { get; set; }
        public Brush HighlightBrush { get; set; }
        public Brush DefaultBrush { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            decimal price;
	        if (!decimal.TryParse(value.ToString(), out price)) return DefaultBrush;
	        return price >= MinimumPriceToHighLight ? HighlightBrush : DefaultBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
