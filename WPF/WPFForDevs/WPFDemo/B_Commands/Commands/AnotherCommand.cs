#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - AnotherCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using WPFDemo.B_Commands.Helpers;
using WPFDemo.BaseClasses;

namespace WPFDemo.B_Commands.Commands
{
    public class AnotherCommand : CommandBase
    {
        readonly IMessager _message;

        public AnotherCommand(IMessager message)
        {
            _message = message;
        }

        public override void Execute(object parameter)
        {
            _message.Show("Me Too!");
        }

        public override bool CanExecute(object parameter) => (bool)parameter;
    }
}