using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp73_Tests.B_EnhancementsTests
{
    public class A_TuplesImprovementsTests
    {
        [Fact]
        public void ShouldTestTupleForEquality()
        {
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            Assert.Equal(left,right); 
        }
        [Fact]
        public void ShouldPerformLiftedConversionsWithNullableTypes()
        {
            var left = (a: 5, b: 10);
            (int a, int b)? nullableTuple = (5,10);
            Assert.Equal(left, nullableTuple);
            (int? a, int? b) nullableMembers = (5, 10);
            Assert.Equal(left, nullableMembers);
        }

        [Fact]
        public void ShouldPerformDataTypeConversion()
        {
            var left = (a: 5, b: 10);
            (long a, long b) longTuple = (5, 10);
            Assert.Equal(left, longTuple);

            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            //This is a compile failure since XUnit doesn't support this feature from 7.3
            //Assert.Equal(longFirst,longSecond);
            Assert.True(longFirst==longSecond);
        }
        [Fact]
        public void ShouldIgnoreVariableNameDueToItemXSyntax()
        {
            (int a, string b) pair = (1, "Hello");
            (int z, string y) another = (1, "Hello");
            Assert.Equal(pair,another);
            Assert.Equal(pair,(z: 1, y: "Hello")); // warning: literal contains different member names
        }

    }
}
