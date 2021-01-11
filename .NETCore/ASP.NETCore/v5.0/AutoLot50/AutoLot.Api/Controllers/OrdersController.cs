using AutoLot.Api.Controllers.Base;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : BaseCrudController<Order, OrdersController>
    {
        public OrdersController(IOrderRepo orderRepo, IAppLogging<OrdersController> logger) : base(orderRepo, logger)
        {
        }
    }
}