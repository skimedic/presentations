#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - IAnimationController.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

using System.Threading.Tasks;

#endregion



namespace WPF.Helpers
{
    public interface IAnimationController
    {
        void StartAnimation();
        void EndAnimation();
    }
}