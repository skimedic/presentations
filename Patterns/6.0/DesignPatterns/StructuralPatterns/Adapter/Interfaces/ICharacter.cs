// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICharacter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace StructuralPatterns.Adapter.Interfaces;

public interface ICharacter
{
    int Chase();

    int Flee();

    int Attack();
}