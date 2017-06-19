// Copyright Information
// =============================
// StructuralPatterns - BaseCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace StructuralPatterns.Decorator
{
    public class BaseCar : ICar
    {
	    public int Drive() => 100;

	    public int Attack() => 100;

	    public int Defend() => 100;
    }
}
