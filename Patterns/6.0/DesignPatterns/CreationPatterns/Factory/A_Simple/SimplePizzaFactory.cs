// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - SimplePizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.A_Simple;

public class SimplePizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new CheesePizza(),
            PizzaTypeEnum.Pepperoni => new PepperoniPizza(),
            PizzaTypeEnum.Sausage => new SausagePizza(),
            _ => null
        };
    }
}