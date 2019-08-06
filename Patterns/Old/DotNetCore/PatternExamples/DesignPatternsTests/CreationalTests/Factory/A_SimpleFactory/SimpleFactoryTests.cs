// Copyright Information
// =============================
// CreationalPatternsTests - SimpleFactoryTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Factory.A_SimpleFactory;
using Xunit;

namespace DesignPatternsTests.CreationalTests.Factory.A_SimpleFactory
{
    [Collection("CreationalPatternsTests")]
    public class SimpleFactoryTests
    {

        [Theory]
        [InlineData(PizzaType.NewYork)]
        public void ShouldCreateDuplicateCodeAndReturnAPizza(PizzaType type)
        {
            var ingredients = new List<string>();
            IPizza pizza = null;
            switch (type)
            {
                case PizzaType.NewYork:
                    pizza = new NewYorkPizza(ingredients);
                    break;
                case PizzaType.Chicago:
                    pizza = new ChicagoPizza(ingredients);
                    break;
                case PizzaType.California:
                    pizza = new CaliforniaPizza(ingredients);
                    break;
            }
            Assert.NotNull(pizza as NewYorkPizza);
        }
        [Fact]
        public void ShouldCreateSpecificPizza()
        {
            var sut = SimplePizzaFactory.CreatePizza(
                PizzaType.NewYork, new List<string>());
            Assert.NotNull(sut as NewYorkPizza);
        }
    }
}
