using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets a single product with category name.
        /// </summary>
        /// <param name="id">Primary Key of the product to retrieve</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Product/5
        /// </remarks>
        /// <returns>Single Product</returns>
        /// <response code="200">Returns single Product.</response>
        /// <response code="404">Returned when Product with specific id doesn't exist.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{id}", Name = "GetProduct")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<Product> Get(int id)
        {
            Product item = _repo.GetOneWithCategoryName(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        /// <summary>
        /// Get all featured Products with Category Name.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     GET /api/featured
        /// </remarks>
        /// <returns>List of all featured Products with Category Name.</returns>
        /// <response code="200">Returns featured Products.</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("featured", Name = "GetFeaturedProducts")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Product>> GetFeatured()
            => Ok(_repo.GetFeaturedWithCategoryName().ToList());
    }
}