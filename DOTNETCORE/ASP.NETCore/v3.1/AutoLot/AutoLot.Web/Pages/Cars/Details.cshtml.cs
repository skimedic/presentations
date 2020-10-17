using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutoLot.Dal.EfStructures;
using AutoLot.Models.Entities;

namespace AutoLot.Web.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly AutoLot.Dal.EfStructures.ApplicationDbContext _context;

        public DetailsModel(AutoLot.Dal.EfStructures.ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Cars
                .Include(c => c.MakeNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
