// Copyright Information
// =============================
// StructuralPatterns - Overdone.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================
namespace DesignPatterns.Structural.AdapterFacade.Facade
{
    public class Overdone : IOverdone
    {
        private string SomeString { get; } = string.Empty;

        public Overdone(string someString)
        {
            SomeString = someString;
        }

        public int DoSomething(int x, int y) => x * y;

        public int DoSomethingElse(int x, int y, int z) => (x + y) * z;

        public int DoSomethingAgain(int x, int y, int z, int a) => (x + y + z) * a;
    }
}