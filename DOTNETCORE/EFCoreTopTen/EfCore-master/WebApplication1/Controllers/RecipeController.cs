using Microsoft.AspNetCore.Mvc;
using Recipe.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeContext _Context;

        public RecipeController(RecipeContext context)
        {
            _Context = context;
        }

        [HttpGet]
        [Route("api/Recipe/Get")]
        public IQueryable<Recipe.Dal.Models.Recipe> GetRecipes()
        {
            return _Context.Recipes.Take(50);
        }
    }
}
