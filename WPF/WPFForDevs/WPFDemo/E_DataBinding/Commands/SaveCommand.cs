#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - SaveCommand.cs
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

namespace WPFDemo.E_DataBinding.Commands
{
    public class SaveCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var p = parameter as Product;
            if (p != null)
            {
                p.IsDirty = false;
            }

        }

        public override bool CanExecute(object parameter)
        {
            var p = parameter as Product;
            return p != null && p.IsDirty;
        }

    }
}