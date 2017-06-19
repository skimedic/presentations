// Copyright Information
// =============================
// BehavioralPatterns - BasePizzaStore.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace BehavioralPatterns.TemplateMethod
{
    //Example of the Template Pattern in .NET
    //TextReader sr = new StreamReader("Foo");

    public abstract class BasePizzaStore
    {
        protected IPizza PizzaForDelivery;
        public IPizza CreatePizzaForDelivery()
        {
            TakeOrder();
            ProcessPayment();
            MakePizza();
            CookPizza();
            DeliverPizza();
            return PizzaForDelivery;
        }

        public abstract void TakeOrder();
        public abstract void MakePizza();
        public abstract void CookPizza();

        internal void ProcessPayment()
        {
            //Processes the customers payment
        }

        internal void DeliverPizza()
        {
            //delivers pizza to the customer
        }

    }


}
