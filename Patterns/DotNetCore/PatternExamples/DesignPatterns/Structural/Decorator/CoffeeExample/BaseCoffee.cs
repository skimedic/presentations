// Copyright Information
// =============================
// StructuralPatterns - BaseCoffee.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Structural.Decorator.CoffeeExample
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