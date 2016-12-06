#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LongRunningTaskViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Windows.Input;
using WPF.Helpers;
using WPF.Samples.F_LongRunner.Commands;

namespace WPF.Samples.F_LongRunner.ViewModels
{
    public class LongRunningTaskViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        private ICommand _loginCmd;
        public ICommand LoginCmd => _loginCmd ?? (_loginCmd = new LoginCommand(new UIMessenger()));
    }
}

