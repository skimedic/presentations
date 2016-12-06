#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LauncherViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Reflection;
using System.Windows.Input;
using WPF.Samples.A_Launcher.Commands;

namespace WPF.Samples.A_Launcher.ViewModels
{
    public class LauncherViewModel
    {
        private ICommand _launchCmd;
        public ICommand LaunchCmd => _launchCmd ?? (_launchCmd = new LaunchCommand());
    }
}