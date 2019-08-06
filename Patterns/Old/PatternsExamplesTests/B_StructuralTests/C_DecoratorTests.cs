// Copyright Information
// =============================
// PatternsExamplesTests - C_DecoratorTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using PatternsExamples.B_Structural.C_Decorator;
using NUnit.Framework;

namespace PatternsExamplesTests.B_StructuralTests
{
    [TestFixture]
    public class DecoratorTests
    {
        [Test]
        public void ShouldReturnBaseCar()
        {
            ICar car = new BaseCar();
            Assert.AreEqual(100, car.Drive());
            Assert.AreEqual(100, car.Attack());
            Assert.AreEqual(100, car.Defend());
        }

        [Test]
        public void ShouldReturnArmoredCar()
        {
            var baseCar = new BaseCar();
            var car = new ArmoredCar(baseCar);
            Assert.AreEqual(80, car.Drive());
            Assert.AreEqual(100, car.Attack());
            Assert.AreEqual(140, car.Defend());
        }

        [Test]
        public void ShouldReturnRaceCar()
        {
            var baseCar = new BaseCar();
            var car = new RaceCar(baseCar);
            Assert.AreEqual(140, car.Drive());
            Assert.AreEqual(90, car.Attack());
            Assert.AreEqual(90, car.Defend());
        }

        [Test]
        public void ShouldReturnAttackCar()
        {
            var baseCar = new BaseCar();
            var car = new AttackCar(baseCar);
            Assert.AreEqual(90, car.Drive());
            Assert.AreEqual(130, car.Attack());
            Assert.AreEqual(90, car.Defend());
        }

        [Test]
        public void ShouldReturnFullyDecoratedRaceCar()
        {
            var baseCar = new BaseCar();
            var armoredCar = new ArmoredCar(baseCar);
            var armoredCar2 = new ArmoredCar(armoredCar);
            var raceCar = new RaceCar(armoredCar2);
            ICar car = new AttackCar(raceCar);
            Assert.AreEqual(90, car.Drive());
            Assert.AreEqual(120, car.Attack());
            Assert.AreEqual(160, car.Defend());
        }
    }
}