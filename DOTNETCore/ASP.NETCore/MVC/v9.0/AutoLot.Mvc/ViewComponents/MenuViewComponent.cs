// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Mvc - MenuViewComponent.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/03
// ==================================

namespace AutoLot.Mvc.ViewComponents;

public class MenuViewComponent(IMakeRepo makeRepo) : ViewComponent
{
    //public IViewComponentResult Invoke()
    //{
    //    var makes = makeRepo.GetAll().ToList();
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
            var makes = makeRepo.GetAll().ToList();
            if (!makes.Any())
            {
                return new ContentViewComponentResult("Unable to get the makes");
            }
            return View("MenuView", makes);
        });
    }
}
