// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - SimpleNewYorkPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

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