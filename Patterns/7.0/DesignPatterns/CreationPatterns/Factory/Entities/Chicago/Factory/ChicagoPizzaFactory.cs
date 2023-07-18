// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatterns.Factory.Entities.Chicago.Factory;

public class ChicagoPizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new ChicagoCheesePizza(),
            PizzaTypeEnum.Pepperoni => new ChicagoPepperoniPizza(),
            PizzaTypeEnum.Sausage => new ChicagoSausagePizza(),
            _ => null
        };
    }
}