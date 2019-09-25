namespace WhatsNewInCSharp71.A_Tuples
{
    public class Tuples71Demos
    {
        public void InferredNames()
        {
            var alpha = "a";
            var beta = "b";
            var letters = (alpha, beta);
            var firstLetter = letters.Item1;
            var firstLetter2 = letters.alpha;
            var secondLetter = letters.Item2;
            var secondLetter2 = letters.beta;
        }

        public void ExplicitNamesOverrideInferredNamedTuples()
        {
            var alpha = "a";
            var beta = "b";
            var letters = (Alpha: alpha, Beta: beta);
            var firstLetter2 = letters.Alpha;
            var secondLetter2 = letters.Beta;
        }
        public void LeftSideStillWins()
        {
            var alpha = "a";
            var beta = "b";
            (string First, string Last) letters = (Alpha: alpha, Beta: beta);
            var firstLetter2 = letters.First;
            var secondLetter2 = letters.Last;
        }


    }
}