#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - UIMessager.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Windows;

namespace WPFDemo.B_Commands.Helpers
{
    public class UIMessager : IMessager
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}