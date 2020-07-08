using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoLot.Dal.Models.Entities.Base;
using AutoLot.Dal.Repos.Base;
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

        [HttpGet]
        public ActionResult<IEnumerable<T>> GetAll()
        {
            return Ok(MainRepo.GetAllIgnoreQueryFilters());
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public ActionResult<T> GetOne(int id)
        {
            var entity = MainRepo.Find(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult UpdateOne(int id, T entity)
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

        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
            return CreatedAtAction(nameof(GetOne), new { id = entity.Id }, entity);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        //public ActionResult<T> DeleteOne(int id, T entity)
        public async Task<ActionResult<T>> DeleteOne(int id)
        {
            //This doesn't work with the timestamp byte[] array.
            //var e = new T();
            //var r = TryUpdateModelAsync(e, string.Empty, c => c.Id, c => c.TimeStamp);

            var bodyStr = "";
            using (var reader
                = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                bodyStr = await reader.ReadToEndAsync();
            }

            var entity = JsonSerializer.Deserialize<T>(bodyStr);

            try
            {
                MainRepo.Delete(entity);
            }
            catch (Exception ex)
            {
                //Should handle more gracefully
                return BadRequest();
            }

            return Ok();
        }
    }
}