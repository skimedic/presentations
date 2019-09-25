using Xunit;

namespace WhatsNewInCSharp71_Tests.A_Tuples71Tests
{
    public class Tuples71Tests
    {
        [Fact]
        public void ShouldInferNames()
        {
            var alpha = "a";
            var beta = "b";
            var letters = (alpha, beta);
            Assert.Equal(alpha, letters.alpha);
            //Works, but doesn't show up in intellisense
            Assert.Equal(alpha, letters.Item1);

            Assert.Equal(beta, letters.beta);
            //Works, but doesn't show up in intellisense
            Assert.Equal(beta, letters.Item2);
        }

        [Fact]
        public void ShouldOverrideInferredNamedTuplesWithExplicitNames()
        {
            var alpha = "a";
            var beta = "b";
            var letters = (Alpha: alpha, Beta: beta);

            Assert.Equal(alpha, letters.Alpha);
            //Works, but doesn't show up in intellisense
            Assert.Equal(alpha, letters.Item1);

            Assert.Equal(beta, letters.Beta);
            //Works, but doesn't show up in intellisense
            Assert.Equal(beta, letters.Item2);
        }

        [Fact]
        public void LeftSideNamingShouldWinOverRightSideNaming()
        {
            var alpha = "a";
            var beta = "b";
            (string First, string Last) letters = (Alpha: alpha, Beta: beta);

            Assert.Equal(alpha, letters.First);
            //Works, but doesn't show up in intellisense
            Assert.Equal(alpha, letters.Item1);

            Assert.Equal(beta, letters.Last);
            //Works, but doesn't show up in intellisense
            Assert.Equal(beta, letters.Item2);
        }
    }
}
