// Copyright Information
// =============================
// CreationalPatternsTests - AbstractFactoryTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Factory.C_AbstractFactory;
using Xunit;

namespace DesignPatternsTests.CreationalTests.Factory.C_AbstractFactory
{
    [Collection("CreationalPatternsTests")]
    public class AbstractFactoryTests
    {
        [Fact]
        public void ShouldUserAnAbstractFactoryToCreatePizza()
        {
            var sut = new NewYorkPizzaStoreWithAbstractFactory(
                new ChicagoPizzaFactory()).OrderPizza(new List<string>());
            Assert.NotNull(sut as ChicagoPizza);
        }

    }
}