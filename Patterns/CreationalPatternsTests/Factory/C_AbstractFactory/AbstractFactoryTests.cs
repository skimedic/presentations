using System.Collections.Generic;
using CreationalPatterns.Factory;
using CreationalPatterns.Factory.C_AbstractFactory;
using Xunit;

namespace CreationalPatternsTests.Factory.C_AbstractFactory
{
    [Collection("CreationalPatternsTests")]
    public class AbstractFactoryTests
    {
        [Fact]
        public void ShouldUserAnAbstractFactoryToCreatePizza()
        {
            var sut = new NewYorkPizzaStoreWithAbstractFactory(new ChicagoPizzaFactory()).OrderPizza(new List<string>());
            Assert.NotNull(sut as ChicagoPizza);
        }

    }
}