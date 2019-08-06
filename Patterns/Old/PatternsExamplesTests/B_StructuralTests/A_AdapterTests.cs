// Copyright Information
// =============================
// PatternsExamplesTests - A_AdapterTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System;
using PatternsExamples.B_Structural.A_Adapter;
using Telerik.JustMock;
using NUnit.Framework;

namespace PatternsExamplesTests.B_StructuralTests
{
    [TestFixture]
    public class AdapterTests
    {
        [Test]
        public void ShouldReturnICharacterFromMoose()
        {
            ICharacter bullwinkle = new MooseAdapter(new Moose());
            Assert.AreEqual(10, bullwinkle.Attack());
            Assert.AreEqual(5, bullwinkle.Chase());
            Assert.AreEqual(5, bullwinkle.Flee());
        }

        [Test]
        public void ShouldReturnICharacterFromMooseWithMock()
        {
            IMoose moose = Mock.Create<IMoose>(Behavior.Strict);
            Mock.Arrange(() => moose.Charge()).Returns(10).MustBeCalled();
            Mock.Arrange(() => moose.Run()).Returns(5).MustBeCalled();
            ICharacter bullwinkle = new MooseAdapter(moose);
            //ICharacter bullwinkle = new MooseAdapter(new Moose());
            Assert.AreEqual(10, bullwinkle.Attack());
            Assert.AreEqual(5, bullwinkle.Chase());
            Assert.AreEqual(5, bullwinkle.Flee());
            Mock.Assert(moose);
            Mock.Assert(() => moose.Charge(), Occurs.Exactly(1));
            Mock.Assert(() => moose.Run(), Occurs.Exactly(2));
        }

        [Test]
        public void ShouldReturnICharacterFromFlyingSquirrel()
        {
            ICharacter rocky = new FlyingSquirrelAdapter(new FlyingSquirrel());
            Assert.AreEqual(1, rocky.Attack());
            Assert.AreEqual(20, rocky.Chase());
            Assert.AreEqual(20, rocky.Flee());
        }

        [Test]
        public void ShouldReturnICharacterFromBadGuy()
        {
            ICharacter boris = new BadGuyAdapter(new BadGuy());
            Assert.AreEqual(50, boris.Attack());
            Assert.AreEqual(30, boris.Chase());
            Assert.Throws<Exception>(() => boris.Flee());
        }
    }
}