// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICar.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Decorator.CarExample.Interfaces;

public interface ICar
{
    int Drive { get; }

    int Attack{ get; }

    int Defend{ get; }
}