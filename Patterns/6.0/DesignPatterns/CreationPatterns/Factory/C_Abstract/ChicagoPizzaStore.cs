// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract;

public class ChicagoPizzaStore : SimplePizzaStoreBase
{
    private readonly IPizzaFactory _factory;


    public ChicagoPizzaStore() : this(new AbstractChicagoPizzaFactory(new ChicagoIngredientFactory()))
    {
    }

    public ChicagoPizzaStore(IPizzaFactory factory)
    {
        _factory = factory;
    }

    public override IPizza CreatePizza(PizzaTypeEnum pizzaType) 
        => _factory.CreatePizza(pizzaType);
}