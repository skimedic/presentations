// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - CarDriversController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion(1.0)]
public class CarDriversController(IAppLogging logger, ICarDriverRepo repo)
    : BaseCrudController<CarDriver>(logger, repo);