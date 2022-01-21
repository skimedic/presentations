// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.Entities.Chicago;

public class ChicagoCheesePizza : CheesePizza
{
    public ChicagoCheesePizza()
    {
        Dough = DoughTypeEnum.DeepDish;
    }
}