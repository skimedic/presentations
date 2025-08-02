// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - Moose.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Adapter;

public class Moose : IMoose
{
    public int Run() => 5;

    public int Charge() => 10;
}