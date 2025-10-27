// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - FlyingSquirrelAdapter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Adapter.Adapters;

public class FlyingSquirrelAdapter : ICharacter
{
    private readonly IFlyingSquirrel _flyingSquirrel;

    public FlyingSquirrelAdapter(IFlyingSquirrel flyingSquirrel)
    {
        _flyingSquirrel = flyingSquirrel;
    }

    public int Chase() => _flyingSquirrel.Fly();

    public int Flee() => _flyingSquirrel.Fly();

    public int Attack() => _flyingSquirrel.DropAcorns();
}