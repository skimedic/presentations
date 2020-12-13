// Copyright Information
// ==================================
// AutoLot50 - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class DeleteModel : PageModel
    {
        private readonly IMakeRepo _makeRepo;

        public DeleteModel(IMakeRepo makeRepo)
        {
            _makeRepo = makeRepo;
        }

        [BindProperty]
        public Make Entity { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Entity = _makeRepo.Find(id);

            if (Entity == null)
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

            if (id.Value != Entity.Id)
            {
                return BadRequest();
            }

            _makeRepo.Delete(Entity);

            return RedirectToPage("./Index");
        }
    }
}
