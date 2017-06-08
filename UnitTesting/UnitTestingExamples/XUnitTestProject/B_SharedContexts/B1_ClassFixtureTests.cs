using Xunit;

namespace XUnitTestProject.B_SharedContexts
{
    public class B1_ClassFixtureTests : IClassFixture<B_ClassFixtures>
    {
        B_ClassFixtures _fixture;

        public B1_ClassFixtureTests(B_ClassFixtures fixture)
        {
            this._fixture = fixture;
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