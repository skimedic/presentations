﻿// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2021/11/13
// ==================================

namespace AutoLot.Mvc.ViewComponents;
//https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
//The runtime searches for the view in the following paths:
//    Views/<controller_name>/Components/<view_component_name>/<view_name>
//    Views/Shared/Components/<view_component_name>/<view_name>
//    /Pages/Shared/Components/<View Component Name>/<View Name>

public class MenuViewComponent : ViewComponent
{
    private readonly IMakeDataService _makeDataService;

    public MenuViewComponent(IMakeDataService makeDataService)
    {
        _makeDataService = makeDataService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var makes = (await _makeDataService.GetAllAsync()).ToList();
        if (!makes.Any())
        {
            return new ContentViewComponentResult("Unable to get the makes");
        }

        return View("MenuView", makes);
    }
}