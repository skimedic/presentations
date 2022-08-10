// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Api.Controllers;

public class CarDriversController : BaseCrudController<CarDriver, CarDriversController>
{
    public CarDriversController(IAppLogging<CarDriversController> logger, ICarDriverRepo repo )
        : base(logger,repo)
    {
    }
}