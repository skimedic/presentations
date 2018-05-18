// Copyright Information
// =============================
// StructuralPatterns - BaseCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Structural.Decorator.CarExample
{
    public class BaseCar : ICar
    {
	    public int Drive() => 100;

	    public int Attack() => 100;

	    public int Defend() => 100;
    }
}
