using System;
using System.Collections.Generic;

namespace WhatsNewInCSharp8.C_RangesIndices
{
    public class RangesAndIndicesDemo
    {
        public IEnumerable<string> GetNames(Range range)
        {
            string[] names =
            {
            "Archimedes", "Pythagoras", "Euclid", "Socrates", "Plato"
        };
            foreach (var name in names[range])
            {
                yield return name;
            }
        }
        public void Foo()
        {
            Range range = 1..4;
            var foo = GetNames(range);

            Range openRange = 0..^1;
            openRange = 1..^0;

        }

    }
}
