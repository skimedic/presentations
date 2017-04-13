using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recipe
{
    [Table("Recipe")]
    public class Recipe
    {
        public long Id {get;set;}
        public string Title {get;set;}
        public string ServingMeasure {get;set;}
        public decimal ServingQuantity {get;set;}
    }

    public class RecipeContext : DbContext
    {
        public DbSet<Recipe> Recipes {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("data source=.;initial catalog=recipecore;integrated security=true;");
        } 
    }
}