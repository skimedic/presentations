// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

namespace CreationPatterns.Factory.Entities.Base;

public class CheesePizza : IPizza
{
    public CheesePizza()
    {
        Toppings = new List<string> { "Cheese" };
    }

    public IList<string> Toppings { get; init; }
    public DoughTypeEnum Dough { get; init; }
    public virtual void Prepare()
    {
        //Do some prep
    }

    public virtual void Bake()
    {
        //Bake it
    }

    public virtual void Cut()
    {
        //Slice it
    }

    public virtual void Box()
    {
        //Box it
    }
}