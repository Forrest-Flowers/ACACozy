using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cozy.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.UI.ViewModels;

namespace Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly List<IdentityRole> _roles;

        public AccountController(UserManager<AppUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            //Here we call this role table once.
            _roles = roleManager.Roles.ToList();
        }

        [HttpGet]
        public IActionResult Register()
        {
            //populate Roles before rendering the view.
            var vm = new RegisterViewModel
            {
                Roles = new SelectList(_roles)
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUser
                {
                    Email = vm.Email,
                    UserName = vm.Email
                };

                var result = await _userManager.CreateAsync(user, vm.Password);

                if(result.Succeeded)
                {
                    //apply roles to user
                    await _userManager.AddToRoleAsync(user, vm.Role);
                    
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Home"); //default to current controller
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            vm.Roles = new SelectList(_roles);

            return View(vm);
        }
    }
}