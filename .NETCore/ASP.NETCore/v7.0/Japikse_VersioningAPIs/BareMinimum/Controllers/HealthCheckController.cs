// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - BareMinimum - HealthCheckController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace BareMinimum.Controllers;

[ApiVersionNeutral]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class HealthCheckController : Controller
{
    // OPTIONS ~/api/myservice?api-version=[1.0|1.5|2.0|3.0]
    [HttpOptions]
    public IActionResult Options()
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();

        var response = new HttpResponseMessage
        {
            Content = new StringContent(string.Empty),
            StatusCode = HttpStatusCode.OK,
            Version = new Version(version?.MajorVersion ?? 0, version?.MinorVersion ?? 0)
        };
        response.Content.Headers.Add("Allow", new[] { "GET", "POST", "OPTIONS" });
        response.Content.Headers.ContentType = null;
        return Ok(response);
    }
    [HttpGet]
    public string Get([FromServices] ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    public string Get()
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}";
    }

}