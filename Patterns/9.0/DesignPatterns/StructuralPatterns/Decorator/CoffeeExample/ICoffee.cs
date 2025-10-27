// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICoffee.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Decorator.CoffeeExample;

public interface ICoffee
{
    decimal Cost { get; set; }
    List<string> Ingredients { get; set; }
}