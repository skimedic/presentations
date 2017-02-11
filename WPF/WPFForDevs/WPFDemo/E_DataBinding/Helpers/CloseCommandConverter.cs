#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - CloseCommandConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SampleData;

namespace WPFDemo.E_DataBinding.Helpers
{
    public class CloseCommandConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
	        var param = new CloseCommandParameter
	        {
		        Window = (Window) values[0],
		        Product = (Product) values[1]
	        };
	        return param;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}