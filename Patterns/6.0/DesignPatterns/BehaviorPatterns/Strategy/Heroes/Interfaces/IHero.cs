// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - IHero.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace BehaviorPatterns.Strategy.Heroes.Interfaces;

public interface IHero
{
    string DoHeroStuff();

    void ChangeSuperPower(ISuperPower power);
}