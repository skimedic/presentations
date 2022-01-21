// Copyright Information
// ==================================
// DesignPatterns - CreationPatterns - PizzaStoreBase.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/01/20
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

    public abstract IPizza CreatePizza(PizzaTypeEnum pizzaType);
}