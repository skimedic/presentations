// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICharacter.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Adapter.Interfaces;

public interface ICharacter
{
    int Chase();

    int Flee();

    int Attack();
}