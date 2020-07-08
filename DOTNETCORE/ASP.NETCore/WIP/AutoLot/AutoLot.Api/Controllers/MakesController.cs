using AutoLot.Api.Controllers.Base;
using AutoLot.Dal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class MakesController : BaseCrudController<Make, MakesController>
    {
        public MakesController(IMakeRepo makeRepo, ILogger<MakesController> logger) : base(makeRepo, logger)
        {
        }
    }
}