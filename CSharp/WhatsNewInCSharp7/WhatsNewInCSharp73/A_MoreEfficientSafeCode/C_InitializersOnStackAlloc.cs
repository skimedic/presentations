using System;
using System.Runtime.CompilerServices;

namespace WhatsNewInCSharp73.A_MoreEfficientSafeCode
{

    public class C_InitializersOnStackAlloc
    {
        public unsafe void Initialize()
        {
            int* pArr = stackalloc int[3] { 1, 2, 3 };
            int* pArr2 = stackalloc int[] { 1, 2, 3 };
            Span<int> arr = stackalloc[] { 1, 2, 3 };
        }
    }
}