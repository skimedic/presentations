#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - Behaviors.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Windows;
using WPF.Samples.E_Behaviors.ViewModels;

namespace WPF.Samples.E_Behaviors.Views
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
