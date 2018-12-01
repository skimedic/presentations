using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp7.B_Tuples
{
    public class TuplesExamples
    {
        public (string, string) SimpleTuples()
        {
            var letters = ("a", "b");
            var firstLetter = letters.Item1;
            var secondLetter = letters.Item2;
            return letters;
        }

        public (string Alpha, string Beta) NamedTuples()
        {
            //NOTE: Names only exist at compile time - are not accessible through reflection
            //Names can be declared on the left
            (string Alpha, string Beta) leftSideNamedTuple = ("a", "b");
            Console.WriteLine($"{leftSideNamedTuple.Alpha},{leftSideNamedTuple.Beta}");

            //or right side (must use var for this)
            var rightSideNamedTuple = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{rightSideNamedTuple.Alpha},{rightSideNamedTuple.Beta}");

            //If declared on both, ignored on the right
            (string First, string Second) bothSideNamedTuple = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{bothSideNamedTuple.First},{bothSideNamedTuple.Second}");
            //This doesn't compile
            //Console.WriteLine($"{bothSideNamedTuple.Alpha},{bothSideNamedTuple.Beta}");

            return bothSideNamedTuple;
        }
    }
}
