using AutoMapper;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using PL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace PL.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IMapper mapper;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                var Users = await userManager.Users.Select(U => new UserViewModel()
                {
                    Id = U.Id,
                    FName = U.Fname,
                    LName = U.Lname,
                    Email = U.Email,
                    PhoneNumber = U.PhoneNumber,
                    Roles = userManager.GetRolesAsync(U).Result
                }).ToListAsync();
                return View(Users);
            }
            else
            {
                var user = await userManager.FindByEmailAsync(Email);
                var MappedUser = new UserViewModel()
                {
                    Id = user.Id,
                    FName = user.Fname,
                    LName = user.Lname,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = userManager.GetRolesAsync(user).Result
                };
                return View(new List<UserViewModel> { MappedUser });
            }
        }

        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var user = await userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            var mappedUser = mapper.Map<ApplicationUser, UserViewModel>(user);
            return View(ViewName, mappedUser);
        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, UserViewModel userVM)
        {
            if (id != userVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByIdAsync(id);
                    user.Fname = userVM.FName;
                    user.Lname = userVM.LName;
                    user.PhoneNumber = userVM.PhoneNumber;

                    await userManager.UpdateAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(userVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id, UserViewModel UserVM)
        {
            if (id != UserVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var user = await userManager.FindByIdAsync(id);
                    user.Fname = UserVM.FName;
                    user.Lname = UserVM.LName;
                    user.PhoneNumber = UserVM.PhoneNumber;

                    await userManager.DeleteAsync(user);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(UserVM);
        }
    }
}

