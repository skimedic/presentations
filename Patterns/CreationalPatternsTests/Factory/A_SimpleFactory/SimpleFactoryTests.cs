// Copyright Information
// =============================
// CreationalPatternsTests - SimpleFactoryTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreationalPatterns.Factory;
using CreationalPatterns.Factory.A_SimpleFactory;
using Xunit;

namespace CreationalPatternsTests.Factory.A_SimpleFactory
{
    [Collection("CreationalPatternsTests")]
    public class SimpleFactoryTests
    {
        [Fact]
        public void ShouldCreateSpecificPizza()
        {
            var sut = SimplePizzaFactory.CreatePizza(PizzaType.NewYork, new List<string>());
            Assert.NotNull(sut as NewYorkPizza);
        }
    }
}
