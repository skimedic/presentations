#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - ProductListDisplayConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace WPFDemo.E_DataBinding.Helpers
{
    public class ProductListDisplayConverter :IMultiValueConverter
    {
        public object Convert(object[] values, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            var sb = new StringBuilder();
            if (values[0]!=null)
            {
                sb.Append(values[0]);
            }
            if (values[1]!=null)
            {
               sb.Append($" ({values[1]})");
            }
            return sb.ToString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
