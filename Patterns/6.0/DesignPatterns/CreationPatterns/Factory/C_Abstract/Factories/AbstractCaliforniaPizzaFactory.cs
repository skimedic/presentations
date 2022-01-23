// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - AbstractCaliforniaPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract.Factories;

public class AbstractCaliforniaPizzaFactory : IPizzaFactory
{
    private readonly IIngredientFactory _ingredientFactory;

    public AbstractCaliforniaPizzaFactory() : this(new CaliforniaIngredientFactory())
    {
    }

    public AbstractCaliforniaPizzaFactory(IIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }


    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new CaliforniaCheesePizza(_ingredientFactory),
            PizzaTypeEnum.Pepperoni => new CaliforniaPepperoniPizza(_ingredientFactory),
            PizzaTypeEnum.Sausage => new CaliforniaSausagePizza(_ingredientFactory),
            _ => null
        };
    }
}