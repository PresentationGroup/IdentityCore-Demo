using  Domain.Users;
using  EndPoint.Models.ViewModels.Role;
using  EndPoint.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Controllers
{
    [Authorize(Roles = "Developer,Admin")]
    public class RoleController : Controller
    {
        public readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var roles = _roleManager.Roles
                //.Where(r => r.IsDisable == false)
                .Select(r =>
                    new RolesListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Description = r.Description,
                        IsDisable = r.IsDisable
                    })
                .ToList();

            return View(roles);
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(RoleViewModel newRole)
        {
            var role = new Role()
            {
                Description = newRole.Description,
                Name = newRole.Name,
                IsDisable = false
            };
            var result = _roleManager.CreateAsync(role).Result;
            if (result.Succeeded)
                return RedirectToAction("Index", "Role");

            ViewBag.Errors = result.Errors.ToList();
            return View(newRole);
        }
        public IActionResult Edit(string Id)
        {
            var role = _roleManager.FindByIdAsync(Id).Result;
            var editRole = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return View(editRole);
        }
        [HttpPost]
        public IActionResult Edit(RoleViewModel editRole)
        {
            var role = _roleManager.FindByIdAsync(editRole.Id).Result;
            
            role.Description = editRole.Description;
            var result = _roleManager.UpdateAsync(role).Result;
            if(result.Succeeded)
            return RedirectToAction("Index", "Role");

            ViewBag.Errors = result.Errors.ToList();
            return View(editRole);
        }
        [HttpGet]
        public IActionResult Delete(string Id)
        {
            var role = _roleManager.FindByIdAsync(Id).Result;
            var deleteRole = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name,
            };
            return View(deleteRole);
        }
        [HttpPost]
        public IActionResult Delete(RoleViewModel deleteRole)
        {
            var role = _roleManager.FindByIdAsync(deleteRole.Id).Result;

            role.IsDisable = true;
            role.DisableDate = DateTime.Now;
            var result = _roleManager.UpdateAsync(role).Result;
            if (result.Succeeded)
                return RedirectToAction("Index", "Role");

            ViewBag.Errors = result.Errors.ToList();
            return View(deleteRole);
        }
        public IActionResult UserInRole(string name)
        {
            var usersInRole = _userManager.GetUsersInRoleAsync(name).Result;
            var role = _roleManager.FindByNameAsync(name).Result;
            ViewData["roleDescription"] = role.Description;
            return View(usersInRole.Select(ur=> new UsersInRoleListViewModel
            {
                Id=ur.Id,
                UserName = ur.UserName,
                FullName = ur.FullName,
                Email = ur.Email,
                PhoneNumber = ur.PhoneNumber,
                RoleName = role.Name,
                RoleDescription = role.Description
            }));
        }
    }
}
