#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - UIMessenger.cs
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
    public class UIMessenger : IMessenger
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}