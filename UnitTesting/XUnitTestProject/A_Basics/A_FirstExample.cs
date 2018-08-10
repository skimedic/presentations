#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - A_FirstExample.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using Xunit;

namespace XUnitTestProject.A_Basics
{
    public class A_FirstExample
    {
        [Fact]
        public void FirstFact()
        {
            Assert.Equal(5,3+2);
        }

        [Theory]
        [InlineData(5,3,2)]
        [InlineData(7,3,4)]
        [InlineData(-1,-3,2)]
        public void FirstTheory(int expected, int addend1, int addend2)
        {
            Assert.Equal(expected,addend1+addend2);
        }
        [Fact(DisplayName = "Ignored Test - Custom Display Name", Skip="this can be anything")]
        public void ThisIsIgnored()
        {

        }

    }
}
