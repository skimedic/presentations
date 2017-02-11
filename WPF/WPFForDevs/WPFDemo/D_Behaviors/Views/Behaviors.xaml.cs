#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - Behaviors.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Windows;
using WPFDemo.D_Behaviors.ViewModels;

namespace WPFDemo.D_Behaviors.Views
{
    /// <summary>
    /// Interaction logic for Behaviors.xaml
    /// </summary>
    public partial class Behaviors : Window
    {
        public Behaviors()
        {
            InitializeComponent();
            DataContext = new BehaviorsViewModel();
        }

    }
}
