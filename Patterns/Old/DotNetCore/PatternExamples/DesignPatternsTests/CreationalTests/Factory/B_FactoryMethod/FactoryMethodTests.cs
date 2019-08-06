// Copyright Information
// =============================
// CreationalPatternsTests - FactoryMethodTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Factory.B_FactoryMethod;
using Xunit;

namespace DesignPatternsTests.CreationalTests.Factory.B_FactoryMethod
{
    [Collection("CreationalPatternsTests")]
    public class FactoryMethodTests
    {
        [Fact]
        public void ShouldCreateSpecificPizza()
        {
            var sut = new NewYorkPizzaStore()
                .OrderPizza(new List<string>());
            Assert.NotNull(sut as NewYorkPizza);
        }

    }
}