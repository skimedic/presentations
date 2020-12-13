using AutoLot.Api.Controllers.Base;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Services.Logging;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : BaseCrudController<Make, MakesController>
    {
        public MakesController(IMakeRepo makeRepo, IAppLogging<MakesController> logger) : base(makeRepo, logger)
        {
        }
    }
}