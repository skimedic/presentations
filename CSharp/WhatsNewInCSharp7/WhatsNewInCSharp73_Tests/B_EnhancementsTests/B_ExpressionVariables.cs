using System;

namespace WhatsNewInCSharp73_Tests.B_EnhancementsTests
{
    public class B_ExpressionVariables
    {
        public class BaseClass
        {
            public BaseClass(int i, out int j)
            {
                j = i;
            }
        }

        public class DerivedClass : BaseClass
        {
            public DerivedClass(int i) : base(i, out var j)
            {
                Console.WriteLine($"The value of 'j' is {j}");
            }
        }

    }
}