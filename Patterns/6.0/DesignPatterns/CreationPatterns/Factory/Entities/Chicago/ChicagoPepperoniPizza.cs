// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoPepperoniPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.Chicago;

public class ChicagoPepperoniPizza : PepperoniPizza
{
    public ChicagoPepperoniPizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public ChicagoPepperoniPizza(): this(new ChicagoIngredientFactory())
    {
        Dough = DoughTypeEnum.DeepDish;
    }
}