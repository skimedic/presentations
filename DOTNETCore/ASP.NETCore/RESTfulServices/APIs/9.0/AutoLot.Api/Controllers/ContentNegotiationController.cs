// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - ContentNegotiationController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;
[ApiController]
[ApiVersion(1.0)]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")] 
public class ContentNegotiationController : ControllerBase
{
    [HttpGet]
    [Produces("application/json","application/xml","text/csv")]

    public IActionResult Get(IDriverRepo driverRepo) => Ok(driverRepo.GetAll().ToList());
}