// Copyright Information
// =============================
// PatternsExamples - FactoryMethod.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 19/06/2017
// See License.txt for more information
// =============================
using PatternsExamples.A_Creational.B_SimpleFactory;
using PatternsExamples.A_Creational.D_AbstractFactory;

namespace PatternsExamples.A_Creational.C_FactoryMethod
{
	public interface IPizzaStore
	{
		IPizza OrderLocalizedPizza(PizzaType type);
	}

	public abstract class PizzaStore : IPizzaStore
	{
		protected IIngredientFactory Ingredients;
		protected PizzaStore() : this(new BaseIngredients())
		{
		}

		protected PizzaStore(IIngredientFactory ingredients)
		{
			Ingredients = ingredients;
		}

		public IPizza OrderLocalizedPizza(PizzaType type)
		{
			var pizza = CreateLocalizedPizza(type);
			pizza.Bake();
			pizza.Cut();
			pizza.Box();
			return pizza;
		}

		//This is the factory "method"
		protected abstract IPizza CreateLocalizedPizza(PizzaType type);
	}

	public class BasePizzaStore : PizzaStore
	{
		public BasePizzaStore() : this(new BaseIngredients())
		{
		}

		public BasePizzaStore(IIngredientFactory ingredients)
		{
			Ingredients = ingredients;
		}

		protected override IPizza CreateLocalizedPizza(PizzaType type) => 
			PizzaFactory.CreateLocalizedPizza(type, Ingredients);
	}

	public class NewYorkPizzaStore : PizzaStore
	{
		public NewYorkPizzaStore() : this(new NYIngredients())
		{
		}

		public NewYorkPizzaStore(IIngredientFactory ingredientFactory)
		{
			Ingredients = ingredientFactory;
		}

		protected override IPizza CreateLocalizedPizza(PizzaType type) => 
			PizzaFactory.CreateLocalizedPizza(type, Ingredients);
	}

	public class ChicagoPizzaStore : PizzaStore
	{
		public ChicagoPizzaStore() : this(new ChicagoIngredients())
		{
		}

		public ChicagoPizzaStore(IIngredientFactory ingredients)
		{
			Ingredients = ingredients;
		}

		protected override IPizza CreateLocalizedPizza(PizzaType type) => 
			PizzaFactory.CreateLocalizedPizza(type, Ingredients);
	}
}