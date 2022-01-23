// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - BasicIngredientFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.C_Abstract.AbstractFactories;

public class BasicIngredientFactory : IIngredientFactory
{
    public virtual void MakeDough()
    {

    }

    public virtual void MakeSauce()
    {
    }

    public virtual void MakeCheese()
    {
    }

    public virtual void MakeSausage()
    {
    }

    public virtual void MakePepperoni()
    {
    }
}