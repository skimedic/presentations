// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkPizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract;

public class NewYorkPizzaStore : SimplePizzaStoreBase
{
    private readonly IPizzaFactory _factory;


    public NewYorkPizzaStore() : this(new AbstractNewYorkPizzaFactory(new NewYorkIngredientFactory()))
    {
    }

    public NewYorkPizzaStore(IPizzaFactory factory)
    {
        _factory = factory;
    }

    public override IPizza CreatePizza(PizzaTypeEnum pizzaType) 
        => _factory.CreatePizza(pizzaType);
}