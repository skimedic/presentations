// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Linq;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServerWithIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.Quickstart.UI
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IHostingEnvironment _environment;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            IIdentityServerInteractionService interaction, 
            IHostingEnvironment environment,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _interaction = interaction;
            _environment = environment;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        internal async Task CreateRole(string role)
        {
            if (!_roleManager.Roles.Any(x => x.Name == role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        internal async Task AddToRole(string role)
        {
            var users = _userManager.Users.ToList();
            foreach (var u in users)
            {
                if ((await _userManager.GetRolesAsync(u)).All(x => x != role))
                {
                    await _userManager.AddToRoleAsync(u, role);
                }
            }
        }
        public async Task<IActionResult> Index()
        {
            await CreateRole("Admin");
            await CreateRole("Clerk");
            await AddToRole("Admin");
            await AddToRole("Clerk");

            if (_environment.IsDevelopment())
            {
                // only show in development
                return View();
            }

            return NotFound();
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;

                if (!_environment.IsDevelopment())
                {
                    // only show in development
                    message.ErrorDescription = null;
                }
            }

            return View("Error", vm);
        }
    }
}