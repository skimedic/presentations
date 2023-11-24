// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Mvc - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Mvc.Controllers.Base;

[Route("[controller]/[action]")]
public abstract class BaseCrudController<TEntity, TController> : Controller where TEntity : BaseEntity, new()
{
    protected readonly IAppLogging<TController> AppLoggingInstance;
    protected readonly IBaseRepo<TEntity> BaseRepoInstance;

    protected BaseCrudController(IAppLogging<TController> appLogging, IBaseRepo<TEntity> baseRepo)
    {
        AppLoggingInstance = appLogging;
        BaseRepoInstance = baseRepo;
    }

    protected abstract SelectList GetLookupValues();
    protected TEntity GetOneEntity(int? id) => id == null ? null : BaseRepoInstance.Find(id.Value);

    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    [HttpGet]
    public virtual IActionResult Index() => View(BaseRepoInstance.GetAllIgnoreQueryFilters());

    [HttpGet("{id?}")]
    //[HttpGet("/[controller]/[action]/{id?}")]
    //[HttpGet("foo/bar/{id?}")]
    public virtual IActionResult Details(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        var entity = GetOneEntity(id);
        if (entity == null)
        {
            return NotFound();
        }

        return View(entity);
    }

    [HttpGet]
    public virtual IActionResult Create()
    {
        ViewData["LookupValues"] = GetLookupValues();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public virtual IActionResult Create(TEntity entity)
    {
        if (ModelState.IsValid)
        {
            BaseRepoInstance.Add(entity);
            return RedirectToAction(nameof(Details),new {entity.Id});
        }
        ViewData["LookupValues"] = GetLookupValues();
        return View(entity);
    }

    [HttpGet("{id?}")]
    public virtual IActionResult Edit(int? id)
    {
        var entity = GetOneEntity(id);
        if (entity == null)
        {
            return NotFound();
        }
        ViewData["LookupValues"] = GetLookupValues();
        return View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public virtual IActionResult Edit(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            BaseRepoInstance.Update(entity);
            return RedirectToAction(nameof(Details), new {entity.Id});
        }
        ViewData["LookupValues"] = GetLookupValues();
        return View(entity);
    }

    [HttpGet("{id?}")]
    public virtual IActionResult Delete(int? id)
    {
        var entity = GetOneEntity(id);
        if (entity == null)
        {
            return NotFound();
        }
        return View(entity);
    }

    [HttpPost("{id}")]
    [ValidateAntiForgeryToken]
    public virtual IActionResult Delete(int id, TEntity entity)
    {
        BaseRepoInstance.Delete(entity);
        return RedirectToAction(nameof(Index));
    }
}