// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Mvc - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Mvc.ViewComponents;
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
    //public IViewComponentResult Invoke()
    //{
    //    var makes = _makeRepo.GetAll().ToList();
    //    if (!makes.Any())
    //    {
    //        return new ContentViewComponentResult("Unable to get the makes");
    //    }
    //    return View("MenuView", makes);
    //}
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return await Task.Run<IViewComponentResult>(() =>
        {
            var makes = _makeRepo.GetAll().ToList();
            if (!makes.Any())
            {
                return new ContentViewComponentResult("Unable to get the makes");
            }

            return View("MenuView", makes);
        });
    }
}