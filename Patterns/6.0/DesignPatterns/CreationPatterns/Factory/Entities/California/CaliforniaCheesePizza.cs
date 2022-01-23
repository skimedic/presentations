// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaCheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
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