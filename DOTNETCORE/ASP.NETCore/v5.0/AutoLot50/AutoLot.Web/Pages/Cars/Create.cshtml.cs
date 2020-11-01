using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        //TODO: Slides Change action name https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-5.0&tabs=visual-studio

        public IActionResult OnPostCreateNewCar()
        {
            if (!ModelState.IsValid)
            {
                Makes = GetMakes();
                return Page();
            }

            try
            {
                _carRepo.Add(Car);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                Makes = GetMakes();
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}