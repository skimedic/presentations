using System.Linq;
using System.Threading.Tasks;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class EditModel : PageModel
    {
        private readonly AutoLot.Dal.EfStructures.ApplicationDbContext _context;

        public EditModel(AutoLot.Dal.EfStructures.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Make).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeExists(Make.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MakeExists(int id)
        {
            return _context.Makes.Any(e => e.Id == id);
        }
    }
}
