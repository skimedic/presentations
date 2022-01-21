// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - ChicagoSausagePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.Entities.Chicago;

public class ChicagoSausagePizza : SausagePizza
{
    public ChicagoSausagePizza()
    {
        Dough = DoughTypeEnum.DeepDish;
    }
}