using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Controllers
{
    public class ApplicationUserClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserClaimsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ApplicationUserClaims
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ApplicationUserClaim.Include(a => a.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ApplicationUserClaims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserClaim = await _context.ApplicationUserClaim
                .Include(a => a.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUserClaim == null)
            {
                return NotFound();
            }

            return View(applicationUserClaim);
        }

        // GET: ApplicationUserClaims/Create
        public IActionResult Create([FromRoute(Name="id")]int? userId)
        {
            if (userId.HasValue)
            {
                ViewData["UserId"] = new SelectList(_context.ApplicationUser, nameof(ApplicationUser.Id), nameof(ApplicationUser.Email), userId.Value);
            }
            else
            {
                ViewData["UserId"] = new SelectList(_context.ApplicationUser, nameof(ApplicationUser.Id), nameof(ApplicationUser.Email));
            }

            return View();
        }

        // POST: ApplicationUserClaims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClaimType,ClaimValue")] ApplicationUserClaim applicationUserClaim)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(applicationUserClaim.UserId.ToString());
                await _userManager.AddClaimAsync(
                    user,new Claim(applicationUserClaim.ClaimType,applicationUserClaim.ClaimValue));
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", applicationUserClaim.UserId);
            return View(applicationUserClaim);
        }

        // GET: ApplicationUserClaims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserClaim = await _context.ApplicationUserClaim.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUserClaim == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", applicationUserClaim.UserId);
            return View(applicationUserClaim);
        }

        // POST: ApplicationUserClaims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClaimType,ClaimValue")] ApplicationUserClaim applicationUserClaim)
        {
            if (id != applicationUserClaim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUserClaim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserClaimExists(applicationUserClaim.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", applicationUserClaim.UserId);
            return View(applicationUserClaim);
        }

        // GET: ApplicationUserClaims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUserClaim = await _context.ApplicationUserClaim
                .Include(a => a.User)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUserClaim == null)
            {
                return NotFound();
            }

            return View(applicationUserClaim);
        }

        // POST: ApplicationUserClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationUserClaim = await _context.ApplicationUserClaim.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUserClaim.Remove(applicationUserClaim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserClaimExists(int id)
        {
            return _context.ApplicationUserClaim.Any(e => e.Id == id);
        }
    }
}
