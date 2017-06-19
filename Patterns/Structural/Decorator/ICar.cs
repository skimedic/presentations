// Copyright Information
// =============================
// StructuralPatterns - ICar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
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