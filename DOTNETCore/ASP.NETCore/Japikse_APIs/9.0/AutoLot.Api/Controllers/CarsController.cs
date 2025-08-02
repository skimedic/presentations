// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Api.Controllers;

public class CarsController(IAppLogging<CarsController> logger, ICarRepo repo)
    : BaseCrudController<Car, CarsController>(logger, repo)
{
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