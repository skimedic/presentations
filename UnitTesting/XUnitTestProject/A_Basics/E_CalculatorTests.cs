#region Copyright

// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - E_CalculatorTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================

#endregion

using Xunit;

namespace XUnitTestProject.A_Basics
{
    [Collection("Calculator")]
    public class E_CalculatorTests
    {
        [Trait("Category", "Calculator")]
        [Theory]
        [InlineData(3, 1, 4)]
        [InlineData(-1, 1, 0)]
        [InlineData(int.MaxValue, int.MaxValue, -2)]
        public void ShouldAddTwoNumbers(int addend1, int addend2, int result)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            int actual;
            actual = sut.Add(addend1, addend2);
            //Assert
            Assert.Equal(result, actual);
        }

        [Trait("Category", "Calculator")]
        [Fact]
        public void ShouldSubtractTwoNumbers()
        {
            var cal = new Calculator();
            //var actual = cal.Subtract(5, 2);
        }
    }
}