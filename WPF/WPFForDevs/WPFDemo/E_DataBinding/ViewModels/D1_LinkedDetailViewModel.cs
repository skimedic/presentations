#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - D1_LinkedDetailViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion

using System.Windows.Input;
using SampleData;
using WPFDemo.E_DataBinding.Commands;

namespace WPFDemo.E_DataBinding.ViewModels
{
    public class D1_LinkedDetailViewModel
    {

        private ICommand _closeCommand;

        private ICommand _saveCommand;
        public Product Product { get; set; }
        public D1_LinkedDetailViewModel(Product product)
        {
            Product = product;
        }

        public ICommand Close => _closeCommand ?? (_closeCommand = new CloseCommand());

	    public ICommand Save => _saveCommand ?? (_saveCommand = new SaveCommand());
    }
}
