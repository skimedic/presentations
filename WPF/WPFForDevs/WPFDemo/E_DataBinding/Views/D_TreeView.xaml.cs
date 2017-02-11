#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - D_TreeView.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using SampleData;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView
    {
        public TreeView()
        {
            InitializeComponent();
            treeOrders.ItemsSource = FakeRepo.GetAllCategories();
        }
    }
}