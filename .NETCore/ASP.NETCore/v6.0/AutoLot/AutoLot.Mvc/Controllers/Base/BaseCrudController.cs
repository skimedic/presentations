// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Mvc.Controllers.Base;

[Route("[controller]/[action]")]
public abstract class BaseCrudController<TEntity, TController> : Controller
    where TEntity : BaseEntity, new()
    where TController : class
{
    protected readonly IAppLogging<TController> AppLoggingInstance;
    protected readonly IDataServiceBase<TEntity> MainDataService;

    protected BaseCrudController(
	IAppLogging<TController> appLogging, 
	IDataServiceBase<TEntity> mainDataService)
    {
        AppLoggingInstance = appLogging;
        MainDataService = mainDataService;
    }
    
    //[BindProperty]
    //public TEntity Entity { get; set; }


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
    public virtual async Task<IActionResult> CreateAsync(TEntity entity)
    {
        if (ModelState.IsValid)
        {
            await MainDataService.AddAsync(entity);
            return RedirectToAction(nameof(DetailsAsync).RemoveAsyncSuffix(),new {id = entity.Id});
        }
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(entity);
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
    public virtual async Task<IActionResult> EditAsync(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            ViewData["Error"] = "Bad Request";
            return View();
        }
        if (ModelState.IsValid)
        {
            await MainDataService.UpdateAsync(entity);
            return RedirectToAction(nameof(DetailsAsync).RemoveAsyncSuffix(),new {id});
        }
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(entity);
    }

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> DeleteAsync(int? id)
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
    public virtual async Task<IActionResult> DeleteAsync(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            ViewData["Error"] = "Bad Request";
            return View();
        }
        try
        {
            await MainDataService.DeleteAsync(entity);
            return RedirectToAction(nameof(IndexAsync).RemoveAsyncSuffix());
        }
        catch (Exception ex)
        {
            ModelState.Clear();
            ModelState.AddModelError(string.Empty, ex.Message);
            MainDataService.ResetChangeTracker();
            entity = await GetOneEntityAsync(id);
            return View(entity);
        }
    }
}