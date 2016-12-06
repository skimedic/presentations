#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - AddProductCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.BaseClasses;
using WPF.Models;
using WPF.Samples.C_ChangeNotification.Converters;

namespace WPF.Samples.C_ChangeNotification.Commands
{
    public class AddProductCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var p = parameter as ProductListChangeNotificationParameter;
            if (p?.ProductList == null) return;
            p.ProductList.Add(new Product { ID = 20, ModelName = "New Model", Inventory = 20, Price = 20M, SKU = "1234567890" });
            p.CallBackControlUpdater.SetContent(p.ProductList.Count.ToString());
        }
        public override bool CanExecute(object parameter)
        {
            var p = parameter as ProductListChangeNotificationParameter;
            return (p?.ProductList != null);
        }
    }
}