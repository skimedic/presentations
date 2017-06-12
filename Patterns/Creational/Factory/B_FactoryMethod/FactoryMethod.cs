#region copyright
// Copyright Information
// ==============================
// PatternsExamples - FactoryMethod.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion

using System.Collections.Specialized;
using Creational.Factory.A_SimpleFactory;

namespace Creational.Factory.B_FactoryMethod
{

    public abstract class PizzaStore
    {
        public IPizza OrderPizza(PizzaType type)
        {
            IPizza pizza = CreatePizza(type);
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
        public abstract IPizza CreatePizza(PizzaType type);
    }

    public class NewYorkPizzaStore : PizzaStore
    {
        public override IPizza CreatePizza(PizzaType type)
        {
            //Specific NYP implementation - perhaps a simple factory here?
            return new CheesePizza();
        }
    }

}