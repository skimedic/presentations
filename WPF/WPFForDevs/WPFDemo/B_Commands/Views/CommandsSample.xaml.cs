#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - CommandsSample.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using WPFDemo.B_Commands.ViewModels;

namespace WPFDemo.B_Commands.Views
{
    /// <summary>
    /// Interaction logic for CommandsSample.xaml
    /// </summary>
    public partial class CommandsSample
    {
        public CommandsSample()
        {
            InitializeComponent();
            DataContext = new CommandViewModel();
            if (chkCommandEnabled.IsChecked == true)
            {
                
            }
        }
    }
}