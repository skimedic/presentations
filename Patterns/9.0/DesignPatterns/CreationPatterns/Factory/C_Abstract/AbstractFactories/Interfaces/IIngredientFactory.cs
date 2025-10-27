// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - IIngredientFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace CreationPatterns.Factory.C_Abstract.AbstractFactories.Interfaces;

public interface IIngredientFactory
{
    void MakeDough();
    void MakeSauce();
    void MakeCheese();
    void MakeSausage();
    void MakePepperoni();
}