// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICar.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace StructuralPatterns.Decorator.CarExample.Interfaces;

public interface ICar
{
    int Drive { get; }

    int Attack{ get; }

    int Defend{ get; }
}