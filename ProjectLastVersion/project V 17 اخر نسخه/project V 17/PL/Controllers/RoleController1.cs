﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PL.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public RoleController(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                var roles = await roleManager.Roles.Select(R => new RoleViewModel()
                {
                    Id = R.Id,
                    RoleName = R.Name,
                }).ToListAsync();
                return View(roles);
            }
            else
            {
                var role = await roleManager.FindByNameAsync(name);
                var MappedRole = new RoleViewModel()
                {
                    Id = role.Id,
                    RoleName = role.Name,
                };
                return View(new List<RoleViewModel> { MappedRole });
            }
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel RoleVM)
        {
            if (ModelState.IsValid)
            {
                var MappedRole = mapper.Map<RoleViewModel, IdentityRole>(RoleVM);

                await roleManager.CreateAsync(MappedRole);
                return RedirectToAction(nameof(Index));
            }
            return View(RoleVM);

        }

        public async Task<IActionResult> Details(string id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var role = await roleManager.FindByIdAsync(id);

            if (role is null)
                return NotFound();

            var mappedRole = mapper.Map<IdentityRole, RoleViewModel>(role);
            return View(ViewName, mappedRole);
        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, RoleViewModel RoleVM)
        {
            if (id != RoleVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(id);
                    role.Name = RoleVM.RoleName;
                    await roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(RoleVM);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id, RoleViewModel RoleVM)
        {
            if (id != RoleVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(id);
                    role.Name = RoleVM.RoleName;
                    await roleManager.DeleteAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(RoleVM);
        }


    }
}
