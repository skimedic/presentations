// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - SpiderMan.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

using BehaviorPatterns.Strategy.Heroes.Base;

namespace BehaviorPatterns.Strategy.Heroes;

public class SpiderMan : HeroBase
{
    public SpiderMan() : base(new WeaveWeb())
    {
    }
}