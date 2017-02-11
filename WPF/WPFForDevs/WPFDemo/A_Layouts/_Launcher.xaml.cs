#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - _Launcher.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace WPFDemo.A_Layouts
{
    /// <summary>
    /// Interaction logic for SelectorExamples.xaml
    /// </summary>
    public partial class _Launcher
    {
        public _Launcher()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var cmd = e.OriginalSource as Button;
            if (cmd == null)
            {
                return;
            }
            var frm = (Window)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType(cmd.Tag.ToString()));
            frm.Show();
        }
    }
}