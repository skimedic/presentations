#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - C_CheckedLists.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Collections.Generic;
using System.Windows;
using SampleData;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for CheckedLists.xaml
    /// </summary>
    public partial class CheckedLists : Window
    {
        public CheckedLists()
        {
            InitializeComponent();
            IList<Product> all = FakeRepo.GetAllProducts();
            lstProductsRB.ItemsSource = all;
            lstProductsCheck.ItemsSource = all;
        }
    }
}