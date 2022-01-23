// Copyright Information
// ==================================
// DesignPatterns - CreationPatternsTests - FactoryMethodTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

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