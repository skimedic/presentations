// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - DriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Api.Controllers;

public class DriversController : BaseCrudController<Driver, DriversController>
{
    public DriversController(IAppLogging<DriversController> logger, IDriverRepo repo)
        : base(logger, repo)
    {
    }
}