#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - B_Theories.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject.A_Basics
{
    public class B_Theories
    {
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(-1, -3, 2)]
        [InlineData(100, -3, 97)]
        public void InlineDataTheory(int expected, int addend1, int addend2)
        {
            Assert.Equal(expected, addend1 + addend2);
        }

        [Theory]
        [MemberData(nameof(TestData))] //NOTE: PropertyData is obsoleted
        public void MemberDataTheory(int expected, int addend1, int addend2)
        {
            Assert.Equal(expected, addend1 + addend2);
        }

        public static IEnumerable<object[]> TestData
            => new[]
            {
                new object[] {5, 3, 2},

                new object[] {-1, -3, 2}
            };


        [Theory]
        [ClassData(typeof(TestDataClass))]
        public void ClassDataTheory(int expected, int addend1, int addend2)
        {
            Assert.Equal(expected, addend1 + addend2);
        }
    }

    public class TestDataClass : IEnumerable<object[]>

    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {5, 3, 2},

            new object[] {-1, -3, 2}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}