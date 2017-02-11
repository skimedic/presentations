#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - G_MasterDetail.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPFDemo.E_DataBinding.ViewModels;

namespace WPFDemo.E_DataBinding.Views
{
	/// <summary>
	/// Interaction logic for E_MasterDetail.xaml
	/// </summary>
	public partial class G_MasterDetail
	{
		public G_MasterDetail()
		{
			InitializeComponent();
			DataContext = new D_MasterDetailVewModel();
		}

	}
}
