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
        public void FirstTheory(int expected, int addend1, int addend2)
        {
            Assert.Equal(expected,addend1+addend2);
        }
        [Fact(DisplayName = "Custom Display Name", Skip = "bar")]
        public void ThisIsIgnored()
        {

        }

    }
}
