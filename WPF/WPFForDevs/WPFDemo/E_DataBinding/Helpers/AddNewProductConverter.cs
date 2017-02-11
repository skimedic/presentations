#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - AddNewProductConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using SampleData;

namespace WPFDemo.E_DataBinding.Helpers
{
    public class AddNewProductConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
	        var param = new AddNewProductParameter
	        {
		        Category = (Category) values[0],
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
