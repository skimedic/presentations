using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;
using Security.Models.AccountViewModels;
using Security.Models.ViewModels;

namespace Security.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationUsersController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: ApplicationUsers
        public IActionResult Index()
        {
            return View(_context.ApplicationUser
                .Include(x => x.UserRoles)
                .Include(x => x.UserLogins)
                .Include(x => x.UserClaims));
        }

        public async Task<IActionResult> AddRole(int roleId, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            await _userManager.AddToRoleAsync(user, role.Name);
            return RedirectToAction(nameof(Details), new { id = userId });
        }
        public async Task<IActionResult> RemoveRole(int roleId, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            await _userManager.RemoveFromRoleAsync(user, role.Name);
            return RedirectToAction(nameof(Details), new { id = userId });
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        public async Task<IActionResult> AddClaim(string claimType, string claimValue, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var claim = (await _userManager.GetClaimsAsync(user)).FirstOrDefault(x => x.Value == claimValue && x.Type == claimValue);
            if (claim == null)
            {
                await _userManager.AddClaimAsync(user, new Claim(claimType, claimValue));
            }
            return RedirectToAction(nameof(Details), new { id = userId });
        }
        public async Task<IActionResult> RemoveClaim(string claimType, string claimValue, int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            await _userManager.RemoveClaimAsync(user, new Claim(claimType, claimValue));
            return RedirectToAction(nameof(Details), new { id = userId });
        }
        // GET: ApplicationUsers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = new ApplicationUserViewModel
            {
                User = _context.ApplicationUser
                    .Include(x => x.UserRoles).ThenInclude(r => r.Role)
                    .Include(x => x.UserLogins)
                    .Include(x => x.UserClaims)
                    .FirstOrDefault(m => m.Id == id),
                Roles = _context.ApplicationRole.OrderBy(x => x.Name).ToList(),
                ClaimViewModels = _context
                    .ApplicationUserClaim
                    .Select(x => new ClaimViewModel
                    {
                        ClaimType = x.ClaimType,
                        ClaimValue = x.ClaimValue
                    })
                    .Distinct()
                    .OrderBy(x => x.ClaimType)
                    .ToList()
            };

            if (vm.User == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
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
            return View(applicationUser);
        }

        private bool ApplicationUserExists(int id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
