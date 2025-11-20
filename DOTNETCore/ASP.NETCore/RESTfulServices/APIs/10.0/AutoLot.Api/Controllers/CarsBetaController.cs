// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/12
// ==================================

namespace AutoLot.Api.Controllers;

//[ApiVersion("2.1-Beta")]
public class Cars2Controller(IAppLogging logger, ICarRepo repo)
    : BaseCrudController<Car>(logger, repo)
{
    /// <summary>
    /// Gets all records really fast (when it’s written)
    /// </summary>
    /// <returns>All records</returns>
    [ApiVersion("2.5-Beta")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllFuture()
    {
        throw new NotImplementedException("I'm working on it");
    }
    /// <summary>
    /// Gets all records really fast (when it’s written)
    /// </summary>
    /// <returns>All records</returns>
    [ApiVersion("3.0-Beta")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAllFutureBeta()
    {
        throw new NotImplementedException("I'm working on it");
    }
}