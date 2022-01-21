using CreationPatterns.Factory.A_Simple;

namespace CreationPatterns.Factory.Entities.NewYork.Factory;

public class NewYorkPizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new NewYorkCheesePizza(),
            PizzaTypeEnum.Pepperoni => new NewYorkPepperoniPizza(),
            PizzaTypeEnum.Sausage => new NewYorkSausagePizza(),
            _ => null
        };
    }
}