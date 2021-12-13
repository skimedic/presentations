namespace AutoLot.Api.Controllers;

public class RadiosController : BaseCrudController<Radio, RadiosController>
{
    public RadiosController(IAppLogging<RadiosController> logger,IRadioRepo repo)
        : base(logger, repo)
    {
    }
}