#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ValidationViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Collections.Generic;
using WPF.Models;

namespace WPF.Samples.B_Validation.ViewModels
{
    public class ValidationViewModel
    {
        public IList<Product> Products { get; set; }
        public ValidationViewModel()
        {
            Products = new ProductService().GetProducts();
        }
        public ValidationViewModel(IList<Product> products)
        {
            Products = products;
        }
    }
}