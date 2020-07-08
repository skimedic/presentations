using System;
using System.Threading.Tasks;
using AutoLot.Dal.Models.Entities;
using AutoLot.Mvc.ServiceInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoLot.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class CarsController : Controller
    {
        private readonly IAutoLotServiceWrapper _serviceWrapper;

        public CarsController(IAutoLotServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
        }

        // GET: Cars
        [HttpGet]
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> Index() => View(await _serviceWrapper.GetAllAsync<Car>());

        [HttpGet("{makeId}/{makeName}")]
        [Route("/[controller]/[action]")]
        public async Task<IActionResult> ByMake(int makeId, string makeName)
        {
            ViewBag.MakeName = makeName;
            return View(await _serviceWrapper.GetCarsByMakeAsync(makeId));
        }

        // GET: Cars/Details/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _serviceWrapper.GetOneAsync<Car>(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        internal async Task<SelectList> GetMakes()
            => new SelectList(await _serviceWrapper.GetAllAsync<Make>(), nameof(Make.Id), nameof(Make.Name));

        // GET: Cars/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["MakeId"] = await GetMakes();
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //public async Task<IActionResult> Create([Bind("MakeId,Color,PetName,Id,TimeStamp")] Car car)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                var newCar = await _serviceWrapper.AddOneAsync(car);
                return RedirectToAction(nameof(Details), new { id = newCar.Id });
            }

            ViewData["MakeId"] = await GetMakes();
            return View(car);
        }

        // GET: Cars/Edit/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _serviceWrapper.GetOneAsync<Car>(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            ViewData["MakeId"] = await GetMakes();
            return View(car);
        }

        // POST: Cars/Edit/5
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _serviceWrapper.UpdateOneAsync(car);
                return RedirectToAction(nameof(Details), new { id = car.Id });
            }

            ViewData["MakeId"] = await GetMakes();
            return View(car);
        }
        //Model Binding: https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-3.1

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit2(int id)
        {
            var vm = new Car();
            if (await TryUpdateModelAsync(vm,"",
                c=>c.Id,c=>c.MakeId, c=>c.TimeStamp))
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
            ViewData["MakeId"] = await GetMakes();
            return View("Edit",vm);
        }

        // GET: Cars/Delete/5
        [HttpGet("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _serviceWrapper.GetOneAsync<Car>(id.Value);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        //[ActionName("Delete")]
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, byte[] timeStamp)
        {
            await _serviceWrapper.DeleteOneAsync(new Car { Id = id, TimeStamp = timeStamp });
            return RedirectToAction(nameof(Index));
        }
    }
}