// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - Moose.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Adapter;

public class Moose : IMoose
{
    public int Run() => 5;

    public int Charge() => 10;
}