// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - FlyingSquirrel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Adapter;

public class FlyingSquirrel : IFlyingSquirrel
{
    public int Fly() => 20;

    public int DropAcorns() => 1;
}