using AutoLot.Api.Controllers.Base;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class CreditRisksController : BaseCrudController<CreditRisk, CreditRisksController>
    {
        public CreditRisksController(ICreditRiskRepo creditRiskRepo, ILogger<CreditRisksController> logger) : base(creditRiskRepo, logger)
        {
        }
    }
}