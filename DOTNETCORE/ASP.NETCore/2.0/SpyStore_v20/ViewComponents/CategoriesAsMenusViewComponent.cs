using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SpyStoreDAL.Repos.Interfaces;

namespace SpyStore_v20.ViewComponents
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
    //The runtime searches for the view in the following paths:
    //    Views/<controller_name>/Components/<view_component_name>/<view_name>
    //    Views/Shared/Components/<view_component_name>/<view_name>
    public class CategoriesAsMenusViewComponent : ViewComponent
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoriesAsMenusViewComponent(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run<IViewComponentResult>(() =>
            {
                var cats = _categoryRepo.GetAll();
                if (cats == null)
                {
                    return new ContentViewComponentResult("There was an error getting the categories");
                }
                return View("MenuView", cats);
            });
        }
    }
}
