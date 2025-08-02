// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BaseCar.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Decorator.CarExample.Base;

public class BaseCar : ICar
{
    public int Drive => 100;

    public int Attack => 100;

    public int Defend => 100;
}