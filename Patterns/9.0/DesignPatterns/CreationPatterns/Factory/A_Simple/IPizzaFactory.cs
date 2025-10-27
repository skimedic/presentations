// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - IPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.A_Simple;

public interface IPizzaFactory
{
    IPizza CreatePizza(PizzaTypeEnum type);
}