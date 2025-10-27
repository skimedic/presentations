// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - SpiderMan.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

using BehaviorPatterns.Strategy.Heroes.Base;

namespace BehaviorPatterns.Strategy.Heroes;

public class SpiderMan : HeroBase
{
    public SpiderMan() : base(new WeaveWeb())
    {
    }
}