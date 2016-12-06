#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - CommandViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Windows.Input;
using WPF.BaseClasses;
using WPF.Helpers;
using WPF.Samples.D_Commands.Commands;

namespace WPF.Samples.D_Commands.ViewModels
{
    public class CommandViewModel
    {
        //private RelayCommand Foo;
        private ICommand _doSomethingCmd;

        public CommandViewModel()
        {
            //Foo = new RelayCommand(DoSomethingMethod);
        }

        //private void DoSomethingMethod()
        //{
        //    throw new System.NotImplementedException();
        //}

        public ICommand DoSomethingCmd
        {
            get { return _doSomethingCmd ?? (_doSomethingCmd = new DoSomethingCommand(new UIMessenger())); }
            set { _doSomethingCmd = value; }
        }
        private ICommand _doSomethingElseCmd;
        public ICommand DoSomethingElseCmd
        {
            get { return _doSomethingElseCmd ?? (_doSomethingElseCmd = new Foo(new UIMessenger())); }
            set { _doSomethingElseCmd = value; }
        }

    }
}