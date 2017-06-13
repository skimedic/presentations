#region copyright
// Copyright Information
// ==============================
// PatternsExamplesTests - A_StrategyTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using BehavioralPatterns.Strategy;
using Xunit;

namespace BehavioralPatternsTests.Strategy
{
    [Collection("StategyTests")]
    public class StrategyTests
    {
        [Fact]
        public void ShouldReturnSuperPower()
        {
            IHero spiderMan = new SpiderMan();
            Assert.Equal(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            IHero superMan = new SuperMan();
            Assert.Equal(new Fly().ExercisePower(), superMan.DoHeroStuff());
            IHero batMan = new BatMan();
            Assert.Equal(new Fight().ExercisePower(), batMan.DoHeroStuff());
        }

        [Fact]
        public void ShouldReturnChangedSuperPower()
        {
            //Consider using IOC container here?
            IHero spiderMan = new SpiderMan();
            Assert.Equal(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(new Fight());
            Assert.Equal(new Fight().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(new Fly());
            Assert.Equal(new Fly().ExercisePower(), spiderMan.DoHeroStuff());
        }
    }
}