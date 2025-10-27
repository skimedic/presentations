// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkPepperoniPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.Entities.NewYork;

public class NewYorkPepperoniPizza : PepperoniPizza
{
    public NewYorkPepperoniPizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public NewYorkPepperoniPizza(): this(new NewYorkIngredientFactory())
    {
        Dough = DoughTypeEnum.Thin;
    }
}