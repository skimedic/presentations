#region copyright
// Copyright Information
// ==============================
// PatternsExamples - SimpleFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion


using System.Collections.Generic;

namespace Creational.Factory.A_SimpleFactory
{
    public enum PizzaType
    {
        NewYork,
        Chicago,
        California
    }

    public static class PizzaFactory
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
