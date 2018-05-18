// Copyright Information
// =============================
// CreationalPatterns - PizzaStoreWithAbstractFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

using System.Collections.Generic;

namespace DesignPatterns.Creational.Factory.C_AbstractFactory
{
    public abstract class PizzaStoreWithAbstractFactory
    {
        private readonly IPizzaFactory _factory;

        protected PizzaStoreWithAbstractFactory(IPizzaFactory factory)
        {
            _factory = factory;
        }

        public IPizza OrderPizza(IList<string> ingredients)
        {
            IPizza pizza = _factory.CreatePizza(ingredients);
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
    }

    public class NewYorkPizzaStoreWithAbstractFactory : 
        PizzaStoreWithAbstractFactory
    {
        public NewYorkPizzaStoreWithAbstractFactory() : 
            this(new NewYorkPizzaFactory()) { }
        public NewYorkPizzaStoreWithAbstractFactory(
            IPizzaFactory pizzaFactory) : 
            base(pizzaFactory) { }

    }
    public class ChicagoPizzaStoreWithAbstractFactory : PizzaStoreWithAbstractFactory
    {
        public ChicagoPizzaStoreWithAbstractFactory() : 
            this(new ChicagoPizzaFactory()) { }
        public ChicagoPizzaStoreWithAbstractFactory(IPizzaFactory pizzaFactory)
            : base(pizzaFactory) { }
    }
    public class CaliforniaPizzaStoreWithAbstractFactory : PizzaStoreWithAbstractFactory
    {
        public CaliforniaPizzaStoreWithAbstractFactory() : 
            this(new CaliforniaPizzaFactory()) { }
        public CaliforniaPizzaStoreWithAbstractFactory(IPizzaFactory pizzaFactory)
            : base(pizzaFactory) { }
    }
}
