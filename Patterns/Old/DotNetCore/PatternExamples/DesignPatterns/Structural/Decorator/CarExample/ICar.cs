// Copyright Information
// =============================
// StructuralPatterns - ICar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Structural.Decorator.CarExample
{
    public interface ICar
    {
        int Drive();

        int Attack();

        int Defend();
    }
}