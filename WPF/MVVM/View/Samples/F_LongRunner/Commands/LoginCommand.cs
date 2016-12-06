#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LoginCommand.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using WPF.BaseClasses;
using WPF.Helpers;
using WPF.Samples.F_LongRunner.Converters;

namespace WPF.Samples.F_LongRunner.Commands
{
	public class LoginCommand : CommandBase
	{
		readonly IMessenger _messenger;
		LoginParameter _param;
		public LoginCommand(IMessenger messenger)
		{
			_messenger = messenger;
		}

		public async override void Execute(object parameter)
		{
			_param = parameter as LoginParameter;
			if (_param == null)
			{
				return;
			}
		   _param.AnimationController.StartAnimation();
			await DoLongRunningTask();
			_param?.AnimationController.EndAnimation();
		}

		private async Task<bool> DoLongRunningTask()
		{
			Thread.Sleep(2000);
			_messenger.Show("OK");
			return true;
		}
		public override bool CanExecute(object parameter)
		{
			var param = parameter as LoginParameter;
			return (param != null);
		}

	}
}