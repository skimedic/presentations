// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - IConfusing.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Facade.UglyCode.Interfaces;

public interface IConfusing
{
    int Execute(int a, int b, int c);

    int Method1();

    int Method2(int x);

    int Method2(int x, int y);
}