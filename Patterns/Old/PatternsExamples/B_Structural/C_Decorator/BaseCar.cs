// Copyright Information
// =============================
// PatternsExamples - BaseCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace PatternsExamples.B_Structural.C_Decorator
{
    public class BaseCar : ICar
    {
	    public int Drive() => 100;

	    public int Attack() => 100;

	    public int Defend() => 100;
    }
}
