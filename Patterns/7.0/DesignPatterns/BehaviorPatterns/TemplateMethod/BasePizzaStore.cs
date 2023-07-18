// Copyright Information
// ==================================
// DesignPatterns - BehaviorPatterns - BasePizzaStore.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/18
// ==================================

namespace BehaviorPatterns.TemplateMethod;
//Example of the Template Pattern in .NET
//TextReader sr = new StreamReader("Foo");

public abstract class BasePizzaStore
{
    protected IPizza PizzaForDelivery;
    public IPizza CreatePizzaForDelivery()
    {
        TakeOrder();
        ProcessPayment();
        MakePizza();
        CookPizza();
        DeliverPizza();
        return PizzaForDelivery;
    }

    public abstract void TakeOrder();
    public abstract void MakePizza();
    public abstract void CookPizza();

    internal void ProcessPayment()
    {
        //Processes the customers payment
    }

    internal void DeliverPizza()
    {
        //delivers pizza to the customer
    }

}