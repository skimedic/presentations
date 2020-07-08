using System.Threading.Tasks;
using AutoLot.Dal.Models.Entities;
using AutoLot.Mvc.ServiceInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AutoLot.Mvc.ViewComponents
{
    //https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
    //The runtime searches for the view in the following paths:
    //    Views/<controller_name>/Components/<view_component_name>/<view_name>
    //    Views/Shared/Components/<view_component_name>/<view_name>
    //    /Pages/Shared/Components/<View Component Name>/<View Name>

    public class MenuViewComponent : ViewComponent
    {
        private readonly IAutoLotServiceWrapper _serviceWrapper;

        public MenuViewComponent(IAutoLotServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        //public IViewComponentResult Invoke()
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var makes = await _serviceWrapper.GetAllAsync<Make>();
            if (makes == null)
            {
                return new ContentViewComponentResult("Unable to get the makes");
            }

            return View("MenuView", makes);
        }

    }
}
