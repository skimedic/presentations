// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - PepperoniPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.Base;

public class PepperoniPizza : Pizza
{
    public PepperoniPizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public PepperoniPizza() : this(new BasicIngredientFactory())
    {
        Toppings = new List<string> { "Pepperoni" };
    }

    public sealed override void Prepare()
    {
        IngredientFactory.MakeDough();
        IngredientFactory.MakeSauce();
        IngredientFactory.MakeCheese();
        IngredientFactory.MakePepperoni();
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