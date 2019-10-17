using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace simpleCalc.WindowsUAP
{
    class DoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if (!(value is double))
                return value;

            double val = (double) value;
            return val.ToString("0.00");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if (!(value is string))
                return value;

            string val = (string) value;

            return System.Convert.ToDouble(val);
        }
    }
}
