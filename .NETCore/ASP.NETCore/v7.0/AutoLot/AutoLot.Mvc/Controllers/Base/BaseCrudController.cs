// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2021/11/13
// ==================================

namespace AutoLot.Mvc.Controllers.Base;

[Route("[controller]/[action]")]
public abstract class BaseCrudController<TEntity, TController> : Controller where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging<TController> AppLoggingInstance;

    protected readonly IDataServiceBase<TEntity> MainDataService;
    protected BaseCrudController(IAppLogging<TController> appLogging, IDataServiceBase<TEntity> mainDataService)
    {
        AppLoggingInstance = appLogging;
        MainDataService = mainDataService;
    }

    protected abstract Task<SelectList> GetLookupValuesAsync();


    protected async Task<TEntity> GetOneEntityAsync(int? id)
        => id == null ? null : await MainDataService.FindAsync(id.Value);

    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    [HttpGet]
    public virtual async Task<IActionResult> IndexAsync()
        => View(await MainDataService.GetAllAsync());

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> DetailsAsync(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }
        var entity = await GetOneEntityAsync(id);
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
            var savedEntity = await MainDataService.AddAsync(entity);
            return RedirectToAction(nameof(DetailsAsync).RemoveAsyncSuffix(), new { savedEntity.Id });
        }
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(entity);
    }

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> EditAsync(int? id)
    {
        var entity = await GetOneEntityAsync(id);
        if (entity == null)
        {
            return NotFound();
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
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            await MainDataService.UpdateAsync(entity);
            return RedirectToAction(nameof(DetailsAsync).RemoveAsyncSuffix(), new { entity.Id });
        }
        ViewData["LookupValues"] = await GetLookupValuesAsync();
        return View(entity);
    }

    [HttpGet("{id?}")]
    public virtual async Task<IActionResult> DeleteAsync(int? id)
    {
        var entity = await GetOneEntityAsync(id);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]

    public virtual async Task<IActionResult> DeleteAsync(int id, TEntity entity)
    {
        await MainDataService.DeleteAsync(entity);
        return RedirectToAction(nameof(IndexAsync).RemoveAsyncSuffix());
    }
}