// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BadGuy.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Adapter;

public class BadGuy : IBadGuy
{
    public int Drive() => 30;

    public int Shoot() => 50;
}