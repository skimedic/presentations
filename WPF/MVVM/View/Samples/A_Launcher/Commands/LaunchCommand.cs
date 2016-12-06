#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LaunchCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Reflection;
using WPF.BaseClasses;
using WPF.Helpers;
using WPF.Samples.A_Launcher.ViewModels;

namespace WPF.Samples.A_Launcher.Commands
{
    [Obfuscation(Exclude = true)]
    internal class LaunchCommand : CommandBase
    {
        readonly IWindowLauncher _launcher;

        public LaunchCommand()
            : this(new WindowLauncher())
        {
        }

        public LaunchCommand(IWindowLauncher launcher)
        {
            _launcher = launcher;
        }

        public override void Execute(object parameter)
        {
            ApplicationWindowsEnum windowEnumType = ParseParameter(parameter);
            if (windowEnumType != ApplicationWindowsEnum.Unknown)
            {
                _launcher.WindowToShow = WindowFactory.CreateApplicationWindow(windowEnumType);
                _launcher.Show();
            }
        }

        public override bool CanExecute(object parameter) => (ParseParameter(parameter) != ApplicationWindowsEnum.Unknown);

	    internal ApplicationWindowsEnum ParseParameter(object parameter)
        {
            ApplicationWindowsEnum windowEnumType;
            try
            {
                windowEnumType = parameter != null ? (ApplicationWindowsEnum)parameter : ApplicationWindowsEnum.Unknown;
            }
            catch (Exception)
            {
                windowEnumType = ApplicationWindowsEnum.Unknown;
            }
            return windowEnumType;
        }
    }
}