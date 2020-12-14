// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Linq;
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
        private readonly IMakeRepo _makeRepo;

        public MenuViewComponent(IMakeRepo makeRepo)
        {
            _makeRepo = makeRepo;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        public IViewComponentResult Invoke()
        {
            var makes = _makeRepo.GetAll().ToList();
            if (!makes.Any())
            {
                return new ContentViewComponentResult("Unable to get the makes");
            }

            return View("MenuView", makes);
        }

    }
}
