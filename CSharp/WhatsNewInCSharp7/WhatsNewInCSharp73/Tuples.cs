using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp73
{
    public class Tuples
    {
        public void TupleStuff1()
        {
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            //R# can't handle C# 7.3 yet
            Console.WriteLine(left == right); // displays 'true'

        }
        public void TupleStuff2()
        {
            var left = (a: 5, b: 10);
            var right = (a: 5, b: 10);
            (int a, int b)? nullableTuple = right;
            Console.WriteLine(left == nullableTuple); // Also true
        }
        public void TupleStuff3()
        {
            // lifted conversions
            var left = (a: 5, b: 10);
            (int? a, int? b) nullableMembers = (5, 10);
            Console.WriteLine(left == nullableMembers); // Also true

            // converted type of left is (long, long)
            (long a, long b) longTuple = (5, 10);
            Console.WriteLine(left == longTuple); // Also true

            // comparisons performed on (long, long) tuples
            (long a, int b) longFirst = (5, 10);
            (int a, long b) longSecond = (5, 10);
            Console.WriteLine(longFirst == longSecond); // Also true
        }

        public void TupleStuff4()
        {
            (int a, string b) pair = (1, "Hello");
            (int z, string y) another = (1, "Hello");
            Console.WriteLine(pair == another); // true. Member names don't participate.
            Console.WriteLine(pair == (z: 1, y: "Hello")); // warning: literal contains different member names
        }
    }
}
