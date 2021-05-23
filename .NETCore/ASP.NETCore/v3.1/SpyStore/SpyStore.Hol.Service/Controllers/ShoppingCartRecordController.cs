using System;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Service.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ShoppingCartRecordController : ControllerBase
  {
    private readonly IShoppingCartRepo _repo;
    public ShoppingCartRecordController(IShoppingCartRepo repo)
    {
      _repo = repo;
    }

    /// <summary>
    /// Get Shopping Cart Record for cart record id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET /api/ShoppingCartRecord/1
    /// </remarks>
    /// <param name="id">Primary Key of the Cart Record</param>
    /// <response code="200">Returns single Shopping Cart Record</response>
    /// <response code="404">Returned when no record was found</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpGet("{recordId}",Name = "GetShoppingCartRecord")]
    [Produces("application/json")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<CartRecordWithProductInfo> GetShoppingCartRecord(int recordId)
    {
      CartRecordWithProductInfo cartRecordWithProductInfo = _repo.GetShoppingCartRecord(recordId);
      return cartRecordWithProductInfo ?? (ActionResult<CartRecordWithProductInfo>) NotFound();
    }

    /// <summary>
    /// Creates a new Shopping Cart Record
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       POST /api/ShoppingCartRecord/1
    ///       {
    ///          "CustomerId": 1,
    ///          "Quantity": 2,
    ///          "ProductId": 34,
    ///       }
    /// </remarks>
    /// <param name="customerId">Primary key of the Customer</param>
    /// <param name="record">Shopping Cart Record
    ///       {
    ///          "CustomerId": 1,
    ///          "Quantity": 2,
    ///          "ProductId": 34,
    ///       }
    /// </param>
    /// <response code="201">Returned new created item</response>
    /// <response code="400">Returned when there was an error in the data (bad CustomerId/ProductId).</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpPost("{customerId}",Name = "AddCartRecord")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult AddShoppingCartRecord(int customerId, ShoppingCartRecord record)
    {
      if (record == null || customerId != record.CustomerId || !ModelState.IsValid)
      {
        return BadRequest();
      }
      record.DateCreated = DateTime.Now;
      record.CustomerId = customerId;
      _repo.Context.CustomerId = customerId;
      _repo.Add(record);
      //Location: http://localhost:8477/api/ShoppingCartRecord/1 (201)
      CreatedAtRouteResult createdAtRouteResult = CreatedAtRoute("GetShoppingCart",
        new {controller = "ShoppingCart", customerId = customerId },
        null);
      return createdAtRouteResult;
    }

    /// <summary>
    /// Updates a Shopping Cart Record
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       PUT /api/ShoppingCartRecord/1
    ///       {
    ///          "CustomerId": 1,
    ///          "Quantity": 2,
    ///          "ProductId": 34,
    ///       }
    /// </remarks>
    /// <param name="recordId">Primary key of the cart record</param>
    /// <param name="item">Shopping Cart Record
    ///       {
    ///          "CustomerId": 1,
    ///          "Quantity": 2,
    ///          "ProductId": 34,
    ///       }
    /// </param>
    /// <response code="201">Returned new created item</response>
    /// <response code="400">Returned when there was an error in the data (bad CustomerId/ProductId).</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpPut("{recordId}", Name = "UpdateCartRecord")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult UpdateShoppingCartRecord(int recordId, ShoppingCartRecord item)
    {
      if (item == null || item.Id != recordId || !ModelState.IsValid)
      {
        return BadRequest();
      }
      item.DateCreated = DateTime.Now;
      _repo.Context.CustomerId = item.CustomerId;
      _repo.Update(item);
      //Location: http://localhost:8477/api/ShoppingCartRecord/0 (201)
      return CreatedAtRoute("GetShoppingCartRecord",
        new {controller = "ShoppingCartRecord", recordId = item.Id},
        null);
    }

    /// <summary>
    /// Deletes a Shopping Cart Record
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///       DELETE /api/ShoppingCartRecord/1
    ///       {
    ///          "CustomerId": 1,
    ///          "Quantity": 2,
    ///          "ProductId": 34,
    ///          "TimeStamp": "AAAAAAAAs+M="
    ///       }
    /// </remarks>
    /// <param name="recordId">Primary key of the cart record</param>
    /// <param name="item">Shopping Cart Record
    ///       {
    ///          "CustomerId": 1,
    ///          "Quantity": 2,
    ///          "ProductId": 34,
    ///          "TimeStamp": "AAAAAAAAs+M="
    ///       }
    /// </param>
    /// <response code="201">Returned new created item</response>
    /// <response code="400">Returned when there was an error in the data (bad CustomerId/ProductId).</response>
    /// <response code="500">Returned when there was an error in the repo.</response>
    [HttpDelete("{recordId}",Name = "DeleteCartRecord")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    //1.1 spec allows for body in delete statement
    public IActionResult DeleteCartRecord(int recordId, ShoppingCartRecord item)
    {
      if (recordId != item.Id)
      {
        return NotFound();
      }
      _repo.Context.CustomerId = item.CustomerId;
      _repo.Delete(item);
      return NoContent();
    }
  }
}