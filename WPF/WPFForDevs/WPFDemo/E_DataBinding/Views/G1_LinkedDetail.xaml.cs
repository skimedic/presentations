#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - G1_LinkedDetail.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows;
using System.Windows.Input;
using SampleData;
using WPFDemo.E_DataBinding.ViewModels;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for E_MasterDetail.xaml
    /// </summary>
    public partial class G1_LinkedDetail
    {
        public G1_LinkedDetail(Product prod)
        {
            InitializeComponent();
            this.DataContext = new D1_LinkedDetailViewModel(prod);
        }

    }
}
