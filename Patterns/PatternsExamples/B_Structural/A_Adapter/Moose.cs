// Copyright Information
// =============================
// PatternsExamples - Moose.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace PatternsExamples.B_Structural.A_Adapter
{
    public class Moose : IMoose
    {
        public int Run() => 5;

        public int Charge() => 10;
    }
}