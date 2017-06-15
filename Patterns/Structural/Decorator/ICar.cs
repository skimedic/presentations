#region copyright
// Copyright Information
// ==============================
// PatternsExamples - ICar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace StructuralPatterns.Decorator
{
    public interface ICar
    {
        int Drive();

        int Attack();

        int Defend();
        //TODO: Add This
        //string CarType { get; set; }
    }
}