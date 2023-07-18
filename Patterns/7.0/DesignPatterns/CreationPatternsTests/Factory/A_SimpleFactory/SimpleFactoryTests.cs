// Copyright Information
// ==================================
// DesignPatterns - CreationPatternsTests - SimpleFactoryTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatternsTests.Factory.A_SimpleFactory;

[Collection("CreationPatternsTests")]
public class SimpleFactoryTests
{

    [Theory]
    [InlineData(PizzaTypeEnum.Cheese,typeof(CheesePizza))]
    [InlineData(PizzaTypeEnum.Pepperoni,typeof(PepperoniPizza))]
    [InlineData(PizzaTypeEnum.Sausage,typeof(SausagePizza))]
    public void ShouldCreateSpecificPizza(PizzaTypeEnum pizzaType, Type instanceType)
    {
        var pizza = new SimplePizzaFactory().CreatePizza(pizzaType);
        Assert.Equal(instanceType, pizza.GetType());
    }
}