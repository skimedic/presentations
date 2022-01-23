// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.Base;

public class CheesePizza : Pizza
{
    public CheesePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public CheesePizza() : this(new BasicIngredientFactory())
    {
        Toppings = new List<string> { "Cheese" };
    }

    public sealed override void Prepare()
    {
        IngredientFactory.MakeDough();
        IngredientFactory.MakeSauce();
        IngredientFactory.MakeCheese();
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