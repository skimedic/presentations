// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - ICoffee.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace StructuralPatterns.Decorator.CoffeeExample;

public interface ICoffee
{
    decimal Cost { get; set; }
    List<string> Ingredients { get; set; }
}