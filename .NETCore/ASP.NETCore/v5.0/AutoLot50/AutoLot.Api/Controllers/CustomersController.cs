// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - CustomersController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using AutoLot.Api.Controllers.Base;
using AutoLot.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : BaseCrudController<Customer, CustomersController>
    {
        public CustomersController(ICustomerRepo customerRepo, IAppLogging<CustomersController> logger) : base(customerRepo, logger)
        {
        }
    }
}