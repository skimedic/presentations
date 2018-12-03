using Xunit;

namespace WhatsNewInCSharp72_Tests.A_PerfImprovTests
{
    public class B_RefReadOnlyDemo
    {
        public ref int GetPositionInArray(int[] intArray, int position)
        {
            return ref intArray[position];
        }

        [Fact]
        public void ShouldGetReferenceToItemInArray()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            ref readonly var result = ref GetPositionInArray(a, position);
            Assert.Equal(4, result);
            //This is now a compile error
            //result = 6;
        }

    }
}