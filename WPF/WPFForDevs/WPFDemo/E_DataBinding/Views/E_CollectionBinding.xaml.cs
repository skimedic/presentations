#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - E_CollectionBinding.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Collections.ObjectModel;
using System.Windows;
using SampleData;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class E_CollectionBinding
    {
        public E_CollectionBinding()
        {
            InitializeComponent();
        }

        private ObservableCollection<Product> products;
        private void cmdGetProducts_Click(object sender, RoutedEventArgs e)
        {
products = FakeRepo.GetAllProducts();
lstProducts.ItemsSource = products;
        }

        private void cmdDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            products.Remove((Product)lstProducts.SelectedItem);
        }
    }
}
