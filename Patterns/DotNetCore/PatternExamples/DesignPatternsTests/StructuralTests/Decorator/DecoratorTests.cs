// Copyright Information
// =============================
// StructuralPatternsTests - DecoratorTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using DesignPatterns.Structural.Decorator.CarExample;
using Xunit;

namespace DesignPatternsTests.StructuralTests.Decorator
{
    [Collection("DecoratorTests")]
    public class DecoratorTests
    {
        [Fact]
        public void ShouldReturnBaseCar()
        {
            ICar car = new BaseCar();
            Assert.Equal(100, car.Drive());
            Assert.Equal(100, car.Attack());
            Assert.Equal(100, car.Defend());
        }

        [Fact]
        public void ShouldReturnArmoredCar()
        {
            var baseCar = new BaseCar();
            var car = new ArmoredCar(baseCar);
            Assert.Equal(80, car.Drive());
            Assert.Equal(100, car.Attack());
            Assert.Equal(140, car.Defend());
        }

        [Fact]
        public void ShouldReturnRaceCar()
        {
            var baseCar = new BaseCar();
            var car = new RaceCar(baseCar);
            Assert.Equal(140, car.Drive());
            Assert.Equal(90, car.Attack());
            Assert.Equal(90, car.Defend());
        }

        [Fact]
        public void ShouldReturnAttackCar()
        {
            var baseCar = new BaseCar();
            var car = new AttackCar(baseCar);
            Assert.Equal(90, car.Drive());
            Assert.Equal(130, car.Attack());
            Assert.Equal(90, car.Defend());
        }

        [Fact]
        public void ShouldReturnFullyDecoratedRaceCar()
        {
            var baseCar = new BaseCar();
            var armoredCar = new ArmoredCar(baseCar);
            var armoredCar2 = new ArmoredCar(armoredCar);
            var raceCar = new RaceCar(armoredCar2);
            ICar car = new AttackCar(raceCar);
            Assert.Equal(90, car.Drive());
            Assert.Equal(120, car.Attack());
            Assert.Equal(160, car.Defend());
        }
    }
}