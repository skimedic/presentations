// Copyright Information
// =============================
// CreationalPatternsTests - SimpleFactoryTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using CreationPatterns.Factory.Entities.Base;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace CreationPatternsTests.Factory.A_SimpleFactory;

[Collection("CreationPatternsTests")]
public class SimpleFactoryTests
{

    [Theory]
    [InlineData(PizzaTypeEnum.Cheese,typeof(CheesePizza))]
    [InlineData(PizzaTypeEnum.Pepperoni,typeof(PepperoniPizza))]
    [InlineData(PizzaTypeEnum.Sausage,typeof(SausagePizza))]
    public void ShouldCreateSpecificPizza(PizzaTypeEnum pizzatype, Type instanceType)
    {
        var pizza = new SimplePizzaFactory().CreatePizza(pizzatype);
        Assert.Equal(instanceType, pizza.GetType());
    }
}