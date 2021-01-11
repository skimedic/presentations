using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AutoLot.Dal.Tests
{
    public class SampleTests
    {
        [Fact]
        public void SimpleFactTest()
        {
            Assert.Equal(5,3+2);
        }
        [Theory]
        [InlineData(3,2,5)]
        [InlineData(1,-1,0)]
        public void SimpleTheoryTest(int addend1, int addend2, int expectedResult)
        {
            Assert.Equal(expectedResult,addend1+addend2);
        }
    }
}
