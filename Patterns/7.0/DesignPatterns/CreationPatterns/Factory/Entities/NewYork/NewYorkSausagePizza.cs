﻿// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - NewYorkSausagePizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatterns.Factory.Entities.NewYork;

public class NewYorkSausagePizza : SausagePizza
{
    public NewYorkSausagePizza(IIngredientFactory ingredientFactory) : base(ingredientFactory)
    {
    }

    public NewYorkSausagePizza(): this(new NewYorkIngredientFactory())
    {
        Dough = DoughTypeEnum.Thin;
    }
}