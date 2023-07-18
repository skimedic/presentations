// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - IOverdone.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace StructuralPatterns.Facade.UglyCode.Interfaces;

public interface IOverdone
{
    int DoSomething(int x, int y);

    int DoSomethingElse(int x, int y, int z);

    int DoSomethingAgain(int x, int y, int z, int a);
}