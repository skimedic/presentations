// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoCheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.Chicago;

public class ChicagoCheesePizza : CheesePizza
{
    public ChicagoCheesePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public ChicagoCheesePizza(): this(new ChicagoIngredientFactory())
    {
        Dough = DoughTypeEnum.DeepDish;
    }
}