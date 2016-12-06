#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - GridClickedCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WPF.BaseClasses;
using WPF.Helpers;
using WPF.Models;

namespace WPF.Samples.E_Behaviors.ViewModels
{
    public class GridClickedCommand : CommandBase
    {
        readonly IMessenger _messenger;

        public GridClickedCommand(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public override void Execute(object parameter)
        {

            if (!(parameter is Product))
            {
                return;
            }
            _messenger.Show(((Product)parameter).ModelName);
            
        }

        public override bool CanExecute(object parameter) => parameter is Product;
    }
}
