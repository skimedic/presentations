#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - AnimationController.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.Helpers
{
    public class AnimationController : IAnimationController
    {
        readonly ProgressBar _control;

        public AnimationController(ProgressBar control)
        {
            _control = control;
        }

        public void StartAnimation()
        {
            if (_control != null)
            {
                _control.IsIndeterminate = true;
            }
        }

        public void EndAnimation()
        {
            if (_control != null)
            {
                _control.IsIndeterminate = false;
            }
        }
    }
}