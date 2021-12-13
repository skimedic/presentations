namespace AutoLot.Web.Pages.Base;

public abstract class BasePageModel<TEntity, TPageModel> : PageModel
    where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging<TPageModel> AppLoggingInstance;
    protected readonly IDataServiceBase<TEntity> DataService;

    [ViewData]
    public string Title { get; init; }

    protected BasePageModel(IAppLogging<TPageModel> appLogging, IDataServiceBase<TEntity> dataService, string pageTitle)
    {
        AppLoggingInstance = appLogging;
        DataService = dataService;
        Title = pageTitle;
    }

    [BindProperty]
    public TEntity Entity { get; set; }
    public SelectList LookupValues { get; set; }
    public string Error { get; set; }

    protected async Task GetLookupValuesAsync<TLookupEntity>(
        IDataServiceBase<TLookupEntity> lookupService, string lookupKey, string lookupDisplay)
        where TLookupEntity : BaseEntity, new()
    {
        LookupValues = new(await lookupService.GetAllAsync(), lookupKey, lookupDisplay);
    }

    protected async Task GetOneAsync(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }

        Entity = await DataService.FindAsync(id.Value);
        if (Entity == null)
        {
            Error = "Not found";
            return;
        }

        Error = string.Empty;
    }

    protected virtual async Task<IActionResult> SaveOneAsync(Func<TEntity, bool, Task<TEntity>> persistenceTask)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await persistenceTask(Entity, true);
        }
        catch (Exception ex)
        {
            Error = ex.Message;
            ModelState.AddModelError(string.Empty, ex.Message);
            AppLoggingInstance.LogAppError(ex, "An error occurred");
            return Page();
        }

        return RedirectToPage("./Details", new { id = Entity.Id });
    }

    protected virtual async Task<IActionResult> SaveWithLookupAsync<TLookupEntity>(
        Func<TEntity, bool, Task<TEntity>> persistenceTask, 
        IDataServiceBase<TLookupEntity> lookupService,string lookupKey, string lookupDisplay)
        where TLookupEntity : BaseEntity, new()
    {
        if (!ModelState.IsValid)
        {
            await GetLookupValuesAsync(lookupService, lookupKey, lookupDisplay);
            return Page();
        }

        try
        {
            await persistenceTask(Entity, true);
        }
        catch (Exception ex)
        {
            Error = ex.Message;
            ModelState.AddModelError(string.Empty, ex.Message);
            await GetLookupValuesAsync(lookupService, lookupKey, lookupDisplay);
            AppLoggingInstance.LogAppError(ex, "An error occurred");
            return Page();
        }

        return RedirectToPage("./Details", new { id = Entity.Id });
    }

    public async Task<IActionResult> DeleteOneAsync(int? id)
    {

        if (!id.HasValue || id.Value != Entity.Id)
        {
            Error = "Bad Request";
            return Page();
        }

        try
        {
            await DataService.DeleteAsync(Entity);
            return RedirectToPage("./Index");
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            DataService.ResetChangeTracker();
            Entity = await DataService.FindAsync(id.Value);
            Error = ex.Message;
            AppLoggingInstance.LogAppError(ex, "An error occurred");
            return Page();
        }

    }
}