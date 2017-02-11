#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - CloseCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows;
using System.Windows.Input;
using WPFDemo.BaseClasses;
using WPFDemo.E_DataBinding.Helpers;

namespace WPFDemo.E_DataBinding.Commands
{
    public class CloseCommand : CommandBase
    {
	    public override void Execute(object parameter)
        {
            var p = parameter as CloseCommandParameter;
		    p?.Window?.Close();
        }

        public override bool CanExecute(object parameter)
        {
            var p = parameter as CloseCommandParameter;
            if (p == null)
            {
                return false;
            }
            return p.Product == null || !p.Product.IsDirty;
        }

    }
}