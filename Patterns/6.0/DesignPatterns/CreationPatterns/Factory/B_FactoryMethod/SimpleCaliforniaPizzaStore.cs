// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - SimpleCaliforniaPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.B_FactoryMethod;

public class SimpleCaliforniaPizzaStore : SimplePizzaStoreBase
{
    private readonly IPizzaFactory _factory;

    public SimpleCaliforniaPizzaStore() : this(new CaliforniaPizzaFactory())
    {
    }

    public SimpleCaliforniaPizzaStore(IPizzaFactory factory) 
        => _factory = factory;

    public override IPizza CreatePizza(PizzaTypeEnum pizzaType) 
        => _factory.CreatePizza(pizzaType);
}

