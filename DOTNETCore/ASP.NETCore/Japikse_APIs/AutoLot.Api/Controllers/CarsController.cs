// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Api.Controllers;

public class CarsController(IAppLogging<CarsController> logger, ICarRepo repo)
    : BaseCrudController<Car, CarsController>(logger, repo)
{
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

    [ApiVersion("1.0")]
    [HttpGet("ProblemDetails")]
    public IActionResult ShowProblemDetails()
    {
        return NotFound();
    }
}