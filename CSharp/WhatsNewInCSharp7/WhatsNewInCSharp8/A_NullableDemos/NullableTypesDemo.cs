using System;

namespace WhatsNewInCSharp8.A_NullableDemos
{
//#nullable disable
//#nullable enable
    public class NullableTypesDemo
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/upgrade-to-nullable-references
        private MySampleType? _sampleNullable;
        private MySampleType _sampleNonNullable;
        public NullableTypesDemo()
        {
            _sampleNullable = null;
            _sampleNonNullable = null;
            if (_sampleNullable!=null)
            {
                //HasValue and Value aren't supported yet
                //var foo = _sampleNullable.Value;
            }
        }
        // Warning: Assignment of null to non-nullable reference type
        //string s1 = null;
        string? s = null; // Ok

        public void MyMethod(string? s)
        {
            // Warning: Possible null reference exception
            Console.WriteLine(s.Length);
            //Use the null forgiving operator
            Console.WriteLine(s!.Length);
            //Use the null coalescing operator
            Console.WriteLine(s?[0] ?? '?'); 
        }
    }
}
