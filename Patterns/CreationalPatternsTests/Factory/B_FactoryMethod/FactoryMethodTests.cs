using System.Collections.Generic;
using CreationalPatterns.Factory;
using CreationalPatterns.Factory.A_SimpleFactory;
using CreationalPatterns.Factory.B_FactoryMethod;
using Xunit;

namespace CreationalPatternsTests.Factory.B_FactoryMethod
{
    [Collection("CreationalPatternsTests")]
    public class FactoryMethodTests
    {
        [Fact]
        public void ShouldCreateSpecificPizza()
        {
            var sut = new NewYorkPizzaStore().OrderPizza(new List<string>());
            Assert.NotNull(sut as NewYorkPizza);
        }

    }
}