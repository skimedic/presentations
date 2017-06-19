// Copyright Information
// =============================
// PatternsExamplesTests - D_AbstractFactoryTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using PatternsExamples.A_Creational.C_FactoryMethod;
using PatternsExamples.A_Creational.D_AbstractFactory;
using NUnit.Framework;

namespace PatternsExamplesTests.A_CreationalTests
{
    [TestFixture]
    public class AbstractFactoryTests
    {
        [Test]
        public void ShouldReturnThinCrustPizzaFromNYStore()
        {
            IPizzaStore store = new NewYorkPizzaStore();
            var pizza = store.OrderLocalizedPizza(PizzaType.Pepperoni);
            Assert.AreEqual(DoughType.Thin, pizza.Dough);
            Assert.AreEqual("Red", pizza.SauceType);
            Assert.AreEqual("Spicy", pizza.Seasonings);
        }

        [Test]
        public void ShouldReturnAPizzaFromDefaultStore()
        {
            IPizzaStore store = new BasePizzaStore();
            var pizza = store.OrderLocalizedPizza(PizzaType.Cheese);
            Assert.AreEqual(DoughType.None, pizza.Dough);
            Assert.AreEqual("Bland", pizza.SauceType);
            Assert.AreEqual("None", pizza.Seasonings);
        }

        [Test]
        public void ShouldReturnDeepDishPizzaFromChicagoStore()
        {
            IPizzaStore store = new ChicagoPizzaStore();
            var pizza = store.OrderLocalizedPizza(PizzaType.Sausage);
            Assert.AreEqual(DoughType.DeepDish, pizza.Dough);
            Assert.AreEqual("TomatoBasil", pizza.SauceType);
            Assert.AreEqual("Mild", pizza.Seasonings);
        }
    }
}