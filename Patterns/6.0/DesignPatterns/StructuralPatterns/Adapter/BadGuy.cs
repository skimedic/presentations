// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BadGuy.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Adapter;

public class BadGuy : IBadGuy
{
    public int Drive() => 30;

    public int Shoot() => 50;
}