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

namespace WPFDemo.A_Layouts
{
	/// <summary>
	/// Interaction logic for WrapPanelExample.xaml
	/// </summary>
	public partial class WrapPanelExample : Window
	{
		public WrapPanelExample()
		{
			InitializeComponent();
		}

		private void RadioButtonClicked(object sender, RoutedEventArgs e)
		{
			MyWrapPanel.Orientation = (rbVertical.IsChecked.HasValue && rbVertical.IsChecked.Value) 
				? Orientation.Vertical: Orientation.Horizontal;
		}
	}
}
