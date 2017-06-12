#region copyright
// Copyright Information
// ==============================
// PatternsExamples - SimpleFactory.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 2016/11/08
// See License.txt for more information
// ==============================
#endregion


namespace Creational.Factory.A_SimpleFactory
{
    public enum PizzaType
    {
        Cheese,
        Pepperoni,
        Sausage,
        UnKnown
    }

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
    }
}
