// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkPepperoniPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

using CreationPatterns.Factory.Entities.Base;

namespace CreationPatterns.Factory.Entities.NewYork;

public class NewYorkPepperoniPizza : PepperoniPizza
{
    public NewYorkPepperoniPizza()
    {
        Dough = DoughTypeEnum.Thin;
    }
}