using WhatsNewInCSharp7.B_Tuples;
using Xunit;

namespace WhatsNewInCSharp7_Tests.B_TuplesTests
{
    public class A_TupleTests
    {
        [Fact]
        public void SimpleTuples()
        {
            var simple = ("a", "b");
            Assert.Equal("a",simple.Item1);
            Assert.Equal("b",simple.Item2);
        }

        [Fact]
        public void NamedTuples()
        {
            //NOTE: Names only exist at compile time - are not accessible through reflection

            var sut = new TuplesExamples();
            //declared on the left
            (string Alpha, string Beta) leftNamed = ("a", "b");
            Assert.Equal("a", leftNamed.Item1);
            Assert.Equal("a", leftNamed.Alpha);
            Assert.Equal("b", leftNamed.Item2);
            Assert.Equal("b", leftNamed.Beta);

            //declared on the right
            var rightNamed = (Alpha: "a", Beta: "b");
            //var rightNamed = sut.NamedTuples();

            //NOTE: ItemX doesn't get picked up by intellisense
            Assert.Equal("a", rightNamed.Item1);
            Assert.Equal("a", rightNamed.Alpha);
            //NOTE: ItemX doesn't get picked up by intellisense
            Assert.Equal("b", rightNamed.Item2);
            Assert.Equal("b", rightNamed.Beta);

            //When declared on both, left wins
            (string First, string Second) bothSideNamedTuple = (Alpha: "a", Beta: "b");
            //NOTE: ItemX doesn't get picked up by intellisense
            Assert.Equal("a", bothSideNamedTuple.Item1);
            Assert.Equal("a", bothSideNamedTuple.First);
            //Doesn't compile
            //Assert.Equal("a", bothSideNamedTuple.Alpha);
            //NOTE: ItemX doesn't get picked up by intellisense
            Assert.Equal("b", bothSideNamedTuple.Item2);
            Assert.Equal("b", bothSideNamedTuple.Second);
            //Doesn't compile
            //Assert.Equal("b", bothSideNamedTuple.Beta);

        }
    }
}
