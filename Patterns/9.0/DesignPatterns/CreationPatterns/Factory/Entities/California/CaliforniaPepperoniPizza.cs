// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaPepperoniPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.Entities.California;

public class CaliforniaPepperoniPizza : PepperoniPizza
{
    public CaliforniaPepperoniPizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public CaliforniaPepperoniPizza() : this(new CaliforniaIngredientFactory())
    {
        Dough = DoughTypeEnum.None;
    }
}