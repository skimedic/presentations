namespace AutoLot.Mvc.Controllers.Base;

[Route("[controller]/[action]")]
public abstract class BaseCrudWithBindingPropertyController<TEntity, TController> : Controller
    where TEntity : BaseEntity, new()
    where TController : class
{
    protected readonly IAppLogging<TController> AppLoggingInstance;
    protected readonly IDataServiceBase<TEntity> MainDataService;

    protected BaseCrudWithBindingPropertyController(
	IAppLogging<TController> appLogging, 
	IDataServiceBase<TEntity> mainDataService)
    {
        AppLoggingInstance = appLogging;
        MainDataService = mainDataService;
    }
    
    [BindProperty]
    public TEntity Entity { get; set; }


    protected async Task<TEntity> GetOneEntityAsync(int id)
        => await MainDataService.FindAsync(id);

    protected abstract Task<SelectList> GetLookupValuesAsync();

    [HttpGet]
    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    public virtual async Task<IActionResult> IndexAsync()
        => View(await MainDataService.GetAllAsync());

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> DetailsAsync(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var entity = await GetOneEntityAsync(id.Value);
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    [HttpGet]
    public virtual async Task<IActionResult> CreateAsync()
    {
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Create")]
    public virtual async Task<IActionResult> CreatePostAsync()
    {
        if (ModelState.IsValid)
        {
            await MainDataService.AddAsync(Entity);
            return RedirectToAction(nameof(DetailsAsync).RemoveAsyncSuffix(),new {id = Entity.Id});
        }
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(Entity);
    }

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> EditAsync(int? id)
    {
        if (!id.HasValue)
        {
            ViewData["Error"] = "Bad Request";
            return View();
        }

        var entity = await GetOneEntityAsync(id.Value);
        if (entity == null)
        {
            ViewData["Error"] = "Not Found";
            return View();
        }

        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    [ActionName("Edit")]
    public virtual async Task<IActionResult> EditPostAsync(int id)
    {
        if (id != Entity.Id)
        {
            ViewData["Error"] = "Bad Request";
            return View();
        }
        if (ModelState.IsValid)
        {
            await MainDataService.UpdateAsync(Entity);
            return RedirectToAction(nameof(DetailsAsync).RemoveAsyncSuffix(),new {id});
        }
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(Entity);
    }

    [HttpGet("{id?}")]
    [ActionName("Delete")]
    public virtual async Task<IActionResult> DeletePostAsync(int? id)
    {
        if (!id.HasValue)
        {
            ViewData["Error"] = "Bad Request";
            return View();
        }

        var entity = await GetOneEntityAsync(id.Value);
        if (entity == null)
        {
            ViewData["Error"] = "Not Found";
            return View();
        }

        return View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> DeleteAsync(int id)
    {
        if (id != Entity.Id)
        {
            ViewData["Error"] = "Bad Request";
            return View();
        }
        try
        {
            await MainDataService.DeleteAsync(Entity);
            return RedirectToAction(nameof(IndexAsync).RemoveAsyncSuffix());
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            ModelState.AddModelError(string.Empty, ex.Message);
            MainDataService.ResetChangeTracker();
            Entity = await GetOneEntityAsync(id);
            return View(Entity);
        }
    }
}