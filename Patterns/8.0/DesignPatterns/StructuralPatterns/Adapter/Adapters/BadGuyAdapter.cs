// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BadGuyAdapter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Adapter.Adapters;

public class BadGuyAdapter : ICharacter
{
    private readonly IBadGuy _badGuy;

    public BadGuyAdapter(IBadGuy badGuy)
    {
        _badGuy = badGuy;
    }

    public int Chase() => _badGuy.Drive();

    public int Flee()
    {
        throw new Exception("Bad guys don't flee!");
    }

    public int Attack() => _badGuy.Shoot();
}