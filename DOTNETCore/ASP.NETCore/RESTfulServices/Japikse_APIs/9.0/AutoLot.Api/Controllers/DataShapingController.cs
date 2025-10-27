// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - DataShapingController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace AutoLot.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DataShapingController(IDriverRepo driverRepo,IDataShaper<Driver> dataShaper) : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetFromQuery([FromQuery] string fields) => Ok(dataShaper.ShapeData(driverRepo.GetAll(), fields));

    [HttpPost("{id}")]
    public IActionResult UpdateDriverFromValues(int id, [FromQuery] string values)
    {
        var convertedValues = JsonSerializer.Deserialize<Dictionary<string, string>>(values);
        var driver = driverRepo.Find(id);
        dataShaper.UpdateData(driver, convertedValues);
        driverRepo.Update(driver);
        return Ok(driver);
    }
}