// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.A_Simple;
using CreationPatterns.Factory.B_FactoryMethod.Base;
using CreationPatterns.Factory.Entities.NewYork.Factory;

namespace CreationPatterns.Factory.B_FactoryMethod;

public class SimpleNewYorkPizzaStore : SimplePizzaStoreBase
{
    private readonly IPizzaFactory _factory;

    public SimpleNewYorkPizzaStore() : this(new NewYorkPizzaFactory())
    {
    }

    public SimpleNewYorkPizzaStore(IPizzaFactory factory) 
        => _factory = factory;

    public override IPizza CreatePizza(PizzaTypeEnum pizzaType) 
        => _factory.CreatePizza(pizzaType);
}