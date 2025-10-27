// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaCheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.Entities.California;

public class CaliforniaCheesePizza : CheesePizza
{
    public CaliforniaCheesePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public CaliforniaCheesePizza() : this(new CaliforniaIngredientFactory())
    {
        Dough = DoughTypeEnum.None;
    }
}