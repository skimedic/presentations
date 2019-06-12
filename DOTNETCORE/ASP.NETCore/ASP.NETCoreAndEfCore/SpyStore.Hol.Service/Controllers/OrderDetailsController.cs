using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderRepo _repo;

        public OrderDetailsController(IOrderRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get order with Details for one customer
        /// </summary>
        /// <param name="orderId">Primary Key for the Order Table</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/OrderDetails/1
        /// </remarks>
        /// <returns>Order with Order Details</returns>
        /// <response code="200">Returns order with order details.</response>
        /// <response code="404">Order unable to be located</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{orderId}", Name = "GetOrderDetails")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult GetOrderWithDetailsForCustomer(int orderId)
        {
            OrderWithDetailsAndProductInfo orderWithDetails = _repo.GetOneWithDetails(orderId);
            return orderWithDetails == null ? (IActionResult) NotFound() : new ObjectResult(orderWithDetails);
        }
    }
}