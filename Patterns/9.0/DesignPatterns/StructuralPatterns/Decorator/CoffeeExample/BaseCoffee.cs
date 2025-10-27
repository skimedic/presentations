// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BaseCoffee.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Decorator.CoffeeExample;

public class BaseCoffee : ICoffee
{
    public BaseCoffee()
    {
        Ingredients.Add("coffee");
        Cost = 1.50M;
    }

    public decimal Cost { get; set; }

    public List<string> Ingredients { get; set; } = new();
}