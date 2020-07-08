using AutoLot.Api.Controllers.Base;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AutoLot.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : BaseCrudController<Order, OrdersController>
    {
        public OrdersController(IOrderRepo orderRepo, ILogger<OrdersController> logger) : base(orderRepo, logger)
        {
        }
    }
}