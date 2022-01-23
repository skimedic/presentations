// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - AttackCar.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Decorator.CarExample;

public class AttackCar : ICar
{
    private readonly ICar _decoratedCar;

    public AttackCar(ICar decoratedCar)
    {
        _decoratedCar = decoratedCar;
    }

    public int Drive() => _decoratedCar.Drive() - 10;

    public int Attack() => _decoratedCar.Attack() + 30;

    public int Defend() => _decoratedCar.Defend() - 10;
}