using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp8_Tests.A_NullableDemosTests
{
    public class NullableTests
    {
        [Fact]
        public void ShouldHandleNullReferenceTypesWhenNull()
        {
            string? sut = null;
            //Use the null coalescing operator
            Assert.Equal('?',sut?[0] ?? '?');
        }

        [Fact]
        public void ShouldHandleNullReferenceTypesWhenNotNull()
        {
            string? sut = "Hello";
            //Use the null forgiving operator if you know the variable is not null
            Assert.Equal(5, sut!.Length);
            //Use the null coalescing operator
            Assert.Equal('H', sut?[0] ?? '?');
        }
    }
}
