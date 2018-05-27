using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNewInCSharp71
{
    public class FeaturesIn71
    {
        #region Default Literals
        public void DefaultLiterals<T>()
        {
            T t = default(T);
            var s = default(string);
            var d = default(dynamic);
            var i = default(int);
            var n = default(int?); // n is a Nullable int where HasValue is false.
        }
        #endregion

        #region Tuples
        public void Tuples()
        {
            void InferredNames()
            {
                var alpha = "a";
                var beta = "b";
                var letters = (alpha, beta);
                var firstLetter = letters.Item1;
                var firstLetter2 = letters.alpha;
                var secondLetter = letters.Item2;
                var secondLetter2 = letters.beta;
            }

            void ExplicitNamesOverrideInferredNamedTuples()
            {
                var alpha = "a";
                var beta = "b";
                var letters = (Alpha: alpha, Beta: beta);
                var firstLetter2 = letters.Alpha;
                var secondLetter2 = letters.Beta;
            }
            void LeftSideStillWins()
            {
                var alpha = "a";
                var beta = "b";
                (string First, string Last) letters = (Alpha: alpha, Beta: beta);
                var firstLetter2 = letters.First;
                var secondLetter2 = letters.Last;
            }

        }

        #endregion


    }
}
