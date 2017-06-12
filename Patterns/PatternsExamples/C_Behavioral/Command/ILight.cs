#region copyright
// Copyright Information
// ==============================
// PatternsExamples - ILight.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion
namespace PatternsExamples.C_Behavioral.Commands
{
    public interface ILight
    {
        bool LightIsOn { get; set; }
    }
}