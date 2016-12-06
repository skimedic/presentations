#region Copyright Info
// Copyright Information
// ==============================
// MVVM - WPF - LoginParameter.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2014/05/13
// See License.txt for more information
// ==============================
#endregion
#region Copyright

#endregion

using WPF.Helpers;

namespace WPF.Samples.F_LongRunner.Converters
{
    public class LoginParameter
    {
        public IAnimationController AnimationController { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}