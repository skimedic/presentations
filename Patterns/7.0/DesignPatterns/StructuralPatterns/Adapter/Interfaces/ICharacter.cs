// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICharacter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace StructuralPatterns.Adapter.Interfaces;

public interface ICharacter
{
    int Chase();

    int Flee();

    int Attack();
}