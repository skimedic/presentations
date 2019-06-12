using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc.ViewComponents
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
    //The runtime searches for the view in the following paths:
    //    Views/<controller_name>/Components/<view_component_name>/<view_name>
    //    Views/Shared/Components/<view_component_name>/<view_name>
    //    /Pages/Shared/Components/<View Component Name>/<View Name>
    public class Menu : ViewComponent
    {
        private readonly SpyStoreServiceWrapper _serviceWrapper;

        public Menu(SpyStoreServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cats = await _serviceWrapper.GetCategoriesAsync();
            if (cats == null)
            {
                return new ContentViewComponentResult("There was an error getting the categories");
            }

            return View("MenuView", cats);
        }
    }
}