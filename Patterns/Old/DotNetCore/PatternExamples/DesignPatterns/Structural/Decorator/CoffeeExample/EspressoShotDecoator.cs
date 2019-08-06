// Copyright Information
// =============================
// StructuralPatterns - EspressoShotDecoator.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Structural.Decorator.CoffeeExample
{
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
}