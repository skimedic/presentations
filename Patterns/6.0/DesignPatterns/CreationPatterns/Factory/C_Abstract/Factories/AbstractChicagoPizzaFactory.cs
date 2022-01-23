// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - AbstractChicagoPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract.Factories;

public class AbstractChicagoPizzaFactory : IPizzaFactory
{
    private readonly IIngredientFactory _ingredientFactory;

    public AbstractChicagoPizzaFactory() : this(new ChicagoIngredientFactory())
    {
    }

    public AbstractChicagoPizzaFactory(IIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }


    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new ChicagoCheesePizza(_ingredientFactory),
            PizzaTypeEnum.Pepperoni => new ChicagoPepperoniPizza(_ingredientFactory),
            PizzaTypeEnum.Sausage => new ChicagoSausagePizza(_ingredientFactory),
            _ => null
        };
    }
}