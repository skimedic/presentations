// Copyright Information
// ==================================
// AutoLot50 - AutoLot.Web - Details.cshtml.cs
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
    public class DetailsModel : PageModel
    {
        private readonly IMakeRepo _repo;

        public DetailsModel(IMakeRepo repo)
        {
            _repo = repo;
        }

        public Make Entity { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Entity = _repo.Find(id.Value);

            if (Entity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
