using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creational.Factory.C_AbstractFactory
{
    public abstract class PizzaFactory
    {
        public abstract IPizza CreatePizza(IList<string> ingredients);
    }

    //public class NewYorkPizzaFactory : PizzaFactory
    //{
    //    public override IPizza CreatePizza(IList<string> ingredients)
    //    {
    //        //IPizza = new Pizza
    //    }
    //}
}
