// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoSausagePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatterns.Factory.Entities.Chicago;

public class ChicagoSausagePizza : SausagePizza
{
    public ChicagoSausagePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public ChicagoSausagePizza(): this(new ChicagoIngredientFactory())
    {
        Dough = DoughTypeEnum.DeepDish;
    }
}