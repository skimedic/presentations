// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class CreateModel : PageModel
    {
        private readonly IMakeRepo _makeRepo;

        public CreateModel(IMakeRepo makeRepo)
        {
            _makeRepo = makeRepo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Make Entity { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _makeRepo.Add(Entity);

            return RedirectToPage("./Index");
        }
    }
}
