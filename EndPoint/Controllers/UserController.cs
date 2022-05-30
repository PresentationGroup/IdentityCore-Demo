using  Domain.Users;
using  EndPoint.Models.ViewModels.Register;
using  EndPoint.Models.ViewModels.Role;
using  EndPoint.Models.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  EndPoint.Controllers
{
    //[Authorize(Roles = "Developer,Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User newUser = new User()
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                IsDisable = false

            };

            var result = _userManager.CreateAsync(newUser, model.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Profile));
                // return RedirectionToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            ViewBag.Errors = result.Errors.ToList();

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userManager.FindByNameAsync(model.UserName).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد!");
                return View(model);
            }

            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, true).Result;
            if (result.Succeeded)
            {
                //return Redirect(model.ReturnUrl);
                return RedirectToAction("Index", "Home");
            }

            //todo.. Check RequiresTwoFatctor
            //todo.. Check IsLockedout

            if (!result.Succeeded)
                ModelState.AddModelError(string.Empty, "خطا در زمان ورود کاربر");

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Index()
        {
            var users = _userManager.Users
               .Where(u => u.IsDisable == false)
               .Select(p =>
                   new UsersListViewModel
                   {
                       Id = p.Id,
                       FullName = p.FullName,
                       UserName = p.UserName,
                       Email = p.Email,
                       EmailConfirmed = p.EmailConfirmed,
                       PhoneNumber = p.PhoneNumber,
                       AccessFailedCount = p.AccessFailedCount
                   }).ToList();

            return View(users);
        }
        public IActionResult Edit(String Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            EditUserViewModel editUser = new EditUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return View(editUser);
        }
        [HttpPost]
        public IActionResult Edit(EditUserViewModel model)
        {
            var user = _userManager.FindByIdAsync(model.Id).Result;
            user.FullName = model.FullName;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = _userManager.UpdateAsync(user).Result;
            if (result.Succeeded)
                return RedirectToAction("Index", "User");

            //Show Errors
            string message = string.Empty;
            foreach (var item in result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(model);

        }
        public ActionResult Delete(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            DeleteUserViewModel deleteUser = new DeleteUserViewModel()
            {
                Id = user.Id,
                UserName = user.UserName
            };
            return View(deleteUser);
        }
        [HttpPost]
        public IActionResult Delete(DeleteUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _userManager.FindByIdAsync(model.Id).Result;


            user.IsDisable = true;
            user.DisableDate = DateTime.Now;
            var result = _userManager.UpdateAsync(user).Result;

            if (result.Succeeded)
                return RedirectToAction("Index", "User");

            //Show Errors
            string message = string.Empty;
            foreach (var item in result.Errors.ToList())
            {
                message += item.Description + Environment.NewLine;
            }
            TempData["Message"] = message;
            return View(model);
        }
        public IActionResult RoleInUser(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            var rolesNames = _userManager.GetRolesAsync(user).Result;
            var roles = new List<RolesInUserListViewModel>();
            foreach (string item in rolesNames)
            {
                var r = _roleManager.FindByNameAsync(item).Result;
                roles.Add(new RolesInUserListViewModel()
                {
                    Id = r.Id,
                    RoleName = r.Name,
                    RoleDescription = r.Description,
                    IsDisable = r.IsDisable,
                    UserName = user.UserName
                });
            }

            ViewData["userName"] = user.UserName;
            return View(roles);
        }
        public IActionResult UserRoleAssignment()
        {
            var users = _userManager.Users
                         .Where(u => u.IsDisable == false)
                         .Select(p => new UserRoleAssignmentViewModel
                         {
                             Id = p.Id,
                             UserName = p.UserName
                         }).ToList();

            users.ForEach(a => a.CurrentRoles = GetRoles(_userManager.GetRolesAsync(_userManager.FindByIdAsync(a.Id).Result).Result.ToList()));

            return View(users);
        }
        public IActionResult AddUserRole(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            //todo.. need to filter Assigned Roles
            var roles = new List<SelectListItem>(
                _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Description,
                    Value = r.Name
                }
                ).ToList());

            return View(new AddUserRoleViewModel
            {
                Id = Id,
                Roles = roles,
                UserName = user.UserName
            });
        }
        [HttpPost]
        public IActionResult AddUserRole(AddUserRoleViewModel model)
        {
            var user = _userManager.FindByIdAsync(model.Id).Result;
            var result = _userManager.AddToRoleAsync(user, model.Role).Result;
            return RedirectToAction("UserRoleAssignment", "User", new { Id = user.Id });
        }
        public IActionResult DeleteUserRole(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            //todo.. need to filter Assigned Roles
            var roles = new List<SelectListItem>(
                _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Description,
                    Value = r.Name
                }
                ).ToList());

            return View(new AddUserRoleViewModel
            {
                Id = Id,
                Roles = roles,
                UserName = user.UserName
            });
        }
        [HttpPost]
        public IActionResult DeleteUserRole(AddUserRoleViewModel model)
        {
            var user = _userManager.FindByIdAsync(model.Id).Result;
            //todo.. delete
            //var result = _userManager.AddToRoleAsync(user, newUserRole.Role).Result;
            return RedirectToAction("UserRoleAssignment", "User", new { Id = user.Id });
        }

        [AllowAnonymous]
        public IActionResult AccessDenied(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }

        #region[Functions]
        List<RoleViewModel> GetRoles(List<string> lstRolesName)
        {
            var result = new List<RoleViewModel>();
            foreach (string item in lstRolesName)
            {
                var r = _roleManager.FindByNameAsync(item).Result;
                result.Add(new RoleViewModel()
                {
                    Name = r.Name,
                    Description = r.Description
                });
            }
            return result;
        }
        #endregion[Functions]

    }
}
