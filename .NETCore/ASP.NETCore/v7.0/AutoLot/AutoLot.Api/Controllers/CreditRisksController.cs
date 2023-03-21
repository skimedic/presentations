// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Api - CreditRisksController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/26
// ==================================

namespace AutoLot.Api.Controllers;

public class CreditRisksController : BaseCrudController<CreditRisk, CreditRisksController>
{
    public CreditRisksController(IAppLogging<CreditRisksController> logger, ICreditRiskRepo repo )
        : base(logger,repo)
    {
    }
}