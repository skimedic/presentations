// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - BatMan.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

using BehaviorPatterns.Strategy.Heroes.Base;

namespace BehaviorPatterns.Strategy.Heroes;

public class BatMan : HeroBase
{
    public BatMan() : base(new Fight())
    {
    }
}