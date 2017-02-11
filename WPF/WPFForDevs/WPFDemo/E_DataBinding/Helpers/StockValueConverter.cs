#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - StockValueConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFDemo.E_DataBinding.Helpers
{
    public class StockValueConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var priceString = values[0].ToString();
            decimal unitCost;
            Decimal.TryParse(priceString, NumberStyles.Any, culture, out unitCost);
            var unitsInStockString = values[1].ToString();
            decimal unitsInStock;
            Decimal.TryParse(unitsInStockString, NumberStyles.Any, culture, out unitsInStock);
            return (unitCost * unitsInStock).ToString("C");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
