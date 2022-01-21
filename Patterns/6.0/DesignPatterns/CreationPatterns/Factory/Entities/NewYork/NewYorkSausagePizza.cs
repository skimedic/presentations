// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkSausagePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.Entities.NewYork;

public class NewYorkSausagePizza : SausagePizza
{
    public NewYorkSausagePizza()
    {
        Dough = DoughTypeEnum.Thin;
    }
}