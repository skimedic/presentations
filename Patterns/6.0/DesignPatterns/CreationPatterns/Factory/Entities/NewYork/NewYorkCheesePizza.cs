// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkCheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.Entities.NewYork;

public class NewYorkCheesePizza : CheesePizza
{
    public NewYorkCheesePizza()
    {
        Dough = DoughTypeEnum.Thin;
    }
}