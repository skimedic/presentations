// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - SuperMan.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

using BehaviorPatterns.Strategy.Heroes.Base;

namespace BehaviorPatterns.Strategy.Heroes;

public class SuperMan : HeroBase
{
    public SuperMan() : base(new Fly())
    {
    }
}