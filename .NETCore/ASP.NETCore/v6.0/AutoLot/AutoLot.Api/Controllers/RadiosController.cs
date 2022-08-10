// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - RadiosController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Api.Controllers;

public class RadiosController : BaseCrudController<Radio, RadiosController>
{
    public RadiosController(IAppLogging<RadiosController> logger,IRadioRepo repo)
        : base(logger, repo)
    {
    }
}