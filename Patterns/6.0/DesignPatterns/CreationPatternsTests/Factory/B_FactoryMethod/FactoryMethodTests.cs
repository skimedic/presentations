// Copyright Information
// =============================
// CreationalPatternsTests - FactoryMethodTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using CreationPatterns.Factory.Entities.NewYork;

namespace CreationPatternsTests.Factory.B_FactoryMethod;

[Collection("CreationPatternsTests")]
public class FactoryMethodTests
{
    [Fact]
    public void ShouldCreateSpecificPizza()
    {
        var pizza = new SimpleNewYorkPizzaStore().OrderPizza(PizzaTypeEnum.Cheese);
        Assert.NotNull(pizza as NewYorkCheesePizza);
        Assert.Equal(DoughTypeEnum.Thin, pizza.Dough);
    }



}