// Copyright Information
// =============================
// PatternsExamples - SimpleFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using PatternsExamples.A_Creational.D_AbstractFactory;

namespace PatternsExamples.A_Creational.B_SimpleFactory
{
    public static class PizzaFactory
    {
        public static IPizza CreatePizza(PizzaType type)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    return new CheesePizza();
                case PizzaType.Sausage:
                    return new SausagePizza();
                case PizzaType.Pepperoni:
                    return new PepperoniPizza();
                default:
                    return null;
            }
        }

        public static IPizza CreateLocalizedPizza(PizzaType type, IIngredientFactory ingredients)
        {
            switch (type)
            {
                case PizzaType.Cheese:
                    return new CheesePizza(ingredients);
                case PizzaType.Sausage:
                    return new SausagePizza(ingredients);
                case PizzaType.Pepperoni:
                    return new PepperoniPizza(ingredients);
                default:
                    return null;
            }
        }
    }
}
