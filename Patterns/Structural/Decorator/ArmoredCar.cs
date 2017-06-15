#region copyright
// Copyright Information
// ==============================
// PatternsExamples - ArmoredCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace StructuralPatterns.Decorator
{
    public class ArmoredCar : ICar
    {
        private readonly ICar _decoratedCar;

        public ArmoredCar(ICar decoratedCar)
        {
            _decoratedCar = decoratedCar;
        }

        public int Drive() => _decoratedCar.Drive() - 20;

	    public int Attack() => _decoratedCar.Attack();

	    public int Defend() => _decoratedCar.Defend() + 40;
    }
}