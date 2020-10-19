using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;

namespace AutoLot.Web.Pages.Cars
{
    public class DeleteModel : PageModel
    {
        private readonly ICarRepo _repo;

        public DeleteModel(ICarRepo repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }
            Car = _repo.Find(id.Value);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            if (Car.Id != id)
            {
                return BadRequest();
            }
            _repo.Delete(Car);
            return RedirectToPage("./Index");
        }
    }
}
