#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - B_BasicGridView.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using SampleData;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for ListView.xaml
    /// </summary>
    public partial class BasicGridView
    {
        public BasicGridView()
        {
            InitializeComponent();
            lstProducts.ItemsSource = FakeRepo.GetAllProducts();
            // new StoreDbWithDataSet().GetProducts().DefaultView;
        }
    }
}