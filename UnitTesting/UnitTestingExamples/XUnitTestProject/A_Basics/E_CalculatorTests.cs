// Copyright Information
// =============================
// XUnitTestProject - E_CalculatorTests.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    [Collection("Calculator")]
    public class E_CalculatorTests
    {
        [Theory]
        [InlineData(3,1,4)]
        [InlineData(-1,1,0)]
        [InlineData(int.MaxValue,int.MaxValue,-2)]
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
