// Copyright Information
// =============================
// CreationalPatterns - PizzaStore.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Creational.Factory.B_FactoryMethod
{
    //TODO: IRL separate out
    public abstract class PizzaStore
    {
        public IPizza OrderPizza(IList<string> ingredients)
        {
            IPizza pizza = CreatePizza(ingredients);
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
        public abstract IPizza CreatePizza(IList<string> ingredients);
    }

    public class NewYorkPizzaStore : PizzaStore
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            //This is tied to a specific pizza implementation
            return new NewYorkPizza(ingredients);
        }
    }
    public class ChicagoPizzaStore : PizzaStore
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            //This is tied to a specific pizza implementation
            return new ChicagoPizza(ingredients);
        }
    }
    public class CaliforniaPizzaStore : PizzaStore
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            //This is tied to a specific pizza implementation
            return new CaliforniaPizza(ingredients);
        }
    }

}