// Copyright Information
// =============================
// CreationalPatterns - PizzaFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Creational.Factory.C_AbstractFactory
{
    public interface IPizzaFactory
    {
        IPizza CreatePizza(IList<string> ingredients);
    }
    public abstract class PizzaFactory : IPizzaFactory
    {
        public abstract IPizza CreatePizza(IList<string> ingredients);
    }

    public class NewYorkPizzaFactory : PizzaFactory
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            return new NewYorkPizza(ingredients);
        }
    }
    public class ChicagoPizzaFactory : PizzaFactory
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            return new ChicagoPizza(ingredients);
        }
    }
    public class CaliforniaPizzaFactory : PizzaFactory
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            return new CaliforniaPizza(ingredients);
        }
    }
}
