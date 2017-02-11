#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - A_ElementBinding.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFDemo.E_DataBinding.Views
{
    /// <summary>
    /// Interaction logic for A_ElementBinding.xaml
    /// </summary>
    public partial class A_ElementBinding
    {
        public A_ElementBinding()
        {
            InitializeComponent();
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            label1.FontSize = Double.Parse(((Button)e.OriginalSource).Tag.ToString());

        }

	 //   private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
	 //   {
		//	label1.FontSize = Double.Parse(((Button)e.OriginalSource).Tag.ToString());
		//}
	}
}