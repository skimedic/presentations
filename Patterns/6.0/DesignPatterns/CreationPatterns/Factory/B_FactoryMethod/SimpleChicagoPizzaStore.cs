// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - SimpleChicagoPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

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