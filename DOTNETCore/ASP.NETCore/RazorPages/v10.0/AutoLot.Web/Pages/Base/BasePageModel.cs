// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - BasePageModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity>(
    IAppLogging appLoggingInstance,
    IBaseRepo<TEntity> baseRepoInstance,
    string pageTitle) : PageModel where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging AppLoggingInstance = appLoggingInstance;
    protected readonly IBaseRepo<TEntity> BaseRepoInstance = baseRepoInstance;

    [ViewData]
    public string Title { get; init; } = pageTitle;

    [BindProperty]
    public TEntity Entity { get; set; }
    public SelectList LookupValues { get; set; }
    public string Error { get; set; }

    protected virtual void GetLookupValues()
    {
        LookupValues = null;
    }

    protected virtual void GetOne(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }
        Entity = BaseRepoInstance.Find(id.Value);
        if (Entity == null)
        {
            Error = "Not found";
            return;
        }
        Error = string.Empty;
    }

    protected virtual IActionResult SaveOne(Func<TEntity,bool,int> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        try
        {
            saveFunction(Entity, true);
            return RedirectToPage("./Details", new { id = Entity.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return HandleErrorReturnPage(ex);
        }
    }
    protected virtual IActionResult SaveWithLookup(Func<TEntity,bool,int> saveFunction)
    {
        if (!ModelState.IsValid)
        {
            GetLookupValues();
            return Page();
        }
        try
        {
            saveFunction(Entity, true);
            return RedirectToPage("./Details", new { id = Entity.Id });
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            GetLookupValues();
            return HandleErrorReturnPage(ex);
        }
    }

    protected virtual IActionResult DeleteOne(int id)
    {
        try
        {
            //throw new Exception("Test");
            BaseRepoInstance.Delete(Entity);
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            Entity = BaseRepoInstance.Find(id);
            return HandleErrorReturnPage(ex);
        }
    }

    internal IActionResult HandleErrorReturnPage(Exception ex)
    {
        Error = ex.Message;
        AppLoggingInstance.LogAppError(ex, "An error occurred");
        return Page();
    }
}
