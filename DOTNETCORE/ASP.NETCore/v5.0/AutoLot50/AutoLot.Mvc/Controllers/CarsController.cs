using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoLot.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class CarsController : Controller
    {
        private readonly ICarRepo _repo;
        private readonly IAppLogging<CarsController> _logging;

        public CarsController(ICarRepo repo, IAppLogging<CarsController> logging)
        {
            _repo = repo;
            _logging = logging;
            _logging.LogAppError("Test error");
        }

        internal SelectList GetMakes(IMakeRepo makeRepo)
            => new SelectList(makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));

        internal Car GetOneCar(int? id)
        {
            return id == null ? null :  _repo.Find(id.Value);
        }

        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        public IActionResult Index()
        {
            return View(_repo.GetAllIgnoreQueryFilters());
        }

        [HttpGet("{makeId}/{makeName}")]
        public IActionResult ByMake(int makeId, string makeName)
        {
            ViewBag.MakeName = makeName;
            return View(_repo.GetAllBy(makeId));
        }

        // GET: Cars/Details/5
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

        // GET: Cars/Create
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

        // GET: Cars/Edit/5
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

        // POST: Cars/Edit/5
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
            ViewData["MakeId"] = GetMakes(makeRepo);
            return View("Edit", vm);
        }

        // GET: Cars/Delete/5
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

        // POST: Cars/Delete/5
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Car car)
        {
            _repo.Delete(car);
            return RedirectToAction(nameof(Index));
        }
    }
}