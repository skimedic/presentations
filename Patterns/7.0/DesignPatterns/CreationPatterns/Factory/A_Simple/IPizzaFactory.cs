// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - IPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatterns.Factory.A_Simple;

public interface IPizzaFactory
{
    IPizza CreatePizza(PizzaTypeEnum type);
}