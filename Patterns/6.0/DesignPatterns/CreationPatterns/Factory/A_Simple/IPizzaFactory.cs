// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - IPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.A_Simple;

public interface IPizzaFactory
{
    IPizza CreatePizza(PizzaTypeEnum type);
}