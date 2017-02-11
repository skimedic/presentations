#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - BehaviorsViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using SampleData;
using WPFDemo.B_Commands.Helpers;

namespace WPFDemo.D_Behaviors.ViewModels
{
    public class BehaviorsViewModel
    {
        public ObservableCollection<Product> Products { get; set; }

        public BehaviorsViewModel()
        {
            Products = new ObservableCollection<Product>(FakeRepo.GetAllProducts());
        }
        public void Clicked()
        {
            MessageBox.Show("Clicked");
        }

        ICommand _gridClickedCommand;

        public ICommand GridClickedCommand
        {
            get { return _gridClickedCommand ?? (_gridClickedCommand = new GridClickedCommand(new UIMessager())); }
            set { _gridClickedCommand = value; }
        }
    }
}