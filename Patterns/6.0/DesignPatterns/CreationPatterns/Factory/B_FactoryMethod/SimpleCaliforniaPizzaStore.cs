using CreationPatterns.Factory.A_Simple;
using CreationPatterns.Factory.B_FactoryMethod.Base;
using CreationPatterns.Factory.Entities.California.Factory;

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

