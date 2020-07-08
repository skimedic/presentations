using System;
using System.Threading.Tasks;
using AutoLot.Dal.Models.Entities;
using AutoLot.Mvc.ServiceInfo;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MakesController : Controller
    {
        private readonly IAutoLotServiceWrapper _serviceWrapper;

        public MakesController(IAutoLotServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        // GET: Admin/Makes
        [Route("/Admin")]
        [Route("/Admin/[controller]")]
        [Route("/Admin/[controller]/[action]")]
        public async Task<IActionResult> Index()
        {
            return View(await _serviceWrapper.GetAllAsync<Make>());
        }

        // GET: Admin/Makes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _serviceWrapper.GetOneAsync<Make>(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // GET: Admin/Makes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Makes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,TimeStamp")] Make make)
        {
            if (!ModelState.IsValid)
            {
                return View(make);
            }

            await _serviceWrapper.AddOneAsync(make);
            //TODO: Get Header Information
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Makes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _serviceWrapper.GetOneAsync<Make>(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Admin/Makes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,TimeStamp")] Make make)
        {
            if (id != make.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(make);
            }

            try
            {
                await _serviceWrapper.UpdateOneAsync(make);
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Makes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var make = await _serviceWrapper.GetOneAsync<Make>(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Admin/Makes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, byte[] timeStamp)
        {
            await _serviceWrapper.DeleteOneAsync(new Make() {Id = id, TimeStamp = timeStamp});
            return RedirectToAction(nameof(Index));
        }
    }
}