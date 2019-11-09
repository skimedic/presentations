using System;
using System.Transactions;

namespace WhatsNewInCSharp73
{
    class Program
    {
        private string _foo = default;

        static void Main(string[] args)
        {
            //var t = new Tuples();
            //t.TupleStuff1();
            //t.TupleStuff2();
            //t.TupleStuff3();
            //t.TupleStuff4();

            var foo = new AdditionalExpressionVariables(out var test);
            Console.WriteLine(test); //outputs 5
            Console.WriteLine("All finished");
            Console.ReadLine();
        }
    }

    internal class AdditionalExpressionVariables
    {
        public AdditionalExpressionVariables(out int test)
        {
            test = 5;
        }
    }
}
