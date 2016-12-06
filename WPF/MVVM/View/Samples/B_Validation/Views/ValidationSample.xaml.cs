#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ValidationSample.xaml.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Samples.B_Validation.ViewModels;

namespace WPF.Samples.Validation.Views
{
    /// <summary>
    /// Interaction logic for ChangeNotificationSample.xaml
    /// </summary>
    public partial class ValidationSample
    {
        public ValidationSample()
        {
            InitializeComponent();
            DataContext = new ValidationViewModel();
        }

    }
}