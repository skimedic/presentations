using BehaviorPatterns.Strategy.Heroes.Base;

namespace BehaviorPatterns.Strategy.Heroes
{
    public class BatMan : HeroBase
    {
        public BatMan() : base(new Fight())
        {
        }
    }
}
