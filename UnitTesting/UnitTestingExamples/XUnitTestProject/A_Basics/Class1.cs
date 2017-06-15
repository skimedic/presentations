using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    [Collection("Calculator")]
    public class Class1
    {
        [Theory]
        [InlineData(3,1,4)]
        [InlineData(-1,1,-2)]
        [InlineData(int.MaxValue,int.MaxValue,int.MinValue)]
        public void ShouldAddTwoNumbers(int addend1, int addend2, int result)
        {
            var sut = new Calculator();
            Assert.Equal(result,sut.Add(addend1,addend2));
        }
    }

    public class Calculator
    {
        public int Add(int addend1, int addend2)
        {
            return addend1 + addend2;
        }
    }
}
