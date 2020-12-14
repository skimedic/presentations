// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - Cars2Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoLot.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class Cars2Controller : Controller
    {
        private readonly ICarRepo _repo;
        private readonly IAppLogging<CarsController> _logging;
        public Cars2Controller(ICarRepo repo, IAppLogging<CarsController> logging)
        {
            _repo = repo;
            _logging = logging;
            //_logging.LogAppError("Test error");
        }
        internal SelectList GetMakes(IMakeRepo makeRepo)
            => new SelectList(makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));

        internal Car GetOneCar(int? id) 
            => id == null ? null : _repo.Find(id.Value);

        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        public IActionResult Index() 
            => View(_repo.GetAllIgnoreQueryFilters());

        [HttpGet("{makeId}/{makeName}")]
        public IActionResult ByMake(int makeId, string makeName)
        {
            ViewBag.MakeName = makeName;
            return View(_repo.GetAllBy(makeId));
        }

        [HttpGet("{id?}")]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var car = GetOneCar(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpGet]
        public IActionResult Create([FromServices] IMakeRepo makeRepo)
        {
            ViewData["MakeId"] = GetMakes(makeRepo);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromServices] IMakeRepo makeRepo, Car car)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(car);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeId"] = GetMakes(makeRepo);
            return View(car);
        }

        [HttpGet("{id?}")]
        public IActionResult Edit([FromServices] IMakeRepo makeRepo, int? id)
        {
            var car = GetOneCar(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["MakeId"] = GetMakes(makeRepo);
            return View(car);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromServices] IMakeRepo makeRepo, int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _repo.Update(car);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeId"] = GetMakes(makeRepo);
            return View(car);
        }

        [HttpGet("{id?}")]
        public IActionResult Delete(int? id)
        {
            var car = GetOneCar(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Car car)
        {
            _repo.Delete(car);
            return RedirectToAction(nameof(Index));
        }
    }
}