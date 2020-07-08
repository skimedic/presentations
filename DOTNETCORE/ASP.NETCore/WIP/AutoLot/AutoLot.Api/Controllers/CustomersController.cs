using AutoLot.Api.Controllers.Base;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseCrudController<Customer, CustomersController>
    {
        public CustomersController(ICustomerRepo customerRepo, ILogger<CustomersController> logger) : base(customerRepo, logger)
        {
        }
    }
}