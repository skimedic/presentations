#region copyright
// Copyright Information
// ==============================
// PatternsExamples - BadGuy.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace PatternsExamples.B_Structural.A_Adapter
{
    public class BadGuy : IBadGuy
    {
        public int Drive() => 30;

        public int Shoot() => 50;
    }
}
