using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreationalPatterns.Prototype;
using Xunit;

namespace CreationalPatternsTests.Prototype
{
    [Collection("CreationalPatternsTests")]
    public class PrototypeTests
    {
        [Fact]
        public void ShouldCreateAnotherFlyingMonster()
        {
            var sut = new FlyingMonster(true,false,true);
            var newMonster = sut.Clone();
            Assert.Equal(sut.CanFly,newMonster.CanFly);
            Assert.Equal(sut.CanSwim,newMonster.CanSwim);
            Assert.Equal(sut.CanSwim,newMonster.CanSwim);
            Assert.NotSame(sut,newMonster);
        }
    }
}
