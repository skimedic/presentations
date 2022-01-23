// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - SausagePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.Base;

public class SausagePizza : Pizza
{
    public SausagePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public SausagePizza() : this(new BasicIngredientFactory())
    {
        Toppings = new List<string> { "Sausage" };
    }

    public sealed override void Prepare()
    {
        IngredientFactory.MakeDough();
        IngredientFactory.MakeSauce();
        IngredientFactory.MakeCheese();
        IngredientFactory.MakeSausage();
    }

    public override void Bake()
    {
        //Bake it
    }

    public override void Cut()
    {
        //Slice it
    }

    public override void Box()
    {
        //Box it
    }
}