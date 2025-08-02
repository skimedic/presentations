﻿// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
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