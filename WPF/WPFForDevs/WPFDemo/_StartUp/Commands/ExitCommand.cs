#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - ExitCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDemo.BaseClasses;

namespace WPFDemo.StartUp.Commands
{
	public class ExitCommand : CommandBase
	{
		public override void Execute(object parameter)
		{
			Application.Current.Shutdown();
		}

		public override bool CanExecute(object parameter) => true;
	}
}
