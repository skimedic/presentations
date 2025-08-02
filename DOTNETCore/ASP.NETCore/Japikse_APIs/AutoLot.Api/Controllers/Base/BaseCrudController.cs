// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - BaseCrudController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Api.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseCrudController<TEntity, TController>(
    IAppLogging<TController> logger,
    IBaseRepo<TEntity> repo)
    : ControllerBase
    where TEntity : BaseEntity, new()
    where TController : class
{
    protected readonly IBaseRepo<TEntity> MainRepo = repo;
    protected readonly IAppLogging<TController> Logger = logger;

    [HttpGet]
    public ActionResult<IEnumerable<TEntity>> GetAll()
    {
        return Ok(MainRepo.GetAllIgnoreQueryFilters());
    }

    [HttpGet("{id}")]
    public ActionResult<TEntity> GetOne(int id)
    {
        var entity = MainRepo.Find(id);
        if (entity == null)
        {
            return NoContent();
        }

        return Ok(entity);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOne(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            MainRepo.Update(entity);
        }
        catch (CustomException ex)
        {
            //This shows an example with the custom exception
            //Should handle more gracefully
            return BadRequest(ex);
        }
        catch (Exception ex)
        {
            //Should handle more gracefully
            return BadRequest(ex);
        }

        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<TEntity> AddOne(TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        try
        {
            MainRepo.Add(entity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

        return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
    }

    [HttpDelete("{id}")]
    public ActionResult<TEntity> DeleteOne(int id, TEntity entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        try
        {
            MainRepo.Delete(entity);
        }
        catch (Exception ex)
        {
            //Should handle more gracefully
            return new BadRequestObjectResult(ex.GetBaseException()?.Message);
        }

        return Ok();
    }
}