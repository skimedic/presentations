#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - UpdatePriceCommand.cs
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
    public class UpdatePriceCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var p = parameter as Product;
            if (p != null)
            {
                p.UnitCost *= 1.1M;
            }
        }

        public override bool CanExecute(object parameter)
        {
            var p = parameter as Product;
            if (p == null || p.IsDirty)
            {
                return false;
            }
            return true;
        }

    }
}