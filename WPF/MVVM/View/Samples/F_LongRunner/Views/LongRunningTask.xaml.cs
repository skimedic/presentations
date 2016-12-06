#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LongRunningTask.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Samples.F_LongRunner.ViewModels;

namespace WPF.Samples.F_LongRunner.Views
{
    /// <summary>
    /// Interaction logic for LongRunningTask.xaml
    /// </summary>
    public partial class LongRunningTask
    {
        public LongRunningTask()
        {
            InitializeComponent();
            DataContext = new LongRunningTaskViewModel();
        }
    }
}