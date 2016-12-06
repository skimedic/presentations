#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - Foo.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.BaseClasses;
using WPF.Helpers;

namespace WPF.Samples.D_Commands.Commands
{
    public class Foo : CommandBase
    {
        readonly IMessenger _messenger;

        public Foo(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public override void Execute(object parameter)
        {
            _messenger.Show("Foo");
        }

		public override bool CanExecute(object parameter) => (bool)parameter;

	}
}