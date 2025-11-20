// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
//[ApiVersion("2.0")]
//[AdvertiseApiVersions("2.0")]
//[AdvertiseApiVersions("3.0")]
public class CarsController(IAppLogging logger, ICarRepo repo)
    : BaseCrudController<Car>(logger, repo)
{
    /// <summary>
    /// Gets all cars by make
    /// </summary>
    /// <returns>All cars for a make</returns>
    /// <param name="id">Primary key of the make</param>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status200OK, "The execution was successful")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request was invalid")]
    [HttpGet("bymake/{id?}")]
    public ActionResult<IEnumerable<Car>> GetCarsByMake(int? id)
    {
        if (id.HasValue && id.Value > 0)
        {
            return Ok(((ICarRepo)MainRepo).GetAllBy(id.Value));
        }
        return Ok(MainRepo.GetAllIgnoreQueryFilters());
    }

    /// <summary>
    /// Gets all records
    /// </summary>
    /// <returns>All records</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status200OK, "The execution was successful")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request was invalid")]
    [ApiVersion("1.5", Deprecated = true)]
    [HideEndpointInProduction]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllBad()
    {
        throw new Exception("I said not to use this one");
    }

    /// <summary>
    /// Gets all records really fast (when it’s written)
    /// </summary>
    /// <returns>All records</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status200OK, "The execution was successful")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request was invalid")]
    [ApiVersion("2.0-Beta")]
    [HideEndpointInProduction]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllFuture()
    {
        throw new NotImplementedException("I'm working on it");
    }
}