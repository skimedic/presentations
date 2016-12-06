#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ChangeNotificationSample.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Samples.C_ChangeNotification.ViewModels;

namespace WPF.Samples.C_ChangeNotification.Views
{
    /// <summary>
    /// Interaction logic for ChangeNotificationSample.xaml
    /// </summary>
    public partial class ChangeNotificationSample
    {
        public ChangeNotificationSample()
        {
            InitializeComponent();
            DataContext = new ChangeNotificationViewModel();
        }
    }
}