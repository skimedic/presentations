#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - DoSomethingCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System;
using System.Windows.Input;
using WPF.Helpers;

namespace WPF.Samples.D_Commands.Commands
{
    public class DoSomethingCommand : ICommand
    {
        readonly IMessenger _messenger;

        public DoSomethingCommand(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void Execute(object parameter)
        {
            _messenger.Show("Clicked!");
        }

        public bool CanExecute(object parameter) 
            => (parameter != null && (bool) parameter);

        //http://joshsmithonwpf.wordpress.com/2008/06/17/allowing-commandmanager-to-query-your-icommand-objects/
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
