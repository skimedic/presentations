using System;
using System.Runtime.CompilerServices;
namespace WhatsNewInCSharp8
{
#nullable enable
    public class MySampleType
    {

    }
    public class NullableTypes
    {
        private MySampleType? _sample;
        public NullableTypes()
        {
        
        }
        // Warning: Assignment of null to non-nullable reference type
        string s1 = null;
        string? s = null; // Ok

        public void MyMethod(string? s)
        {
            // Warning: Possible null reference exception
            //Console.WriteLine(s.Length);
            if (s != null)
            {
                Console.WriteLine(s.Length); // Ok: You won't get here if s is null
            }
        }
    }
}
