// Copyright Information
// ==============================
// PatternsExamples - AttackCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================

namespace StructuralPatterns.Decorator
{
    public class AttackCar : ICar
    {
        private readonly ICar _decoratedCar;

        public AttackCar(ICar decoratedCar)
        {
            _decoratedCar = decoratedCar;
        }

        public int Drive() => _decoratedCar.Drive() - 10;

	    public int Attack() => _decoratedCar.Attack() + 30;

	    public int Defend() => _decoratedCar.Defend() - 10;
    }
}
