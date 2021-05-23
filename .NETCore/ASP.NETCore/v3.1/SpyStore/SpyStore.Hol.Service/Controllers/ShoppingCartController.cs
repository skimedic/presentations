using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Service.Controllers
{
  [Route("api/[controller]/{customerId}")]
  [ApiController]
  public class ShoppingCartController : ControllerBase
  {
    private readonly IShoppingCartRepo _repo;

    public ShoppingCartController(IShoppingCartRepo repo)
    {
      _repo = repo;
    }

    /// <summary>
    /// Get Shopping Cart Records for a customer.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET /api/ShoppingCart/1
    /// </remarks>
    /// <param name="customerId">Primary Key of the Customer</param>
    /// <response code="200">Returns all Shopping Cart Records for the customer</response>
    /// <response code="204">Returned when no content in the response</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpGet(Name = "GetShoppingCart")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<CartWithCustomerInfo> GetShoppingCart(int customerId) 
      => _repo.GetShoppingCartRecordsWithCustomer(customerId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="customer"></param>
    /// <returns></returns>
    [HttpPost("buy", Name = "Purchase")]
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    public IActionResult Purchase(int customerId, Customer customer)
    {
      if (customer == null || customer.Id != customerId || !ModelState.IsValid)
      {
        return BadRequest();
      }

      int orderId;
      orderId = _repo.Purchase(customerId);
      //Location: http://localhost:8477/api/OrderDetails/2
      return CreatedAtRoute("GetOrderDetails",
        routeValues: new {orderId = orderId},null);
    }
  }
}