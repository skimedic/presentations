#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - C_CollectionFixtures.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject.B_SharedContexts
{
    [CollectionDefinition("Custom Context Collection")]
    public class MyTestCollection : ICollectionFixture<B_ClassFixtures>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Custom Context Collection")]
    public class B1_CollectionFixtureTestsA
    {
        B_ClassFixtures _fixture;

        public B1_CollectionFixtureTestsA(B_ClassFixtures fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void ThisIsATest()
        {
            Assert.Equal((string)"Skimedic", (string)_fixture.Name);
            Assert.Equal(1, _fixture.InstanceCount);
        }

        [Fact]
        public void ThisIsAnotherTest()
        {
            Assert.Equal((string)"Skimedic", (string)_fixture.Name);
            Assert.Equal(1, _fixture.InstanceCount);
        }
    }

    [Collection("Custom Context Collection")]
    public class B1_CollectionFixtureTestsB
    {
        B_ClassFixtures _fixture;
        public B1_CollectionFixtureTestsB(B_ClassFixtures fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public void ThisIsATest()
        {
            Assert.Equal((string)"Skimedic", (string)_fixture.Name);
            Assert.Equal(1, _fixture.InstanceCount);
        }

        [Fact]
        public void ThisIsAnotherTest()
        {
            Assert.Equal((string)"Skimedic", (string)_fixture.Name);
            Assert.Equal(1, _fixture.InstanceCount);
        }
    }

}
