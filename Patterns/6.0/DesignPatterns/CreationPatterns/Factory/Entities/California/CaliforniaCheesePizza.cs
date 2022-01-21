// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - CaliforniaCheesePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.Entities.California;

public class CaliforniaCheesePizza : CheesePizza
{
    public CaliforniaCheesePizza()
    {
        Dough = DoughTypeEnum.None;
    }
}