using System;
using System.Windows.Input;

namespace MVVM.Cmds
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
