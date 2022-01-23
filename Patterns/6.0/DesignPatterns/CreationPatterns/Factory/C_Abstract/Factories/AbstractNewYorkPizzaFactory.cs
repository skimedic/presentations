// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - AbstractNewYorkPizzaFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract.Factories;

public class AbstractNewYorkPizzaFactory : IPizzaFactory
{
    private readonly IIngredientFactory _ingredientFactory;

    public AbstractNewYorkPizzaFactory() : this(new NewYorkIngredientFactory())
    {
    }

    public AbstractNewYorkPizzaFactory(IIngredientFactory ingredientFactory)
    {
        _ingredientFactory = ingredientFactory;
    }

    public IPizza CreatePizza(PizzaTypeEnum type)
    {
        return type switch
        {
            PizzaTypeEnum.Cheese => new NewYorkCheesePizza(_ingredientFactory),
            PizzaTypeEnum.Pepperoni => new NewYorkPepperoniPizza(_ingredientFactory),
            PizzaTypeEnum.Sausage => new NewYorkSausagePizza(_ingredientFactory),
            _ => null
        };
    }
}