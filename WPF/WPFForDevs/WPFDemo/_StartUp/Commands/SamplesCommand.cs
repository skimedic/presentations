#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - SamplesCommand.cs
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
using WPFDemo.BaseClasses;

namespace WPFDemo.StartUp.Commands
{
	public class SamplesCommand: CommandBase
	{
		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			Window w = (Window)Activator.CreateInstance((Type)parameter);
			//w.Left = this.Left;
			//w.Top = this.Top + this.Height;
			w.Show();
		}
	}
}
