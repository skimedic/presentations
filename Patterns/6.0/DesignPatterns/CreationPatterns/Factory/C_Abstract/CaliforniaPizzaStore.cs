// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract;

public class CaliforniaPizzaStore : SimplePizzaStoreBase
{
    private readonly IPizzaFactory _factory;

    public CaliforniaPizzaStore() : this(new AbstractCaliforniaPizzaFactory(new CaliforniaIngredientFactory()))
    {
    }

    public CaliforniaPizzaStore(IPizzaFactory factory)
    {
        _factory = factory;
    }

    public override IPizza CreatePizza(PizzaTypeEnum pizzaType) 
        => _factory.CreatePizza(pizzaType);
}

