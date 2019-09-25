using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp8_Tests.B_RangesIndicesTests
{
    public class RangeAndIndicesTests
    {
        [Fact]
        public void ShouldGetRangeOfValuesExplicitly()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            //Endpoint is exclusive
            Range range = 1..4;
            var subNames = names[range];
            Assert.NotEmpty(subNames);
            Assert.Equal(names[1], subNames[0]);
            Assert.Equal(names[2], subNames[1]);
            Assert.Equal(names[3], subNames[2]);
            Assert.Equal(3,subNames.Length);
        }

        [Fact]
        public void ShouldGetRangeOfValuesImplicitly()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            //Endpoint is exclusive
            var subNames = names[1..4];
            Assert.NotEmpty(subNames);
            Assert.Equal(names[1], subNames[0]);
            Assert.Equal(names[2], subNames[1]);
            Assert.Equal(names[3], subNames[2]);
            Assert.Equal(3, subNames.Length);
        }

        [Fact]
        public void ShouldGetRangeOfValuesUsingFromTheEndSyntax()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            //Endpoint is exclusive
            var subNames = names[1..^0];
            Assert.NotEmpty(subNames);
            Assert.Equal(names[1], subNames[0]);
            Assert.Equal(names[2], subNames[1]);
            Assert.Equal(names[3], subNames[2]);
            Assert.Equal(names[4], subNames[3]);
            Assert.Equal(4, subNames.Length);
        }
        [Fact]
        public void ShouldGetRangeOfValuesUsingFromTheEndAndFromTheBeginningSyntax()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            //Endpoint is exclusive
            //Open means from the beginning
            var subNames = names[..^0];
            Assert.NotEmpty(subNames);
            Assert.Equal(names[0], subNames[0]);
            Assert.Equal(names[1], subNames[1]);
            Assert.Equal(names[2], subNames[2]);
            Assert.Equal(names[3], subNames[3]);
            Assert.Equal(names[4], subNames[4]);
            Assert.Equal(5, subNames.Length);
        }

        [Fact]
        public void ShouldGetRangeOfValuesUsingOpenSyntax()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            //Open means from the beginning and/or from the end
            var subNames = names[..];
            Assert.NotEmpty(subNames);
            Assert.Equal(names[0], subNames[0]);
            Assert.Equal(names[1], subNames[1]);
            Assert.Equal(names[2], subNames[2]);
            Assert.Equal(names[3], subNames[3]);
            Assert.Equal(names[4], subNames[4]);
            Assert.Equal(5, subNames.Length);
        }

        [Fact]
        public void ShouldGetRangeOfValuesUsingIndexTypes()
        {
            string[] names = { "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato" };
            //Open means from the beginning and/or from the end
            Index i1 = 1;
            Index i2 = ^1;
            Range r = 1..2;
            var subNames = names[i1..i2];
            Assert.NotEmpty(subNames);
            Assert.Equal(names[1], subNames[0]);
            Assert.Equal(names[2], subNames[1]);
            Assert.Equal(names[3], subNames[2]);
            Assert.Equal(3, subNames.Length);
        }
    }
}
