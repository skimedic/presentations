using System;

namespace WhatsNewInCSharp7
{
    class Program
    {
        static void Main(string[] args)
        {
            var features = new FeaturesIn70();
            features.RefsLocalsAndReturns();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
