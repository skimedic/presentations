// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - Confusing.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace StructuralPatterns.Facade.UglyCode;

public class Confusing : IConfusing
{
    public int Execute(int a, int b, int c) => a + b + c;

    public int Method1() => 0;

    public int Method2(int x) => x;

    public int Method2(int x, int y) => x + y;
}