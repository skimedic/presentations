#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ProductChangeNotificationParameter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Helpers;
using WPF.Models;

namespace WPF.Samples.C_ChangeNotification.Converters
{
    public class ProductChangeNotificationParameter
    {
        public IControlUpdater CallBackControlUpdater { get; set; }
        public Product Product { get; set; }
    }
}