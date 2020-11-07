using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoLot.Models.Entities.Base;
using AutoLot.Dal.Repos.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AutoLot.Api.Controllers.Base
{
    [ApiController]
    public abstract class BaseCrudController<T, TController> : ControllerBase
        where T : BaseEntity, new()
        where TController : BaseCrudController<T, TController>
    {
        protected readonly IRepo<T> MainRepo;
        protected readonly ILogger<TController> Logger;

        protected BaseCrudController(IRepo<T> repo, ILogger<TController> logger)
        {
            MainRepo = repo;
            Logger = logger;
        }

        /// <summary>
        /// Gets all records
        /// </summary>
        /// <returns>All records</returns>
        /// <response code="200">Returns all items</response>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<T>> GetAll()
        {
            return Ok(MainRepo.GetAllIgnoreQueryFilters());
        }

        /// <summary>
        /// Gets a single record
        /// </summary>
        /// <param name="id">Primary key of the record</param>
        /// <returns>Single record</returns>
        /// <response code="200">Found the record</response>
        /// <response code="204">No content</response>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{id}")]
        public ActionResult<T> GetOne(int id)
        {
            var entity = MainRepo.Find(id);

            if (entity == null)
            {
                return NoContent();
            }

            return Ok(entity);
        }

        /// <summary>
        /// Updates a single record
        /// </summary>
        /// <remarks>
        /// Sample body:
        /// <pre>
        /// {
        ///   "Id": 1,
        ///   "TimeStamp": "AAAAAAAAB+E="
        ///   "MakeId": 1,
        ///   "Color": "Black",
        ///   "PetName": "Zippy",
        ///   "MakeColor": "VW (Black)",
        /// }
        /// </pre>
        /// </remarks>
        /// <param name="id">Primary key of the record to update</param>
        /// <returns>Single record</returns>
        /// <response code="200">Found and updated the record</response>
        /// <response code="400">Bad request</response>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public IActionResult UpdateOne(int id,T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                MainRepo.Update(entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Should handle more gracefully
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                //Should handle more gracefully
                return BadRequest(ex);
            }

            return Ok(entity);
        }

        /// <summary>
        /// Adds a single record
        /// </summary>
        /// <remarks>
        /// Sample body:
        /// <pre>
        /// {
        ///   "Id": 1,
        ///   "TimeStamp": "AAAAAAAAB+E="
        ///   "MakeId": 1,
        ///   "Color": "Black",
        ///   "PetName": "Zippy",
        ///   "MakeColor": "VW (Black)",
        /// }
        /// </pre>
        /// </remarks>
        /// <returns>Added record</returns>
        /// <response code="201">Found and updated the record</response>
        /// <response code="400">Bad request</response>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<T> AddOne(T entity)
        {
            try
            {
                MainRepo.Add(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return CreatedAtAction(nameof(GetOne), new {id = entity.Id}, entity);
        }

        /// <summary>
        /// Deletes a single record
        /// </summary>
        /// <remarks>
        /// Sample body:
        /// <pre>
        /// {
        ///   "Id": 1,
        ///   "TimeStamp": "AAAAAAAAB+E="
        /// }
        /// </pre>
        /// </remarks>
        /// <returns>Nothing</returns>
        /// <response code="200">Found and deleted the record</response>
        /// <response code="400">Bad request</response>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public ActionResult<T> DeleteOne(int id, T entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            try
            {
                MainRepo.Delete(entity);
            }
            catch (Exception ex)
            {
                //Should handle more gracefully
                return new BadRequestObjectResult(ex.GetBaseException()?.Message);
            }

            return Ok();
        }
    }
}