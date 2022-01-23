// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.NewYork.Factory;

public class NewYorkPizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new NewYorkCheesePizza(),
            PizzaTypeEnum.Pepperoni => new NewYorkPepperoniPizza(),
            PizzaTypeEnum.Sausage => new NewYorkSausagePizza(),
            _ => null
        };
    }
}