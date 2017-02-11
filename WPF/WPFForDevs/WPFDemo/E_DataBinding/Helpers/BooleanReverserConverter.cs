#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - BooleanReverserConverter.cs
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
    [ValueConversion(typeof(bool),typeof(bool))]
    public class BooleanReverserConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var original = (bool)value;
            return !original;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var updated = (bool)value;
            return !updated;
        }
    }
}