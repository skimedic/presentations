using System.Collections.Generic;
using System.Threading.Tasks;
using AutoLot.Models.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoLot.Web.Areas.Admin.Pages.Makes
{
    public class IndexModel : PageModel
    {
        private readonly AutoLot.Dal.EfStructures.ApplicationDbContext _context;

        public IndexModel(AutoLot.Dal.EfStructures.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Make> Make { get;set; }

        public async Task OnGetAsync()
        {
            Make = await _context.Makes.ToListAsync();
        }
    }
}
