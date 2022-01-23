// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - Pizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.Entities.Base;

public abstract class Pizza : IPizza
{
    protected IIngredientFactory IngredientFactory;

    protected Pizza(IIngredientFactory ingredientFactory)
    {
        IngredientFactory = ingredientFactory;
    }

    public IList<string> Toppings { get; init; }
    public DoughTypeEnum Dough { get; init; }
    public abstract void Prepare();

    public abstract void Bake();

    public abstract void Cut();

    public abstract void Box();
}