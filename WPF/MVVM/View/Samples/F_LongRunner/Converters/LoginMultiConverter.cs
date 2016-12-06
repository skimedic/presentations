#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LoginMultiConverter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Windows.Controls;
using System.Windows.Data;
using WPF.Helpers;

namespace WPF.Samples.F_LongRunner.Converters
{
public class LoginMultiConverter : IMultiValueConverter
{
    public object Convert(
        object[] values, 
        Type targetType, 
        object parameter, 
        System.Globalization.CultureInfo culture)
    {
        var param = new LoginParameter();
        //UN/PWD/PB
        if (values == null || values.Length != 3 
            || values[0] == null || values[0].ToString() == string.Empty 
            || values[1] == null || values[1].ToString() == string.Empty)
        {
            return null;
        }
        param.UserName = values[0].ToString();
        param.Password = values[1].ToString();
        param.AnimationController = new AnimationController(values[2] as ProgressBar);
        return param;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }

}
}