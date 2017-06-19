// Copyright Information
// =============================
// PatternsExamplesTests - B_CommandTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using NUnit.Framework;
using PatternsExamples.C_Behavioral.Commands;

namespace PatternsExamplesTests.C_BehavioralTests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void ShouldTurnTheLightOnAndOff()
        {
            var light = new Light();
            var c = new Controller();
            c.DemoCommands[0] = new LightCommand(light);
            Assert.IsFalse(light.LightIsOn);
            c.DemoCommands[0].Execute();
            Assert.IsTrue(light.LightIsOn);
            c.DemoCommands[0].Execute();
            Assert.IsFalse(light.LightIsOn);
        }
    }
}