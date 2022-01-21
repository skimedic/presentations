// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - PizzaStoreBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
// ==================================

namespace CreationPatterns.Factory.C_Abstract;

public abstract class PizzaStoreBase
{
    public IPizza OrderPizza(IList<string> ingredients)
    {
        //IPizza pizza = CreatePizza(ingredients);
        //pizza.Bake();
        //pizza.Cut();
        //pizza.Box();
        //return pizza;
        return null;
    }
    //public abstract IPizza CreatePizza(IList<string> ingredients);
}