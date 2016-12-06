#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - ControlUpdater.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Windows.Controls;

namespace WPF.Helpers
{
    public class ControlUpdater : IControlUpdater
    {
        readonly ContentControl _control;

        public ControlUpdater(ContentControl control)
        {
            _control = control;
        }

        public void SetContent(string contentToShow)
        {
            _control.Content = contentToShow;
        }
    }
}