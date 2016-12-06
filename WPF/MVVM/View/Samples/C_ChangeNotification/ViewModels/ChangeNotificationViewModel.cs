#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ChangeNotificationViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Models;
using WPF.Samples.C_ChangeNotification.Commands;

namespace WPF.Samples.C_ChangeNotification.ViewModels
{
    public class ChangeNotificationViewModel
    {
        public IList<Product> Products { get; set; }
        public ChangeNotificationViewModel()
        {
            Products = new ObservableCollection<Product>(new ProductService().GetProducts());
        }
        public ChangeNotificationViewModel(IEnumerable<Product> products)
        {
            Products = new ObservableCollection<Product>(products);
        }
        private ICommand _updatePrice;
        public ICommand UpdatePriceCmd
        {
            get { return _updatePrice ?? (_updatePrice = new PriceUpdaterCommand()); }
            set { _updatePrice = value; }
        }

        private ICommand _addProduct;
        public ICommand AddProductCmd
        {
            get { return _addProduct ?? (_addProduct = new AddProductCommand()); }
            set { _addProduct = value; }
        }
    }
}