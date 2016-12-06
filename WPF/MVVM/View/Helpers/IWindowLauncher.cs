#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - IWindowLauncher.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Windows;

namespace WPF.Helpers
{
    public interface IWindowLauncher
    {
        Window WindowToShow { get; set; }
        void Show();
    }
}