// Copyright Information
// =============================
// CreationalPatterns - IPizza.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Creational.Factory
{
    public interface IPizza
    {
        IList<string> Toppings { get; }
        DoughType Dough { get; set; }
        string Seasonings { get; set; }
        string SauceType { get; set; }
        void Bake();
        void Cut();
        void Box();
    }

    public abstract class Pizza : IPizza
    {
        protected Pizza(IList<string> ingredients)
        {
            Toppings = ingredients;
        }
        public IList<string> Toppings { get; }
        public DoughType Dough { get; set; }
        public string Seasonings { get; set; }
        public string SauceType { get; set; }
        public abstract void Bake();
        public abstract void Cut();
        public abstract void Box();
    }
    public class NewYorkPizza : Pizza
    {
        public NewYorkPizza(IList<string> ingredients):base(ingredients)
        {
            Dough = DoughType.Thin;
        }

        public override void Bake() { }
        public override void Cut() { }
        public override void Box() { }
    }
    public class ChicagoPizza : Pizza
    {
        public ChicagoPizza(IList<string> ingredients) : base(ingredients)
        {
            Dough = DoughType.Pan;
        }
        public override void Bake() { }
        public override void Cut() { }
        public override void Box() { }
    }
    public class CaliforniaPizza : Pizza
    {
        public CaliforniaPizza(IList<string> ingredients) : base(ingredients)
        {
            Dough = DoughType.None;
        }
        public override void Bake() { }
        public override void Cut() { }
        public override void Box() { }
    }

}