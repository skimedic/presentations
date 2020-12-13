// Copyright Information
// ==================================
// AutoLot50 - AutoLot.Mvc - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MakesController : Controller
    {
        private readonly IMakeRepo _repo;

        public MakesController(IMakeRepo repo)
        {
            _repo = repo;
        }

        // GET: Admin/Makes
        [Route("/Admin")]
        [Route("/Admin/[controller]")]
        [Route("/Admin/[controller]/[action]")]

        public IActionResult Index()
        {
            return View(_repo.GetAllIgnoreQueryFilters());
        }

        // GET: Admin/Makes/Details/5
        [HttpGet("{id?}")]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var make = _repo.Find(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // GET: Admin/Makes/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Makes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //TODO: Slides Add Overposting MVC + Razor Pages
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Id,TimeStamp")] Make make)
        {
            if (!ModelState.IsValid)
            {
                return View(make);
            }

            try
            {
                _repo.Add(make);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(make);
            }
        }

        // GET: Admin/Makes/Edit/5
        [HttpGet("{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var make = _repo.Find(id.Value);
            if (make == null)
            {
                return NotFound();
            }
            return View(make);
        }

        // POST: Admin/Makes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("{id?}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id,TimeStamp")] Make make)
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
                _repo.Update(make);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(make);
            }
        }

        // GET: Admin/Makes/Delete/5
        [HttpGet("{id?}")]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var make = _repo.Find(id.Value);
            if (make == null)
            {
                return NotFound();
            }

            return View(make);
        }

        // POST: Admin/Makes/Delete/5
        //[ActionName("Delete")]
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Make entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Delete(entity);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return View(entity);
            }
        }
    }
}
