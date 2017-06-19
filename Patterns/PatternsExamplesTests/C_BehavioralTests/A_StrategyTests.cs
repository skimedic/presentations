// Copyright Information
// =============================
// PatternsExamplesTests - A_StrategyTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using PatternsExamples.A_Creational.A_Singleton;
using NUnit.Framework;
using PatternsExamples.C_Behavioral.Strategy;

namespace PatternsExamplesTests.C_BehavioralTests
{
    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void ShouldReturnSuperPower()
        {
            IHero spiderMan = new SpiderMan();
            Assert.AreEqual(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            IHero superMan = new SuperMan();
            Assert.AreEqual(new Fly().ExercisePower(), superMan.DoHeroStuff());
            IHero batMan = new BatMan();
            Assert.AreEqual(new Fight().ExercisePower(), batMan.DoHeroStuff());
        }

        [Test]
        public void ShouldReturnChangedSuperPower()
        {
            IHero spiderMan = new SpiderMan();
            Assert.AreEqual(new WeaveWeb().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(new Fight());
            Assert.AreEqual(new Fight().ExercisePower(), spiderMan.DoHeroStuff());
            spiderMan.ChangeSuperPower(IOCContainer.Instance.GetSuperPower());
            Assert.AreEqual(new Fly().ExercisePower(), spiderMan.DoHeroStuff());
            //TODO: Add Power Factory
        }
    }
}