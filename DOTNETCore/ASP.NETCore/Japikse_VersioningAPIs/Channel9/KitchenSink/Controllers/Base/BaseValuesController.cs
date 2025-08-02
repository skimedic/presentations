// Copyright Information
// ==================================
// Japikse_VersioningDocumentingAPIs - KitchenSink - BaseValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/25
// ==================================

namespace KitchenSink.Controllers.Base;

[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public abstract class BaseValuesController : ControllerBase
{
}