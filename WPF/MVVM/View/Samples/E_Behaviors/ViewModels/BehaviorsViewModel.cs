#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - BehaviorsViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WPF.Helpers;
using WPF.Models;

namespace WPF.Samples.E_Behaviors.ViewModels
{
    public class BehaviorsViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public BehaviorsViewModel()
        {
            Products = new ObservableCollection<Product>(new ProductService().GetProducts());
        }
        ICommand _gridClickedCommand;

        public ICommand GridClickedCommand
        {
            get { return _gridClickedCommand ?? (_gridClickedCommand = new GridClickedCommand(new UIMessenger())); }
            set { _gridClickedCommand = value; }
        }
    }
}