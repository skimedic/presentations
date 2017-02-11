#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - CommandViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System.Windows.Input;
using WPFDemo.B_Commands.Commands;
using WPFDemo.B_Commands.Helpers;

namespace WPFDemo.B_Commands.ViewModels
{
    public class CommandViewModel
    {
        private ICommand _doSomethingCmd;
        public ICommand DoSomethingCmd
        {
            get
            {
                return _doSomethingCmd ?? (_doSomethingCmd = new DoSomethingCommand(new UIMessager()));
            }
            set
            {
                _doSomethingCmd = value;
            }
        }
        private ICommand _doSomethingElseCmd;
        public ICommand DoSomethingElseCmd
        {
            get
            {
                return _doSomethingElseCmd ?? (_doSomethingElseCmd = new AnotherCommand(new UIMessager()));
            }
            set
            {
                _doSomethingElseCmd = value;
            }
        }
    }
}