#region Copyright Info
// Copyright Information
// ==============================
// WPFDemo - WPFDemo - StartUpFormViewModel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFDemo.StartUp.Commands;

namespace WPFDemo.StartUp.ViewModel
{
    public class StartUpFormViewModel
    {
        private ICommand _exitCommand;

        private ICommand _samplesCommand;

        public ICommand ExitCommand
        {
            get { return _exitCommand ?? (_exitCommand = new ExitCommand()); }
	        private set
            {
                _exitCommand = value;
            }
        }
        public ICommand SamplesCommand
        {
            get { return _samplesCommand ?? (_samplesCommand = new SamplesCommand()); }
	        private set
            {
                _samplesCommand = value;
            }
        }
    }
}
