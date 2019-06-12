using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public SearchController(IProductRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets a single category.
        /// </summary>
        /// <param name="searchString">String to search the product name and product description description.</param>
        /// <remarks>
        /// Sample request:
        ///     GET /api/Seach/persuade%20anyone
        /// </remarks>
        /// <returns>Single Category</returns>
        /// <response code="200">Returns matching products.</response>
        /// <response code="204">Returned when no content in the response</response>
        /// <response code="500">Returned when there was an error in the repo.</response>
        [HttpGet("{searchString}", Name = "SearchProducts")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult<IList<Product>> Search(string searchString)
        {
            var results = _repo.Search(searchString).ToList();
            if (results.Count == 0)
            {
                return NoContent();
            }

            return results;
        }
    }
}