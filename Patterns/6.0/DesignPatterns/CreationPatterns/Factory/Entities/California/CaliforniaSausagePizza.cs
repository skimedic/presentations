// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaSausagePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.California;

public class CaliforniaSausagePizza : SausagePizza
{
    public CaliforniaSausagePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public CaliforniaSausagePizza() : this(new CaliforniaIngredientFactory())
    {
        Dough = DoughTypeEnum.None;
    }
}