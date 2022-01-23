// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - SimplePizzaStoreBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/23
// ==================================

namespace CreationPatterns.Factory.B_FactoryMethod.Base;

public abstract class SimplePizzaStoreBase
{
    public IPizza OrderPizza(PizzaTypeEnum pizzaType)
    {
        IPizza pizza = CreatePizza(pizzaType);
        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }

    //This is the factory method
    public abstract IPizza CreatePizza(PizzaTypeEnum pizzaType);
}