#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - Launcher.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Samples.A_Launcher.ViewModels;

namespace WPF.Samples.A_Launcher.Views
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class Launcher
    {
        public Launcher()
        {
            InitializeComponent();
            DataContext = new LauncherViewModel();
        }
    }
}