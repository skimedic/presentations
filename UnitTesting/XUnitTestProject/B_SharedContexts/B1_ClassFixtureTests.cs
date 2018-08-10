#region Copyright
// Copyright Information
// ==================================
// UnitTesting - XUnitTestProject - B1_ClassFixtureTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 08/09/2018
// See License.txt for more information
// ==================================
#endregion
using System;
using Xunit;

namespace XUnitTestProject.B_SharedContexts
{
    public class B1_ClassFixtureTests : IClassFixture<B_ClassFixtures>, IDisposable
    {
        B_ClassFixtures _fixture;

        public B1_ClassFixtureTests(B_ClassFixtures fixture)
        {
            //Test setup
            this._fixture = fixture;
        }
        public void Dispose()
        {
            //Test teardown
            var foo = "foo";
        }

        [Fact]
        public void ThisIsATest()
        {
            Assert.Equal((string) "Skimedic",(string) _fixture.Name);
            Assert.Equal(1,_fixture.InstanceCount);
        }

        [Fact]
        public void ThisIsAnotherTest()
        {
            Assert.Equal((string) "Skimedic", (string) _fixture.Name);
            Assert.Equal(1, _fixture.InstanceCount);
        }

    }
}