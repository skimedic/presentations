#region copyright
// Copyright Information
// ==============================
// PatternsExamples - Moose.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

namespace StructuralPatterns.AdapterFacade.Adapter
{
    public class Moose : IMoose
    {
        public int Run() => 5;

        public int Charge() => 10;
    }
    public class BadGuy : IBadGuy
    {
        public int Drive() => 30;

        public int Shoot() => 50;
    }
    public class FlyingSquirrel : IFlyingSquirrel
    {
        public int Fly() => 20;

        public int DropAcorns() => 1;
    }


}