// Copyright Information
// =============================
// PatternsExamples - BadGuy.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace PatternsExamples.B_Structural.A_Adapter
{
    public class BadGuy : IBadGuy
    {
        public int Drive() => 30;

        public int Shoot() => 50;
    }
}
