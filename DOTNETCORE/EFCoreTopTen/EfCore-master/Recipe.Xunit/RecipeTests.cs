using Microsoft.EntityFrameworkCore;
using Recipe.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Recipe.Xunit
{
    public class RecipeTests
    {
        private readonly ITestOutputHelper output;
        private RecipeContext dc = RecipeContext.RecipeContextFactory();

        public RecipeTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Recipe_Load()
        {
            var items = dc.Recipes.Take(5);
            Assert.True(items.Any());
            foreach (var recipe in items)
            {
                output.WriteLine(recipe.Title);
                foreach (var ingredient in recipe.Ingredients)
                {
                    output.WriteLine($"{ingredient.Units} {ingredient.UnitType} - {ingredient.Description}");
                }
                output.WriteLine("-----");
            }
        }

        [Fact]
        public void Category_Create()
        {
            var newCategory = new Category { Description = $"Test {DateTime.Now.Ticks}" };
            dc.Categories.Add(newCategory);
            dc.SaveChanges();
            Assert.True(newCategory.Id > 0);

            // Cleanup
            dc.Categories.Remove(newCategory);
            dc.SaveChanges();
        }

        [Fact]
        public async Task Recipe_CanCreateBatch()
        {
            var recipe = new Recipe.Dal.Models.Recipe
            {
                Title = "Add Test",
                ServingMeasure = "Bites",
                ServingQuantity = 42
            };
            dc.Recipes.Add(recipe);
            for (int i = 0; i < 10; i++)
            {
                recipe.Ingredients.Add(new Ingredient { Description = $"Ing {i}", SortOrder = i, Units = i.ToString(), UnitType = "pn" });
                recipe.Directions.Add(new Direction { Description = $"Step {i} - Stir", LineNumber = i });
            }
            await dc.SaveChangesAsync();
            Assert.True(recipe.Id > 0);

            // Cleanup
            dc.Ingredients.RemoveRange(recipe.Ingredients);
            dc.Directions.RemoveRange(recipe.Directions);
            dc.Recipes.Remove(recipe);
            await dc.SaveChangesAsync();
        }
        [Fact]
        public async Task StoredProcs()
        {
            var brownies = await dc.SearchRecipeAsync("Brownie");
            Assert.NotEqual(0, brownies.Count());
        }
        [Fact]
        public async Task StoredProcs_CanExtend()
        {
            // Note, this version lies because stored procs aren't extendable
            // so the additional query portions are done client side.
            var brownies = await dc.SearchRecipeOrderedAsync("Brownie");
            Assert.True(brownies.Any());
        }

        [Fact]
        public void Recipe_EagerLoading()
        {
            var brownies = from r in dc.Recipes
                                .Include(rec => rec.RecipeCategories).ThenInclude(rc => rc.Category)
                                .Include(rec => rec.Ingredients)
                                .Include(rec => rec.Directions)
                           where r.Title.Contains("brownie")
                           select r;

            foreach (var recipe in brownies.Take(5).ToList())
            {
                output.WriteLine(recipe.Title);
                output.WriteLine($"    Category: " + recipe.RecipeCategories.FirstOrDefault()?.Category?.Description);

                foreach (var ingredient in recipe.Ingredients.OrderBy(i => i.SortOrder))
                {
                    output.WriteLine($"{ingredient.Units} {ingredient.UnitType}: {ingredient.Description}");
                }

                foreach (var directionLine in recipe.Directions.OrderBy(d => d.LineNumber))
                {
                    output.WriteLine(directionLine.Description);
                }
            }
        }

        [Fact]
        public void Recipe_Projections()
        {
            var brownies = from r in dc.Recipes
                           where r.Title.Contains("Brownie")
                           select new
                           {
                               r.Title,
                               Categories = r.RecipeCategories.Select(rc => rc.Category.Description),
                               Ingredients = r.Ingredients.OrderBy(i => i.SortOrder),
                               Directions = r.Directions.OrderBy(d => d.LineNumber).Select(d => d.Description)
                           };

            foreach (var recipe in brownies.Take(5).ToList())
            {
                output.WriteLine(recipe.Title);
                foreach (var category in recipe.Categories)
                {
                    output.WriteLine($"    Category: " + category);
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    output.WriteLine($"{ingredient.Units} {ingredient.UnitType}: {ingredient.Description}");
                }

                foreach (var directionLine in recipe.Directions)
                {
                    output.WriteLine(directionLine);
                }
            }
        }

        [Fact]
        public void Recipe_WithoutNavigationProperties()
        {
            var brownies = from r in dc.Recipes
                           where r.Title.Contains("Brownie")
                           select new
                           {
                               r.Title,
                               Categories = dc.RecipeCategory.Where(rc => rc.RecipeId == r.Id).Select(rc => rc.Category.Description),
                               Ingredients = dc.Ingredients.Where(i => i.RecipeId == r.Id).OrderBy(i => i.SortOrder),
                               Directions = dc.Directions.Where(d => d.RecipeId == r.Id).OrderBy(d => d.LineNumber).Select(d => d.Description)
                           };

            foreach (var recipe in brownies.Take(5).ToList())
            {
                output.WriteLine(recipe.Title);
                foreach (var category in recipe.Categories)
                {
                    output.WriteLine($"    Category: " + category);
                }

                foreach (var ingredient in recipe.Ingredients)
                {
                    output.WriteLine($"{ingredient.Units} {ingredient.UnitType}: {ingredient.Description}");
                }

                foreach (var directionLine in recipe.Directions)
                {
                    output.WriteLine(directionLine);
                }
            }
        }

    }
}
