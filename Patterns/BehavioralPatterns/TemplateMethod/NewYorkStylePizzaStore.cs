// Copyright Information
// =============================
// BehavioralPatterns - NewYorkStylePizzaStore.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
namespace BehavioralPatterns.TemplateMethod
{
    public class NewYorkStylePizzaStore : BasePizzaStore
    {
        public override void TakeOrder()
        {
            //great places for a call to the basic factory pattern
            //operates on PizzaForDelivery
        }
        public override void MakePizza()
        {
            //add thin crust dough and NY style specific ingregients
            //operates on PizzaForDelivery
        }

        public override void CookPizza()
        {
            //cook the thin crust pizza in a wood fired oven
            //operates on PizzaForDelivery
        }
    }
}