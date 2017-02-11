#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - LinkedFormCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows;
using System.Windows.Input;
using SampleData;
using WPFDemo.BaseClasses;
using WPFDemo.E_DataBinding.Views;

namespace WPFDemo.E_DataBinding.Commands
{
    public class LinkedFormCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var p = parameter as Product;
            if (p != null)
            {
                var window = new G1_LinkedDetail(p);
                window.Show();
            }

        }

        public override bool CanExecute(object parameter)
        {
            var p = parameter as Product;
            if (p != null)
            {
                return true;
            }
            return false;
        }

    }
}