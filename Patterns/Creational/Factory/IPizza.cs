using System.Collections.Generic;

namespace Creational.Factory
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
        protected Pizza()
        {
            Toppings = new List<string>();
        }
        public IList<string> Toppings { get; }
        public DoughType Dough { get; set; }
        public string Seasonings { get; set; }
        public string SauceType { get; set; }
        public abstract void Bake();
        public abstract void Cut();
        public abstract void Box();
    }
    public class CheesePizza : Pizza
    {
        public override void Bake() { }
        public override void Cut() { }
        public override void Box() { }
    }
    public class SausagePizza : Pizza
    {
        public override void Bake() { }
        public override void Cut() { }
        public override void Box() { }
    }
    public class PepperoniPizza : Pizza
    {
        public override void Bake() { }
        public override void Cut() { }
        public override void Box() { }
    }

}