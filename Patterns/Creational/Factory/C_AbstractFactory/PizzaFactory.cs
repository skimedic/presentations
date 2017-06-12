using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Factory.C_AbstractFactory
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
