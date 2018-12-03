using System;
using WhatsNewInCSharp7.A_LocalFunctions;
using Xunit;

namespace WhatsNewInCSharp7_Tests.A_LocalFunctionTests
{
    public class LocalFunctionTests
    {
        [Fact]
        public void ShouldCalculateWeight()
        {
            var sut = new LocalFunctionExamples();
            var weight = sut.GetWeightForHolloBar(12m, 8m, 20m);
            Assert.Equal(356.01m, weight);
        }
        [Fact]
        public void ShouldThrowWithIteratorOldWay()
        {
            var sut = new LocalFunctionExamples();
            var enumerable = sut.AlphabetSubset3OldWay('1', '2');
            Assert.Throws<ArgumentOutOfRangeException>(() => enumerable.GetEnumerator().MoveNext());
        }
        [Fact]
        public void ShouldThrowWithIteratorFunction()
        {
            var sut = new LocalFunctionExamples();
            Assert.Throws<ArgumentOutOfRangeException>(()=>sut.AlphabetSubset3('1', '2'));
        }
    }
}
