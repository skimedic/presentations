using Xunit;

namespace WhatsNewInCSharp73_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var foo = 0;
            for (int x=0; x<100; x++)
            {
                foo++;
            }

            Assert.Equal(100,foo);
        }
    }
}
