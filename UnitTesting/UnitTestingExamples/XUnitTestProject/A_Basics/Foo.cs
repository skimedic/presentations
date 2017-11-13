using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    public class Foo
    {
        [Theory]
        [InlineData(2, 3, 5)]
        //[InlineData(Int16.MaxValue, 3, 5)]
        public void ShouldAddTwoNumbers(int addend1, int addend2, int sum)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var actual = calculator.Add(addend1,addend2);
            //Assert
            Assert.Equal(sum,actual);
        }

        [Fact]
        public void ShouldSubtractTwoNumbers()
        {
            var cal = new Calculator();
            var actual = cal.Subtract(5, 2);
        }
    }
}
