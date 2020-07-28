using System;
using WhatsNewInCSharp8.F_Interfaces;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Person? p = new Person();
            Person? foo = default;
            ((IPerson) p).GetName();
            ((IGetName) p).GetName();
            var bar = foo ??= p;
        }
    }
}
