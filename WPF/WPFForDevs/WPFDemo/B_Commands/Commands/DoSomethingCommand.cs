#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - DoSomethingCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows.Input;
using WPFDemo.B_Commands.Helpers;
using WPFDemo.BaseClasses;

namespace WPFDemo.B_Commands.Commands
{
    public class DoSomethingCommand : CommandBase
    {
        readonly IMessager _messager;

        public DoSomethingCommand(IMessager messager)
        {
            _messager = messager;
        }

        public override void Execute(object parameter)
        {
            _messager.Show("Clicked!");
        }

		public override bool CanExecute(object parameter) => (parameter != null && (bool)parameter);
    }
}
