// Copyright Information
// =============================
// PatternsExamplesTests - C_FactoryMethodTests.cs
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
    public class FactoryMethodTests
    {
        [Test]
        public void ShouldReturnThinCrustPizzaFromNYStore()
        {
            var store = new NewYorkPizzaStore();
            IPizza pizza = store.OrderLocalizedPizza(PizzaType.Pepperoni);
            Assert.AreEqual(DoughType.Thin, pizza.Dough);
        }

        [Test]
        public void ShouldReturnSausageDefaultPizza()
        {
            var store = new BasePizzaStore();
            IPizza pizza = store.OrderLocalizedPizza(PizzaType.Cheese);
            Assert.AreEqual(DoughType.None, pizza.Dough);
        }

        [Test]
        public void ShouldReturnDeepDishPizzaFromChicagoStore()
        {
            var store = new ChicagoPizzaStore();
            IPizza pizza = store.OrderLocalizedPizza(PizzaType.Pepperoni);
            Assert.AreEqual(DoughType.DeepDish, pizza.Dough);
        }
    }
}