﻿// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.Entities.California.Factory;

public class CaliforniaPizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new CaliforniaCheesePizza(),
            PizzaTypeEnum.Pepperoni => new CaliforniaPepperoniPizza(),
            PizzaTypeEnum.Sausage => new CaliforniaSausagePizza(),
            _ => null
        };
    }
}