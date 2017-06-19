// Copyright Information
// =============================
// StructuralPatterns - ArmoredCar.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
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