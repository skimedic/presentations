#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - CommandsSample.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Samples.D_Commands.ViewModels;

namespace WPF.Samples.D_Commands.Views
{
    /// <summary>
    /// Interaction logic for CommandsSample.xaml
    /// </summary>
    public partial class CommandsSample
    {
        public CommandsSample()
        {
            InitializeComponent();
            DataContext = new CommandViewModel();
        }
    }
}