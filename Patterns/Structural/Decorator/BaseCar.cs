#region copyright
// Copyright Information
// ==============================
// PatternsExamples - BaseCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace Structural.C_Decorator
{
    public class BaseCar : ICar
    {
	    public int Drive() => 100;

	    public int Attack() => 100;

	    public int Defend() => 100;
    }
}
