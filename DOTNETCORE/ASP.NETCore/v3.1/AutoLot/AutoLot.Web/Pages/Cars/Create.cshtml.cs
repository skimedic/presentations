using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;

namespace AutoLot.Web.Pages.Cars
{
    public class CreateModel : PageModel
    {
        private readonly ICarRepo _carRepo;
        private readonly IMakeRepo _makeRepo;

        public CreateModel(ICarRepo carRepo, IMakeRepo makeRepo)
        {
            _carRepo = carRepo;
            _makeRepo = makeRepo;
        }

        internal SelectList GetMakes() =>
            new SelectList(_makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));

        public SelectList Makes { get; set; }

        public IActionResult OnGet()
        {
            Makes = GetMakes();
            return Page();
        }

        [BindProperty] public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _carRepo.Add(Car);
                return RedirectToPage("./Index");
            }
            Makes = GetMakes();
            return Page();
        }
    }
}