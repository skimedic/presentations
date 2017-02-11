#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - CommandBase.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Windows.Input;

namespace WPFDemo.BaseClasses
{
	public abstract class CommandBase : ICommand
	{
		public abstract bool CanExecute(object parameter);

		public abstract void Execute(object parameter);

		//http://joshsmithonwpf.wordpress.com/2008/06/17/allowing-commandmanager-to-query-your-icommand-objects/
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}
	}
}