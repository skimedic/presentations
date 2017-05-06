using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SpyStore_HOL.DAL.Repos.Interfaces;

namespace SpyStore_HOL.MVC.ViewComponents
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
    //The runtime searches for the view in the following paths:
    //    Views/<controller_name>/Components/<view_component_name>/<view_name>
    //    Views/Shared/Components/<view_component_name>/<view_name>
public class Menu : ViewComponent
{
    private readonly ICategoryRepo _categoryRepo;

    public Menu(ICategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cats = _categoryRepo.GetAll();
        if (cats == null)
        {
            return new ContentViewComponentResult("There was an error getting the categories");
        }
        return View("MenuView", cats);
    }
}
}
