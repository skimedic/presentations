// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - RadiosController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class RadiosController(IAppLogging logger, IRadioRepo repo)
    : BaseCrudController<Radio>(logger, repo);