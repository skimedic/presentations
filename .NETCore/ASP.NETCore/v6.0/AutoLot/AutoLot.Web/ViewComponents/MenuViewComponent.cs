namespace AutoLot.Web.ViewComponents;

//https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components
//The runtime searches for the view in the following paths:
//    Views/<controller_name>/Components/<view_component_name>/<view_name>
//    Views/Shared/Components/<view_component_name>/<view_name>
//    /Pages/Shared/Components/<View Component Name>/<View Name>

public class MenuViewComponent : ViewComponent
{
    private readonly IMakeDataService _dataService;

    public MenuViewComponent(IMakeDataService dataService)
    {
        _dataService = dataService;
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
        var makes = (await _dataService.GetAllAsync()).ToList();
        if (!makes.Any())
        {
            return new ContentViewComponentResult("Unable to get the makes");
        }

        return View("MenuView", makes);
    }
}
