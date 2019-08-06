// Copyright Information
// =============================
// PatternsExamples - FlyingSquirrel.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using PatternsExamples.B_Structural.A_Adapter;

namespace PatternsExamples.B_Structural.A_Adapter
{
    public class FlyingSquirrel : IFlyingSquirrel
    {
        public int Fly() => 20;

        public int DropAcorns() => 1;
    }
}
