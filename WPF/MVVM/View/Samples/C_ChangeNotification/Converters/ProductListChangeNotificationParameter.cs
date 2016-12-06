#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ProductListChangeNotificationParameter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.Generic;
using WPF.Helpers;
using WPF.Models;

namespace WPF.Samples.C_ChangeNotification.Converters
{
    public class ProductListChangeNotificationParameter
    {
        public IControlUpdater CallBackControlUpdater { get; set; }
        public IList<Product> ProductList { get; set; }
    }
}