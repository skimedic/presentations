// Copyright Information
// ==================================
// DesignPatterns - StructuralPatterns - BaseCoffee.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

using System.Collections.Generic;

namespace StructuralPatterns.Decorator.CoffeeExample
{
    public interface ICoffee
    {
        decimal Cost { get; set; }
        List<string> Ingredients { get; set; }
    }

    public class BaseCoffee : ICoffee
    {
        public BaseCoffee()
        {
            Ingredients.Add("coffee");
            Cost = 1.50M;
        }

        public decimal Cost { get; set; }

        public List<string> Ingredients { get; set; } 
            = new List<string>();
    }
}