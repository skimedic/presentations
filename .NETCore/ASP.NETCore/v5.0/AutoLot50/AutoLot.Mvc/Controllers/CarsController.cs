// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using AutoLot.Services.ApiWrapper;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoLot.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    //[Route("Cars/[action]")]
    public class CarsController : Controller
    {
        private readonly IApiServiceWrapper _serviceWrapper;
        private readonly IAppLogging<CarsController> _logging;
        public CarsController(IApiServiceWrapper serviceWrapper, IAppLogging<CarsController> logging)
        {
            _serviceWrapper = serviceWrapper;
            _logging = logging;
            //_logging.LogAppError("Test error");
        }
        internal async Task<SelectList> GetMakesAsync()
            => new SelectList(await _serviceWrapper.GetMakesAsync(), nameof(Make.Id), nameof(Make.Name));

        internal async Task<Car> GetOneCarAsync(int? id) 
            => id == null ? null : await _serviceWrapper.GetCarAsync(id.Value);

        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> Index() 
            => View(await _serviceWrapper.GetCarsAsync());

        [HttpGet("{makeId}/{makeName}")]
        public async Task<IActionResult> ByMake(int makeId, string makeName)
        {
            ViewBag.MakeName = makeName;
            return View(await _serviceWrapper.GetCarsByMakeAsync(makeId));
        }

        // GET: Cars/Details/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var car = await GetOneCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["MakeId"] = await GetMakesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                await _serviceWrapper.AddCarAsync(car);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeId"] = await GetMakesAsync();
            return View(car);
        }

        // GET: Cars/Edit/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var car = await GetOneCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["MakeId"] = await GetMakesAsync();
            return View(car);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                await _serviceWrapper.UpdateCarAsync(id,car);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MakeId"] = await GetMakesAsync();
            return View(car);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2([FromServices] IMakeRepo makeRepo, int id)
        {
            var vm = new Car();
            if (await TryUpdateModelAsync(vm, "",
                c => c.Id, c => c.MakeId, c => c.TimeStamp))
            {
                //Color doesn't get updated because it's not in the list
                //c=>c.Color, 
                //Petname from the forms is ignored but hard coded later
                //c=>c.PetName, 
            }

            var valid0 = ModelState.IsValid;
            ModelState.Clear();
            vm.PetName = "Model T";
            vm.Color = "Black";
            var valid1 = TryValidateModel(vm);
            var valid2 = ModelState.IsValid;
            //ViewData["MakeId"] = GetMakes(makeRepo);
            ViewData["MakeId"] = await GetMakesAsynce();
            return View("Edit", vm);
        }

        // GET: Cars/Delete/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var car = await GetOneCarAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Car car)
        {
            await _serviceWrapper.DeleteCarAsync(id,car);
            return RedirectToAction(nameof(Index));
        }
    }
}