// Copyright Information
// =============================
// CreationalPatterns - SimplePizzaFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Creational.Factory.A_SimpleFactory
{
    public enum PizzaType
    {
        NewYork,
        Chicago,
        California
    }

    public static class SimplePizzaFactory
    {
        public static IPizza CreatePizza(PizzaType type, IList<string> ingredients)
        {
            switch (type)
            {
                case PizzaType.NewYork:
                    return new NewYorkPizza(ingredients);
                case PizzaType.Chicago:
                    return new ChicagoPizza(ingredients);
                case PizzaType.California:
                    return new CaliforniaPizza(ingredients);
                default:
                    return null;
            }
        }
    }
}
