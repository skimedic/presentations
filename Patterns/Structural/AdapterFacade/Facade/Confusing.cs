#region copyright
// Copyright Information
// ==============================
// PatternsExamples - Confusing.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace Structural.AdapterFacade.Facade
{
    public class Confusing : IConfusing
    {
        /// <summary>
        /// this is a terrible name for an api
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Execute(int a, int b, int c) => a + b + c;

        public int Method1() => 0;

        public int Method2(int x) => x;

        public int Method2(int x, int y) => x + y;
    }
}