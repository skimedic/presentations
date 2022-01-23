// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - Overdone.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Facade.UglyCode;

public class Overdone : IOverdone
{
    private string SomeString { get; init; }

    public Overdone(string someString)
    {
        SomeString = someString;
    }

    public int DoSomething(int x, int y) => x * y;

    public int DoSomethingElse(int x, int y, int z) => (x + y) * z;

    public int DoSomethingAgain(int x, int y, int z, int a) => (x + y + z) * a;
}