#region copyright
// Copyright Information
// ==============================
// PatternsExamples - RaceCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace StructuralPatterns.Decorator
{
    public class RaceCar : ICar
    {
        private readonly ICar _decoratedCar;

        public RaceCar(ICar decoratedCar)
        {
            _decoratedCar = decoratedCar;
        }

        public int Drive() => _decoratedCar.Drive() + 40;

	    public int Attack() => _decoratedCar.Attack() - 10;

	    public int Defend() => _decoratedCar.Defend() - 10;
    }
}