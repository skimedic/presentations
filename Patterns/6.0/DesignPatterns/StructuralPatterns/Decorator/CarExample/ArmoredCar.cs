// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ArmoredCar.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Decorator.CarExample;

public class ArmoredCar : ICar
{
    private readonly ICar _decoratedCar;

    public ArmoredCar(ICar decoratedCar)
    {
        _decoratedCar = decoratedCar;
    }

    public int Drive() => _decoratedCar.Drive() - 20;

    public int Attack() => _decoratedCar.Attack();

    public int Defend() => _decoratedCar.Defend() + 40;
}