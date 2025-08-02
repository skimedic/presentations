// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - EspressoShotDecoator.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace StructuralPatterns.Decorator.CoffeeExample;

public class EspressoShotDecorator : ICoffee
{
    private readonly ICoffee _decoratedCoffee;

    public EspressoShotDecorator(ICoffee decoratedCoffee)
    {
        _decoratedCoffee = decoratedCoffee;
        Cost = decoratedCoffee.Cost + .55M;
        decoratedCoffee.Ingredients.ForEach(x=>Ingredients.Add(x));
        Ingredients.Add("Espresso");
    }

    public decimal Cost { get; set; }

    public List<string> Ingredients { get; set; }
        = new List<string>();
}