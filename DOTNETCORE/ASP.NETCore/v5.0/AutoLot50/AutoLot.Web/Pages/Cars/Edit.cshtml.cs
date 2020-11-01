using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;

namespace AutoLot.Web.Pages.Cars
{
    public class EditModel : PageModel
    {
        private readonly ICarRepo _repo;
        private readonly IMakeRepo _makeRepo;

        public EditModel(ICarRepo repo, IMakeRepo makeRepo)
        {
            _repo = repo;
            _makeRepo = makeRepo;
        }

        public SelectList Makes { get; set; }
        [BindProperty] public Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }

            Car = _repo.Find(id.Value);
            if (Car == null)
            {
                return NotFound();
            }
            Makes = GetMakes();
            return Page();
        }

        internal SelectList GetMakes() =>
            new SelectList(_makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                Makes = GetMakes();
                return Page();
            }

            if (!id.HasValue || id.Value != Car.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Update(Car);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                Makes = GetMakes();
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}