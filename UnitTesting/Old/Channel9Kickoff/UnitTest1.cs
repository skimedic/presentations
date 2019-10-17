using System;
using Xunit;

namespace Channel9Kickoff
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(5,10,15)]
        public void Should_Add_Two_Numbers(int? addend1, int addend2, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(addend1, addend2);
            //Assert
            Assert.Equal(expected,result);
        }
        [Theory]
        [InlineData(null,10)]
        public void Should_Not_Add_Nulls(int? addend1, int addend2)
        {
            //Arrange
            var sut = new Calculator();
            Assert.Throws<ArgumentNullException>(()=>sut.Add(addend1, addend2));
        }

    }

    public class Calculator
    {
        public int Add(int? addend1, int? addend2)
        {
            if (!addend1.HasValue || !addend2.HasValue)
            {
                throw new ArgumentNullException();
            }
            return addend1.Value + addend2.Value;
        }
    }
}
