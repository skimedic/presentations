using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp73.A_MoreEfficientSafeCode
{
    public class A_NoLongerNeedToPinVariable
    {
        unsafe struct S
        {
            public fixed int myFixedField[10];
        }
        static S s = new S();

        //Pre 7.3 version
        public unsafe void M_Old()
        {
            fixed (int* ptr = s.myFixedField)
            {
                int p = ptr[5];
            }
        }
        //Post 7.3 version
        public unsafe void M()
        {
            int p = s.myFixedField[5];
        }
    }
}
