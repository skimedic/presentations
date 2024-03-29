﻿// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - IPizza.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace CreationPatterns.Factory.Entities.Interfaces;

public interface IPizza
{
    IList<string> Toppings { get; init; }
    DoughTypeEnum Dough { get; init; }
    public void Prepare();
    public void Bake();
    public void Cut();
    public void Box();
}