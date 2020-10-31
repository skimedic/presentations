using System.Threading.Tasks;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class DeleteModel : PageModel
    {
        private readonly AutoLot.Dal.EfStructures.ApplicationDbContext _context;

        public DeleteModel(AutoLot.Dal.EfStructures.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Make Make { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Makes.FirstOrDefaultAsync(m => m.Id == id);

            if (Make == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Make = await _context.Makes.FindAsync(id);

            if (Make != null)
            {
                _context.Makes.Remove(Make);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
