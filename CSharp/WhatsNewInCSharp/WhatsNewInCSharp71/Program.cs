using System;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsNewInCSharp71
{
    class Foo<T>
    {

        public Foo()
        { 
            T local = default;
        }
           
    }
    class Program
    {
        
        //Pre 7.1 syntax
        //static void Main(string[] args)
        //{
        //     DoSomething().GetAwaiter().GetResult();    
        //}

        //7.1 and later
        static async Task Main(string[] args)
        {
            await DoSomething();
        }
        //or
        //static async Task<int> Main(string[] args)
        //{
        //}

        static async Task DoSomething()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
            });
        }
    }
}
