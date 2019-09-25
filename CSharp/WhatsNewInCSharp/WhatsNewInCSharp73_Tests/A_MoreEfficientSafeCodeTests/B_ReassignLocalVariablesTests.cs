using Xunit;

namespace WhatsNewInCSharp73_Tests.A_MoreEfficientSafeCodeTests
{
    public class B_ReassignLocalVariablesTests
    {
        public ref int GetPositionInArray(int[] intArray, int position)
        {
            return ref intArray[position];
        }

        [Fact]
        public void ShouldGetReferenceToItemInArrayAndReassignToNewArray()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            ref var result = ref GetPositionInArray(a, position);
            Assert.Equal(4, result);
            result = 6;
            Assert.Equal(6, a[position]);

            int[] b = new[] { 2, 4, 6, 8, 10 };
            result = ref GetPositionInArray(b, position);
            Assert.Equal(8, result);
            result = 19;
            Assert.Equal(19, b[position]);
        }


    }
}
