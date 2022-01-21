using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.A_Simple;

public class SimplePizzaFactory : IPizzaFactory
{
    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new CheesePizza(),
            PizzaTypeEnum.Pepperoni => new PepperoniPizza(),
            PizzaTypeEnum.Sausage => new SausagePizza(),
            _ => null
        };
    }
    //public IPizza CreatePizza(PizzaStyleEnum type, IList<string> ingredients)
    //{
    //    return type switch
    //    {
    //        PizzaStyleEnum.NewYork => new NewYorkPizza(ingredients),
    //        PizzaStyleEnum.Chicago => new ChicagoPizza(ingredients),
    //        PizzaStyleEnum.California => new CaliforniaPizza(ingredients),
    //        _ => null
    //    };
    //}
}