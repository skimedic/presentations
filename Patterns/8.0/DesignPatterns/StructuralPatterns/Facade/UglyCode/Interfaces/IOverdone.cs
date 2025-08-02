// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - IOverdone.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Facade.UglyCode.Interfaces;

public interface IOverdone
{
    int DoSomething(int x, int y);

    int DoSomethingElse(int x, int y, int z);

    int DoSomethingAgain(int x, int y, int z, int a);
}