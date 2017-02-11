#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - _Launcher.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFDemo.E_DataBinding.Views
{
	/// <summary>
	/// Interaction logic for _Launcher.xaml
	/// </summary>
	public partial class _Launcher : Window
	{
		public _Launcher()
		{
			InitializeComponent();
		}

		public void MenuItem_Click(object sender, RoutedEventArgs e)
		{
			var cmd = e.OriginalSource as Button;
			if (cmd == null)
			{
				return;
			}
			var frm = (Window)Activator.CreateInstance((Type)cmd.Tag);
			frm.Show();
			
		}
	}
}