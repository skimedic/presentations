using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace WhatsNewInCSharp7_Tests.F_RefLocalsAndReturnsTests
{
    public class RefLocalsAndReturnsTests
    {
        public ref int GetPositionInArray(int[] intArray, int position) => ref intArray[position];

        [Fact]
        public void ShouldGetReferenceToItemInArray()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            ref var result = ref GetPositionInArray(a, position);
            Assert.Equal(4,result);
            result = 6;
            Assert.Equal(6,a[position]);
        }

        [Fact]
        public void DisallowedConstructsWithRefLocalsAndReturns()
        {
            var position = 3;
            int[] a = new[] { 1, 2, 3, 4, 5 };
            ref var result = ref GetPositionInArray(a, position);

            //Can't assign a standard method call to a ref local
            //Doesn't compile
            //ref int c = a.GetLength(0);

            //Can't return a ref local to a local
            //int b = ref GetPositionInArray(a, position);

            //Can't be used with async methods
        }
    }
}
