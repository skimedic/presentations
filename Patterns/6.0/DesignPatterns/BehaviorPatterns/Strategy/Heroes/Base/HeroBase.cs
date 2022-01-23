// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - HeroBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

using BehaviorPatterns.Strategy.Heroes.Interfaces;

namespace BehaviorPatterns.Strategy.Heroes.Base;

public abstract class HeroBase : IHero
{
    private ISuperPower _power;

    protected HeroBase() : this(new RegularJoe())
    {
    }

    protected HeroBase(ISuperPower power)
    {
        _power = power;
    }

    public string DoHeroStuff() => _power.ExercisePower();

    public void ChangeSuperPower(ISuperPower power)
    {
        _power = power;
    }
}