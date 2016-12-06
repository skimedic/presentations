#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - PriceUpdaterCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.BaseClasses;
using WPF.Samples.C_ChangeNotification.Converters;

namespace WPF.Samples.C_ChangeNotification.Commands
{
    public class PriceUpdaterCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var p = parameter as ProductChangeNotificationParameter;
            if (p?.Product == null) return;
            p.Product.Price *= 1.1M;
            p.CallBackControlUpdater.SetContent(p.Product.Price.ToString());
        }
        public override bool CanExecute(object parameter)
        {
            var p = parameter as ProductChangeNotificationParameter;
            return (p?.Product != null);
        }
    }
}