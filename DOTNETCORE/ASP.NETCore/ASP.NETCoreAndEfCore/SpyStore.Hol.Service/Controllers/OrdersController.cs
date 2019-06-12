using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrdersController(IOrderRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get Order History for a customer (top line only)
        /// </summary>
        /// <param name="customerId"></param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/OrdersController/1
        /// </remarks>
        /// <returns>Order History</returns>
        /// <response code="200">Returns order history for a customer.</response>
        /// <response code="404">Order history unable to be located</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{customerId}", Name = "GetOrderHistory")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetOrderHistory(int customerId)
        {
            _repo.Context.CustomerId = customerId;
            IList<Order> orderWithTotals = _repo.GetOrderHistory();
            return orderWithTotals == null ? (IActionResult) NotFound() : new ObjectResult(orderWithTotals);
        }
    }
}