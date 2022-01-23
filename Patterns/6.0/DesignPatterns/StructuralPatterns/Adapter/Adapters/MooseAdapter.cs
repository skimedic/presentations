// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - MooseAdapter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Adapter.Adapters;

public class MooseAdapter : ICharacter
{
    private readonly IMoose _moose;

    public MooseAdapter(IMoose moose)
    {
        _moose = moose;
    }

    public int Chase() => _moose.Run();

    public int Flee() => _moose.Run();

    public int Attack() => _moose.Charge();
}