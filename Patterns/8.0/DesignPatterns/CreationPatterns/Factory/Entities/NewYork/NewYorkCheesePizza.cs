// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkCheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.Entities.NewYork;

public class NewYorkCheesePizza : CheesePizza
{
    public NewYorkCheesePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public NewYorkCheesePizza(): this(new NewYorkIngredientFactory())
    {
        Dough = DoughTypeEnum.Thin;
    }
}