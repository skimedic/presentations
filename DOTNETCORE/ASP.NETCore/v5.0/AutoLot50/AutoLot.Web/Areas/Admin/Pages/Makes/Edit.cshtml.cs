using System;
using System.Linq;
using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class EditModel : PageModel
    {
        private readonly IMakeRepo _repo;

        public EditModel(IMakeRepo repo)
        {
            _repo = repo;
        }

        [BindProperty] public Make Make { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Make = _repo.Find(id.Value);

            if (Make == null)
            {
                return NotFound();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _repo.Update(Make);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}