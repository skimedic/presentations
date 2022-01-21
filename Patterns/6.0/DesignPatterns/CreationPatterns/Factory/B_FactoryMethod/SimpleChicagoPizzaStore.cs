// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.A_Simple;
using CreationPatterns.Factory.B_FactoryMethod.Base;
using CreationPatterns.Factory.Entities.California.Factory;
using CreationPatterns.Factory.Entities.Chicago.Factory;

namespace CreationPatterns.Factory.B_FactoryMethod;

public class SimpleChicagoPizzaStore : SimplePizzaStoreBase
{
    private readonly IPizzaFactory _factory;

    public SimpleChicagoPizzaStore() : this(new ChicagoPizzaFactory())
    {
    }

    public SimpleChicagoPizzaStore(IPizzaFactory factory) 
        => _factory = factory;

    public override IPizza CreatePizza(PizzaTypeEnum pizzaType) 
        => _factory.CreatePizza(pizzaType);
}