#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - CommandBase.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Windows.Input;

namespace WPF.BaseClasses
{
    public abstract class CommandBase : ICommand
    {

        public abstract void Execute(object parameter);
        public abstract bool CanExecute(object parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
