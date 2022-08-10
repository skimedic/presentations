// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Api.Controllers;

public class MakesController : BaseCrudController<Make, MakesController>
{
    public MakesController(IAppLogging<MakesController> logger, IMakeRepo repo)
        : base(logger, repo)
    {
    }
}
