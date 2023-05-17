namespace AutoLot.Api.Controllers;

public class CarsController : BaseCrudController<Car, CarsController>
{
    public CarsController(IAppLogging<CarsController> logger, ICarRepo repo)
        : base(logger, repo)
    {
    }


    [ApiVersionNeutral]
    [HttpGet("/[controller]/[action]/throwError")]
    public ActionResult ThrowError([FromServices]ICustomerRepo custRepo)
    {
        return NotFound();
    }
    [ApiVersionNeutral]
    [HttpGet("/[controller]/[action]/environ")]
    public ActionResult ThrowError([FromServices]IWebHostEnvironment environment)
    {
        return new OkObjectResult(environment);
    }
    /// <summary>
    /// Gets all cars by make
    /// </summary>
    /// <returns>All cars for a make</returns>
    /// <param name="id">Primary key of the make</param>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [ApiVersion("1.0")]
    [HttpGet("bymake/{id?}")]
    public ActionResult<IEnumerable<Car>> GetCarsByMake(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            return Ok(((ICarRepo)MainRepo).GetAllBy(id.Value));
        }

        return Ok(MainRepo.GetAllIgnoreQueryFilters());
    }
}