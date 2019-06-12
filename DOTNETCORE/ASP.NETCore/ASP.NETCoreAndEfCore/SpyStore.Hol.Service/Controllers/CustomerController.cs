using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Service.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerRepo _repo;
    public CustomerController(ICustomerRepo repo)
    {
      _repo = repo;
    }
    /// <summary>
    /// Get all customers.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET /api/Customer
    /// </remarks>
    /// <returns>List of all customers.</returns>
    /// <response code="200">Returns customers.</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpGet(Name = "GetAllCustomers")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<Customer>> Get() => Ok(_repo.GetAll().ToList());

    /// <summary>
    /// Gets a single customer.
    /// </summary>
    /// <param name="id">Primary Key of the customer to retrieve</param>
    /// <remarks>
    /// Sample request:
    ///     GET /api/Customer/1
    /// </remarks>
    /// <returns>Customer</returns>
    /// <response code="200">Returns single customer.</response>
    /// <response code="404">Returned when customer with specific id doesn't exist.</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpGet("{id}", Name = "GetCustomer")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<Customer> Get(int id)
    {
      var item = _repo.Find(id);
      if (item == null)
      {
        return NotFound();
      }

      return Ok(item);
    }
  }
}