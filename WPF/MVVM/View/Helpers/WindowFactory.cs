#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - WindowFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Windows;
using WPF.Samples.A_Launcher.ViewModels;
using WPF.Samples.C_ChangeNotification.Views;
using WPF.Samples.D_Commands.Views;
using WPF.Samples.E_Behaviors.Views;
using WPF.Samples.F_LongRunner.Views;
using WPF.Samples.Validation.Views;

namespace WPF.Helpers
{
    public static class WindowFactory
    {
        public static Window CreateApplicationWindow(ApplicationWindowsEnum windowEnumType)
        {
            switch (windowEnumType)
            {
                case ApplicationWindowsEnum.ValidationSample:
                {
                    return new ValidationSample();
                }
                case ApplicationWindowsEnum.ChangeNotificationSample:
                {
                    return new ChangeNotificationSample();
                }
                case ApplicationWindowsEnum.CommandsSample:
                {
                    return new CommandsSample();
                }
                case ApplicationWindowsEnum.LongRunningTasksSample:
                {
                    return new LongRunningTask();
                }
                case ApplicationWindowsEnum.BehaviorSample:
                {
                    return new Behaviors();
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}