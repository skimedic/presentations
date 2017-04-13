using System;
using Recipe.Models;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dc = new RecipeContext())
            {
                foreach(var recipe in dc.Recipe.Take(5))
                {
                    Console.WriteLine(recipe.Title);
                }
            }
        }
    }
}