#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ProductListChangeNotificationMultiConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Helpers;
using WPF.Models;

namespace WPF.Samples.C_ChangeNotification.Converters
{
    public class ProductListChangeNotificationMultiConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values, 
            Type targetType, 
            object parameter, 
            System.Globalization.CultureInfo culture)
        {
            var param = new ProductListChangeNotificationParameter();
            foreach (var obj in values)
            {
                if (obj is ContentControl)
                {
                    param.CallBackControlUpdater = new ControlUpdater(obj as ContentControl);
                }
                if (obj is IList<Product>)
                {
                    param.ProductList = obj as IList<Product>;
                }
            }
            return param;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}