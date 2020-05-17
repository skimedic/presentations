using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AutoLot.Web.ViewComponents
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
    //The runtime searches for the view in the following paths:
    //    Views/<controller_name>/Components/<view_component_name>/<view_name>
    //    Views/Shared/Components/<view_component_name>/<view_name>
    //    /Pages/Shared/Components/<View Component Name>/<View Name>

    public class MenuViewComponent : ViewComponent
    {
        private readonly IMakeRepo _repo;

        public MenuViewComponent(IMakeRepo repo)
        {
            _repo = repo;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        public IViewComponentResult Invoke()
        {
                var makes = _repo.GetAll();
                if (makes == null)
                {
                    return new ContentViewComponentResult("There was an error getting the makes");
                }

                return View("MenuView", makes);

        }

    }
}
