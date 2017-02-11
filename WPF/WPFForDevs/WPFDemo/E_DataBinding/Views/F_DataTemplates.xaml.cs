#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - F_DataTemplates.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using SampleData;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for D_DataTemplates.xaml
    /// </summary>
    public partial class F_DataTemplates
    {
        public F_DataTemplates()
        {
            InitializeComponent();
            lbProducts.ItemsSource = FakeRepo.GetAllProducts();
        }
    }
}