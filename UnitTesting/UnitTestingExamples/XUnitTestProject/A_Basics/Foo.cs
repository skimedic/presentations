using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    public class Foo
    {
        [Theory]
        [InlineData(3, 1, 4)]
        [InlineData(3, 0, 3)]
        [InlineData(int.MaxValue, 2, 3)]
        public void ShouldReturnASum(
            int addend1,int addend2, int sum)
        {
            var sut = new Calculator();
            var result = sut.Add(addend1, addend2);
            Assert.Equal(sum,result);
        }
    }
}
