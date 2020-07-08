using System.Collections.Generic;
using AutoLot.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.Extensions.Logging;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : BaseCrudController<Car, CarsController>
    {

        public CarsController(ICarRepo carRepo, ILogger<CarsController> logger) : base(carRepo, logger)
        {
        }

        [HttpGet("bymake/{id?}")]
        public ActionResult<IEnumerable<Car>> GetCarsByMake(int? id)
        {
            if (id.HasValue && id.Value>0)
            {
                return Ok(((ICarRepo)MainRepo).GetAllBy(id.Value));
            }
            return Ok(MainRepo.GetAllIgnoreQueryFilters());
        }
    }
}