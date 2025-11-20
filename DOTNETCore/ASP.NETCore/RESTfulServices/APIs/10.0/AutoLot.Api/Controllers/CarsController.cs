// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/12
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion("1.0")]
//[ApiVersion("2.0")]
//[AdvertiseApiVersions("2.0")]
//[AdvertiseApiVersions("3.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CarsController(IAppLogging logger, ICarRepo repo)
    : BaseCrudController<Car>(logger, repo)
{
    /// <summary>
    /// Gets all cars by make
    /// </summary>
    /// <returns>All cars for a make</returns>
    /// <param name="id">Primary key of the make</param>
    [Produces("application/json")]
    [ProducesResponseType<IEnumerable<Car>>(StatusCodes.Status200OK,Description="Success")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<IEnumerable<Car>>(StatusCodes.Status200OK, Description = "Failure")]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("bymake/{id?}")]
    public ActionResult<IEnumerable<Car>> GetCarsByMake([Description("The PK of the car")]int? id)
    {
        if (id is > 0)
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
    [ApiVersion("1.5", Deprecated = true)]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllBad()
    {
        throw new Exception("I said not to use this one");
    }


}