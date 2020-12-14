// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Linq;
using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Services.ApiWrapper;
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
        private readonly IApiServiceWrapper _serviceWrapper;
        private readonly IMakeRepo _makeRepo;

        public MenuViewComponent(IApiServiceWrapper serviceWrapper, IMakeRepo makeRepo)
        {
            _serviceWrapper = serviceWrapper;
            _makeRepo = makeRepo;
        }

        public IViewComponentResult Invoke()
        {
            var makes = _makeRepo.GetAll().ToList();
            if (!makes.Any())
            {
                return new ContentViewComponentResult("Unable to get the makes");
            }

            return View("MenuView", makes);
        }
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var makes = await _serviceWrapper.GetMakesAsync();
        //    if (makes == null)
        //    {
        //        return new ContentViewComponentResult("Unable to get the makes");
        //    }
        //    return View("MenuView", makes);
        //}
    }
}
