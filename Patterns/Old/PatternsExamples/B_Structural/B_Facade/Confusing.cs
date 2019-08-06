// Copyright Information
// =============================
// PatternsExamples - Confusing.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace PatternsExamples.B_Structural.B_Facade
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